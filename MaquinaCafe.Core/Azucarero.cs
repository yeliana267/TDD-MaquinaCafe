namespace MaquinaCafe.Core
{
    public class Azucarero
    {
        private int _cantidadAzucar;

        public Azucarero(int cantidadAzucar)
        {
            _cantidadAzucar = cantidadAzucar;
        }

        public int GetCantidadAzucar()
        {
            return _cantidadAzucar;
        }

        public void SetCantidadAzucar(int cantidad)
        {
            _cantidadAzucar = cantidad;
        }

        public bool HasAzucar(int cantidad)
        {
            return _cantidadAzucar >= cantidad;
        }

        public void GiveAzucar(int cantidad)
        {
            _cantidadAzucar -= cantidad;
        }
    }
}