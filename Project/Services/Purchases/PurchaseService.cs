namespace Project.Services.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly DataContext _context;

        public PurchaseService(DataContext context)
        {
            _context = context;
        }

        //Add
        public async Task<List<Purchase>> Add(List<Purchase> items)
        {
            foreach (var item in items)
            {
                item.TotalCost = item.Quantity * item.ItemsNavigation!.prize;
                _context.purchases.Add(item);
            }
            await _context.SaveChangesAsync();
            var result = await _context.purchases.ToListAsync();
            return result;
        }


        //DeleteItem
        public async Task<List<Purchase>> Delete(Guid id)
        {
            var item = await _context.purchases.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null || item.Id != id)
            {
                throw new Exception("ID NOT FOUND!");
            }

            _context.purchases.Remove(item);

            _context.SaveChanges();

            return await _context.purchases.ToListAsync();

        }


        //GET-BY-ID
        public async Task<Purchase> GetById(Guid id)
        {

            var item = await _context.purchases.FirstOrDefaultAsync(c => c.Id == id);

            if (item is null || item.Id != id)
            {
                throw new Exception("ID NOT FOUND");
            }

            return item;
        }


        //GET-ALL
        public async Task<List<Purchase>> GetAll()
        {
            return await _context.purchases.ToListAsync();
        }

        //UPDATE
        public async Task<List<Purchase>> Update(Purchase updateitem)
        {

            var item = await _context.purchases.FirstOrDefaultAsync(x => x.Id == updateitem.Id);

            if (updateitem is null || item is null)
            {
                throw new Exception("ID NOT FOUND!");
            }

            item.Quantity = updateitem.Quantity;                    
            item.TotalCost = updateitem.Quantity * updateitem.ItemsNavigation!.prize; ;
            item.ItemsId = updateitem.ItemsId;


            await _context.SaveChangesAsync();

            var items = await _context.purchases.ToListAsync();
            return items;

        }
    }
}
