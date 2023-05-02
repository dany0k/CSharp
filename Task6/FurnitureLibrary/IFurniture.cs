namespace FurnitureLibrary;

public interface IFurniture
{
    string Material { get; set; }
    string GetInfo();
    double CalculatePrice();
}