using FormsPlatform.DomainModels.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.Contracts
{
    public interface ISessionProvider
    {
        Form GetForm(int formsetId, int formId);
        void StoreForm(int formsetId, Form form);
    }
}
