using System.Diagnostics;
using System.IO.Compression;
using HandySerialization.Extensions;
using HandySerialization.Wrappers;

namespace HandySerialization.Tests;

[TestClass]
public class OrbitDataTests
{
    private class OrbitDataPage
    {
        public List<double3> Positions;
        public List<double3> Velocities;
        public List<double> Timestamps;

        public ulong ID;
        public long ByteSize;

        public OrbitDataPage(List<double3> positions, List<double3> velocities, List<double> timestamps, ulong id, long size)
        {
            Positions = positions;
            Velocities = velocities;
            Timestamps = timestamps;
            ID = id;
            ByteSize = size;
        }

        public static OrbitDataPage Read(FileStream stream)
        {
            var start = stream.Position;
            using var reader = new BinaryReader(stream);

            var count = reader.ReadInt32();
            var id = reader.ReadUInt64();

            var p = new List<double3>();
            var v = new List<double3>();
            var t = new List<double>();

            for (var i = 0; i < count; i++)
                p.Add(new double3(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble()));
            for (var i = 0; i < count; i++)
                v.Add(new double3(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble()));
            for (var i = 0; i < count; i++)
                t.Add(reader.ReadDouble());

            return new OrbitDataPage(p, v, t, id, stream.Position - start);
        }

        public void Write(Stream dest)
        {
            using var writer = new BinaryWriter(dest);

            writer.Write(Positions.Count);
            writer.Write(ID);

            for (var i = 0; i < Positions.Count; i++)
            {
                writer.Write(Positions[i].X);
                writer.Write(Positions[i].Y);
                writer.Write(Positions[i].Z);
            }

            for (var i = 0; i < Velocities.Count; i++)
            {
                writer.Write(Velocities[i].X);
                writer.Write(Velocities[i].Y);
                writer.Write(Velocities[i].Z);
            }

            for (var i = 0; i < Timestamps.Count; i++)
            {
                writer.Write(Timestamps[i]);
            }
        }
    }

    private record struct double3(double X, double Y, double Z)
    {
        public static double3 operator+(double3 a, double3 b) => new double3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static double3 operator-(double3 a, double3 b) => new double3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static double3 operator/(double3 a, double b) => new double3(a.X / b, a.Y / b, a.Z / b);
    }

    private record struct RunResult(int Better, int Worse, long TotalBytesSaved, long BestWin, long WorstLoss, double SizePercentage, long elapsedMs);

    private RunResult TestRun(Action<OrbitDataPage, Stream> writer)
    {
        var better = new List<long>();
        var worse = new List<long>();

        var timer = new Stopwatch();
        timer.Start();

        var totalBaseline = 0L;
        foreach (var dat in Directory.EnumerateFiles("OrbitData", "*.dat"))
        {
            using var file = File.Open(dat, FileMode.Open);
            var page = OrbitDataPage.Read(file);
            totalBaseline += page.ByteSize;

            var result = new MemoryStream();
            writer(page, result);

            if (result.Position > page.ByteSize)
                worse.Add(result.Position - page.ByteSize);
            else
                better.Add(result.Position - page.ByteSize);
        }

        var totalSaved = worse.Sum() + better.Sum();
        return new RunResult(
            better.Count,
            worse.Count,
            totalSaved,
            better.Count == 0 ? 0 : better.Min(),
            worse.Count == 0 ? 0 : worse.Max(),
            (double)(totalBaseline + totalSaved) / (double)totalBaseline,
            timer.ElapsedMilliseconds
        );
    }

    [TestMethod]
    public void Options()
    {
        var gzip = TestRun((page, stream) => page.Write(new GZipStream(stream, CompressionLevel.Optimal, true)));
        Console.WriteLine("GZIP (Optimal):" + gzip);

        var brotli = TestRun((page, stream) => page.Write(new BrotliStream(stream, CompressionLevel.Optimal, true)));
        Console.WriteLine("Brotli (Optimal):" + brotli);

        var deflateOpt = TestRun((page, stream) => page.Write(new DeflateStream(stream, CompressionLevel.Optimal, true)));
        Console.WriteLine("DEFLATE (Optimal):" + deflateOpt);

        //var deflateFast = TestRun((page, stream) => page.Write(new DeflateStream(stream, CompressionLevel.Fastest, true)));
        //Console.WriteLine("DEFLATE (Fast):" + deflateFast);

        var custom1 = TestRun(CustomWrite1);
        Console.WriteLine("CUSTOM1:" + custom1);
    }

    private void CustomWrite1(OrbitDataPage page, Stream stream)
    {
        var writer = new StreamByteWriter(stream);

        writer.Write((ushort)page.Positions.Count);
        writer.Write(page.ID);

        // Pos
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.X).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.Y).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.Z).ToArray());

        // Vel
        writer.WriteCompressedSequenceFloat64(page.Velocities.Select(a => a.X).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Velocities.Select(a => a.Y).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Velocities.Select(a => a.Z).ToArray());

        // Times
        writer.WriteCompressedSequenceFloat64(page.Timestamps.ToArray());
    }
}