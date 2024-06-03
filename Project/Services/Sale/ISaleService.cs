namespace Project.Services.Sale
{
    public interface ISaleService
    {
        public Task<List<Sales>> GetAll();

        public Task<Sales> GetItemById(Guid id);

        public Task<List<Sales>> DeleteItem(Guid id);

        public Task<List<Sales>> AddItem(Sales item);

        public Task<List<Sales>> UpdateItem(Sales updateitem);
    }
}
