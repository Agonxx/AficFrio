using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
    }

    public class ClienteApi
    {
        public const string Autenticar = "Autenticar";
    }

}
