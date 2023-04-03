namespace Task5;

public interface IFurniture
{
    string Material { get; set; }
    string GetInfo();
    double CalculatePrice();
}