using GestionareProduse.Models;
using Microsoft.EntityFrameworkCore;



namespace GestionareProduse.Data
{
    public class GestionareProduseContext:DbContext 
    {
        public GestionareProduseContext(DbContextOptions<GestionareProduseContext> options) 
            : base(options){ }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Branduri { get; set; }
        public virtual DbSet<Category> Categorii { get; set; }
        public virtual DbSet<Warehouse> Depozite { get; set; }
    }
}
