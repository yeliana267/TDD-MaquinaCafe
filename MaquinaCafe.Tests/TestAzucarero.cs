using NUnit.Framework;
using MaquinaCafe.Core;

namespace MaquinaCafe.Tests
{
    [TestFixture]
    public class TestAzucarero
    {
        private Azucarero _azucarero;

        [SetUp]
        public void SetUp()
        {
            _azucarero = new Azucarero(10);
        }

        [Test]
        public void DeberiaDevolver_Verdadero_SiHaySuficienteAzucar()
        {
            bool resultado = _azucarero.HasAzucar(5);
            Assert.That(resultado, Is.EqualTo(true));

            resultado = _azucarero.HasAzucar(10);
            Assert.That(resultado, Is.EqualTo(true));
        }

        [Test]
        public void DeberiaDevolver_Falso_PorqueNoHaySuficienteAzucar()
        {
            bool resultado = _azucarero.HasAzucar(15);

            Assert.That(resultado, Is.EqualTo(false));
        }

        [Test]
        public void DeberiaRestarAzucarAlAzucarero()
        {
            _azucarero.GiveAzucar(5);
            Assert.That(_azucarero.GetCantidadAzucar(), Is.EqualTo(5));

            _azucarero.GiveAzucar(2);
            Assert.That(_azucarero.GetCantidadAzucar(), Is.EqualTo(3));
        }
    }
}