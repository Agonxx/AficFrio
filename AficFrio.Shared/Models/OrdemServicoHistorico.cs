using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class OrdemServicoHistorico
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
    }

    public class OrdemServicoHistoricoApi
    {
        public const string Autenticar = "Autenticar";
    }

}
