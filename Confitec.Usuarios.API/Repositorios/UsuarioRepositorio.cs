using Confitec.Usuarios.API.Data;
using Confitec.Usuarios.API.Interfaces;
using Confitec.Usuarios.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Usuarios.API.Repositorios
{
    public class UsuarioRepositorio : IUsuariosRepositorio
    {
        private readonly UsuariosDbContex _dbContex;

        public UsuarioRepositorio(UsuariosDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }

        public async Task<int> AdicionarUsuario(Usuario usuario)
        {
            await _dbContex.Usuarios.AddAsync(usuario);
            await Salvar();
            return usuario.Id;
        }

        public async Task<int> AlterarUsuario(Usuario usuario)
        {
            _dbContex.Usuarios.Update(usuario);
            await Salvar();
            return usuario.Id;

        }

        public async Task<Usuario> ObterUsuarioPorId(int? usuarioId)
        {
            return await _dbContex.Usuarios
                .Where(p => p.Id == usuarioId)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ExcluirUsuario(int? usuarioId)
        {
            var usuario = await ObterUsuarioPorId(usuarioId);

            if (usuario != null)
            {
                _dbContex.Usuarios.Remove(usuario);
                await Salvar();
            }

            return usuario;
        }

        public async Task Salvar()
        {
            await _dbContex.SaveChangesAsync();
        }
    }
}
