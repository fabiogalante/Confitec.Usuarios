using Confitec.Usuarios.API.Models;
using System;

namespace Confitec.Usuarios.API.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(Usuario usuario)
        {
            DataNascimento = usuario.DataNascimento;
            Escolaridade = usuario.Escolaridade;
            Email = usuario.Email;
            Id = usuario.Id;
            Sobrenome = usuario.Sobrenome;
            Nome = usuario.Nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }


    }
}
