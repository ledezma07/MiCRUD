using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Context
{
    public class MiContext : DbContext
    {        
        public MiContext(DbContextOptions options ) : base (options)
        {
        }  
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
