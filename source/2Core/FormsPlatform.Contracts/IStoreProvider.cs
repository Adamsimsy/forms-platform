using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Forms;

namespace FormsPlatform.Contracts
{
    public interface IStoreProvider
    {     
        void AddFormSet(FormSet item);
        void DeleteFormSet(int id);

        IEnumerable<FormSet> GetAllFormSets();
        FormSet GetFormSet(int id);
        Form GetForm(int id);
        FormField GetFormField(int id);
    }
}
