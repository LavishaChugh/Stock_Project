namespace Project.Services.Purchases
{
    public interface IPurchaseService
    {
        public Task<List<Purchase>> GetAll();

        public Task<Purchase> GetById(Guid id);

        public Task<List<Purchase>> Delete(Guid id);

        public Task<List<Purchase>> Add(Purchase item);

        public Task<List<Purchase>> Update(Purchase updateitem);
    }
}
