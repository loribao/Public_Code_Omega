namespace Enriquecimento.Models
{
    public class Enumeradores
    {
        public enum DBSqlServer
        {
            ControleGerencialInfinit = 1,
            EnriquecimentoInfinit = 2,
        }

        public enum OrigemAppsettingsJson : int
        {
            WebApp = 1,
            ServiceBackground = 2
        }

        public enum Cliente : int
        {
            Infinit = 1,
        }

        public enum Produto : int
        {
            Enriquecimento = 1
        }

        public enum StatusJob : int
        {
            EmFila = 1,
            Processando = 2,
            Compactando = 3,
            Cancelando = 4,
            Importando = 5,
            Exportando = 6,
            Processado = 7,
            Cancelado = 8,
            Erro = 9,
            Descompactando = 10
        }
    }
}