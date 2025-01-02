using System.ComponentModel.DataAnnotations;

namespace pertemuan2C_Lanjutan.Models.DB
{
    public class Item
    {
        [Key]
        public int Id { get; set; } // ID, primary key, auto-increment

        [Required]
        [MaxLength(100)]
        public string NamaItem { get; set; } // Nama item (required, max length 100)

        [Required]
        public int Qty { get; set; } // Quantity (required)

        [Required]
        public DateTime TglExpire { get; set; } // Tanggal expire (required)

        [Required]
        [MaxLength(100)]
        public string Supplier { get; set; } // Supplier (required, max length 100)

        [MaxLength(100)]
        public string AlamatSupplier { get; set; } // Alamat supplier (nullable, max length 100)
    }
}
