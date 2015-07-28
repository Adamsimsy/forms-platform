using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DecisionProviders.Model
{
    public class FieldRule : Rule
    {
        public string FieldToMatch { get; set; }
        public string ValueToMatch { get; set; }
    }
}
