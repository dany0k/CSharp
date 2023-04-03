using System;

namespace Task4;

public class Sportsman
{
    private string Surname { get; set; }
    private int Competitions { get; set; }
    private int PlacesSum { get; set; }

    public Sportsman(string surname, int competitions, int placesSum)
    {
        Surname = surname;
        Competitions = competitions;
        PlacesSum = placesSum;
    }

    public double Quality()
    {
        return Competitions / (double)PlacesSum;
    }

    public String PrintInfo()
    {
        return $"Sportsman: {Surname},\n Competitions: {Competitions},\n Places sum: {PlacesSum}\n";
    }
    
    public String PrintFullInfo()
    {
        return $"Sportsman: {Surname},\n Competitions: {Competitions},\n Places sum: {PlacesSum},\n Quality: {Quality()}\n";
    }
}