using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Task2Linux;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ProcessButton_OnClick(object sender, RoutedEventArgs e)
    {
        var isComplete = false;
        var pathNameN = NameNText.Text;
        var pathNameT = NameTText.Text;
        Console.WriteLine(pathNameN);
        Console.WriteLine(pathNameT);
        var readerN = new StreamReader(pathNameN);
        var readerT = new StreamReader(pathNameT);
        var nameN = readerN.ReadToEnd().Split("\n");
        var nameT = readerT.ReadToEnd().Split("\n");
        Console.WriteLine(nameN.Length);
        Console.WriteLine(nameT.Length);
        Array.ForEach(nameN, Console.WriteLine);
        Array.ForEach(nameT, Console.WriteLine);
        readerN.Close();
        readerT.Close();
        var writer = new StreamWriter(pathNameT, false);
        for (int i = 0; i < nameT.Length; i++)
        {
            isComplete = true;
            writer.WriteLine(nameN[i] + nameT[i]);
        }

        writer.Close();
        Console.WriteLine(isComplete ? "Complete" : "Smth went wrong");
    }
}