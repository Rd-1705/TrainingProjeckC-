using System.ComponentModel.DataAnnotations;

namespace pertemuan2C_Lanjutan.Models.DB
{
    public class Customer
    {
        //    [Key]
        //    public int id_customer { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }
    }
}
