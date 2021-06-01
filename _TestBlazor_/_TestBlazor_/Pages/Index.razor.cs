using _TestBlazor_.Data;
using _TestBlazor_.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _TestBlazor_.Pages
{
    public class IndexBase: OwningComponentBase<ItemService>
    {
        protected System.Collections.Generic.IList<Item> it;
        protected string currentTitle { get; set; }
        protected string currentNote { get; set; }
        protected void Save()
        {
            Service.saveChange(it.ToList());
        }
        protected override void OnInitialized()
        {
            it = Service.displayItem();
        }
        protected void changeImportant(Item item)
        {
            item.important = !item.important;
        }
        protected void Add()
        {
            if (string.IsNullOrWhiteSpace(currentTitle) == false && string.IsNullOrWhiteSpace(currentNote) == false)
            {
                it.Add(new Item() { title = currentTitle, note = currentNote, done = false, important = false });
            }
        }
        protected void AddIfEnter(KeyboardEventArgs eventArgs)
        {
            if (eventArgs.Key == "Enter")
            {
                Add();
            }
        }
        protected void delete(Item item)
        {
            it.Remove(item);
            Service.deleteChanges(item);
        }
    }
}
