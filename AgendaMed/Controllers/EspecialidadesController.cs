using AgendaMed.Business.Genericos;
using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class EspecialidadesController : Controller
    {
        public IActionResult Index()
        {
            var model = new EspecialidadesModel();

            foreach (var especialidade in Business.Genericos.Especialidade.Especialidades)
            {
                model.Especialidades.Add(new EspecialidadeModel()
                {
                    Nome = especialidade.Nome,
                    Codigo = especialidade.Codigo,
                });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EspecialidadeModel especialidadeModel)
        {
            var especialidadeCadastro = new Business.Genericos.Especialidade()
            {
                Nome = especialidadeModel.Nome,
                Codigo = especialidadeModel.Codigo,
            };

            Business.Genericos.Especialidade.Especialidades.Add(especialidadeCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new EspecialidadeModel();
            Business.Genericos.Especialidade especialidadeAlterar = null;

            foreach (var especialidade in Business.Genericos.Especialidade.Especialidades)
            {
                if (especialidade.Id == id)
                {
                    especialidadeAlterar = especialidade;
                    break;
                }
            }

            if (especialidadeAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Nome = especialidadeAlterar.Nome;
            model.Codigo = especialidadeAlterar.Codigo;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EspecialidadeModel especialidadeAtualizado)
        {
            var especialidadeCadastrado = Especialidade.Especialidades.FirstOrDefault(x => x.Id == especialidadeAtualizado.Id);

            if (especialidadeCadastrado == null)
            {
                throw new Exception("Esse usuário não existe!");
            }

            especialidadeCadastrado.Nome = especialidadeAtualizado.Nome;
            especialidadeCadastrado.Codigo = especialidadeAtualizado.Codigo;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            var especialidadeCadastrada = Especialidade.Especialidades.FirstOrDefault(x => x.Id == id);
            if (especialidadeCadastrada == null)
            {
                throw new Exception("Esse ser não existe!");
            }

            var model = new EspecialidadeModel();
            model.Id = id;
            model.Nome = especialidadeCadastrada.Nome;
            model.Codigo = especialidadeCadastrada.Codigo;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(EspecialidadeModel especialidadeModel)
        {
            var especialidadeCadastrada = Especialidade.Especialidades.FirstOrDefault(x => x.Id == especialidadeModel.Id);
            if (especialidadeCadastrada == null)
            {
                throw new Exception("Esse ser não existe!");
            }

            Especialidade.Especialidades.Remove(especialidadeCadastrada);

            return RedirectToAction("Index");
        }
    }
}
