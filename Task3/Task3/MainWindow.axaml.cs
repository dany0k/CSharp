using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Task3;

public partial class MainWindow : Window
{

    public static double rad = 1; 
        
    public MainWindow()
    {
        this.InitializeComponent();
    }
    
    
    private void ProcessButton_OnClick(object? sender, RoutedEventArgs e)
    {
        EllipseDrawier.Children.Clear();
        try
        {
            var r = RadiusText.Text;
            rad = Convert.ToDouble(r);
            Console.WriteLine(rad);

        }
        catch (Exception)
        {
            ResultTB.Text = "Error!";
        }
        
    }

    private void CheckPointInside_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var h = rad * Math.Sqrt(2);
            Point centralPoint = new Point(rad, rad);
            EllipseShape ellipseShape = new EllipseShape(centralPoint, rad);
            Point point = new Point(Convert.ToDouble(PointXText.Text), Convert.ToDouble(PointYText.Text));
            if (ellipseShape.IsPointInside(point))
            {
                ResultTB.Text = "Point inside";
            }
            else
            {
                ResultTB.Text = "Point outside";
            }
        }
        catch (Exception)
        {
            ResultTB.Text = "Error!";
        }
    }
}