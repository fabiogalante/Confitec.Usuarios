using Confitec.Usuarios.API.Interfaces;
using Confitec.Usuarios.API.Models;
using Confitec.Usuarios.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Usuarios.API.Servicos.Request;

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

        public async Task<IActionResult> AdicionarUsuario(IncluirUsuariosRequest request)
        {
            if (request == null)
                return new BadRequestResult();

            request.Validate();

            if (request.Invalid)
            {
                return new UnprocessableEntityObjectResult(request.Notifications);
            }


         

            var id = await _usuariosRepositorio.AdicionarUsuario(request);

            if (id > 0)
                return new OkObjectResult(id);

            return new StatusCodeResult(500);
        }

        public async Task<IActionResult> AlterarUsuario(IncluirUsuariosRequest request)
        {
            try
            {
                if (request == null)
                    return new BadRequestResult();


                request.Validate();

                if (request.Invalid)
                {
                    return new UnprocessableEntityObjectResult(request.Notifications);
                }



                await _usuariosRepositorio.AlterarUsuario(request);


                return new OkObjectResult(request);
            }
            catch
            {
                return new StatusCodeResult(500);
            }



        }

        public async Task<IActionResult> ObterUsuarioPorId(int? usuarioId)
        {
            if (usuarioId == null)
            {
                return new NotFoundResult();
            }

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
