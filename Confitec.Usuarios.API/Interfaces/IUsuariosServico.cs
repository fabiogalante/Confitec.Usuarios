using Confitec.Usuarios.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Confitec.Usuarios.API.Servicos.Request;

namespace Confitec.Usuarios.API.Interfaces
{
    public interface IUsuariosServico
    {
        Task<IActionResult> ObterUsuarios();
        Task<IActionResult> AdicionarUsuario(IncluirUsuariosRequest request);
        Task<IActionResult> AlterarUsuario(IncluirUsuariosRequest request);
        Task<IActionResult> ObterUsuarioPorId(int? usuarioId);
        Task<IActionResult> ExcluirUsuario(int? usuarioId);
    }
}
