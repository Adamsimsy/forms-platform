using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels;

namespace FormsPlatform.Contracts
{
    public interface IStoreProvider
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem GetItem(int id);
        void PutItem(TodoItem item);
        void DeleteItem(int id);
    }
}
