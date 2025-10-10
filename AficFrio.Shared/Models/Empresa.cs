using System.ComponentModel.DataAnnotations;

namespace AficFrio.Shared.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Nome { get; set; }

        [MaxLength(500)]
        public string QRCodeMobile { get; set; }
    }
}
