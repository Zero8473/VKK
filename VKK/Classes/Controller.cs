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

            results.Add("");

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

            foreach (Recipe rec in recs)
            {
                string curr = rec.Title;
                recEntries.Add(curr);
            }

            return recEntries;
        }

        public List<string> GetRecipesPerSearch(string search, string category)
        {
            List<Recipe> recs = db.GetRecipes();
            List<string> recEntries = new List<string>();

            foreach (Recipe rec in recs)
            {
                if (category != "")
                {
                    if (rec.Title.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 && rec.Category.Title == category)
                    {
                        string curr = rec.Title;
                        recEntries.Add(curr);
                    }
                }
                else
                {
                    if (rec.Title.Contains(search))
                    {
                        string curr = rec.Title;
                        recEntries.Add(curr);
                    }
                }
            }

            recEntries.Sort();
            return recEntries;
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
