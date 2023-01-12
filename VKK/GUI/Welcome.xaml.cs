using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VKK.GUI
{
    /// <summary>
    /// Interaktionslogik für Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
            MySqlConnector test = new MySqlConnector("kochrezepte");
            MessageBox.Show(test.TestConnection());
        }
    }
}
