using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.Contracts;
using FormsPlatform.DomainModels;
using FormsPlatform.DomainModels.Forms;

namespace FormsPlatform.StoreProviders
{
    public class StaticStoreProvider : IStoreProvider
    {
        readonly List<Formset> _items = new List<Formset>();

        public StaticStoreProvider()
        {
            _items = new List<Formset>();

            _items.Add(new Formset()
            {
                Id = 1,
                Title = "My first form",
                Forms = {
                    new Form() { Id = 1, Title = "My first form - step 1",
                        Fields = {
                            new InputFormField() {  Id = 1, Label = "Step 1 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 2, Label = "Step 1 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 3, Label = "Step 1 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 2, Title = "My first form - step 2",
                        Fields = {
                            new InputFormField() {  Id = 1, Label = "Step 2 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 2, Label = "Step 2 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 3, Label = "Step 2 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 3, Title = "My first form - step 3",
                        Fields = {
                            new InputFormField() {  Id = 1, Label = "Step 3 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 2, Label = "Step 3 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 3, Label = "Step 3 input field 3", Value = "Default value for field 3" },
                        }
                    }
                }
            });
        }

        public void AddFormset(Formset item)
        {
            item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(item);
        }

        public void DeleteFormset(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            _items.Remove(item);
        }

        public IEnumerable<Formset> GetAllFormsets()
        {
            return _items;
        }

        public Form GetForm(int id)
        {
            throw new NotImplementedException();
        }

        public FormField GetFormField(int id)
        {
            throw new NotImplementedException();
        }

        public Formset GetFormset(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
}
