using System.Linq;

[Flags]
public enum Allergen
{
    Eggs         = 1 << 0,  // 1
    Peanuts      = 1 << 1,  // 2
    Shellfish    = 1 << 2,  // 4
    Strawberries = 1 << 3,  // 8
    Tomatoes     = 1 << 4,  // 16
    Chocolate    = 1 << 5,  // 32
    Pollen       = 1 << 6,  // 64
    Cats         = 1 << 7   // 128
}

public record Allergies(int code)
{
    public bool IsAllergicTo(Allergen allergen) => ((Allergen)code).HasFlag(allergen);

    public Allergen[] List() => Enum.GetValues(typeof(Allergen))
                                .Cast<Allergen>()
                                .Where(IsAllergicTo)
                                .ToArray();
}