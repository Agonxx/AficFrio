using AficFrio.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace AficFrio.Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Senha { get; set; }

        public ERole Role { get; set; } = ERole.User;

        public DateTime CadastradoEm { get; set; } = DateTime.Now;
    }

    public class UsuarioRestApi
    {
        public const string Autenticar = "Autenticar";
        public const string Cadastrar = "Cadastrar";
        public const string BuscarUsuarios = "BuscarUsuarios";
        public const string CryptografarString = "CryptografarString";
        public const string DescryptografarString = "DescryptografarString";
    }

    public class UsuarioRestClaims
    {
        public const string Id = nameof(Usuario.Id);
        public const string Username = nameof(Usuario.Username);
        public const string CriadoEm = nameof(Usuario.CadastradoEm);
    }

}
