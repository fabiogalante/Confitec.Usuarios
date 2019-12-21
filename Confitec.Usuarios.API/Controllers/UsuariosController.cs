using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Usuarios.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosServico _usuariosServico;

        public UsuariosController(IUsuariosServico usuariosServico)
        {
            _usuariosServico = usuariosServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterUsuarios()
        {
            return await _usuariosServico.ObterUsuarios();
        }
    }
}