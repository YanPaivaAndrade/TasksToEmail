using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TasksToEmail.Models;
using TasksToEmail.Services;

namespace TasksToEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly TarefaService _TarefaService = new TarefaService();
       
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
        public ActionResult Email()
        {
            var list = _TarefaService.FindAllPendente();
            Email e = new Email();
            e.Assunto = "Tarefas  pendentes ordenadas por Priority ";
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();
                e.CorpoDoEmail += "\n\n";
            }
            return View(e);
        }

    }
}