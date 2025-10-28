using System.ComponentModel;

namespace AficFrio.Shared.Enums
{
    public enum ETipoProduto
    {
        [Description("Lava e Seca")]
        LavaESeca = 1,

        [Description("Lavadora de Roupas")]
        Lavadora = 2,

        [Description("Secadora de Roupas")]
        Secadora = 3,

        [Description("Geladeira / Refrigerador")]
        Geladeira = 4,

        [Description("Freezer")]
        Freezer = 5,

        [Description("Balcão Refrigerado")]
        BalcaoRefrigerado = 6,

        [Description("Câmara Fria")]
        CamaraFria = 7,

        [Description("Ultra Congelador")]
        UltraCongelador = 8,

        [Description("Adega")]
        Adega = 9,

        [Description("Frigobar")]
        Frigobar = 10,

        [Description("Fogão")]
        Fogao = 11,

        [Description("Forno a Gás")]
        FornoAGas = 12,

        [Description("Forno Elétrico")]
        FornoEletrico = 13,

        [Description("Forno Combinado / Convector")]
        FornoCombinado = 14,

        [Description("Micro-ondas")]
        MicroOndas = 15,

        [Description("Bebedouro")]
        Bebedouro = 16,

        [Description("Purificador de Água")]
        PurificadorDeAgua = 17,

        [Description("Ar Condicionado")]
        ArCondicionadoSplit = 18
    }

}
