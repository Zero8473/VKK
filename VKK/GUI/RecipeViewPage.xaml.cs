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

            Lbl_RecipeTitle.Content = curr.Title;

            try
            {
                string imgString;

                if (curr.Pic != "")
                {
                    if (curr.Pic.Substring(0, 1) == @"\")
                    {
                        imgString = "..\\.." + curr.Pic;
                    }
                    else
                    {
                        imgString = curr.Pic;
                    }

                    Img_RecipePic.Source = new ImageSourceConverter().ConvertFromString(imgString) as ImageSource;
                }
            }

            catch
            {
                // do nothing
            }

            foreach(Ingredient ing in curr.Ingredients)
            {
                if (ing.Amount == 0 && ing.UnitOfMeasure == Unit.leer)
                {
                    ings += ing.Title + Environment.NewLine;
                }
                else
                {
                    ings += String.Format("{0} {1} {2}", ing.Amount.ToString("0.##"), ing.UnitOfMeasure.ToString(), ing.Title) + Environment.NewLine;
                }
            }

            Lbl_Time.Content = String.Format("Arbeitszeit: {0} min.", curr.TimeInMinutes.ToString());

            foreach(Step step in curr.Steps)
            {
                steps += step.Description + Environment.NewLine + Environment.NewLine;
            }

            Txt_Ingredients.Text = ings;
            Txt_Steps.Text = steps;
            Txt_Servings.Text = curr.Servings.ToString();
        }

        private void Btn_RecipeDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie dieses Rezept löschen möchten?", "Achtung!", MessageBoxButton.YesNo);

            switch(result)
            {
                case MessageBoxResult.Yes:
                    controller.DeleteRecipe(curr);
                    WelcomePage page = new WelcomePage();
                    this.NavigationService.RemoveBackEntry();
                    this.NavigationService.Navigate(page);
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }

        private void Txt_Servings_TextChanged(object sender, TextChangedEventArgs e)
        {
           ings = "";
            int ServingInt;

            try
            {
                if (Txt_Servings.Text == "")
                {
                    ServingInt = 0;
                }
                else
                {
                    ServingInt = Int32.Parse(Txt_Servings.Text);
                }

                foreach (Ingredient ing in curr.Ingredients)
                {
                    if (ServingInt == curr.Servings)
                    {
                        if (ing.Amount == 0 && ing.UnitOfMeasure == Unit.leer)
                        {
                            ings += ing.Title + Environment.NewLine;
                        }
                        else
                        {
                            ings += String.Format("{0} {1} {2}", ing.Amount.ToString("0.##"), ing.UnitOfMeasure.ToString(), ing.Title) + Environment.NewLine;
                        }
                    }
                    else if (ing.Amount == 0 && ing.UnitOfMeasure == Unit.leer)
                    {
                        ings += ing.Title + Environment.NewLine;
                    }
                    else
                    {
                        decimal newAmount = ing.Amount / curr.Servings * ServingInt;
                        ings += String.Format("{0} {1} {2}", newAmount.ToString("0.##"), ing.UnitOfMeasure.ToString(), ing.Title) + Environment.NewLine;
                    }
                }

                Txt_Ingredients.Text = ings;
            }
            catch
            {
                MessageBox.Show("Ihre Eingabe ist ungültig. Bitte beachten Sie, dass in dem Feld 'Portionen' eine Ganzzahl als Eingabe erwartet wird.");
                Txt_Servings.Text = "";
            }
        }
    }
}
