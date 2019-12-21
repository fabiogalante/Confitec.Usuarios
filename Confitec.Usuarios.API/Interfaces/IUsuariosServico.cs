using Confitec.Usuarios.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Confitec.Usuarios.API.Interfaces
{
    public interface IUsuariosServico
    {
        Task<IActionResult> ObterUsuarios();
        Task<IActionResult> AdicionarUsuario(Usuario usuario);
        Task<IActionResult> AlterarUsuario(Usuario usuario);
        Task<IActionResult> ObterUsuarioPorId(int? usuarioId);
        Task<IActionResult> ExcluirUsuario(int? usuarioId);
    }
}
