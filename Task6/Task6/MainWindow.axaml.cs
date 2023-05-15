using System;
using System.Collections.Generic;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Brushes = Avalonia.Media.Brushes;

namespace Task6;

public partial class MainWindow : Window
{
    private List<Type> _types;
    private List<string> _methods = new();
    private string _currentType;
    private Object? _currentObject;

    public MainWindow()
    {
        InitializeComponent();
        _types = new List<Type>();
    }
    
    private void CreateDropDown()
    {
        ClassesComboBox.Items = _types;
        ClassesComboBox.SelectedIndex = 0;
    }

    private void LoadMethodsOnGrid()
    {
        MethodsGrid.Children.Clear();
        MethodsGrid.RowDefinitions.Clear();
        for (int i = 0; i < _methods.Count; i++)
        {
            MethodsGrid.RowDefinitions.Add(new RowDefinition(height: GridLength.Auto));
            var button = new Button
            {
                Name = _methods[i],
                Content = _methods[i],
                VerticalAlignment = VerticalAlignment.Center
            };
            button.Click += ProcessMethodButton_onClick;
            Grid.SetRow(button, i);
            Grid.SetColumn(button, 0);
            MethodsGrid.Children.Add(button);
        }
    }

    private void ProcessMethodButton_onClick(object? sender, RoutedEventArgs e)
    {
        var parameters = new object[0];
        if (MethodArgsTextBox.Text != null)
        {
            var parametersStr = MethodArgsTextBox.Text.Split(";");
            parameters = Array.ConvertAll(parametersStr, item => (object)item);
        }
        var methods = (Button) sender!;
        if (methods.Name != null)
        {
            InvokeMethod(methods.Name, parameters);
        }
    }

     private void InvokeMethod(string methodName, object[] parameters)
    {
        var staticFlag = false;
        if (methodName.StartsWith("static"))
        {
            methodName = methodName.Replace("static", " ");
            staticFlag = true;
        }
        if (methodName.StartsWith("virtual"))
            methodName = methodName.Replace("virtual", " ");

        methodName = methodName.Trim();
        if (methodName.IndexOf("System.Void", StringComparison.Ordinal) != -1)
        {
            var tokens = methodName.Split(new char[]{' ', '(', ')'});
            var type = _types.Find((t) => t.Name == _currentType);
            var method = type?.GetMethod(tokens[1]);
            if (staticFlag)
            {
                method?.Invoke(null, parameters);
            }
            else
            {
                if (_currentObject == null || type != _currentObject.GetType())
                    if (type != null)
                        _currentObject = Activator.CreateInstance(type);
                method?.Invoke(_currentObject, parameters);
            }
        }
        else
        {
            var tokens = methodName.Split(' ', '(', ')');
            var type = _types.Find((t) => t.Name == _currentType);
            var method = type?.GetMethod(tokens[1]);
            object? result;
            if (staticFlag)
            {
                result = method?.Invoke(null, parameters);
            }
            else
            {
                if (_currentObject == null || type != _currentObject.GetType())
                    if (type != null)
                        _currentObject = Activator.CreateInstance(type);
            }
            try
            {
                ResultTextBlock.IsVisible = true;
                ErrorMethodArgsTextBox.IsVisible = false;
                result = method?.Invoke(_currentObject, parameters);
                ResultTextBlock.Text = result?.ToString();
            }
            catch (Exception e)
            {
                ErrorTextBlock.Foreground = Brushes.Red;
                ResultTextBlock.IsVisible = false;
                ErrorMethodArgsTextBox.IsVisible = true;
            }
        }
    }
     
     private void ShowMethods_OnClick(object? sender, RoutedEventArgs e)
     {
         var selectedItem = ClassesComboBox.SelectedItem?.ToString();
         Console.WriteLine(selectedItem);
         if (selectedItem != null)
         {
             var index = selectedItem.LastIndexOf('.') + 1;
             var result = selectedItem[index..];
             var type = _types.Find((t) => t.Name == result);
             _currentType = type.Name;
             _methods.Clear();
             foreach (var method in type.GetMethods())
             {
                 var res = "";
                 if (method.IsStatic)
                     res += "static ";
                 if (method.IsVirtual)
                     res += "virtual ";
                 res += method.ReturnType + " ";
                 res += method.Name + "(";
                 foreach (var parameter in method.GetParameters())
                 {
                     res += parameter.ParameterType.Name + " " + parameter.Name;
                     res += ", ";
                 }
                 if(res[^1] == ' ')
                     res = res.Remove(res.Length - 2);
                 res += ")";
                 _methods.Add(res);
             }
         }
         LoadMethodsOnGrid();
     }

     private void LoadDllButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var asm = Assembly.LoadFrom(PathToDllTextBlock.Text);
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterfaces().Length != 0 && !type.IsAbstract)
                    _types.Add(type);
            }
            ErrorTextBlock.IsVisible = false;
            ClassesComboBox.IsVisible = true;
            ShowMethodsButton.IsVisible = true;
            MethodsTextBlock.IsVisible = true;
            MethodArgsTextBox.IsVisible = true;
            ResultTextBlock.IsVisible = true;
            ResultLabelTextBlock.IsVisible = true;
            CreateDropDown();
        }
        catch (Exception exception)
        {
            ErrorTextBlock.Foreground = Brushes.Red;
            ErrorTextBlock.IsVisible = true;
        }
    }
}