
namespace Project.Services.stock
{
    public class StockService : IStockService
    {
        private readonly DataContext _context;

        public StockService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Stocks>> AddStock(Stocks stocks)
        {
            _context.stocks.Add(stocks);
            await _context.SaveChangesAsync();

            var Stocks = await _context.stocks.ToListAsync();
            return Stocks;
        }

        public async Task<List<Stocks>> DeleteStock(Guid id)
        {
            var resposne = await _context.stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (resposne is null)
            {
                throw new Exception("ID not found!");
            }

            _context.stocks.Remove(resposne);
            await _context.SaveChangesAsync();

            var stocks = await _context.stocks.ToListAsync();
            return stocks;

        }

        public async Task<List<Stocks>> GetAll()
        {
            var response = await _context.stocks.ToListAsync();
            return response;
        }

        public async Task<Stocks> GetStockById(Guid id)
        {
            var response = await _context.stocks.FirstOrDefaultAsync(c => c.Id == id);

            if (response is null)
            {
                throw new Exception("ID not found!");
            }

            return response;
        }

        public async Task<List<Stocks>> UpdateStock(Stocks updateStocks)
        {
            var response = await _context.stocks.FirstOrDefaultAsync(c => c.Id == updateStocks.Id);

            if (response is null)
            {
                throw new Exception("ID not found");

            }

            response.Quantity = updateStocks.Quantity;
            response.PurchaseId = updateStocks.PurchaseId;

            await _context.SaveChangesAsync();

            var stocks = await _context.stocks.ToListAsync();
            return stocks;

        }
    }
}
