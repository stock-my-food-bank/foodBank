namespace Server.Models
{
    public class FoodItemsGet
    {
        public int id { get; set; }
        public string title { get; set; }
        public string[]? badges { get; set; }
    }
}
