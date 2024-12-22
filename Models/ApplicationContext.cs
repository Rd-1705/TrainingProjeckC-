using Microsoft.EntityFrameworkCore;
using pertemuan2C_Lanjutan.Models.DB;

namespace pertemuan2C_Lanjutan.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options) 
        {
        }
       
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
