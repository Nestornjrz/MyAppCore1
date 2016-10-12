using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.Entities
{
    public class MyAppCore1DbContext:DbContext
    {
        public MyAppCore1DbContext(DbContextOptions opciones):base(opciones) {

        }
        public DbSet<Restaurante> Restaurantes { get; set; }

    }
}
