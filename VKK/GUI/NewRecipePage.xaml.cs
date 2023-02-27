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
    /// Interaktionslogik für NewRecipePage.xaml
    /// </summary>
    public partial class NewRecipePage : Page
    {
        Controller controller = new Controller();
        List<Step> steps = new List<Step>();
        List<Ingredient> ings = new List<Ingredient>();
        List<Category> cats = new List<Category>();
        int stepCount = 1;

        public NewRecipePage()
        {
            InitializeComponent();

            cats = controller.GetCategories();
            Lbl_Steps.Content = String.Format("Schritt {0}:", stepCount.ToString());

            CB_Units.ItemsSource = controller.GetUnits();
            CB_Categories.ItemsSource = controller.GetCategoriesAsList();
        }

        /// <summary>
        /// Fügt Zutat in die Zutatenliste ein
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddIng_Click(object sender, RoutedEventArgs e)
        {
            if (Txt_Ingredient.Text != "")
            {
                Ingredient ing = new Ingredient();
                ing.Title = Txt_Ingredient.Text;

                if (Txt_Amount.Text != "" && CB_Units.Text != "")
                {
                    try
                    {
                        ing.Amount = Decimal.Parse(Txt_Amount.Text);
                        Enum.TryParse<Unit>(CB_Units.Text, out ing.UnitOfMeasure);
                    }
                    catch
                    {
                        MessageBox.Show("Ihre Eingabe ist ungültig. Bitte beachten Sie, dass in dem Feld für die Menge der Zutat eine Dezimalzahl als Eingabe erwartet wird.");
                    }
                }
                else if (Txt_Amount.Text != "" && CB_Units.Text == "")
                {
                    MessageBox.Show("Bitte geben Sie der Zutat eine Einheit, oder lassen Sie Menge und Einheit leer.");
                }
                else if (Txt_Amount.Text == "" && CB_Units.Text != "")
                {
                    MessageBox.Show("Bitte geben Sie der Zutat eine Menge, oder lassen Sie Menge und Einheit leer.");
                }
                else if (Txt_Amount.Text == "" && CB_Units.Text == "")
                {
                    ing.Amount = 0;
                    ing.UnitOfMeasure = Unit.leer;
                }

                Txt_Ingredient.Text = "";
                Txt_Amount.Text = "";
                CB_Units.Text = "";

                ings.Add(ing);
            }
            else
            {
                MessageBox.Show("Bitte geben Sie der Zutat einen Namen.");
            }
        }

        /// <summary>
        /// Fügt Schritt in die Schrittliste ein
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddStep_Click(object sender, RoutedEventArgs e)
        {
            if (Txt_Step.Text != "")
            {
                Step step = new Step();
                step.No = stepCount;
                step.Description = Txt_Step.Text;

                stepCount += 1;
                Txt_Step.Text = "";
                Lbl_Steps.Content = String.Format("Schritt {0}:", stepCount.ToString());

                steps.Add(step);
            }
            else
            {
                MessageBox.Show("Bitte geben Sie dem Schritt eine Beschreibung");
            }
        }

        /// <summary>
        /// Speichert gesamtes Rezept in die Datenbank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Recipe rec = new Recipe();

            if (CB_Categories.Text == "" || Txt_RecipeName.Text == "" || Txt_RecipeServings.Text == "" || Txt_Time.Text == "")
            {
                MessageBox.Show("Bitte geben Sie dem Rezept einen Namen, eine Portionsanzahl, eine Zeitangabe sowie eine Kategorie.");
                return;
            }
            else
            {
                foreach (Category cat in cats)
                {
                    if (CB_Categories.SelectedItem.ToString() == cat.Title)
                    {
                        rec.Category = cat;
                    }
                }
            }
            
            rec.Title = Txt_RecipeName.Text;
            rec.Pic = Txt_RecipePic.Text;

            try
            {
                rec.Servings = Int32.Parse(Txt_RecipeServings.Text);
                rec.TimeInMinutes = Int32.Parse(Txt_Time.Text);
            }
            catch
            {
                MessageBox.Show("Ihre Eingabe ist ungültig. Bitte beachten Sie, dass in den Feldern 'Portionen' und 'Zeit (in min.)' Ganzzahlen als Eingabe erwartet werden.");
                Txt_RecipeServings.Text = "";
                Txt_Time.Text = "";

                return;
            }

            rec.Ingredients = ings;
            rec.Steps = steps;


            foreach (Ingredient ing in ings)
            {
                ing.Rec = rec;
            }

            foreach(Step step in steps)
            {
                step.Rec = rec;
            }

            controller.InsertRecipe(rec);

            Txt_RecipeName.Text = "";
            Txt_RecipePic.Text = "";
            Txt_RecipeServings.Text = "";
            Txt_Time.Text = "";

            WelcomePage page = new WelcomePage();
            this.NavigationService.RemoveBackEntry();
            this.NavigationService.Navigate(page);
        }
    }
}
