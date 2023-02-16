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
    /// Interaktionslogik für NewCategoryPage.xaml
    /// </summary>
    public partial class NewCategoryPage : Page
    {
        Controller controller = new Controller();
        public NewCategoryPage()
        {
            InitializeComponent();

            List<string> categories = controller.GetCategoriesAsList();
            CB_Categories.ItemsSource = categories;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Category cat = new Category();
            cat.Title = Txt_CatName.Text;
            Txt_CatName.Text = "";

            controller.InsertCategory(cat);
        }

        private void Btn_Done_Click(object sender, RoutedEventArgs e)
        {
            WelcomePage page = new WelcomePage();
            this.NavigationService.RemoveBackEntry();
            this.NavigationService.Navigate(page);
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            List<Category> cats = controller.GetCategories();
            Category curr = new Category();
            foreach (Category cat in cats)
            {
                if (CB_Categories.SelectedItem.ToString() == cat.Title)
                {
                    curr = cat;
                }
            }

            controller.DeleteCategory(curr);
            CB_Categories.Text = "";
        }
    }
}
