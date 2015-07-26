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
        public IActionResult Next([FromBody] Form item)
        {
            return new ObjectResult(new State() { FormsetId = 1, FormId = item.Id + 1 });
        }

        [HttpPost("previous", Name = "Previous")]
        public IActionResult Previous([FromBody] Form item)
        {
            return new ObjectResult(new State() { FormsetId = 1, FormId = item.Id - 1 });
        }
    }

    public class State
    {
        public int FormsetId { get; set; }
        public int FormId { get; set; }
    }
}
