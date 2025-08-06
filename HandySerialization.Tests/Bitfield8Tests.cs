using HandySerialization.Collections;

namespace HandySerialization.Tests;

[TestClass]
public class Bitfield8Tests
{
    [TestMethod]
    public void Constructor_Default_InitializesToZero()
    {
        var bits = new Bitfield8();
        var value = bits.Value;
        Assert.AreEqual(0, value);
    }

    [TestMethod]
    public void Constructor_WithInitialValue_SetsCorrectValue()
    {
        const byte initialValue = 0b0010_1010;
        var bits = new Bitfield8(initialValue);
        Assert.AreEqual(initialValue, bits.Value);
    }

    [TestMethod]
    public void BitProperties_Get_ReturnCorrectBooleanValues()
    {
        var bits = new Bitfield8(0b1010_1010);

        Assert.IsFalse(bits.Bit0);
        Assert.IsTrue(bits.Bit1);
        Assert.IsFalse(bits.Bit2);
        Assert.IsTrue(bits.Bit3);
        Assert.IsFalse(bits.Bit4);
        Assert.IsTrue(bits.Bit5);
        Assert.IsFalse(bits.Bit6);
        Assert.IsTrue(bits.Bit7);
    }

    [TestMethod]
    public void BitProperties_Set_FromZeroToTrue_UpdatesValueCorrectly()
    {
        var bits = new Bitfield8(0);

        bits.Bit0 = true;
        Assert.AreEqual(0b0000_0001, bits.Value);

        bits.Bit2 = true;
        Assert.AreEqual(0b0000_0101, bits.Value);

        bits.Bit7 = true;
        Assert.AreEqual(0b1000_0101, bits.Value);
    }

    [TestMethod]
    public void BitProperties_Set_FromAllOnesToFalse_UpdatesValueCorrectly()
    {
        var bits = new Bitfield8(0b1111_1111);

        bits.Bit1 = false;
        Assert.AreEqual(0b1111_1101, bits.Value);

        bits.Bit3 = false;
        Assert.AreEqual(0b1111_0101, bits.Value);

        bits.Bit6 = false;
        Assert.AreEqual(0b1011_0101, bits.Value);
    }

    [TestMethod]
    public void Indexer_Get_ReturnsCorrectBooleanValues()
    {
        var bits = new Bitfield8(0b1010_1010);

        Assert.IsFalse(bits[0]);
        Assert.IsTrue(bits[1]);
        Assert.IsFalse(bits[2]);
        Assert.IsTrue(bits[3]);
        Assert.IsFalse(bits[4]);
        Assert.IsTrue(bits[5]);
        Assert.IsFalse(bits[6]);
        Assert.IsTrue(bits[7]);
    }

    [TestMethod]
    public void Indexer_Set_UpdatesValueCorrectly()
    {
        // Arrange
        var bits = new Bitfield8(0);

        bits[0] = true;
        bits[2] = true;
        bits[4] = true;
        bits[6] = true;

        Assert.AreEqual(0b0101_0101, bits.Value);

        bits[0] = false;
        bits[6] = false;

        Assert.AreEqual(0b0001_0100, bits.Value);
    }

    [TestMethod]
    public void Indexer_Get_ThrowsOnOutOfRange()
    {
        var bits = new Bitfield8(0);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var _ = bits[-1]; });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var _ = bits[8]; });
    }

    [TestMethod]
    public void Indexer_Set_ThrowsOnOutOfRange()
    {
        var bits = new Bitfield8(0);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => bits[-1] = true);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => bits[8] = false);
    }

    [TestMethod]
    public void ImplicitConversion_FromByte_WorksCorrectly()
    {
        const byte sourceByte = 123;

        Bitfield8 bits = sourceByte;

        Assert.AreEqual(sourceByte, bits.Value);
    }

    [TestMethod]
    public void ImplicitConversion_ToByte_WorksCorrectly()
    {
        var bits = new Bitfield8(215);

        byte destinationByte = bits;

        Assert.AreEqual(215, destinationByte);
    }

    [DataTestMethod]
    [DataRow((byte)0, "00000000")]
    [DataRow((byte)255, "11111111")]
    [DataRow((byte)42, "00101010")]
    [DataRow((byte)1, "00000001")]
    [DataRow((byte)128, "10000000")]
    public void ToString_ReturnsCorrectPaddedBinaryString(byte value, string expected)
    {
        // Arrange
        var bits = new Bitfield8(value);

        // Act
        var result = bits.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}