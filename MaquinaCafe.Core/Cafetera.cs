namespace MaquinaCafe.Core
{
    public class Cafetera
    {
        private int _cantidadCafe;

        public Cafetera(int cantidadCafe)
        {
            _cantidadCafe = cantidadCafe;
        }

        public int GetCantidadCafe()
        {
            return _cantidadCafe;   
        }

        public void SetCantidadCafe(int cantidad)
        {
            _cantidadCafe = cantidad;
        }

        public bool HasCafe(int cantidad)
        {
            return _cantidadCafe >= cantidad;
        }

        public void GiveCafe(int cantidad)
        {
            if (HasCafe(cantidad))
            {
                _cantidadCafe -= cantidad;
            }
        }
    }
}