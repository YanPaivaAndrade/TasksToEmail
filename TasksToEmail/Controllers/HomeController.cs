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
        private readonly SpamEmailService _spamEmailService = new SpamEmailService();
       
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
        public ActionResult Email(string arg)
        {
            var metodo = _TarefaService.GetType().GetMethod("FindAll" + arg);
            var list =(List<Tarefa>) metodo.Invoke(_TarefaService, null);
            return View(CorpoEmail(list, arg));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email(Email e, string arg)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var metodo = _spamEmailService.GetType().GetMethod("SendEmail" + arg);
            metodo.Invoke(_spamEmailService, new object[] { e });
            return RedirectToAction(nameof(Alerta));
        }

        public ActionResult Alerta()
        {
            return View();
        }

        private Email CorpoEmail(List<Tarefa> list, string arg)
        {
            Email e = new Email();
            e.Assunto = "Tarefas " + arg + " ordenadas por Priority ";
            e.CorpoDoEmail = SpamEmailService.GetHtml();
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();
            }
            e.CorpoDoEmail += "</tr></table></table></tr></table>";
            return e;
        }
    }
}