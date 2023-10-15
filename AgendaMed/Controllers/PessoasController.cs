using AgendaMed.Business.Genericos;
using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class PessoasController : Controller
    {
        public IActionResult Index()
        {
            var model = new PessoasModel();

            foreach (var pessoa in Business.Genericos.Pessoa.Pessoas)
            {
                model.Pessoas.Add(new PessoaModel()
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    CPF = pessoa.CPF,
                    Telefone = pessoa.Telefone,
                    DataNascimento = pessoa.DataNascimento,
                });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PessoaModel pessoaModel)
        {
            var pessoaCadastro = new Business.Genericos.Pessoa()
            {
                Nome = pessoaModel.Nome,
                CPF = pessoaModel.CPF,
                Telefone = pessoaModel.Telefone,
                DataNascimento = pessoaModel.DataNascimento,
            };

            Business.Genericos.Pessoa.Pessoas.Add(pessoaCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new PessoaModel();
            Business.Genericos.Pessoa pessoaAlterar = null;

            foreach (var pessoa in Business.Genericos.Pessoa.Pessoas)
            {
                if (pessoa.Id == id)
                {
                    pessoaAlterar = pessoa;
                    break;
                }
            }

            if (pessoaAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Nome = pessoaAlterar.Nome;
            model.CPF = pessoaAlterar.CPF;
            model.Telefone = pessoaAlterar.Telefone;
            model.DataNascimento = pessoaAlterar.DataNascimento;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PessoaModel pessoaAtualizado)
        {
            var pessoaCadastrado = Pessoa.Pessoas.FirstOrDefault(x => x.Id == pessoaAtualizado.Id);

            if (pessoaCadastrado == null)
            {
                throw new Exception("Esse usuário não existe!");
            }

            pessoaCadastrado.Nome = pessoaAtualizado.Nome;
            pessoaCadastrado.CPF = pessoaAtualizado.CPF;
            pessoaCadastrado.Telefone = pessoaAtualizado.Telefone;
            pessoaCadastrado.DataNascimento = pessoaAtualizado.DataNascimento;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoaCadastrada == null)
            {
                throw new Exception("Esse ser não existe!");
            }

            var model = new PessoaModel();
            model.Id = id;
            model.Nome = pessoaCadastrada.Nome;
            model.CPF = pessoaCadastrada.CPF;
            model.Telefone = pessoaCadastrada.Telefone;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(PessoaModel pessoaModel)
        {
            var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == pessoaModel.Id);
            if (pessoaCadastrada == null)
            {
                throw new Exception("Esse ser não existe!");
            }

            Pessoa.Pessoas.Remove(pessoaCadastrada);

            return RedirectToAction("Index");
        }
    }
}
