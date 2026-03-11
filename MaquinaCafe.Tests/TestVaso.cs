using NUnit.Framework;
using MaquinaCafe.Core;

namespace MaquinaCafe.Tests
{
    [TestFixture]
    public class TestVaso
    {
        [Test]
        public void DeberiaDevolverVerdaderoSiExistenVasos()
        {
            Vaso vasosPequenos = new Vaso(2, 10);

            bool resultado = vasosPequenos.HasVasos(1);

            Assert.That(resultado, Is.EqualTo(true));
        }

        [Test]
        public void DeberiaDevolverFalsoSiNoExistenVasos()
        {
            Vaso vasosPequenos = new Vaso(1, 10);

            bool resultado = vasosPequenos.HasVasos(2);

            Assert.That(resultado, Is.EqualTo(false));
        }

        [Test]
        public void DeberiaRestarCantidadDeVaso()
        {
            Vaso vasosPequenos = new Vaso(5, 10);

            vasosPequenos.GiveVasos(1);

            Assert.That(vasosPequenos.GetCantidadVasos(), Is.EqualTo(4));
        }
    }
}