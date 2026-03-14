namespace MaquinaCafe.Core
{
    public class MaquinaDeCafe
    {
        public Vaso? VasosPequeno { get; private set; }
        public Vaso? VasosMediano { get; private set; }
        public Vaso? VasosGrande { get; private set; }

        private Cafetera? _cafetera;
        private Azucarero? _azucarero;

        public void SetCafetera(Cafetera cafetera) => _cafetera = cafetera;
        public void SetAzucarero(Azucarero azucarero) => _azucarero = azucarero;
        public void SetVasosPequeno(Vaso vaso) => VasosPequeno = vaso;
        public void SetVasosMediano(Vaso vaso) => VasosMediano = vaso;
        public void SetVasosGrande(Vaso vaso) => VasosGrande = vaso;

        public Cafetera GetCafetera() => _cafetera!;
        public Azucarero GetAzucarero() => _azucarero!;

        public Vaso GetTipoDeVaso(string tipoDeVaso)
        {
            switch (tipoDeVaso.ToLower())
            {
                case "pequeno":
                    return VasosPequeno!;
                case "mediano":
                    return VasosMediano!;
                case "grande":
                    return VasosGrande!;
                default:
                    throw new ArgumentException("Tipo de vaso no válido");
            }
        }

        public string GetVasoDeCafe(Vaso vaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            if (!vaso.HasVasos(cantidadDeVasos))
                return "No hay Vasos";

            if (!_cafetera!.HasCafe(vaso.GetContenido() * cantidadDeVasos))
                return "No hay Cafe";

            if (!_azucarero!.HasAzucar(cantidadDeAzucar))
                return "No hay Azucar";

            vaso.GiveVasos(cantidadDeVasos);
            _cafetera.GiveCafe(vaso.GetContenido() * cantidadDeVasos);
            _azucarero.GiveAzucar(cantidadDeAzucar);

            return "Felicitaciones";
        }
    }
}