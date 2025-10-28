using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class Tecnico
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public string Especialidades { get; set; }
        public string Celular { get; set; }
        public string Observações { get; set; }
    }

    public class TecnicoApi
    {
        public const string Autenticar = "Autenticar";
    }

}
