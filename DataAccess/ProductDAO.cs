using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = null;
        public static ProductDAO Instance { 
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance; 
            } 
        }

        public List<Product> GetProducts()
        {
            List<Product> products = null;
            using var db = new FStoreDBAssignmentContext();
            products = db.Product.ToList();
            return products;
        }
        
        public Product GetProductById(int id)
        {
            Product product= null;
            using var db = new FStoreDBAssignmentContext();
            product = db.Product.SingleOrDefault(x => x.ProductId == id);
            return product;
        }

        public void AddNew(Product product)
        {
            using var db=new FStoreDBAssignmentContext();
            Product product1 = GetProductById(product.ProductId);
            if (product1 == null)
            {
                db.Product.Add(product);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("product already exsit");
            }
        }
        public void UpdateProduct(Product product)
        {
            using var db = new FStoreDBAssignmentContext();
            Product product1 = GetProductById(product.ProductId);
            if (product1 != null)
            {
                db.Product.Update(product);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("product already exsit");
            }
        }
        public void DeleteProduct(Product product)
        {
            using var db = new FStoreDBAssignmentContext();
            Product product1 = GetProductById(product.ProductId);
            if (product1 != null)
            {
                db.Product.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
