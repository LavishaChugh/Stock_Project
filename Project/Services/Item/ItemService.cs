namespace Project.Services.Item
{
    public class ItemService : IItemsService
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        //Add
        public async Task<List<Items>> AddItem(List<Items> items)
        {
            foreach (var item in items)
            {
                _context.Items.Add(item);
            }
            await _context.SaveChangesAsync();
            var response = await _context.Items.ToListAsync();
            return response;
        }


        //DeleteItem
        public async Task<List<Items>> DeleteItem(Guid id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null || item.Id != id)
            {
                throw new Exception("ID NOT FOUND!");
            }

            _context.Items.Remove(item);

            _context.SaveChanges();

            return await _context.Items.ToListAsync();

        }


        //GET-BY-ID
        public async Task<Items> GetItemById(Guid id)
        {

            var item = await _context.Items.FirstOrDefaultAsync(c => c.Id == id);

            if (item is null || item.Id != id)
            {
                throw new Exception("ID NOT FOUND");
            }

            return item;
        }


        //GET-ALL
        public async Task<List<Items>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        //UPDATE
        public async Task<List<Items>> UpdateItem(Items updateitem)
        {

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == updateitem.Id);

            if (updateitem is null)
            {
                throw new Exception("ID NOT FOUND!");
            }

            item.Name = updateitem.Name;
            item.prize = updateitem.prize;

            await _context.SaveChangesAsync();

            var items = await _context.Items.ToListAsync();
            return items;

        }
    }
}
