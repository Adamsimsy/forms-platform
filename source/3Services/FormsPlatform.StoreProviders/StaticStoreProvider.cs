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
                Title = "My first formset",
                Forms = {
                    new Form() { Id = 1, Title = "My first formset - step 1",
                        Fields = {
                            new InputFormField() {  Id = 1, Label = "Step 1 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 2, Label = "Step 1 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 3, Label = "Step 1 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 2, Title = "My first formset - step 2",
                        Fields = {
                            new InputFormField() {  Id = 4, Label = "Step 2 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 5, Label = "Step 2 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 6, Label = "Step 2 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 3, Title = "My first formset - step 3",
                        Fields = {
                            new InputFormField() {  Id = 7, Label = "Step 3 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 8, Label = "Step 3 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 9, Label = "Step 3 input field 3", Value = "Default value for field 3" },
                        }
                    }
                }
            });
            _items.Add(new Formset()
            {
                Id = 2,
                Title = "My second formset",
                Forms = {
                    new Form() { Id = 4, Title = "My second formset - step 1",
                        Fields = {
                            new InputFormField() {  Id = 10, Label = "Step 1 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 11, Label = "Step 1 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 12, Label = "Step 1 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 5, Title = "My second formset - step 2",
                        Fields = {
                            new InputFormField() {  Id = 13, Label = "Step 2 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 14, Label = "Step 2 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 15, Label = "Step 2 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 6, Title = "My second formset - step 3",
                        Fields = {
                            new InputFormField() {  Id = 16, Label = "Step 3 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 17, Label = "Step 3 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 18, Label = "Step 3 input field 3", Value = "Default value for field 3" },
                        }
                    }
                }
            });
            _items.Add(new Formset()
            {
                Id = 3,
                Title = "My third formset",
                Forms = {
                    new Form() { Id = 7, Title = "My third formset - step 1",
                        Fields = {
                            new InputFormField() {  Id = 19, Label = "Step 1 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 20, Label = "Step 1 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 21, Label = "Step 1 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 8, Title = "My third formset - step 2",
                        Fields = {
                            new InputFormField() {  Id = 22, Label = "Step 2 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 23, Label = "Step 2 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 24, Label = "Step 2 input field 3", Value = "Default value for field 3" },
                        }
                    },
                    new Form() { Id = 9, Title = "My third formset - step 3",
                        Fields = {
                            new InputFormField() {  Id = 25, Label = "Step 3 input field 1", Value = "Default value for field 1" },
                            new InputFormField() {  Id = 26, Label = "Step 3 input field 2", Value = "Default value for field 2" },
                            new InputFormField() {  Id = 27, Label = "Step 3 input field 3", Value = "Default value for field 3" },
                        }
                    }
                }
            });
        }

        public void SaveFormset(Formset formset)
        {
            formset.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(formset);
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

        public void SaveFormset(int id, Formset formset)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _items.Remove(item);
                _items.Add(formset);
            }
        }
    }
}
