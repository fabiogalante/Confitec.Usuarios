using Confitec.Usuarios.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Usuarios.API.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<Usuario>> ObterUsuarios();
        Task<int> AdicionarUsuario(Usuario usuario);
        Task<int> AlterarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPorId(int? usuarioId);
        Task<Usuario> ExcluirUsuario(int? usuarioId);
    }
}
