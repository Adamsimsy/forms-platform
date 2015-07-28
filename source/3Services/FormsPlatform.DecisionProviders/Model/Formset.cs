using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DecisionProviders.Model
{
    public class Formset
    {
        public Formset()
        {
            Forms = new List<Form>();
        }

        public int FormsetId { get; set; }
        public List<Form> Forms { get; set; }
    }
}
