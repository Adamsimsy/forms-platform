using FormsPlatform.DomainModels.Decisions;
using FormsPlatform.DomainModels.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.Contracts
{
    public interface IFormsManager
    {
        NextState Next(int formsetId, Form form);

        NextState Previous(int formsetId, Form form);
    }
}
