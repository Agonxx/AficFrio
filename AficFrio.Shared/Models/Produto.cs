using AficFrio.Shared.Enums;

namespace AficFrio.Shared.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public ETipoProduto Tipo { get; set; }
        public EMarcaProduto Marca { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime CadastradoEm { get; set; }
    }

    public class ProdutoApi
    {
        public const string Autenticar = "Autenticar";
    }

}
