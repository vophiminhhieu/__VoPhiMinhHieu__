using _TestBlazor_.Data;
using _TestBlazor_.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _TestBlazor_.Pages
{
    public class ImportantBase: OwningComponentBase<ItemService>
    {
        protected System.Collections.Generic.IList<Item> itemInList;
        protected List<Item> it = new List<Item>();
        protected override void OnInitialized()
        {
            itemInList = Service.displayItem();
            foreach(var item in itemInList)
            {
                if (item.important == true)
                {
                    it.Add(item);
                }
            }
        }
    }
}
