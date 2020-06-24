using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TasksToEmail.Services;

namespace TasksToEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly TarefaService _TarefaService = new TarefaService(new Data.TasksToEmailContext());
        public HomeController()
        {

        }
        public HomeController(TarefaService service)
        {
            _TarefaService = service;
        }
        public ActionResult Index()
        {
            var list = _TarefaService.FindAll();
            return View(list);
        }

    }
}