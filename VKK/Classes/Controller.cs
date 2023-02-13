using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKK
{
    class Controller
    {
        DBAdapter db = new DBAdapter();
        public static Recipe curr { get; set; }

        public List<string> GetCategoriesAsList()
        {
            List<Category> cats = this.GetCategories();
            List<string> results = new List<string>();

            foreach (Category cat in cats)
            {
                string catstring = cat.Title;
                results.Add(catstring);
            }

            return results;
        }

        public List<Category> GetCategories()
        {
            return db.GetCategories();
        }

        public List<Recipe> GetAllRecipes()
        {
            return db.GetRecipes();
        }

        public List<string> GetRecipesAsStrings()
        {
            List<Recipe> recs = db.GetRecipes();
            List<string> recEntries = new List<string>();

            foreach(Recipe rec in recs)
            {
                string curr = GetRecipeString(rec);
                recEntries.Add(curr);
            }

            return recEntries;
        }

        public List<string> GetRecipesPerSearch(string search)
        {
            List<Recipe> recs = db.GetRecipes();
            List<string> recEntries = new List<string>();

            foreach(Recipe rec in recs)
            {
                if(rec.Title.Contains(search))
                {
                    string curr = GetRecipeString(rec);
                    recEntries.Add(curr);
                }
            }

            return recEntries;
        }

        public List<string> GetRecipesPerSearchAndCategory(string search, string category)
        {
            List<Recipe> recs = db.GetRecipes();
            List<string> recEntries = new List<string>();

            foreach(Recipe rec in recs)
            {
                if(category != "")
                {
                    if (rec.Title.Contains(search) && rec.Category.Title == category)
                    {
                        string curr = GetRecipeString(rec);
                        recEntries.Add(curr);
                    }
                }
                else
                {
                    if (rec.Title.Contains(search))
                    {
                        string curr = GetRecipeString(rec);
                        recEntries.Add(curr);
                    }
                }
            }

            return recEntries;
        }

        private string GetRecipeString(Recipe rec)
        {
            return String.Format("{0}, Arbeitszeit: {1} min, Kategorie: {2}", rec.Title, rec.TimeInMinutes, rec.Category.Title); 
        }

        public int DeleteRecipe(Recipe rec)
        {
            return db.DeleteRecipe(rec);
        }

        public bool InsertRecipe(Recipe rec)
        {
            return db.InsertRecipe(rec);
        }

        public List<string> GetUnits()
        {
            return Unit.GetNames(typeof(Unit)).ToList();
        }
    }
}
