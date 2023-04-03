using System.Collections.Generic;

namespace Task5;

static class BookShelfList
{
    private static List<Bookshelf> _furnitureList = new List<Bookshelf>();
    public static string _bookshelves { get; set; }

    private static int count = 0;

    public static void AddFurniture(Bookshelf furniture)
    {
        _furnitureList.Add(furniture);
        _bookshelves =  _bookshelves + count + ": " + " " + furniture.GetInfo() + "\n";
        count++;
    }

    public static Bookshelf getBookshelf(int index)
    {
        return _furnitureList[index];
    }
}