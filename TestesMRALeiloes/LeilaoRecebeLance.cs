using System.Linq;
using Xunit;
using MRALeiloes.Models;

namespace TestesMRALeiloes
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(3000, new double[] { 1500, 2000, 2500, 3000 })]
        [InlineData(1500, new double[] { 800, 500, 1500 })]
        [InlineData(2500, new double[] { 1500, 2000, 2500 })]
        [InlineData(100, new double[] { 80, 50, 100 })]
        [InlineData(0, new double[] { })]
        [InlineData(509, new double[] { -19, -50, -489, 509 })]
        private void RetornaMaiorLanceDadoLances(double valorEsperado, double[] lances)
        {
            //Arrange preparação cenário
            Produto produto = new Produto("Monaliza", 25000, 0.00);
            Interessado Interessado = new Interessado("Ana Ribeiro");
            Leilao leilao = new Leilao("Leilão de verão", produto);

            leilao.IniciaPregao();

            foreach (var lance in lances)
            {
                leilao.RecebeLance(new Lance(Interessado, lance));
            }

            //Action  chamada ação
            var valorObtido = leilao.Pregao();

            //Assert esperado
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(4, new double[] { 1500, 2000, 2500, 3000 })]
        [InlineData(3, new double[] { 800, 500, 1500 })]
        private void RetornarMairoLanceDadoTerminoDoLeilao(double valorEsperado, double[] lances)
        {
            Produto produto = new Produto("Van Gogh", 40000, 0.00);
            Interessado Interessado = new Interessado("Rafael Massula");
            Leilao leilao = new Leilao("Raros", produto);

            leilao.IniciaPregao();

            foreach (var lance in lances)
            {
                leilao.RecebeLance(new Lance(Interessado, lance));
            }

            leilao.Pregao();

            var valorObtido = leilao.Lances.Count();

            Assert.Equal(valorEsperado, valorObtido);

        }
    }
}
