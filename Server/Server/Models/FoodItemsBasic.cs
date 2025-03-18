namespace Server.Models
{
    public class FoodItemsBasic
    {
        public string type { get; set; }

        public List<Product> products { get; set; }
    }

    public class Product
    {
        public int id { get; set; }

        public string title { get; set; }

        public string image { get; set; }
        
        public string imageType { get; set; }
    }
}