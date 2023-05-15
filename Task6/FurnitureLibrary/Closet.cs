namespace FurnitureLibrary;

public abstract class Closet : IFurniture
{
    public string Material;
    protected int Height { get; set; }
    protected int Width { get; set; }
    protected int Depth { get; set; }
    protected int NumShelves { get; set; }

    protected Closet(string material, int height, int width, int depth, int numShelves)
    {
        Material = material;
        Height = height;
        Width = width;
        Depth = depth;
        NumShelves = numShelves;
    }

    protected Closet()
    {
        Material = "oak";
        Height = 2000;
        Width = 1000;
        Depth = 500;
        NumShelves = 5;
    }

    public virtual string GetInfo()
    {
        return $"Метериал шкафа: {Material}. Параметры: {Height}x{Width}x{Depth}. Количество полок: {NumShelves}";
    }

    public abstract double CalculatePrice();

    public string Open()
    {
        return "Дверь открыта";
    }

    public string Close()
    {
        return "Дверь закрыта";
    }

    public string SetMaterial(string material)
    {
        Material = material;
        return $"Изменен материал на {material}";
    }

    public string GetMaterial()
    {
        return $"Материал: {Material}";
    }

    public string AddShelf()
    {
        NumShelves++;
        return $"Новая полка добавлена. Шкаф имеет {NumShelves} полок.";
    }

    public string RemoveShelf()
    {
        if (NumShelves > 0)
        {
            NumShelves--;
            return $"Полка кудалена. Шкаф имеет {NumShelves} полок.";
        }
        else
        {
            return "Больше нельзя удалить полки!";
        }
    }
}