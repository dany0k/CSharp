using System;

namespace Task5;

public abstract class Closet : IFurniture
{
    public string Material { get; set; }
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