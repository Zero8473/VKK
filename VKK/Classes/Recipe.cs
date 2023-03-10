using System;
using System.Collections.Generic;
using System.Text;

namespace VKK
{
    class Recipe
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _pic;
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        public Category Category;

        public List<Ingredient> Ingredients = new List<Ingredient>();

        public List<Step> Steps = new List<Step>();

        public decimal Servings;

        public int TimeInMinutes;

        public Recipe()
        {
        }
    }
}
