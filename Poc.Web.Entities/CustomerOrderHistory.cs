using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.Web.Entities
{
    [Table("CustomerOrderHistory")]
    public class CustomerOrderHistory
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public virtual Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string DeliveredAddress { get; set; }
        public decimal TotalPurchase { get; set; }
    }
}