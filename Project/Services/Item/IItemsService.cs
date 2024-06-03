
namespace Project.Services.Item
{
    public interface IItemsService
    {
        public Task<List<Items>> GetAll();

        public Task<Items> GetItemById(Guid id);

        public Task<List<Items>> DeleteItem(Guid id);

        public Task<List<Items>> AddItem(Items item);

        public Task<List<Items>> UpdateItem(Items updateitem);
    }
}
