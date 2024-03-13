using Ecomm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecomm.Infrastructor
{
    public interface IProduct
    {
        IQueryable<Product> GetAll();
        Product GetProductById(int id);
        void Insert(Product product);
        void update(Product product);
        void Delete(Product product);


    }
}
