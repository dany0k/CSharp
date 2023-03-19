namespace Task3;

public class Point
{
    private double _x;
    private double _y;

    public Point(double x, double y)
    {
        this._x = x;
        this._y = y;
    }

    protected Point() { }

    public double X
    {
        get => _x;
        set => _x = value;
    }

    public double Y
    {
        get => _y;
        set => _y = value;
    }
}