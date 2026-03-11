using NUnit.Framework;
using MaquinaCafe.Core;

namespace MaquinaCafe.Tests
{
    [TestFixture]
    public class TestCafetera
    {
        [Test]
        public void DeberiaDevolverVerdaderoSiExisteCafe()
        {
            Cafetera cafetera = new Cafetera(10);

            bool resultado = cafetera.HasCafe(5);

            Assert.That(resultado, Is.EqualTo(true));
        }

        [Test]
        public void DeberiaDevolverFalsoSiNoExisteCafe()
        {
            Cafetera cafetera = new Cafetera(10);

            bool resultado = cafetera.HasCafe(11);

            Assert.That(resultado, Is.EqualTo(false));
        }

        [Test]
        public void DeberiaRestarCafeALaCafetera()
        {
            Cafetera cafetera = new Cafetera(10);

            cafetera.GiveCafe(7);

            Assert.That(cafetera.GetCantidadCafe(), Is.EqualTo(3));
        }
    }
}