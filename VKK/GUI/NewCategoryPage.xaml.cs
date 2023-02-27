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

        /// <summary>
        /// Fügt Kategorie in die Datenbank ein
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Category cat = new Category();
            if (Txt_CatName.Text != "")
            {
                cat.Title = Txt_CatName.Text;
                Txt_CatName.Text = "";

                controller.InsertCategory(cat);
                List<string> categories = controller.GetCategoriesAsList();
                CB_Categories.ItemsSource = categories;
            }
            else
            {
                MessageBox.Show("Bitte geben Sie der Kategorie einen Namen.");
            }
        }

        /// <summary>
        /// Schließt die Seite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Done_Click(object sender, RoutedEventArgs e)
        {
            WelcomePage page = new WelcomePage();
            this.NavigationService.RemoveBackEntry();
            this.NavigationService.Navigate(page);
        }

        /// <summary>
        /// Löscht Kategorie nach Abfrage aus der Datenbank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diese Kategorie löschen möchten?", "Achtung!", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    List<Recipe> allRecs = controller.GetAllRecipes();
                    List<Recipe> recs = new List<Recipe>();

                    foreach(Recipe rec in allRecs)
                    {
                        if (rec.Category.Title == CB_Categories.SelectedItem.ToString())
                        {
                            MessageBox.Show("Diese Kategorie kann nicht gelöscht werden, da bereits Rezepte existieren, die dieser Kategorie zugeordnet sind.");
                            CB_Categories.Text = "";
                            return;
                        }
                    }

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

                    List<string> categories = controller.GetCategoriesAsList();
                    CB_Categories.ItemsSource = categories;
                    break;

                case MessageBoxResult.No:
                    return;
            }
        }
    }
}
