using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApis.Models;
using WebApis.Models.Products;
using WebApis.Services;

namespace WebApis.Controllers
{
    public class ProductsController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductsforCategory(int id)
        {
            List<ProductsModel> products = ProductsService.GetProductsByCategory(id);

            //TODO check for correct category ==> getcategorybyId()
            ProductListingModel model = new ProductListingModel()
                                            {
                                                Products = products,
                                                CategoryName = products[0].Category
                                            };

            return View("ProductListing", model);
        }

        public ActionResult GetProduct(int id)
        {
            ProductsModel prd = ProductsService.GetProductById(id);

            return View("ProductDetails", prd);

        }
    }
}
