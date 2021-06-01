using _TestBlazor_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _TestBlazor_.Service
{
    public class ItemService
    {

        protected readonly ApplicationDbContext _dbcontext;
        public ItemService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }
        public List<Item> displayItem()
        {
            return _dbcontext.items.ToList();
        }
        public void saveChange(List<Item> it)
        {
            foreach (var context in _dbcontext.items)
            {
                _dbcontext.items.Remove(context);
            }
            _dbcontext.SaveChanges();
            foreach (var item in it)
            {
                _dbcontext.items.Add(item);
            }
            _dbcontext.SaveChanges();
        }
        public void deleteChanges(Item item)
        {
            _dbcontext.items.Remove(item);
            _dbcontext.SaveChanges();
        }
    }
}
