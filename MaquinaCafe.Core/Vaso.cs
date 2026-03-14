namespace MaquinaCafe.Core
{
    public class Vaso
    {
        private int _cantidadVasos;
        private int _contenido;

        public Vaso(int cantidadVasos, int contenido)
        {
            _cantidadVasos = cantidadVasos;
            _contenido = contenido;
        }

        public int GetCantidadVasos()
        {
            return _cantidadVasos;
        }

        public int GetContenido()
        {
            return _contenido;
        }

        public bool HasVasos(int cantidad)
        {
            return _cantidadVasos >= cantidad;
        }

        public void GiveVasos(int cantidad)
        {
            _cantidadVasos -= cantidad;
        }
    }
}