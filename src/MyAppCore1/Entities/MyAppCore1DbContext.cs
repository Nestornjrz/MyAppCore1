using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAppCore1.Entities {
    public class MyAppCore1DbContext:IdentityDbContext<User>
    {
        public MyAppCore1DbContext(DbContextOptions opciones):base(opciones) {

        }
        public DbSet<Restaurante> Restaurantes { get; set; }

    }
}
