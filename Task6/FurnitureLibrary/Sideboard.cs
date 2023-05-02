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

    public override double CalculatePrice()
    {
        var pricePerShelf = 15.0;
        if (HasDecorativeElements)
        {
            pricePerShelf += 5;
        }

        return pricePerShelf;
    }

    public void AddDecorativeElement()
    {
        if (!HasDecorativeElements)
        {
            HasDecorativeElements = true;
        }
        DecorativeElementsNum++;
    }
    
    public void RemoveDecorativeElement()
    {
        DecorativeElementsNum--;
        if (DecorativeElementsNum == 0)
        {
            HasDecorativeElements = false;
        }
    }
}