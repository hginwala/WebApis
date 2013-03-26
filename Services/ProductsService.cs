


using System.Collections.Generic;
using System.Linq;


using WebApis.Models;

namespace WebApis.Services
{

    public class ProductsService : Repository
    {
        public static PMEntities Context = new PMEntities();
        public static List<ProductsModel> GetProductsByCategory(int categoryId)
        {
           
            return Context.Products.Where(x => x.Category == categoryId).Select(Map).ToList();
        }

        public static ProductsModel Map(Product p)
        {
            return new ProductsModel
                       {
                           Id = p.ProductId,
                           Name = p.Name,
                           Description = p.Description,
                           CategoryId = p.Category.Value,
                           Price = p.Price.Value,
                           Stock = p.Stock.Value,
                           Category = p.Category1.Name,
                           ImageUrl = p.ImageUrl
                       };
        }

        public static ProductsModel GetProductById(int id)
        {
            return Context.Products.Where(x => x.ProductId == id).Select(Map).SingleOrDefault();
        }
    }
}