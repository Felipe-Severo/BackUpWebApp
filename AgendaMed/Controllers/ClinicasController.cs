using AgendaMed.Business.Genericos;
using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class ClinicasController : Controller
    {
        public IActionResult Index()
        {
            var model = new ClinicasModel();
            
            foreach (var clinica in Business.Genericos.Clinica.Clinicas)
            {
                model.Clinicas.Add(new ClinicaModel()
                {
                    Nome = clinica.Nome,
                    //Responsavel = clinica.Pessoa,
                    CNPJ = clinica.CNPJ,
                    Cep = clinica.Cep,
                    Rua = clinica.Rua,
                    Numero = clinica.Numero,
                    Complemento = clinica.Complemento,
                    Bairro = clinica.Bairro,
                    Telefone = clinica.Telefone,
                });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClinicaModel clinicaModel)
        {
            var clinicaCadastro = new Business.Genericos.Clinica()
            {
                Nome = clinicaModel.Nome, 
                CNPJ = clinicaModel.CNPJ, 
                Cep = clinicaModel.Cep, 
                Rua = clinicaModel.Rua,
                Numero = clinicaModel.Numero,
                Complemento = clinicaModel.Complemento,
                Bairro = clinicaModel.Bairro,
                Telefone = clinicaModel.Telefone,
               
            };

            Business.Genericos.Clinica.Clinicas.Add(clinicaCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new ClinicaModel();
            Business.Genericos.Clinica clinicaAlterar = null;

            foreach (var clinica in Business.Genericos.Clinica.Clinicas)
            {
                if (clinica.Id == id)
                {
                    clinicaAlterar = clinica;
                    break;
                }
            }

            if (clinicaAlterar == null)
            {
                throw new Exception("Não existe clinica cadastrada com o ID informado!");
            }

            model.Id = id;
            model.Nome = clinicaAlterar.Nome;
            //model.Responsavel = clinicaAlterar.Responsavel;
            model.CNPJ = clinicaAlterar.CNPJ;
            model.Cep = clinicaAlterar.Cep;
            model.Rua = clinicaAlterar.Rua;
            model.Numero = clinicaAlterar.Numero;
            model.Complemento = clinicaAlterar.Complemento;
            model.Telefone = clinicaAlterar.Telefone;


            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ClinicaModel clinicaAtualizada)
        {
            var clinicaCadastrada = Clinica.Clinicas.FirstOrDefault(x => x.Id == clinicaAtualizada.Id);

            if (clinicaCadastrada == null)
            {
                throw new Exception("Esse usuário não existe!");
            }

            clinicaCadastrada.Nome = clinicaAtualizada.Nome;
            //clinicaCadastrada.Responsavel = clinicaAtualizada.Responsavel;
            clinicaCadastrada.CNPJ = clinicaAtualizada.CNPJ;
            clinicaCadastrada.Cep = clinicaAtualizada.Cep;
            clinicaCadastrada.Rua = clinicaAtualizada.Rua;
            clinicaCadastrada.Numero = clinicaAtualizada.Numero;
            clinicaCadastrada.Complemento = clinicaAtualizada.Complemento;
            clinicaCadastrada.Telefone = clinicaAtualizada.Telefone;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            var clinicaCadastrada = Clinica.Clinicas.FirstOrDefault(x => x.Id == id);
            if (clinicaCadastrada == null)
            {
                throw new Exception("Essa Clinica não existe!");
            }

            var model = new ClinicaModel();

            model.Id = id;
            model.Nome = clinicaCadastrada.Nome;
            //model.Responsavel = clinicaAlterar.Responsavel;
            model.CNPJ = clinicaCadastrada.CNPJ;
            model.Cep = clinicaCadastrada.Cep;
            model.Rua = clinicaCadastrada.Rua;
            model.Numero = clinicaCadastrada.Numero;
            model.Complemento = clinicaCadastrada.Complemento;
            model.Telefone = clinicaCadastrada.Telefone;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ClinicaModel clinicaModel)
        {
            var clinicaCadastrada = Clinica.Clinicas.FirstOrDefault(x => x.Id == clinicaModel.Id);
            if (clinicaCadastrada == null)
            {
                throw new Exception("Essa Clinica não existe!");
            }

            Clinica.Clinicas.Remove(clinicaCadastrada);

            return RedirectToAction("Index");
        }
    }
}

