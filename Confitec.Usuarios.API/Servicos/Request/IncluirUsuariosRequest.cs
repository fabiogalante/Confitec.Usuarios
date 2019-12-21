using System;
using Confitec.Usuarios.API.Enum;
using Confitec.Usuarios.API.Models;
using Flunt.Validations;

namespace Confitec.Usuarios.API.Servicos.Request
{
    public class IncluirUsuariosRequest : BaseRequest
    {
        public static Escolaridade _escolaridade;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Escolaridade { get; set; }
        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsEmail(Email,nameof(Email),"Email inválido")
                .IsLowerThan(DataNascimento,DateTime.Now, nameof(DataNascimento),"Data de nascimento inválida, a data de nascimento não pode ser maior que hoje")
                .IsNotNull(Escolaridade,nameof(Escolaridade),"Informe a escolaridade")
            );


            if (!System.Enum.TryParse(Escolaridade, out _escolaridade))
            {
                AddNotification(Escolaridade, "Escolaridade inválida. PERMITIDOS [Infantil, Fundamental, Medio, Superior]");
            }
                
        }


        public static implicit operator Usuario(IncluirUsuariosRequest request)
        {
            return new Usuario
            {
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Escolaridade = (int)_escolaridade
            };
        }
    }
}
