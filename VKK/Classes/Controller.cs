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

        /// <summary>
        ///  Gibt die Kategorien aus der Datenbank als String-Liste zurück
        /// </summary>
        /// <returns>categories as list of strings</returns>
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

        /// <summary>
        /// Gibt die Kategorien aus der Datenbank als Category-Liste zurück
        /// </summary>
        /// <returns>categories as list of categories</returns>
        public List<Category> GetCategories()
        {
            return db.GetCategories();
        }

        /// <summary>
        /// Gibt die Rezepte aus der Datenbank als Recipe-Liste zurück
        /// </summary>
        /// <returns>recipes as list of recipes</returns>
        public List<Recipe> GetAllRecipes()
        {
            return db.GetRecipes();
        }

        /// <summary>
        /// Gibt die Rezepte aus der Datenbank als String-Liste zurück
        /// </summary>
        /// <returns>recipes as list of strings</returns>
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

        /// <summary>
        /// Gibt eine String-Liste der Rezepte zurück, die den Filterkriterien entsprechen
        /// </summary>
        /// <param name="search"></param>
        /// <param name="category"></param>
        /// <returns>filtered recipes as list of strings</returns>
        public List<string> GetRecipesPerSearch(string search, string category)
        {
            List<Recipe> recs = db.GetRecipes();
            List<string> recEntries = new List<string>();

            foreach (Recipe rec in recs)
            {
                if (category != "" && search != "")
                {
                    if (rec.Title.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 && rec.Category.Title == category)
                    {
                        string curr = rec.Title;
                        recEntries.Add(curr);
                    }
                }
                else if (search != "")
                {
                    if (rec.Title.Contains(search))
                    {
                        string curr = rec.Title;
                        recEntries.Add(curr);
                    }
                }
                else if (category != "")
                {
                    if(rec.Category.Title == category)
                    {
                        string curr = rec.Title;
                        recEntries.Add(curr);
                    }
                }
            }

            recEntries.Sort();
            return recEntries;
        }

        /// <summary>
        /// Löscht ausgewähltes Rezept aus der Datenbank
        /// </summary>
        /// <param name="rec"></param>
        /// <returns>ExecuteNonQuery result</returns>
        public int DeleteRecipe(Recipe rec)
        {
            return db.DeleteRecipe(rec);
        }

        /// <summary>
        /// Löscht ausgewählte Kategorie aus der Datenbank
        /// </summary>
        /// <param name="cat"></param>
        /// <returns>ExecuteNonQuery result</returns>
        public int DeleteCategory(Category cat)
        {
            return db.DeleteCategory(cat);
        }

        /// <summary>
        /// Fügt ein in der GUI erstelltes Rezept in die Datenbank ein
        /// </summary>
        /// <param name="rec"></param>
        /// <returns>if successful</returns>
        public bool InsertRecipe(Recipe rec)
        {
            return db.InsertRecipe(rec);
        }

        /// <summary>
        /// Fügt eine in der GUI erstellte Kategorie in die Datenbank ein
        /// </summary>
        /// <param name="rec"></param>
        /// <returns>if successful</returns>
        public bool InsertCategory(Category cat)
        {
            return db.InsertCategory(cat);
        }

        /// <summary>
        /// Gibt Einheiten als String-Liste zurück
        /// </summary>
        /// <returns>units as list of strings</returns>
        public List<string> GetUnits()
        {
            List<string> units = new List<string>();
            units = Unit.GetNames(typeof(Unit)).ToList();
            units.Remove("leer");
            units.Add("");

            return units;
        }
    }
}
