using pertemuan2C_Lanjutan.Models.DB;
using pertemuan2C_Lanjutan.Models;

namespace pertemuan2C_Lanjutan.Services
{
    public class ItemService
    {

        private readonly ApplicationContext _context;

        public ItemService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Item> GetlistItem()
        {
            var datas = _context.Items.ToList();
            return datas;
        }

        public Item DataId(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();


                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                var itemOld = _context.Items.Where(x => x.Id == item.Id).FirstOrDefault();
                if (itemOld != null)
                {
                    itemOld.NamaItem = item.NamaItem;
                    itemOld.Qty = item.Qty;
                    itemOld.TglExpire = item.TglExpire;
                    itemOld.Supplier = item.Supplier;
                    itemOld.AlamatSupplier = item.AlamatSupplier;

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

        public bool DeleteItem(int id)
        {
            try
            {
                var itemDelete = _context.Items.FirstOrDefault(x => x.Id == id);
                if (itemDelete != null)
                {
                    _context.Items.Remove(itemDelete);
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
