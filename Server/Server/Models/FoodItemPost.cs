namespace Server.Models
{
    public class FoodItemModel
    {
        public int foodId { get; set; }
        public string foodName { get; set; }
        public string[]? allergens { get; set; }

        public FoodItemModel(int foodId, string foodName, string[]? allergens)
        {
            this.foodId = foodId;
            this.foodName = foodName;
            this.allergens = allergens;
        }
    }
}
