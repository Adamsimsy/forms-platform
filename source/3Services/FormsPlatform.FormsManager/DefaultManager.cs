using FormsPlatform.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Decisions;
using FormsPlatform.DomainModels.Forms;

namespace FormsPlatform.FormsManager
{
    public class DefaultManager : IFormsManager
    {
        public NextState Next(int formsetId, Form form)
        {
            return new NextState() { FormsetId = formsetId, FormId = form.Id + 1 };
        }

        public NextState Previous(int formsetId, Form form)
        {
            return new NextState() { FormsetId = formsetId, FormId = form.Id - 1 };
        }
    }
}
