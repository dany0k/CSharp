using System;
using System.Collections.Generic;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace Task6;

public partial class MainWindow : Window
{
    private List<Type> _types;
    private List<string> _methods = new List<string>();
    private string _currentType;
    private Object? _currentObject = null;

    private void CreateDropPlaun()
    {
        for (int i = 0; i < _types.Count; i++)
        {
            ClassesGrid.ColumnDefinitions.Add(new ColumnDefinition(width: GridLength.Star));
            var button = new Button();
            button.Name = _types[i].Name;
            button.Content = _types[i].Name;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.Click += LoadMethodsFromClass;
            Grid.SetRow(button, 0);
            Grid.SetColumn(button, i);
            ClassesGrid.Children.Add(button);
        }
    }

    private void LoadMethodsOnGrid()
    {
        MethodsGrid.Children.Clear();
        MethodsGrid.RowDefinitions.Clear();
        for (int i = 0; i < _methods.Count; i++)
        {
            MethodsGrid.RowDefinitions.Add(new RowDefinition(height: GridLength.Auto));
            var button = new Button();
            button.Name = _methods[i];
            button.Content = _methods[i];
            button.VerticalAlignment = VerticalAlignment.Center;
            button.Click += CreateDialogWithParameters;
            Grid.SetRow(button, i);
            Grid.SetColumn(button, 0);
            MethodsGrid.Children.Add(button);
        }
    }

    private async void CreateDialogWithParameters(object? sender, RoutedEventArgs e)
    {
        var inputParams = new InputParamsDialog();
        var parameters = await inputParams.ShowDialog<object[]>(this);
        var methods = (Button) sender!;
        if (methods.Name != null)
        {
            InvokeMethod(methods.Name, parameters);
        }
    }

     private void InvokeMethod(string methodName, object[] parameters)
    {
        BindingFlags flags = BindingFlags.Public;
        // Флаг для отображения, статический метод или нет
        bool staticFlag = false;
        // Убираем из названия static (если есть)
        if (methodName.StartsWith("static"))
        {
            methodName = methodName.Replace("static", " ");
            flags = flags | BindingFlags.Static;
            staticFlag = true;
        }
        // Убираем из названия virtual (если есть)
        if (methodName.StartsWith("virtual"))
            methodName = methodName.Replace("virtual", " ");

        methodName = methodName.Trim();
        // Если метод ничего не возвращает
        if (methodName.IndexOf("System.Void", StringComparison.Ordinal) != -1)
        {
            // Отсюда нам надо разбить метод по некоторым разделителям, чтобы вытащить имя
            var tokens = methodName.Split(new char[]{' ', '(', ')'});
            
            // через лямбда-выражения ищем в нашем списке типов текущий тип, с которым работаем
            Type? t = _types.Find((t) => t.Name == _currentType);
            
            // Получаем объект метода из этого класса
            var method = t.GetMethod(tokens[1]);
            if (staticFlag)
            {
                // Если метод статический, то просто вызываем его с переданными параметрами, больше ничего не надо
                method.Invoke(null, parameters);
            }
            else
            {
                // Иначе через специальную штуку Activator.CreateInstanse(Type) создаем экземпляр этого типа
                if (_currentObject == null || t != _currentObject.GetType())
                    _currentObject= Activator.CreateInstance(t);
                
                // И передаем в вызов метода
                method.Invoke(_currentObject, parameters);
            }
        }
        else
        {
            // Тут все тоже самое, что и выше, за исключением того, что у нас метод что-то возвращает
            // и это что-то мы должны получить в переменную типа object? (базовый самый класс для всего)
            var tokens = methodName.Split(new char[]{' ', '(', ')'});
            Type? t = _types.Find((t) => t.Name == _currentType);
            var method = t.GetMethod(tokens[1]);
            
            // Вот этот наш результат выполнения
            object? result = "";
            if (staticFlag)
            {
                result = method.Invoke(null, parameters);
            }
            else
            {
                if (_currentObject == null || t != _currentObject.GetType())
                    _currentObject= Activator.CreateInstance(t);
                result = method.Invoke(_currentObject, parameters);
            }
            // Потом результат переводится в string и печатается в MessageBox
            // var msgBox =
            //     MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Result",
            //         result.ToString());
            // msgBox.Show();
        }
    }
     
     private void LoadMethodsFromClass(object? sender, RoutedEventArgs e)
     {
         Button btn = (Button)sender;
         // Вот здесь мы получили экземпляр кнопки, которая была нажата, и вытянули из нее имя типа, которая она
         // представляет
         var type = _types.Find((t) => t.Name == btn.Name);
         _currentType = type.Name;
         // Очищаем список от предыдущих методов
         _methods.Clear();
         // Потом проходимся по каждому методу и вытаскиваем из него инфу, после чего приводим все в строку
         // формат которой указан в комментарии около списка выше
         foreach (var method in type.GetMethods())
         {
             string res = "";
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
         LoadMethodsOnGrid();
     }


    public MainWindow()
    {
        InitializeComponent();
        _types = new List<Type>();
    }

    private void LoadDllButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            // Пытаемся подгрузить динамически либу (например, пришло PrinterLib.dll
            var asm = Assembly.LoadFrom(PathToDllTextBlock.Text);
            foreach (var type in asm.GetTypes())
            {
                // Проходимся по типам, и если это не интерфейс и не абстрактный класс, то добавляем в наш список
                if (type.GetInterfaces().Length != 0 && !type.IsAbstract)
                    _types.Add(type);
            }
            CreateDropPlaun();
        }
        catch (Exception exception)
        {
            // var msgBox =
            //     MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Error",
            //         "Не удалось подключить библиотеку");
            // msgBox.Show();
        }
    }
}