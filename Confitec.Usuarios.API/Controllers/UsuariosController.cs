using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Confitec.Usuarios.API.Interfaces;
using Confitec.Usuarios.API.Servicos.Request;
using Flunt.Notifications;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Usuarios.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServico _usuariosServico;

        public UsuariosController(IUsuariosServico usuariosServico)
        {
            _usuariosServico = usuariosServico;
        }


        /// <summary>
        /// Obtem todos usuários Confitec
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso</response>
        /// <response code="422">Ocorreu um erro</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return await _usuariosServico.ObterUsuarios();
        }


        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> ObterPorId(int usuarioId)
        {
            return await _usuariosServico.ObterUsuarioPorId(usuarioId);
        }



        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <response code="200">Cadastro realizado com sucesso</response>
        /// <response code="400">Bad request</response>
        /// <response code="422">Erro de validação</response>
        /// <param name="request">Model that represents an account unlock request</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnprocessableEntityObjectResult), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Cadastrar([FromBody]IncluirUsuariosRequest request)
        {
            return await _usuariosServico.AdicionarUsuario(request);
        }


        /// <summary>
        /// Alteracao de usuários
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(HttpStatusCode), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(UnprocessableEntityObjectResult), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Alterar(AlterarUsuariosRequest request)
        {
            return await _usuariosServico.AlterarUsuario(request);
        }


        /// <summary>
        /// Excluir usuário
        /// </summary>
        /// <param name="usuarioId"></param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnprocessableEntityObjectResult), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Excluir(int usuarioId)
        {
            return await _usuariosServico.ExcluirUsuario(usuarioId);
        }



    }
}