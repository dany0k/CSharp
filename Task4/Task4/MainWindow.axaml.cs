using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Task4;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ProcessButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var surname = SurnameTextBox.Text;
            var compAmount = Convert.ToInt32(CompAmountTextBox.Text);
            var placeSum = Convert.ToInt32(PlaceSumTextBox.Text);
            var sportsman = new Sportsman(surname, compAmount, placeSum);
        
            var proSurname = ProSurnameTextBox.Text;
            var proCompAmount = Convert.ToInt32(ProCompAmountTextBox.Text);
            var proPlaceSum = Convert.ToInt32(ProPlaceSumTextBox.Text);
            var isFirstPlace = Convert.ToBoolean(IsFirstPlaceTextBox.Text);
            var proSportsman = new ProSportsman(proSurname, proCompAmount, proPlaceSum, isFirstPlace);

            QSportsman.Text = sportsman.PrintFullInfo();
            QProSportsman.Text = proSportsman.PrintInfo();
        }
        catch (Exception exception)
        {
            QSportsman.Text = "Данные введены некорректно!";
            QProSportsman.Text = "";
        }
        
    }
}