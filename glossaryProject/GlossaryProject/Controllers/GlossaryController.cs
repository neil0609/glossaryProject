using GlossaryProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlossaryProject.Controllers
{
    [RoutePrefix("")]
    public class GlossaryController : Controller
    {
        [Route("Add")]
        [Route("{id:int}")]
        public ActionResult Index(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }

        [Route]
        public ActionResult List()
        {
            return View();
        }
    }
}