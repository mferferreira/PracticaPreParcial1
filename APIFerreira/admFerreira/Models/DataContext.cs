using System.Data.Entity;

namespace admFerreira.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admFerreira.Models.Ferreira> Ferreiras { get; set; }
    }
}