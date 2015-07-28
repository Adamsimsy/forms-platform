using FormsPlatform.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsPlatform.DomainModels.Decisions;
using FormsPlatform.DecisionProviders.Model;

namespace FormsPlatform.DecisionProviders
{
    public class StaticDecisionProvider : IDecisionProvider
    {
        private List<Formset> _formsets;

        public StaticDecisionProvider()
        {
            _formsets = new List<Formset>();

            _formsets.Add(new Formset()
            {
                FormsetId = 1,
                Forms = {
                    new Form() { FormId = 1, Previous = 1, Next = 2 },
                    new Form() { FormId = 2, Previous = 1, Next = 3 },
                    new Form() { FormId = 3, Previous = 2, Next = 3 }
                }
            });

            _formsets.Add(new Formset()
            {
                FormsetId = 2,
                Forms = {
                    new Form() { FormId = 4, Previous = 4, Next = 5 },
                    new Form() { FormId = 5, Previous = 4, Next = 6 },
                    new Form() { FormId = 6, Previous = 5, Next = 6 }
                }
            });

            _formsets.Add(new Formset()
            {
                FormsetId = 3,
                Forms = {
                    new Form() { FormId = 7, Previous = 7, Next = 8 },
                    new Form() { FormId = 8, Previous = 7, Next = 9 },
                    new Form() { FormId = 9, Previous = 8, Next = 9 }
                }
            });
        }

        public NextState Next(int formsetId, int formId, List<KeyValuePair<string, string>> formValues)
        {
            var form = FindForm(formsetId, formId);

            int nextFormId = form.Next;

            if (form.FieldRules.Any())
            {
                var matchingFieldRule = form.FieldRules.Where(x => formValues.Any(y => x.FieldToMatch == y.Key && x.ValueToMatch == y.Value)).FirstOrDefault();

                if (matchingFieldRule != null)
                {
                    nextFormId = matchingFieldRule.NextForm;
                }
            }

            return new NextState() { FormsetId = formsetId, FormId = nextFormId };
        }

        public NextState Previous(int formsetId, int formId)
        {
            var form = FindForm(formsetId, formId);

            return new NextState() { FormsetId = formsetId, FormId = form.Previous };
        }

        private Form FindForm(int formsetId, int formId)
        {
            var formset = _formsets.Where(x => x.FormsetId == formsetId).FirstOrDefault();

            return formset.Forms.Where(x => x.FormId == formId).FirstOrDefault();
        }
    }
}
