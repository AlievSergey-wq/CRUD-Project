using SimpleShop.Core.models;

namespace SimpleShop.Application.Services
{
    public interface IItemService
    {
        Task<Guid> CreateItem(Item item);
        Task<Guid> DeleteItem(Guid id);
        Task<List<Item>> GetAllItems();
        Task<Guid> UpdateItem(Guid id, string title, string description, float price);
    }
}