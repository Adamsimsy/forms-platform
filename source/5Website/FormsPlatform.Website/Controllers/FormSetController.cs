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
    public class FormsetController : Controller
    {
        private IFormsManager _formsManager;

        public FormsetController(IFormsManager formsManager)
        {
            _formsManager = formsManager;
        }

        [HttpGet]
        public IEnumerable<Formset> GetAllFormsets()
        {
            return _formsManager.GetAllFormsets();
        }

        [HttpGet("{formsetId:int}", Name = "GetFormset")]
        public IActionResult GetFormset(int formsetId)
        {
            var item = _formsManager.GetFormset(formsetId);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item.Forms.First());
        }

        [HttpGet("{formsetId:int}/{formId:int}", Name = "GetForm")]
        public IActionResult GetForm(int formsetId, int formId)
        {
            var form = _formsManager.GetForm(formsetId, formId);
            if (form == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(form);
        }

        [HttpPost]
        public void CreateTodoItem([FromBody] Formset item)
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
        public void UpdateTodoItem(int id, [FromBody] Formset item)
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
        public IActionResult DeleteItem(int id)
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
