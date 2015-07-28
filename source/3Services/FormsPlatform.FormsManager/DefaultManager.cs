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
        private ISessionProvider _sessionProvider;
        private IStoreProvider _iStoreProvider;

        public DefaultManager(IDecisionProvider decisionProvider, ISessionProvider sessionProvider, IStoreProvider storeProvider)
        {
            _decisionProvider = decisionProvider;
            _sessionProvider = sessionProvider;
            _iStoreProvider = storeProvider;
        }

        public NextState Next(int formsetId, Form form)
        {
            var fieldValues = new List<KeyValuePair<string, string>>();

            form.Fields.ForEach(x => fieldValues.Add(new KeyValuePair<string, string>(x.Label, x.Value)));

            return _decisionProvider.Next(formsetId, form.Id, fieldValues);
        }

        public NextState Previous(int formsetId, Form form)
        {
            return _decisionProvider.Previous(formsetId, form.Id);
        }

        public IEnumerable<Formset> GetAllFormsets()
        {
            return _iStoreProvider.GetAllFormsets();
        }

        public Formset GetFormset(int formsetId)
        {
            return _iStoreProvider.GetFormset(formsetId);
        }

        public void SaveFormset(Formset item)
        {
            _iStoreProvider.SaveFormset(item);
        }

        public void SaveFormset(int id, Formset item)
        {
            _iStoreProvider.SaveFormset(id, item);
        }

        public void DeleteFormset(int id)
        {
            _iStoreProvider.DeleteFormset(id);
        }
    }
}
