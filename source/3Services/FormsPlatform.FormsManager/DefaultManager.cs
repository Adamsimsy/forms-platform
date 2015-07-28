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
        private IDecisionProvider _decisionProvider;

        public DefaultManager(IDecisionProvider decisionProvider)
        {
            _decisionProvider = decisionProvider;
        }

        public NextState Next(int formsetId, Form form)
        {
            return _decisionProvider.Next(formsetId, form.Id, new KeyValuePair<string, string>());
        }

        public NextState Previous(int formsetId, Form form)
        {
            return _decisionProvider.Previous(formsetId, form.Id);
        }
    }
}
