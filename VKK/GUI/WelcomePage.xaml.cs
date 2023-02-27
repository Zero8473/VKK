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

        /// <summary>
        /// Navigiert zur "Stöbern" Seite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            BrowsePage page = new BrowsePage();
            this.NavigationService.Navigate(page);
            
        }

        /// <summary>
        /// Navigiert zur "Neues Rezept" Seite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            NewRecipePage page = new NewRecipePage();
            this.NavigationService.Navigate(page);
        }

        /// <summary>
        /// Navigiert zur "Kategorien" Seite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Category_Click(object sender, RoutedEventArgs e)
        {
            NewCategoryPage page = new NewCategoryPage();
            this.NavigationService.Navigate(page);
        }

        /// <summary>
        /// Schließt die Anwendung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
