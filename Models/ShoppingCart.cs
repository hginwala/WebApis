using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApis.Models
{
    public class ShoppingCart
    {
        public int Quantity { get; set; }
        public ProductsModel Product { get; set; }
        public decimal CartTotal { get; set; }
        public Guid UniqueIdentifier { get; set; }

    }

    public class ShoppingCartVM
    {
        public List<ShoppingCart> cartitems = new List<ShoppingCart>();
        public Guid UniqueIdentifier { get; set; }
        public decimal CartTotal
        {
            get { return this.cartitems.Select(c => c.Quantity * c.Product.Price).Sum(); }
        }
    }
}