namespace Domain.Products;

// Stock Keeping Unit
public record Sku
{
    private const int DefaultLength = 15;
    private Sku(string value) => Value = value;

    // Why init-only property? As soon as the object is created, its value cannot be changed.
    public string Value { get; init; }

    // Factory method to create a Sku instance
    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length != DefaultLength)
        {
            return null;
        }

        return new Sku(value);
    }
}
