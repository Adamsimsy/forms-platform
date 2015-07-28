using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DecisionProviders.Model
{
    public class Form
    {
        public Form()
        {
            FieldRules = new List<FieldRule>();
        }

        public int FormId { get; set; }
        public List<FieldRule> FieldRules { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
