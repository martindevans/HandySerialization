using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;
using HandySerialization.Extensions;
using HandySerialization.Extensions.Bits;
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

    private record struct RunResult(
        long TotalBytesSaved, double SizePercentage,
        double AvgBytesPerDatapoint,
        double AvgBytesPerDouble
    );

    private RunResult TestRun(Action<OrbitDataPage, Stream> writer)
    {
        var better = new List<long>();
        var worse = new List<long>();

        var timer = new Stopwatch();
        timer.Start();

        var totalDatapoints = 0;
        var totalBaseline = 0L;
        var totalActual = 0L;
        foreach (var dat in Directory.EnumerateFiles("OrbitData", "*.dat"))
        {
            using var file = File.Open(dat, FileMode.Open);
            var page = OrbitDataPage.Read(file);
            totalBaseline += page.ByteSize;
            totalDatapoints += page.Velocities.Count;

            var result = new MemoryStream();
            writer(page, result);

            totalActual += result.Length;

            if (result.Position > page.ByteSize)
                worse.Add(result.Position - page.ByteSize);
            else
                better.Add(result.Position - page.ByteSize);
        }

        if (worse.Count > 0)
            throw new NotImplementedException("That made it worse");

        var totalSaved = worse.Sum() + better.Sum();
        return new RunResult(
            totalSaved,
            totalActual / (double)totalBaseline,
            totalActual / (double)totalDatapoints,
            totalActual / (double)totalDatapoints / 7
        );
    }

    [TestMethod]
    public void DoubleInt()
    {
        const double value = (1.496e+11) * 1;

        // Translate the double into sign, exponent and mantissa.
        var bits = BitConverter.DoubleToInt64Bits(value);

        // Note that the shift is sign-extended, hence the test against -1 not 1
        var negative = (bits & (1L << 63)) != 0;
        var exponent = (int)((bits >> 52) & 0b11111111111);
        var mantissa = bits & 0xfffffffffffff;

        Console.WriteLine(negative);
        Console.WriteLine(exponent.ToString());
        Console.WriteLine(mantissa.ToString());

        
    }

    [TestMethod]
    public void Options()
    {
        //var gzip = TestRun((page, stream) => page.Write(new GZipStream(stream, CompressionLevel.Optimal, true)));
        //Console.WriteLine("GZIP (Optimal):" + gzip);

        //var brotli = TestRun((page, stream) => page.Write(new BrotliStream(stream, CompressionLevel.Optimal, true)));
        //Console.WriteLine("Brotli (Optimal):" + brotli);

        //var deflateOpt = TestRun((page, stream) => page.Write(new DeflateStream(stream, CompressionLevel.Optimal, true)));
        //Console.WriteLine("DEFLATE (Optimal):" + deflateOpt);

        var custom1 = TestRun(CustomWrite1);
        Console.WriteLine("CUSTOM1:" + custom1);

        var custom2 = TestRun(CustomWrite2);
        Console.WriteLine("CUSTOM2:" + custom2);

        var custom3 = TestRun(CustomWrite3);
        Console.WriteLine("CUSTOM3:" + custom3);
    }

    private static void CustomWrite1(OrbitDataPage page, Stream stream)
    {
        using var deflate = new DeflateStream(stream, CompressionLevel.Fastest, true);

        var writer = new StreamByteWriter(deflate);

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

    private static void CustomWrite2(OrbitDataPage page, Stream stream)
    {
        using var deflate = new DeflateStream(stream, CompressionLevel.Fastest, true);

        var writer = new StreamByteWriter(deflate);

        writer.Write((ushort)page.Positions.Count);
        writer.Write(page.ID);

        // Times
        writer.WriteCompressedSequenceFloat64(page.Timestamps.ToArray());

        // Pos
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.X).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.Y).ToArray());
        writer.WriteCompressedSequenceFloat64(page.Positions.Select(a => a.Z).ToArray());

        // For each position, determine it from arithmetic on the position (except the first one)
        var velErrsX = new double[page.Velocities.Count - 1];
        var velErrsY = new double[page.Velocities.Count - 1];
        var velErrsZ = new double[page.Velocities.Count - 1];
        for (var i = 1; i < page.Velocities.Count; i++)
        {
            var start = page.Positions[i - 1];
            var end = page.Positions[i];

            var vel = page.Velocities[i];

            var dt = page.Timestamps[i] - page.Timestamps[i - 1];
            var est = (end - start) / dt;

            var err = vel - est;
            velErrsX[i - 1] = err.X;
            velErrsY[i - 1] = err.Y;
            velErrsZ[i - 1] = err.Z;
        }

        // Write error streams
        writer.WriteCompressedSequenceFloat64(velErrsX);
        writer.WriteCompressedSequenceFloat64(velErrsY);
        writer.WriteCompressedSequenceFloat64(velErrsZ);

        // Write the first velocity
        writer.Write(page.Velocities[0].X);
        writer.Write(page.Velocities[0].Y);
        writer.Write(page.Velocities[0].Z);
    }

    private static void CustomWrite3(OrbitDataPage page, Stream stream)
    {
        using var deflate = new DeflateStream(stream, CompressionLevel.Fastest, true);

        var writer = new StreamByteWriter(deflate);

        writer.Write((ushort)page.Positions.Count);
        writer.Write(page.ID);

        //// Vel
        //WriteDoubleSequence(page.Velocities.Select(a => a.X).ToArray());
        //WriteDoubleSequence(page.Velocities.Select(a => a.Y).ToArray());
        //WriteDoubleSequence(page.Velocities.Select(a => a.Z).ToArray());

        //// Times
        //WriteDoubleSequence(page.Timestamps.ToArray());

        //// Pos
        //WriteDoubleSequence(page.Positions.Select(a => a.X).ToArray());
        //WriteDoubleSequence(page.Positions.Select(a => a.Y).ToArray());
        //WriteDoubleSequence(page.Positions.Select(a => a.Z).ToArray());

        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Velocities.ToArray()), 0, 3);
        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Velocities.ToArray()), 1, 3);
        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Velocities.ToArray()), 2, 3);

        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double,  double>(page.Timestamps.ToArray()));

        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Positions.ToArray()), 0, 3);
        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Positions.ToArray()), 1, 3);
        writer.WriteDeltaCompressedSequence(8, MemoryMarshal.Cast<double3, double>(page.Positions.ToArray()), 2, 3);

        void WriteDoubleSequence(double[] values)
        {
            var bitWriter = new BitWriter<StreamByteWriter>(writer);

            // Write sign bits and exponent
            uint prevExponent = 0;
            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];

                prevExponent = WriteSignedDoubleExponent(ref bitWriter, value, prevExponent);
            }

            bitWriter.Flush();

            // Write out mantissas
            Span<long> mantissaState = stackalloc long[8];
            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                WriteDoubleMantissa(ref writer, value, mantissaState);
            }
        }

        uint WriteSignedDoubleExponent(ref BitWriter<StreamByteWriter> writer, double x, uint prevExponent)
        {
            var exponent = BitTwiddle.Exponent(x);

            // Mix in the sign
            exponent <<= 1;
            exponent |= x < 0 ? 1u : 0u;

            // xor with previous value, to get the changed bits
            var value = exponent ^ prevExponent;

            // Write it out
            writer.WriteEliasDeltaGamma32(value);

            return exponent;
        }

        void WriteDoubleMantissa(ref StreamByteWriter writer, double x, Span<long> mantissaState)
        {
            var mantissa = BitTwiddle.Mantissa(x);

            var state = (long)mantissa;
            for (var i = 0; i < mantissaState.Length; i++)
            {
                var a = state;
                var b = mantissaState[i];
                mantissaState[i] = state;

                state = a - b;
            }

            var zigzag = state.ZigZag();
            writer.WriteVariableUInt64(zigzag);

            //Console.WriteLine(zigzag);
        }
    }
}