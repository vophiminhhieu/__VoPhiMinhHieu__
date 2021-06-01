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


        public Item NewItem = new Item();
        [Parameter]
        public EventCallback<Item> OnPosted { get; set; }
        public async Task HandleSubmit()
        {
            Add();
            await OnPosted.InvokeAsync(NewItem);
            NewItem = new Item();
        }

        protected System.Collections.Generic.IList<Item> it;
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
            if (string.IsNullOrWhiteSpace(NewItem.title) == false && string.IsNullOrWhiteSpace(NewItem.note) == false)
            {
                it.Add(new Item() { title = NewItem.title, note = NewItem.note, done = false, important = false });
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
