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

        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int id)
        {
            //var item = _items.FirstOrDefault(x => x.Id == id);
            var item = _iStoreProvider.GetFormset(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
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
                _iStoreProvider.AddFormset(item);

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
