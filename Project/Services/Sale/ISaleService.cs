namespace Project.Services.Sale
{
    public interface ISaleService
    {
        public Task<List<Sales>> GetAll();

        public Task<Sales> GetItemById(Guid id);

        public Task<List<Sales>> DeleteItem(Guid id);

        public Task<List<Sales>> AddItem(List<Sales> item);

        public Task<List<Sales>> UpdateItem(Sales updateitem);
    }
}
