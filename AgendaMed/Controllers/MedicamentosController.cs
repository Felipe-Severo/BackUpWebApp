using AgendaMed.Business.Genericos;
using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            var model = new MedicamentosModel();

            foreach (var medicamento in Business.Genericos.Medicamento.Medicamentos)
            {
                model.Medicamentos.Add(new MedicamentoModel()
                {
                    Nome = medicamento.Nome,
                    Descricao = medicamento.Descricao,
                    Dosagem = medicamento.Descricao,
                });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicamentoModel medicamentoModel)
        {
            var medicamentoCadastro = new Business.Genericos.Medicamento()
            {
                Nome = medicamentoModel.Nome,
                Descricao = medicamentoModel.Descricao,
            };

            Business.Genericos.Medicamento.Medicamentos.Add(medicamentoCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new MedicamentoModel();
            Business.Genericos.Medicamento medicamentoAlterar = null;

            foreach (var medicamento in Business.Genericos.Medicamento.Medicamentos)
            {
                if (medicamento.Id == id)
                {
                    medicamentoAlterar = medicamento;
                    break;
                }
            }

            if (medicamentoAlterar == null)
            {
                throw new Exception("Não existe medicamento cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Nome = medicamentoAlterar.Nome;
            model.Descricao = medicamentoAlterar.Descricao;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(MedicamentoModel medicamentoAtualizado)
        {
            var medicamentoCadastrado = Medicamento.Medicamentos.FirstOrDefault(x => x.Id == medicamentoAtualizado.Id);

            if (medicamentoCadastrado == null)
            {
                throw new Exception("Esse meidicamento não existe!");
            }

            medicamentoCadastrado.Nome = medicamentoAtualizado.Nome;
            medicamentoCadastrado.Descricao = medicamentoAtualizado.Descricao;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            var medicamentoCadastrada = Medicamento.Medicamentos.FirstOrDefault(x => x.Id == id);
            if (medicamentoCadastrada == null)
            {
                throw new Exception("Esse medicamento não existe!");
            }

            var model = new MedicamentoModel();
            model.Id = id;
            model.Nome = medicamentoCadastrada.Nome;
            model.Descricao = medicamentoCadastrada.Descricao;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(MedicamentoModel medicamentoModel)
        {
            var medicamentoCadastrada = Medicamento.Medicamentos.FirstOrDefault(x => x.Id == medicamentoModel.Id);
            if (medicamentoCadastrada == null)
            {
                throw new Exception("Esse medicamento não existe!");
            }

            Medicamento.Medicamentos.Remove(medicamentoCadastrada);

            return RedirectToAction("Index");
        }
    }
}
