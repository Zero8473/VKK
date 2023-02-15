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

        private void Btn_AddIng_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ing = new Ingredient();
            ing.Title = Txt_Ingredient.Text;
            Decimal.TryParse(Txt_Amount.Text, out ing.Amount);
            Enum.TryParse<Unit>(CB_Units.Text, out ing.UnitOfMeasure);

            Txt_Ingredient.Text = "";
            Txt_Amount.Text = "";

            ings.Add(ing);
        }

        private void Btn_AddStep_Click(object sender, RoutedEventArgs e)
        {
            Step step = new Step();
            step.No = stepCount;
            step.Description = Txt_Step.Text;

            stepCount += 1;
            Txt_Step.Text = "";
            Lbl_Steps.Content = String.Format("Schritt {0}:", stepCount.ToString());

            steps.Add(step);
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Recipe rec = new Recipe();
            rec.Title = Txt_RecipeName.Text;
            rec.Pic = Txt_RecipePic.Text;
            rec.Servings = Int32.Parse(Txt_RecipeServings.Text);
            rec.TimeInMinutes = Int32.Parse(Txt_Time.Text);
            rec.Ingredients = ings;
            rec.Steps = steps;

            foreach(Category cat in cats)
            {
                if(CB_Categories.Text == cat.Title)
                {
                    rec.Category = cat;
                }
            }


            foreach(Ingredient ing in ings)
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
