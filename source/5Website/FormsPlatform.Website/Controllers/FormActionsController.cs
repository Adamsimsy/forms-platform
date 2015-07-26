using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FormsPlatform.DomainModels.Forms;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FormsPlatform.Website.Controllers
{
    [Route("api/[controller]")]
    public class FormActionsController : Controller
    {
        [HttpPost("next", Name = "Next")]
        public void Next([FromBody] Form item)
        {
        }

        [HttpPost("previous", Name = "Previous")]
        public void Previous([FromBody] Form item)
        {
        }
    }
}
