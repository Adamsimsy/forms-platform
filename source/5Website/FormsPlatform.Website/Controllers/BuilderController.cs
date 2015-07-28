using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FormsPlatform.DomainModels.Forms;
using FormsPlatform.Contracts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FormsPlatform.Website.Controllers
{
    [Route("api/[controller]")]
    public class BuilderController : Controller
    {
        private IFormsManager _formsManager;

        public BuilderController(IFormsManager formsManager)
        {
            _formsManager = formsManager;
        }

        [HttpPost]
        public void CreateFormset([FromBody] Formset item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _formsManager.SaveFormset(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpPut("{id:int}")]
        public void UpdateFormset(int id, [FromBody] Formset item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _formsManager.SaveFormset(id, item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFormset(int id)
        {
            var item = _formsManager.GetAllFormsets().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _formsManager.DeleteFormset(id);
            //_items.Remove(item);
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
