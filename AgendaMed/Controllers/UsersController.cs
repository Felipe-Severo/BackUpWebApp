using Microsoft.AspNetCore.Mvc;
using AgendaMed.Models;
using AgendaMed.Business.Genericos;

namespace AgendaMed.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            //if (Business.Genericos.User.GetLoggedUser().AccessType != Business.Genericos.AccessType.Adm)
            //{
            //    return BadRequest("O usuário não possui acesso a esta página");
            //}

            var model = new UsersModel();

            foreach (var user in Business.Genericos.User.Users)
            {
                model.Users.Add(new UserModel() {
                    Id = user.Id,
                    Nickname = user.Nickname,
                    Password = user.Password,
                    AccessType = user.AccessType,
                    });
            }

            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel userModel)
        {
            var usuarioCadastro = new Business.Genericos.User()
            {
                Nickname = userModel.Nickname,
                Password = userModel.Password,
                AccessType = userModel.AccessType,
            };

            Business.Genericos.User.Users.Add(usuarioCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Users)
            {
                if (usuario.Id == id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Nickname = usuarioAlterar.Nickname;
            model.AccessType = usuarioAlterar.AccessType;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserModel usuarioAtualizado)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Users)
            {
                if (usuario.Id == usuarioAtualizado.Id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            usuarioAlterar.Nickname = usuarioAtualizado.Nickname;
            usuarioAlterar.AccessType = usuarioAtualizado.AccessType;

            if (usuarioAtualizado.Password != "00000000" && usuarioAtualizado.Password != usuarioAlterar.Password)
            {
                usuarioAlterar.Password = usuarioAtualizado.Password;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Users)
            {
                if (usuario.Id == id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Nickname = usuarioAlterar.Nickname;
            model.AccessType = usuarioAlterar.AccessType;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(UserModel usuarioAtualizado)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioExcluir = null;

            foreach (var usuario in Business.Genericos.User.Users)
            {
                if (usuario.Id == usuarioAtualizado.Id)
                {
                    usuarioExcluir = usuario;
                    break;
                }
            }

            if (usuarioExcluir == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            Business.Genericos.User.Users.Remove(usuarioExcluir);

            return RedirectToAction("Index");
        }
    }
}