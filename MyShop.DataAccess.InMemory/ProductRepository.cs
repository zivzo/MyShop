using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product p)
        {
            Product product = products.Find(x => x.Id == p.Id);
            if (product != null)
            {
                product = p;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
        public Product Find(string id) {
            Product product = products.Find(x => x.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
       public IQueryable<Product> Collection()
        {
                return products.AsQueryable();  
        }
        public void Delete(string id)
        {
             Product pro = products.Find(x => x.Id == id);
            if (pro != null)
            {
                products.Remove(pro);
            }
            else
            {
                throw new Exception("no product found");
            }
        }
    }
}
