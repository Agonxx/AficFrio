using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ERole Tipo { get; set; } = ERole.User;
        public bool Ativo { get; set; } = true;
        public DateTime CadastradoEm { get; set; } = DateTime.Now;
    }

    public class UsuarioApi
    {
        public const string Autenticar = "Autenticar";
        public const string Cadastrar = "Cadastrar";
        public const string BuscarUsuarios = "BuscarUsuarios";
        public const string CryptografarString = "CryptografarString";
        public const string DescryptografarString = "DescryptografarString";
    }

    public class UsuarioClaims
    {
        public const string Id = nameof(Usuario.Id);
        public const string Username = nameof(Usuario.Username);
        public const string CriadoEm = nameof(Usuario.CadastradoEm);
    }

}
