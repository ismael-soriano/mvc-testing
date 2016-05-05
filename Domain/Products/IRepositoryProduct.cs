using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public interface IRepositoryProduct
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        Product Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
