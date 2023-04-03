using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Task5;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddBookshelfButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var material = MaterialTextBox.Text;
            var height = Convert.ToInt32(HeightTextBox.Text);
            var width = Convert.ToInt32(WidthTextBox.Text);
            var depth = Convert.ToInt32(DepthTextBox.Text);
            var numShelves = Convert.ToInt32(NumShelvesTextBox.Text);
            var hasGlassDoor = Convert.ToBoolean(HasGlassDoorTextBox.Text);
            var color = ColorTextBox.Text;

            var newBookshelf = new Bookshelf(material, height, width, depth, numShelves, hasGlassDoor, color);
            BookShelfList.AddFurniture(newBookshelf);
            ResultBookshelvesTextBlock.Text = BookShelfList._bookshelves;
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void OpenShelfButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.Open();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void CloseShelfButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.Close();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void ChangeColorButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.Paint(NewColorTextBox.Text);
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void AddShelfButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.AddShelf();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void RemoveShelfButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.RemoveShelf();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void CheckDoorButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.CheckDoor();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }

    private void GetInformationButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var shelfIndex = Convert.ToInt32(ShelfIndexTextBox.Text);
            var bookshelf = BookShelfList.getBookshelf(shelfIndex);
            ResultMethodTextBlock.Text = bookshelf.GetInfo();
        }
        catch (Exception exception)
        {
            ResultMethodTextBlock.Text = "Неккоректные данные!";
        }
    }
}