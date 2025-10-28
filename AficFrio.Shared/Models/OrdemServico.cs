using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
    }

    public class OrdemServicoApi
    {
        public const string Autenticar = "Autenticar";
    }

}
