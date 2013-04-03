using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApis.Models
{
    public class Order
    {
        public Guid CartId { get; set; }
        public Decimal OrderTotal { get; set; }
        public int ProductId { get; set; }
    }
}