using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Stocks
    {

        public Guid Id { get; set; }

        public int Quantity { get; set; }

       // public Guid ItemsId { get; set; }

       //[ForeignKey("ItemsId")]
       // public Items? ItemsNavigation { get; set; }

        public Guid PurchaseId { get; set; }

        [ForeignKey("PurchaseId")]
        public Purchase? PurchaseNavigation { get; set; }

    }
}
