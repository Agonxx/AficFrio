using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ERole Role { get; set; } = ERole.User;
        public DateTime CadastradoEm { get; set; } = DateTime.Now;
    }
}
