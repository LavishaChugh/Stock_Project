using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public int TotalCost { get; set; }

        public Guid ItemsId { get; set; }

        [ForeignKey("ItemsId")]
        public Items? ItemsNavigation { get; set; }
    }
}
