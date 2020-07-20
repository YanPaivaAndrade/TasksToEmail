using System;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using TasksToEmail.Models;
using TasksToEmail.Models.Interface;
using TasksToEmail.Models.ViewModel;
using TasksToEmail.Services;
using TasksToEmail.Services.Exceções;

namespace TasksToEmail.Controllers
{
    public class TaskController : Controller
    {
        private readonly TarefaService _TarefaService = new TarefaService();

        public TaskController()
        {
        }
        public ActionResult Editar(int? IdTarefa)
        {
            
            if (IdTarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var tarefa = _TarefaService.FindById(IdTarefa.Value);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            TarefaViewModel viewModel = new TarefaViewModel();
            viewModel.Tarefa = tarefa;
            
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int idTarefa, Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TarefaViewModel();
                viewModel.Tarefa = tarefa;
                return View(viewModel);
            }
            if (idTarefa != tarefa.IdTarefa)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não corresponde ao vendedor" });
            }
            try
            {
                var statusAntigo = _TarefaService.FindById(idTarefa).Status;
                if (!statusAntigo.Equals(tarefa.Status))
                {
                    string nomeClasse = "TasksToEmail.Models.Tarefa"+statusAntigo;
                    string nomeMetodo = "SetTarefa" + tarefa.Status;
                    var typeObj = Type.GetType(nomeClasse);
                    var obj = Activator.CreateInstance(typeObj);
                    tarefa.SetStatus((TarefaStatus)obj);
                    var metodo = tarefa.GetType().GetMethod(nomeMetodo);
                    metodo.Invoke(tarefa, null);
                }
                _TarefaService.Update(tarefa);
                return RedirectToAction(nameof(HomeController.Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { menssagem = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { menssagem = e.Message });
            }
        }

        public ActionResult NovaTarefa()
        {
            TarefaViewModel viewModel = new TarefaViewModel();
            viewModel.Tarefa = new Tarefa();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaTarefa(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                TarefaViewModel viewModel = new TarefaViewModel();
                viewModel.Tarefa = tarefa;
                return View(viewModel);
            }
            _TarefaService.Insert(tarefa);
            return RedirectToAction("../Home/"+nameof(HomeController.Index));
        }

        public ActionResult Deletar(int? idTarefa)
        {
            if (idTarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var tarefa = _TarefaService.FindById(idTarefa.Value);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            return View(tarefa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int idTarefa)
        {
            try
            {
                _TarefaService.Remove(idTarefa);
                return RedirectToAction("../Home/" + nameof(HomeController.Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { menssagem = e.Message });
            }
        }
        public ActionResult ViewTarefa(int? idTarefa)
        {
            if (idTarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var tarefa = _TarefaService.FindById(idTarefa.Value);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            return View(tarefa);
        }
        public ActionResult Error(string menssagem)
        {
            var viewModel = new ErrorViewModel
            {
                Menssagem = menssagem,                
            };
            return View(viewModel);
        }
    }
}