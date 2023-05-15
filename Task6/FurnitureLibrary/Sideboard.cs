namespace FurnitureLibrary;

public class Sideboard : Closet
{
    private bool HasDecorativeElements { get; set; }
    private int DecorativeElementsNum { get; set; }

    public Sideboard(
        string material,
        int height,
        int width,
        int depth,
        int numShelves,
        bool hasDecorativeElements,
        int numDecorativeElements) : 
        base(material, height, width, depth, numShelves)
    {
        HasDecorativeElements = hasDecorativeElements;
        DecorativeElementsNum = numDecorativeElements;
    }

    public Sideboard()
    {
        HasDecorativeElements = false;
        DecorativeElementsNum = 0;
    }

    public override double CalculatePrice()
    {
        var pricePerShelf = 15.0;
        if (HasDecorativeElements)
        {
            pricePerShelf += 5;
        }

        return pricePerShelf;
    }

    public string AddDecorativeElement()
    {
        if (!HasDecorativeElements)
        {
            HasDecorativeElements = true;
        }
        DecorativeElementsNum++;
        return $"Декоративный элемент добавлен. Серван имеет {DecorativeElementsNum} декоративных элементов.";
    }
    
    public string RemoveDecorativeElement()
    {
        DecorativeElementsNum--;
        if (DecorativeElementsNum == 0)
        {
            HasDecorativeElements = false;
        }
        return $"Декоративный элемент удален. Серван имеет {DecorativeElementsNum} декоративных элементов.";

    }
}