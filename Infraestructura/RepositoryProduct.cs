using Domain.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    
    public class RepositoryProduct: RepositoryBase<Product>, IRepositoryProduct
    {
       
        public RepositoryProduct(IDbContext context)
            :base(context)
        {
            
        }
        public Product Get(int id)
        {
            return Entity.Where(c=>c.Id==id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return Entity.Select(c => c);
        }

        public Product Add(Product product)
        {
            Entity.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            Modify(product);
        }

        public void Delete(Product product)
        {
           Entity.Remove(product);
        }
    }
}
