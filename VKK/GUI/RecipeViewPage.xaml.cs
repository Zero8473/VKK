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
    /// Interaktionslogik für RecipeViewPage.xaml
    /// </summary>
    public partial class RecipeViewPage : Page
    {
        Controller controller = new Controller();
        Recipe curr = Controller.curr;
        string ings = "";
        string steps = "";

        public RecipeViewPage()
        {
            InitializeComponent();

            string recString = Txt_CurrRecipe.Text;
            Lbl_RecipeTitle.Content = curr.Title;

            try
            {
                Img_RecipePic.Source = new ImageSourceConverter().ConvertFromString(curr.Pic) as ImageSource;
            }

            catch
            {
                // do nothing
            }

            foreach(Ingredient ing in curr.Ingredients)
            {
                ings += String.Format("{0} {1} {2}", ing.Amount.ToString("0.##"), ing.UnitOfMeasure.ToString(), ing.Title) + Environment.NewLine;
            }

            steps = String.Format("Arbeitszeit: {0} min.", curr.TimeInMinutes.ToString()) + Environment.NewLine;
            foreach(Step step in curr.Steps)
            {
                steps += step.Description + Environment.NewLine;
            }

            Txt_Ingredients.Text = ings;
            Txt_Steps.Text = steps;
            Txt_Servings.Text = curr.Servings.ToString();
        }

        private void Btn_RecipeDelete_Click(object sender, RoutedEventArgs e)
        {
            controller.DeleteRecipe(curr);
        }

        private void Txt_Servings_TextChanged(object sender, TextChangedEventArgs e)
        {
            ings = "";
            int ServingInt;

            try
            {
                ServingInt = Int32.Parse(Txt_Servings.Text);

                if (ServingInt == curr.Servings || ServingInt == 0)
                {
                    return;
                }

                foreach (Ingredient ing in curr.Ingredients)
                {
                    decimal newAmount = ing.Amount / curr.Servings * ServingInt;
                    ings += String.Format("{0} {1} {2}", newAmount.ToString("0.##"), ing.UnitOfMeasure.ToString(), ing.Title) + Environment.NewLine;
                }

                Txt_Ingredients.Text = ings;
            }
            catch
            {
                return;
            }
        }
    }
}
