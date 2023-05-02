using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FurnitureLibrary;

namespace Task6;

public partial class InputParamsDialog : Window
{
    private TextBox _paramsTextBox;

    public InputParamsDialog()
    {
        InitializeComponent();
        _paramsTextBox = ParamsTextBox;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void SendDataButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_paramsTextBox.Text == null)
        {
            Close();
        }
        else
        {
            var result = _paramsTextBox.Text.Split(";");
            Close(result);
        }
    }
}