using System.ComponentModel.DataAnnotations;

namespace AficFrio.Shared.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string CpfCnpj { get; set; }
    }
}
