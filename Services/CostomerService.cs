using Microsoft.EntityFrameworkCore.Update.Internal;
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

        public Customer DataId(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateCustomer (Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

            
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
                if (customerOld != null)
                {
                    customerOld.Name = customer.Name;
                    customerOld.Address = customer.Address;
                    customerOld.City = customer.City;
                    customerOld.PhoneNumber = customer.PhoneNumber;

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public bool DeleteCutomer (int id)
        {
            try
            {
                var customerDelete = _context.Customers.FirstOrDefault(x => x.Id == id);
                if (customerDelete != null) 
                {
                    _context.Customers.Remove(customerDelete);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
