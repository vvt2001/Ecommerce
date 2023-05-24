using EcommerceData;
using EcommerceData.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Services
{
    public interface IProductServices
    {
        Product Create(Product product);
        void Delete(int id);
        Product Get(int id);
        Product Edit(Product product);
        List<Product> Search(ProductSearching productSearching);
        Cart AddToCart(int UserID, int ProductID, int ProductQuantity);
        Cart RemoveFromCart(int UserID, int ProductID);
    }
    public class ProductServices : IProductServices
    {
        private readonly DatabaseContext _context;
        public ProductServices(DatabaseContext context)
        {
            _context = context;
        }
        public Product Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Where(x => x.ID == id).Include(x=>x.Carts).FirstOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Edit(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }

        public Product Get(int id)
        {
            var product = _context.Products.Where(product => product.ID == id).FirstOrDefault();
            return product;
        }

        public List<Product> Search(ProductSearching productSearching)
        {
            List<Product> searchResult = new List<Product>();
            searchResult = _context.Products.Where(x => x.Name.Contains(productSearching.SearchString) 
                                                     && x.Price >= productSearching.LowerPrice 
                                                     && x.Price <= productSearching.UpperPrice
                                                     && x.Category == productSearching.Category)
                                            .Skip((productSearching.PageNumber - 1) * productSearching.PageSize)
                                            .Take(productSearching.PageSize)
                                            .ToList();
            return searchResult;
        }
        public Cart AddToCart(int UserID, int ProductID, int ProductQuantity)
        {
            var user = _context.Accounts.Find(UserID);
            var product = _context.Products.Find(ProductID);
            var cart = new Cart();
            if (_context.Carts.Where(x => x.AccountID == UserID && x.ProductID == ProductID).FirstOrDefault() == null) 
            {
                cart = new Cart()
                {
                    AccountID = UserID,
                    ProductID = ProductID,
                    ProductQuantity = ProductQuantity,
                   
                };
                _context.Carts.Add(cart);
            }
            else
            {
                cart = _context.Carts.Where(x => x.AccountID == UserID && x.ProductID == ProductID).FirstOrDefault();
                cart.ProductQuantity += ProductQuantity;
                _context.Entry(cart).State = EntityState.Modified;
            }

            _context.SaveChanges();

            return cart;
        }
        public Cart RemoveFromCart(int UserID, int ProductID)
        {
            var user = _context.Accounts.Find(UserID);
            var product = _context.Products.Find(ProductID);
            var cart = _context.Carts.Where(x => x.AccountID == UserID && x.ProductID == ProductID).FirstOrDefault();
            _context.Carts.Remove(cart);

            return cart;
        }
    }
}
