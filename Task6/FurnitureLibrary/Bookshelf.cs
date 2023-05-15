namespace FurnitureLibrary;

public class Bookshelf : Closet
{
    private bool HasGlassDoor { get; set; }
    private string Color { get; set; }

    public Bookshelf(string material, int height, int width, int depth, int numShelves, bool hasGlassDoor, string color)
        : base(material, height, width, depth, numShelves)
    {
        HasGlassDoor = hasGlassDoor;
        Color = color;
    }

    public Bookshelf()
    {
        HasGlassDoor = false;
        Color = "Brown";
    }

    public override string GetInfo()
    {
        if (HasGlassDoor)
            return base.GetInfo() + $" Имеет стеклянную дверь. Стоимость: {CalculatePrice()}";
        return base.GetInfo() + $" Cтоимость: {CalculatePrice()}";
    }

    public override double CalculatePrice()
    {
        double pricePerShelf = 10.0;
        if (HasGlassDoor)
            pricePerShelf += 5.0;
        return NumShelves * pricePerShelf;
    }

    public string CheckDoor()
    {
        return HasGlassDoor ? "Дверь сделана из стекла." : "Отсутсвует стеклянная дверь.";
    }

    public string Paint(string color)
    {
        Color = color;
        return "Шкаф покрашен в " + color + " цвет.";
    }
}