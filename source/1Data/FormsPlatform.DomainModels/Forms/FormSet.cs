using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsPlatform.DomainModels.Forms
{
    public class FormSet
    {
        public FormSet()
        {
            Forms = new List<Form>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Form> Forms { get; set; }
    }
}
