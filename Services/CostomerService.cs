using pertemuan2C_Lanjutan.Models;
using pertemuan2C_Lanjutan.Models.DB;

namespace pertemuan2C_Lanjutan.Services
{
    public class CostomerService
    {
        private readonly ApplicationContext _context;

        public CostomerService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Customer> GetlistCustomer() 
        { 
            var datas = _context.Customers.ToList();
            return datas;
        }
    }
}
