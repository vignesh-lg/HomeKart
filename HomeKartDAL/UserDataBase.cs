
using HomeKartEntity;
using System.Data.Entity;
using System.Reflection.Emit;

namespace HomeKartDAL
{
    public class UserDataBase : DbContext
    {
        public UserDataBase() : base("MyConnection")
        {
        }
        public DbSet<User> user { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCategory> productcategory { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<CustomExceptionHandler> customExceptionHandlers { get; set; }
    }
}
