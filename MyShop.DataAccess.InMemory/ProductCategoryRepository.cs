using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory p)
        {
            ProductCategory product = productCategories.Find(x => x.Id == p.Id);
            if (product != null)
            {
                product = p;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
        public ProductCategory Find(string id) {
            ProductCategory product = productCategories.Find(x => x.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
       public IQueryable<ProductCategory> Collection()
        {
                return productCategories.AsQueryable();  
        }
        public void Delete(string id)
        {
             ProductCategory pro = productCategories.Find(x => x.Id == id);
            if (pro != null)
            {
                productCategories.Remove(pro);
            }
            else
            {
                throw new Exception("no product found");
            }
        }
    }
}
