using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.Contracts;
using FormsPlatform.DomainModels;

namespace FormsPlatform.StoreProviders
{
    public class StaticStoreProvider : IStoreProvider
    {
        readonly List<TodoItem> _items = new List<TodoItem>();

        public StaticStoreProvider()
        {
            _items.Add(new TodoItem { Id = 1, Title = "First Item" });
        }

        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            _items.Remove(item);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _items;
        }

        public TodoItem GetItem(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void PutItem(TodoItem item)
        {
            item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(item);
        }
    }
}
