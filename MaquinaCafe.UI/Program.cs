using MaquinaCafe.Core;

namespace MaquinaCafe.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Maquina de Cafe";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MaquinaDeCafe maquina = new MaquinaDeCafe();
            maquina.SetCafetera(new Cafetera(100));
            maquina.SetAzucarero(new Azucarero(30));
            maquina.SetVasosPequeno(new Vaso(10, 10));
            maquina.SetVasosMediano(new Vaso(10, 20));
            maquina.SetVasosGrande(new Vaso(10, 30));

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                DibujarMaquina();
                MostrarMenu();

                Console.Write("\nSeleccione una opcion: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        ServirCafe(maquina, "pequeno");
                        break;
                    case "2":
                        ServirCafe(maquina, "mediano");
                        break;
                    case "3":
                        ServirCafe(maquina, "grande");
                        break;
                    case "4":
                        MostrarEstado(maquina);
                        break;
                    case "5":
                        salir = true;
                        MostrarDespedida();
                        break;
                    default:
                        MostrarError("Opcion no valida.");
                        Pausa();
                        break;
                }
            }
        }

        static void DibujarMaquina()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==============================================================");
            Console.WriteLine("                     MAQUINA DE CAFE ☕");
            Console.WriteLine("==============================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"                 __________________________");
            Console.WriteLine(@"                |  ______________________  |");
            Console.WriteLine(@"                | |                      | |");
            Console.WriteLine(@"                | |   CAFE EXPRESS 3000  | |");
            Console.WriteLine(@"                | |______________________| |");
            Console.WriteLine(@"                |   [1] Peq   [2] Med     |");
            Console.WriteLine(@"                |   [3] Gra   [4] Estado  |");
            Console.WriteLine(@"                |   [5] Salir             |");
            Console.WriteLine(@"                |-------------------------|");
            Console.WriteLine(@"                |         ______          |");
            Console.WriteLine(@"                |        |      |         |");
            Console.WriteLine(@"                |        | CAFE |         |");
            Console.WriteLine(@"                |        |______|         |");
            Console.WriteLine(@"                |           ||            |");
            Console.WriteLine(@"                |           ||            |");
            Console.WriteLine(@"                |         .-''-.          |");
            Console.WriteLine(@"                |        /      \         |");
            Console.WriteLine(@"                |       |  ☕    |         |");
            Console.WriteLine(@"                |        \______/         |");
            Console.WriteLine(@"                |_________________________|");
            Console.ResetColor();
        }

        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================== MENU PRINCIPAL ====================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Servir cafe pequeno");
            Console.WriteLine("2. Servir cafe mediano");
            Console.WriteLine("3. Servir cafe grande");
            Console.WriteLine("4. Ver estado de la maquina");
            Console.WriteLine("5. Salir");
            Console.ResetColor();
        }

        static void ServirCafe(MaquinaDeCafe maquina, string tipoVaso)
        {
            Console.Clear();
            DibujarMaquina();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHa elegido un cafe {tipoVaso}.");
            Console.ResetColor();

            Console.Write("Cuanta azucar desea? ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadAzucar) || cantidadAzucar < 0)
            {
                MostrarError("Cantidad de azucar invalida.");
                Pausa();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nPreparando su cafe");
            Console.ResetColor();

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine();

            Vaso vaso = maquina.GetTipoDeVaso(tipoVaso);
            string resultado = maquina.GetVasoDeCafe(vaso, 1, cantidadAzucar);

            if (resultado == "Felicitaciones")
            {
                MostrarCafeServido(tipoVaso, cantidadAzucar);
            }
            else
            {
                MostrarError(resultado);
            }

            Pausa();
        }

        static void MostrarCafeServido(string tipoVaso, int azucar)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
               (  )   (   )  )
                ) (   )  (  (
                ( )  (    ) )
                _____________
               <_____________> ___
               |             |/ _ \
               |   CAFE OK   | | | |
               |_____________|_| |_|
                \           /      
                 \_________/
");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Felicitaciones");
            Console.WriteLine($"Cafe servido: {tipoVaso}");
            Console.WriteLine($"Azucar: {azucar}");
            Console.ResetColor();
        }

        static void MostrarEstado(MaquinaDeCafe maquina)
        {
            Console.Clear();
            DibujarMaquina();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================== ESTADO DE LA MAQUINA ====================");
            Console.ResetColor();

            Console.WriteLine($"Cafe disponible       : {maquina.GetCafetera().GetCantidadCafe()}");
            Console.WriteLine($"Azucar disponible     : {maquina.GetAzucarero().GetCantidadAzucar()}");
            Console.WriteLine($"Vasos pequenos        : {maquina.VasosPequeno?.GetCantidadVasos()}");
            Console.WriteLine($"Vasos medianos        : {maquina.VasosMediano?.GetCantidadVasos()}");
            Console.WriteLine($"Vasos grandes         : {maquina.VasosGrande?.GetCantidadVasos()}");

            Pausa();
        }

        static void MostrarDespedida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==============================================================");
            Console.WriteLine("                 GRACIAS POR USAR LA MAQUINA");
            Console.WriteLine("==============================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"
                    \  /
                     \/
                 .-''''-.
                /  .--.  \
               /  /    \  \
               |  |    |  |
               \  \____/  /
                '.______.'
");
            Console.ResetColor();

            Console.WriteLine("Hasta luego...");
            Thread.Sleep(1500);
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {mensaje}");
            Console.ResetColor();
        }

        static void Pausa()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}