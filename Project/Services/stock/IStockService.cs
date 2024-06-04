namespace Project.Services.stock
{
    public interface IStockService
    {

        public Task<List<Stocks>> GetAll();

        public Task<Stocks> GetStockById(Guid id);

        public Task<List<Stocks>> DeleteStock(Guid id);

        public Task<List<Stocks>> AddStock(List<Stocks> stocks);

        public Task<List<Stocks>> UpdateStock(Stocks updateStocks);

    }
}
