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
    /// Interaktionslogik für BrowsePage.xaml
    /// </summary>
    public partial class BrowsePage : Page
    {
        Controller controller = new Controller();

        public BrowsePage()
        {
            InitializeComponent();
            
            List<string> categories = controller.GetCategoriesAsList();
            List<string> recipes = controller.GetRecipesAsStrings();
            recipes.Sort();

            LB_RecipeList.ItemsSource = recipes;
            CB_Categories2.ItemsSource = categories;
        }

        private void Btn_Go3_Click(object sender, RoutedEventArgs e)
        {
            List<string> recipes = controller.GetRecipesPerSearch(Txt_Search3.Text, CB_Categories2.Text);
            LB_RecipeList.ItemsSource = recipes;
        }

        private void LB_RecipeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string recipeName = LB_RecipeList.SelectedItem.ToString();
            List<Recipe> recs = controller.GetAllRecipes();
            Recipe curr = new Recipe();
            foreach (Recipe rec in recs)
            {
                if (rec.Title == recipeName)
                {
                    curr = rec;
                }
            }

            Controller.curr = curr;
            RecipeViewPage page = new RecipeViewPage();
            this.NavigationService.Navigate(page);
        }

        private void CB_Categories2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> recipes = controller.GetRecipesPerSearch(Txt_Search3.Text, CB_Categories2.SelectedItem.ToString());
            LB_RecipeList.ItemsSource = recipes;
        }
    }
}
