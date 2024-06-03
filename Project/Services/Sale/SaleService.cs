
namespace Project.Services.Sale
{
    public class SaleService : ISaleService
    {
        private readonly DataContext _context;

        public SaleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Sales>> AddItem(Sales item)
        {
            _context.Sales.Add(item);
            await _context.SaveChangesAsync();

            var sales = await _context.Sales.ToListAsync();
            return sales;
        }

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

        public async Task<List<Sales>> UpdateItem(Sales updateitem)
        {
            var response = await _context.Sales.FirstOrDefaultAsync(c => c.Id == updateitem.Id);

            if (response is null)
            {
                throw new Exception("ID not found");
            }

            response.TotalCost = updateitem.TotalCost;
            response.Date = updateitem.Date;
            response.Quantity = updateitem.Quantity;
            response.ItemsId = updateitem.ItemsId;

            await _context.SaveChangesAsync();

            var sales = await _context.Sales.ToListAsync();
            return sales;

        }
    }
}
