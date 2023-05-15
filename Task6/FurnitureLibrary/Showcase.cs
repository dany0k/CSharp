namespace FurnitureLibrary;

public class Showcase : Closet
{
    private bool HasLight { get; set; }

    public Showcase(string material, int height, int width, int depth, int numShelves, bool hasLight) : 
        base(material, height, width, depth, numShelves)
    {
        HasLight = hasLight;
    }

    public Showcase()
    {
        HasLight = true;
    }

    public string turnOnLight()
    {
        return "Свет теперь включен";
    }
    
    public string turnOffLight()
    {
        return "Свет теперь выключен";
    }
    
    public override double CalculatePrice()
    {
        var pricePerShelf = 10.0;
        if (HasLight)
        {
            pricePerShelf += 20.0;
        }

        return pricePerShelf;
    }
}