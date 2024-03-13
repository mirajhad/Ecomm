using Ecomm.Data;
using Ecomm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecomm.Infrastructor
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Product product)
        {
           _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
          return _context.Products;
        }

        public Product GetProductById(int id)
        {
           return 
                _context.Products.FirstOrDefault(x=>x.Id==id);
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
