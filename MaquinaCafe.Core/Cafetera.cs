namespace MaquinaCafe.Core
{
    public class Cafetera
    {
        private int _cantidadCafe;

        public Cafetera(int cantidadCafe)
        {
            if (cantidadCafe < 0)
                throw new ArgumentOutOfRangeException(nameof(cantidadCafe), "La cantidad inicial no puede ser negativa.");
            _cantidadCafe = cantidadCafe;
        }

        public int GetCantidadCafe()
        {
            return _cantidadCafe;   
        }

        public void SetCantidadCafe(int cantidad)
        {
            if (cantidad < 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad no puede ser negativa.");
            _cantidadCafe = cantidad;
        }

        public bool HasCafe(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad a consultar no puede ser negativa o cero.");
            return _cantidadCafe >= cantidad;
        }

        public void GiveCafe(int cantidad)
        {
            if (cantidad < 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "No se puede dar una cantidad negativa de café.");

            
            if (!HasCafe(cantidad))
                throw new InvalidOperationException("No hay suficiente café en la máquina para despachar esta cantidad.");

            _cantidadCafe -= cantidad;
        }
    }
}