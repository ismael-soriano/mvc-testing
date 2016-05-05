using Domain.Products;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class UsersContext : DbContext, IUnitOfWork, IDbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {

        }

        //Esto no vale para nada, excepto para la configuracion de E.F.
        //o para utilizarlo como Repository y tendrías una fuerte dependencia de E.F.
        //DbSet === Repositorio implementado
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Product> Products { get; set; }

        public IDbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
       
}
