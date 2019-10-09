using Poc.Web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Poc.Web.Entities
{

    [Table("Cart")]
    public class Cart
    {
        public int CartId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Product_Image { get; set; }
    }
}
