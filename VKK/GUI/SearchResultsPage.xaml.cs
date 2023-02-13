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
    /// Interaktionslogik für SearchResultsPage.xaml
    /// </summary>
    public partial class SearchResultsPage : Page
    {
        Controller controller = new Controller();

        public SearchResultsPage()
        {
            InitializeComponent();

            List<string> categories = controller.GetCategoriesAsList();
            List<string> recipes = controller.GetRecipesPerSearch(Txt_Search2.Text);

            LB_SpecRecipeList.ItemsSource = recipes;
            CB_Categories.ItemsSource = categories;
        }

        private void Btn_Go2_Click(object sender, RoutedEventArgs e)
        {
            List<string> recipes = controller.GetRecipesPerSearchAndCategory(Txt_Search2.Text, CB_Categories.Text);
            LB_SpecRecipeList.ItemsSource = recipes;
        }
    }
}
