using Server.Models;

namespace Server.Interfaces
{
    public interface IFoodItemsRepository
    {
        Task<List<Product>> GetFoodItemsFromSpoonacular();
        int GetCount();
    }
}
