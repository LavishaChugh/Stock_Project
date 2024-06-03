using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Sales
    {

        public Guid Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int TotalCost { get; set; }

        public Guid StockId { get; set; }

        [ForeignKey("StockId")]
        public Stocks? StocksNavigation { get; set; }

    }
}
