using NUnit.Framework;
using MaquinaCafe.Core;

namespace MaquinaCafe.Tests
{
    [TestFixture]
    public class TestMaquinaDeCafe
    {
        private Cafetera _cafetera;
        private Vaso _vasosPequeno;
        private Vaso _vasosMediano;
        private Vaso _vasosGrande;
        private Azucarero _azucarero;
        private MaquinaDeCafe _maquinaDeCafe;

        [SetUp]
        public void SetUp()
        {
            _cafetera = new Cafetera(50);
            _vasosPequeno = new Vaso(5, 10);
            _vasosMediano = new Vaso(5, 20);
            _vasosGrande = new Vaso(5, 30);
            _azucarero = new Azucarero(20);

            _maquinaDeCafe = new MaquinaDeCafe();
            _maquinaDeCafe.SetCafetera(_cafetera);
            _maquinaDeCafe.SetVasosPequeno(_vasosPequeno);
            _maquinaDeCafe.SetVasosMediano(_vasosMediano);
            _maquinaDeCafe.SetVasosGrande(_vasosGrande);
            _maquinaDeCafe.SetAzucarero(_azucarero);
        }

        [Test]
        public void DeberiaDevolverUnVasoPequeno()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");
            Assert.That(vaso, Is.EqualTo(_maquinaDeCafe.VasosPequeno));
        }

        [Test]
        public void DeberiaDevolverUnVasoMediano()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("mediano");
            Assert.That(vaso, Is.EqualTo(_maquinaDeCafe.VasosMediano));
        }

        [Test]
        public void DeberiaDevolverUnVasoGrande()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("grande");
            Assert.That(vaso, Is.EqualTo(_maquinaDeCafe.VasosGrande));
        }

        [Test]
        public void DeberiaDevolverNoHayVasos()
        {
            _maquinaDeCafe.SetVasosPequeno(new Vaso(0, 10));
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = _maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);

            Assert.That(resultado, Is.EqualTo("No hay Vasos"));
        }

        [Test]
        public void DeberiaDevolverNoHayCafe()
        {
            _maquinaDeCafe.SetCafetera(new Cafetera(5));
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);

            Assert.That(resultado, Is.EqualTo("No hay Cafe"));
        }

        [Test]
        public void DeberiaDevolverNoHayAzucar()
        {
            _maquinaDeCafe.SetAzucarero(new Azucarero(2));
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.That(resultado, Is.EqualTo("No hay Azucar"));
        }

        [Test]
        public void DeberiaRestarCafe()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");
            _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.That(_maquinaDeCafe.GetCafetera().GetCantidadCafe(), Is.EqualTo(40));
        }

        [Test]
        public void DeberiaRestarVaso()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");
            _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.That(_maquinaDeCafe.VasosPequeno.GetCantidadVasos(), Is.EqualTo(4));
        }

        [Test]
        public void DeberiaRestarAzucar()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");
            _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.That(_maquinaDeCafe.GetAzucarero().GetCantidadAzucar(), Is.EqualTo(17));
        }

        [Test]
        public void DeberiaDevolverFelicitaciones()
        {
            Vaso vaso = _maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = _maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.That(resultado, Is.EqualTo("Felicitaciones"));
        }
    }
}