namespace Server.Models
{
    public class FoodItemsGet
    {
        public int foodId { get; set; }
        public string foodName { get; set; }
        public string[]? allergens { get; set; }
    }
}
