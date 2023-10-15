using AgendaMed.Business.Genericos;
using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class ReceitasController : Controller
    {
        public IActionResult Index()
        {
            var model = new ReceitasModel();

            foreach (var receita in Business.Genericos.Receita.Receitas)
            {
                model.Receitas.Add(new ReceitaModel()
                {
                    DataPrescricao = receita.DataPrescricao,
                    //Medicamento = receita.Medicamento,
                    Dosagem = receita.Dosagem,
                    PosologiaDias = receita.PosologiaDias,
                    PosologiaHora = receita.PosologiaHora,
                });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ReceitaModel receitaModel)
        {
            var receitaCadastro = new Business.Genericos.Receita()
            {
                DataPrescricao = receitaModel.DataPrescricao,
                Dosagem = receitaModel.Dosagem,
            };

            Business.Genericos.Receita.Receitas.Add(receitaCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new ReceitaModel();
            Business.Genericos.Receita receitaAlterar = null;

            foreach (var receita in Business.Genericos.Receita.Receitas)
            {
                if (receita.Id == id)
                {
                    receitaAlterar = receita;
                    break;
                }
            }

            if (receitaAlterar == null)
            {
                throw new Exception("Não existe receita cadastrado com o ID informado!");
            }

            model.Id = id;
            model.DataPrescricao = receitaAlterar.DataPrescricao;
            model.Dosagem = receitaAlterar.Dosagem;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ReceitaModel receitaAtualizado)
        {
            var receitaCadastrado = Receita.Receitas.FirstOrDefault(x => x.Id == receitaAtualizado.Id);

            if (receitaCadastrado == null)
            {
                throw new Exception("Esse meidicamento não existe!");
            }

            receitaCadastrado.DataPrescricao = receitaAtualizado.DataPrescricao;
            receitaCadastrado.Dosagem = receitaAtualizado.Dosagem;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            var receitaCadastrada = Receita.Receitas.FirstOrDefault(x => x.Id == id);
            if (receitaCadastrada == null)
            {
                throw new Exception("Esse receita não existe!");
            }

            var model = new ReceitaModel();
            model.Id = id;
            model.DataPrescricao = receitaCadastrada.DataPrescricao;
            model.Dosagem = receitaCadastrada.Dosagem;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ReceitaModel receitaModel)
        {
            var receitaCadastrada = Receita.Receitas.FirstOrDefault(x => x.Id == receitaModel.Id);
            if (receitaCadastrada == null)
            {
                throw new Exception("Esse receita não existe!");
            }

            Receita.Receitas.Remove(receitaCadastrada);

            return RedirectToAction("Index");
        }
    }
}
