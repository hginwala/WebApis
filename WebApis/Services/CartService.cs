using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApis.Models;

namespace WebApis.Services
{
    public class CartService : Repository
    {
        public PMEntities context = new PMEntities();

        Guid ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public CartService GetCart(HttpContextBase context)
        {
            CartService cart = new CartService();
            cart.ShoppingCartId = Guid.Parse(cart.GetCartId(context));
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                Guid tempCartId = Guid.NewGuid();
                context.Session[CartSessionKey] = tempCartId.ToString();
            }
            return context.Session[CartSessionKey].ToString();
        }



        public List<ShoppingCart> GetCartItems()
        {

            var items = context.Carts.Where(item => item.UniqueIdentifier == ShoppingCartId)
                .Select(c => new ShoppingCart
                {
                    Quantity = c.Quantity.Value,
                    UniqueIdentifier = c.UniqueIdentifier,
                    Product = new ProductsModel
                    {
                        Id = c.Product.ProductId,
                        Name = c.Product.Name,
                        ImageUrl = c.Product.ImageUrl,
                        Price = c.Product.Price.Value
                    }                    
                }).ToList();
            return items;
        }

        public void AddToCart(int pid)
        {
            // Get the matching cart and album instances
            var cartItem = context.Carts.SingleOrDefault(c => c.UniqueIdentifier == ShoppingCartId
                && c.ProductId == pid);

            if (cartItem == null)
            {

                cartItem = new Cart
                {
                    ProductId = pid,
                    UniqueIdentifier = ShoppingCartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                context.Carts.AddObject(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Quantity++;
            }

            // Save changes
            context.SaveChanges();
        }
    }
}