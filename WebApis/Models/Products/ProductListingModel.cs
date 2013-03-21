using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApis.Models.Products
{
    public class ProductListingModel
    {
        public List<ProductsModel> Products = new List<ProductsModel>();
        public string CategoryName { get; set; }
    }
}