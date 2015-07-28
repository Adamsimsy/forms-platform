using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DecisionProviders.Model
{
    abstract public class Rule
    {
        public int NextForm { get; set; }
    }
}
