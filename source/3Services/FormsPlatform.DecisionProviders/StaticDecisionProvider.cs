using FormsPlatform.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Decisions;

namespace FormsPlatform.DecisionProviders
{
    public class StaticDecisionProvider : IDecisionProvider
    {
        public NextState Next(int formsetId, int formId, KeyValuePair<string, string> formValues)
        {
            return new NextState() { FormsetId = formsetId, FormId = formId + 1 };
        }

        public NextState Previous(int formsetId, int formId)
        {
            return new NextState() { FormsetId = formsetId, FormId = formId - 1 };
        }
    }
}
