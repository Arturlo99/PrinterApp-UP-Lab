using System;
using System.Collections.Generic;
using System.Drawing;
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
using Microsoft.Win32;

namespace PrinterApp
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

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(toPrintTextBox.Text)|| string.IsNullOrEmpty(toPrintTextBox.Text))
            {

                var file = File.Create("file.txt");
                StreamWriter writer = new StreamWriter(file);

                if (fontTypeComboBox.SelectedItem != null )
                {
                    string font="0";
                    if ((string)((ComboBoxItem)fontTypeComboBox.SelectedItem).Content == "Arial")
                        font = "16602";
                    else if ((string)((ComboBoxItem)fontTypeComboBox.SelectedItem).Content == "Times New Roman")
                        font = "517";
                    else if ((string)((ComboBoxItem)fontTypeComboBox.SelectedItem).Content == "CG Times")
                        font = "4101";

                    writer.WriteLine( "\x1B" + "(s1p" + (string)((ComboBoxItem)fontSizeComboBox.SelectedItem).Content + "v0s0b" + font + "T");
                }
                   
                if (orientationComboBox.SelectedItem != null)
                {
                    string orientation = "";
                    if ((string)((ComboBoxItem)orientationComboBox.SelectedItem).Content == "Horizontal")
                        orientation = "&l0O";
                    else if ((string)((ComboBoxItem)orientationComboBox.SelectedItem).Content == "Vertical")
                        orientation = "&l1O";
                    writer.WriteLine("\x1B" + orientation);
                }


                if ((bool)boldCheckBox.IsChecked)
                {
                    writer.WriteLine("\x1B" + "(s5B");
                }
                if ((bool)underlineCheckBox.IsChecked)
                {
                    writer.WriteLine("\x1B" + "&d0D");
                }
                if ((bool)italicCheckBox.IsChecked)
                {
                    writer.WriteLine("\x1B" + "(s1S");
                }

                writer.WriteLine(toPrintTextBox.Text);
                writer.WriteLine("\x1B" + "E");
                writer.Close();
            }
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            {
                var file = File.Create("file");
                StreamWriter writer = new StreamWriter(file);


                // Do zrobienia
                /* 
                    writer.Write("\x1B" + "*p10x10Y"); // Pozycja początkowa
                    writer.Write("\x1B" + "*t300R"); // Rozdzielczość
                    writer.Write("\x1B" + "*r200T"); // Height
                    writer.Write("\x1B" + "*r200S"); // Width
                    writer.Write("\x1B" + "*r1A"); // Start
                    writer.Write("\x1B" + "c0P");
                    writer.Write("\x1B" + "*rC"); // End
                */
            }
        }
    }
}
