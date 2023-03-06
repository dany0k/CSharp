using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void ProcessButton_OnClick(object sender, RoutedEventArgs e)
        {
            string PATH_NAMEN = NameNText.Text;
            string PATH_NAMET = NameTText.Text;
            var readerN = new StreamReader(PATH_NAMEN);
            var readerT = new StreamReader(PATH_NAMET);
            var nameN = readerN.ReadToEnd().Replace("\n", "").Split("\r");
            var nameT = readerT.ReadToEnd().Replace("\n", "").Split("\r");
            readerN.Close();
            readerT.Close();
            var writer = new StreamWriter(PATH_NAMET, false);
            for (int i = 0; i < nameT.Length; i++)
            {
                writer.WriteLine(nameN[i] + nameT[i]);
            }

            MessageBox.Show("Complete");

            writer.Close();
        }
    }
}
