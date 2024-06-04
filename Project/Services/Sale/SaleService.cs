
namespace Project.Services.Sale
{
    public class SaleService : ISaleService
    {
        private readonly DataContext _context;

        public SaleService(DataContext context)
        {
            _context = context;
        }


        //add items
        public async Task<List<Sales>> AddItem(Sales item)
        {
            _context.Sales.Add(item);
            await _context.SaveChangesAsync();

            var stockItem = await _context.stocks.FirstOrDefaultAsync(s => s.Id == item.StockId);

            if (stockItem != null)
            {
                stockItem.Quantity -= item.Quantity;    //updating stock quantity
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Stock ID not found!");
            }

            var sales = await _context.Sales.ToListAsync();
            return sales;
        }

        //delete item
        public async Task<List<Sales>> DeleteItem(Guid id)
        {
            var resposne = await _context.Sales.FirstOrDefaultAsync(s => s.Id == id);

            if (resposne is null)
            {
                throw new Exception("ID not found");

            }

            _context.Sales.Remove(resposne);
            await _context.SaveChangesAsync();

            var sales = await _context.Sales.ToListAsync();
            return sales;
        }


        //getall
        public async Task<List<Sales>> GetAll()
        {
            var response = await _context.Sales.ToListAsync();
            return response;
        }

        public async Task<Sales> GetItemById(Guid id)
        {
            var resposne = await _context.Sales.FirstOrDefaultAsync(c => c.Id == id);

            if (resposne is null)
            {
                throw new Exception("ID not found!");
            }

            return resposne;
        }

        //update
        public async Task<List<Sales>> UpdateItem(Sales updateitem)
        {
            var response = await _context.Sales.FirstOrDefaultAsync(c => c.Id == updateitem.Id);

            if (response is null)
            {
                throw new Exception("ID not found");
            }

            int quantityDifference = updateitem.Quantity - response.Quantity;   //difference that needs to be subtracted

            response.TotalCost = updateitem.TotalCost;
            response.Date = updateitem.Date;
            response.Quantity = updateitem.Quantity;
            response.StockId = updateitem.StockId;

            await _context.SaveChangesAsync();

            var stockItem = await _context.stocks.FirstOrDefaultAsync(s => s.Id == updateitem.StockId);
            if (stockItem != null)
            {
                stockItem.Quantity -= quantityDifference;  //updating stocks table
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Stock ID not found!");
            }

            var sales = await _context.Sales.ToListAsync();
            return sales;
        }
    }
}
