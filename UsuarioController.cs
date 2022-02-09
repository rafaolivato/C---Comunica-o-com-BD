using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT02_RafaelOlivato_UC04.Models;
 
 
namespace AT02_RafaelOlivato_UC04.Controllers
{
    public class UsuarioController : Controller
    {
       public IActionResult Lista(){

           UsuarioRepository ur = new UsuarioRepository();
           
           List<Usuario> lista = ur.Listar();
           return View(lista);
       }

       public IActionResult Excluir(int id){

           UsuarioRepository ur = new UsuarioRepository();
            Usuario userEncontrado = ur.BuscarPorId(id);

           ur.remover(userEncontrado);

           return RedirectToAction ("Lista");
       }

       public IActionResult Inserir(){
           return View();
       }
        [HttpPost]
       public IActionResult Inserir(Usuario novoUser){

           UsuarioRepository ur = new UsuarioRepository();
           ur.inserir (novoUser);

           ViewData["mensagem"] = "Cadastro realizado com sucesso";
           return View();
       }

       public IActionResult Alterar(int id){

           UsuarioRepository ur = new UsuarioRepository();
           Usuario userEncontrado = ur.BuscarPorId(id);

           return View(userEncontrado);

       }

       [HttpPost]

       public IActionResult Alterar (Usuario usuario){

           UsuarioRepository ur = new UsuarioRepository();
           ur.atualizar(usuario);

           return RedirectToAction("Lista");

       }
    }


}
