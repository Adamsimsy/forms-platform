using FormsPlatform.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Forms;

namespace FormsPlatform.SessionProviders
{
    public class StaticSessionProvider : ISessionProvider
    {
        private Dictionary<int, List<Form>> session;

        public StaticSessionProvider()
        {
            session = new Dictionary<int, List<Form>>();
        }

        public Form GetForm(int formsetId, int formId)
        {
            if (!session.ContainsKey(formsetId))
            {
                return null;
            }

            var form = session[formsetId].Where(x => x.Id == formId).FirstOrDefault();

            if (form != null)
            {
                return form;
            }

            return null;
        }

        public void StoreForm(int formsetId, Form form)
        {
            if (!session.ContainsKey(formsetId))
            {
                session.Add(formsetId, new List<Form>() { form });
            }
            else
            {
                var forms = session[formsetId].Where(x => x.Id == form.Id).ToList();

                forms.RemoveAll(x => x.Id == form.Id);

                forms.Add(form);

                session[formsetId] = forms;
            }
        }
    }
}
