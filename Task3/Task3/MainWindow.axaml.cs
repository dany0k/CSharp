using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

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
            Console.WriteLine("Error!");
        }
        
    }

    private void CheckPointInside_OnClick(object? sender, RoutedEventArgs e)
    {
        EllipseShape ellipseShape = new EllipseShape(new Point(100, 100), rad);
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
}