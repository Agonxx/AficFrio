namespace AficFrio.Shared.Dtos
{
    public class InfoToken
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }

}
