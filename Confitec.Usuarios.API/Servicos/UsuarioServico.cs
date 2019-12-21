using Confitec.Usuarios.API.Interfaces;
using Confitec.Usuarios.API.Models;
using Confitec.Usuarios.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Usuarios.API.Servicos
{
    public class UsuarioServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuarioServico(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        public async Task<IActionResult> ObterUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuarios = await _usuariosRepositorio.ObterUsuarios();

                if (usuarios != null)
                    return new OkObjectResult(usuarios.Select(u => new UsuarioViewModel(u)).OrderBy(u => u.Nome));

                return new NotFoundResult();

            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> AdicionarUsuario(Usuario usuario)
        {
            if (usuario == null)
                return new BadRequestResult();

            var id = await _usuariosRepositorio.AdicionarUsuario(usuario);

            if (id > 0)
                return new OkObjectResult(id);

            return new StatusCodeResult(500);
        }

        public async Task<IActionResult> AlterarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return new BadRequestResult();

                await _usuariosRepositorio.AlterarUsuario(usuario);


                return new OkObjectResult(usuario);
            }
            catch
            {
                return new StatusCodeResult(500);
            }



        }

        public async Task<IActionResult> ObterUsuarioPorId(int? usuarioId)
        {
            var usuario = await _usuariosRepositorio.ObterUsuarioPorId(usuarioId);

            if (usuario != null)
            {
                return new OkObjectResult(new UsuarioViewModel(usuario));
            }

            return new NoContentResult();
        }

        public async Task<IActionResult> ExcluirUsuario(int? usuarioId)
        {
            if (usuarioId == null)
                return new NoContentResult();

            var usuario = await _usuariosRepositorio.ExcluirUsuario(usuarioId);

            return new OkObjectResult(new UsuarioViewModel(usuario));
        }
    }
}
