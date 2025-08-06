namespace HandySerialization.Collections;

/// <summary>
/// Represents a field of 8 bits (a single byte) with easy-to-use methods
/// for getting and setting individual bits.
/// </summary>
public struct Bitfield8
{
    /// <summary>
    /// The underlying byte value of the bitfield.
    /// </summary>
    public byte Value;

    /// <summary>
    /// Initializes a new instance of the<see cref = "Bitfield8" /> struct with a specific byte value.
    /// </summary>
    /// <param name="initialValue">The initial value of the byte.</param>
    public Bitfield8(byte initialValue)
    {
        Value = initialValue;
    }


    #region Accessor Properties
    /// <summary>Gets or sets the value of bit 0 (the least significant bit).</summary>
    public bool Bit0
    {
        get => (Value & 0b0000_0001) != 0;
        set => Value = (byte)(value ? (Value | 0b0000_0001) : (Value & ~0b0000_0001));
    }

    /// <summary>Gets or sets the value of bit 1.</summary>
    public bool Bit1
    {
        get => (Value & 0b0000_0010) != 0;
        set => Value = (byte)(value ? (Value | 0b0000_0010) : (Value & ~0b0000_0010));
    }

    /// <summary>Gets or sets the value of bit 2.</summary>
    public bool Bit2
    {
        get => (Value & 0b0000_0100) != 0;
        set => Value = (byte)(value ? (Value | 0b0000_0100) : (Value & ~0b0000_0100));
    }

    /// <summary>Gets or sets the value of bit 3.</summary>
    public bool Bit3
    {
        get => (Value & 0b0000_1000) != 0;
        set => Value = (byte)(value ? (Value | 0b0000_1000) : (Value & ~0b0000_1000));
    }

    /// <summary>Gets or sets the value of bit 4.</summary>
    public bool Bit4
    {
        get => (Value & 0b0001_0000) != 0;
        set => Value = (byte)(value ? (Value | 0b0001_0000) : (Value & ~0b0001_0000));
    }

    /// <summary>Gets or sets the value of bit 5.</summary>
    public bool Bit5
    {
        get => (Value & 0b0010_0000) != 0;
        set => Value = (byte)(value ? (Value | 0b0010_0000) : (Value & ~0b0010_0000));
    }

    /// <summary>Gets or sets the value of bit 6.</summary>
    public bool Bit6
    {
        get => (Value & 0b0100_0000) != 0;
        set => Value = (byte)(value ? (Value | 0b0100_0000) : (Value & ~0b0100_0000));
    }

    /// <summary>Gets or sets the value of bit 7 (the most significant bit).</summary>
    public bool Bit7
    {
        get => (Value & 0b1000_0000) != 0;
        set => Value = (byte)(value ? (Value | 0b1000_0000) : (Value & ~0b1000_0000));
    }
    #endregion

    /// <summary>
    /// Gets or sets the bit at the specified index (0-7).
    /// This is often more convenient than the accessor properties.
    /// </summary>
    /// <param name="index">The zero-based index of the bit to get or set (must be 0-7).</param>
    /// <returns>The boolean value of the bit at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is not between 0 and 7.</exception>
    public bool this[int index]
    {
        get
        {
            if (index is < 0 or > 7)
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 7.");

            return (Value & (1 << index)) != 0;
        }
        set
        {
            if (index is < 0 or > 7)
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 7.");

            var mask = 1 << index;
            if (value)
                Value = (byte)(Value | mask);
            else
                Value = (byte)(Value & ~mask);
        }
    }

    /// <summary>
    /// Returns a string that represents the current object in binary format (e.g., "10101010").
    /// </summary>
    public override string ToString()
    {
        return Convert.ToString(Value, 2).PadLeft(8, '0');
    }

    /// <summary>
    /// Allows implicit conversion from a <see cref="Bitfield8"/> to a <see cref="byte"/>.
    /// </summary>
    public static implicit operator byte(Bitfield8 field) => field.Value;

    /// <summary>
    /// Allows implicit conversion from a <see cref="byte"/> to a <see cref="Bitfield8"/>.
    /// </summary>
    public static implicit operator Bitfield8(byte b) => new Bitfield8(b);
}