using System;

namespace Task4;

public class ProSportsman : Sportsman
{
    private bool IsFirstPlace { get; set; }

    public ProSportsman(string surname, int competitions, int placesSum, bool isFirstPlace)
        : base(surname, competitions, placesSum)
    {
        IsFirstPlace = isFirstPlace;
    }

    private new double Quality()
    {
        var q = base.Quality();
        return IsFirstPlace ? q * 1.5 : q;
    }

    public new String PrintInfo()
    {
        return base.PrintInfo() + $"Is first place: {IsFirstPlace},\n Quality: {Quality()}\n";
    }
}