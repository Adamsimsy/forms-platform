using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DomainModels.Forms
{
    public class Form
    {
        public Form()
        {
            Fields = new List<FormField>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<FormField> Fields { get; set; }
    }
}
