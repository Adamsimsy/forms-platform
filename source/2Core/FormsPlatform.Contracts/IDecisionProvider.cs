using FormsPlatform.DomainModels.Decisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.Contracts
{
    public interface IDecisionProvider
    {
        NextState Next(int formsetId, int formId, List<KeyValuePair<string, string>> formValues);
        NextState Previous(int formsetId, int formId);
    }
}
