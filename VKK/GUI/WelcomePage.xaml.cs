using System;
using System.Collections.Generic;
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

namespace VKK.GUI
{
    /// <summary>
    /// Interaktionslogik für WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            BrowsePage page = new BrowsePage();
            this.NavigationService.Navigate(page);
            
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            NewRecipePage page = new NewRecipePage();
            this.NavigationService.Navigate(page);
        }

        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            SearchResultsPage page = new SearchResultsPage();
            page.Txt_Search2.Text = Txt_Search.Text;
            this.NavigationService.Navigate(page);
        }
    }
}
