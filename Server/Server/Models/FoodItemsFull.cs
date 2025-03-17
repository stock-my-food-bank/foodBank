namespace Server.Models
{
    public class FoodItemsFull
    {
        public string type { get; set; }
        public List<Product> products { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalProducts { get; set; }
        public int processingTimeMs { get; set; }
    }

    public class Product
    {
        public List<string> breadcrumbs { get; set; }
        public string category { get; set; }
        public object usdaCode { get; set; } // Could be null
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public int likes { get; set; }
        public List<string> badges { get; set; }
        public List<string> importantBadges { get; set; }
        public Nutrition nutrition { get; set; }
        public Servings servings { get; set; }
        public double spoonacularScore { get; set; }
        public object aisle { get; set; } // Could be null
        public string description { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public List<string> images { get; set; }
        public string generatedText { get; set; }
        public object upc { get; set; } // Could be null
        public string brand { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public int ingredientCount { get; set; }
        public string ingredientList { get; set; }
        public Credits credits { get; set; }
    }
    public class Nutrition
    {
        public List<Nutrient> nutrients { get; set; }
        public CaloricBreakdown caloricBreakdown { get; set; }
        public double calories { get; set; }
        public string fat { get; set; }
        public string protein { get; set; }
        public string carbs { get; set; }
    }

    public class Nutrient
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class CaloricBreakdown
    {
        public double percentProtein { get; set; }
        public double percentFat { get; set; }
        public double percentCarbs { get; set; }
    }

    public class Servings
    {
        public double number { get; set; }
        public double size { get; set; }
        public string unit { get; set; }
        public object raw { get; set; } // Could be null
    }

    public class Ingredient
    {
        public string name { get; set; }
        public string safety_level { get; set; } // Can be null
        public string description { get; set; }  // Can be null
    }

    public class Credits
    {
        public string text { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string imageLink { get; set; }
    }
}
