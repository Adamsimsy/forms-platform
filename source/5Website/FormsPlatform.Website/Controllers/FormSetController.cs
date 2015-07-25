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
        private IStoreProvider _iStoreProvider;

        public FormsetController(IStoreProvider iStoreProvider)
        {
            _iStoreProvider = iStoreProvider;
        }

        [HttpGet]
        public IEnumerable<Formset> GetAll()
        {
            return _iStoreProvider.GetAllFormsets();
        }

        [HttpGet("{formsetId:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int formsetId)
        {
            var item = _iStoreProvider.GetFormset(formsetId);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item.Forms.First());
        }

        [HttpGet("{formsetId:int}/{formId:int}", Name = "GetByIdAndFormIdRoute")]
        public IActionResult GetById(int formsetId, int formId)
        {
            var item = _iStoreProvider.GetFormset(formsetId);
            if (item == null)
            {
                return HttpNotFound();
            }

            var form = item.Forms.Where(x => x.Id == formId).First();
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
                _iStoreProvider.SaveFormset(item);

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
                _iStoreProvider.SaveFormset(id, item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _iStoreProvider.GetAllFormsets().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _iStoreProvider.DeleteFormset(id);
            //_items.Remove(item);
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
