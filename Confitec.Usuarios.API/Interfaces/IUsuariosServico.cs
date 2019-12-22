using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Confitec.Usuarios.API.Servicos.Request;

namespace Confitec.Usuarios.API.Interfaces
{
    public interface IUsuariosServico
    {
        Task<IActionResult> ObterUsuarios();
        Task<IActionResult> AdicionarUsuario(IncluirUsuariosRequest request);
        Task<IActionResult> AlterarUsuario(AlterarUsuariosRequest request);
        Task<IActionResult> ObterUsuarioPorId(int? usuarioId);
        Task<IActionResult> ExcluirUsuario(int? usuarioId);
    }
}
