using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Forms;

namespace FormsPlatform.Contracts
{
    public interface IStoreProvider
    {     
        void AddFormset(Formset item);
        void DeleteFormset(int id);

        IEnumerable<Formset> GetAllFormsets();
        Formset GetFormset(int id);
        Form GetForm(int id);
        FormField GetFormField(int id);
    }
}
