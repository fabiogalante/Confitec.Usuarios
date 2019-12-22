using Confitec.Usuarios.API.Models;
using System;
using Confitec.Usuarios.API.Enum;

namespace Confitec.Usuarios.API.ViewModel
{
    public class UsuarioViewModel
    {

        public UsuarioViewModel(Usuario usuario)
        {
            DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy");
            Escolaridade = ((Escolaridade) usuario.Escolaridade);
            Email = usuario.Email;
            Id = usuario.Id;
            Sobrenome = usuario.Sobrenome;
            Nome = usuario.Nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }


    }
}
