using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)=>ProductDAO.Instance.AddNew(product);

        public void DeleteProduct(Product product)=>ProductDAO.Instance.DeleteProduct(product);

        public Product GetProductById(int id) => ProductDAO.Instance.GetProductById(id);

        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)=>ProductDAO.Instance.UpdateProduct(product);
        
    }
}
