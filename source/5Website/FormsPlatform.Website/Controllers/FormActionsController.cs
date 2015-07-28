using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FormsPlatform.DomainModels.Forms;
using FormsPlatform.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FormsPlatform.Website.Controllers
{
    [Route("api/[controller]")]
    public class FormActionsController : Controller
    {
        private IFormsManager _formsManager;

        public FormActionsController(IFormsManager formsManager)
        {
            _formsManager = formsManager;
        }

        [HttpPost("{formsetId:int}/next", Name = "Next")]
        public IActionResult Next([FromBody] Form form, int formsetId)
        {
            return new ObjectResult(_formsManager.Next(formsetId, form));
        }

        [HttpPost("{formsetId:int}/previous", Name = "Previous")]
        public IActionResult Previous([FromBody] Form form, int formsetId)
        {
            return new ObjectResult(_formsManager.Previous(formsetId, form));
        }
    }
}
