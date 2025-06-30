using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CBresenhamMiddlePoint
    {
        public static List<Point> CalcularPuntosCirculo(int radio)
        {
            List<Point> puntos = new List<Point>();

            int x = 0;
            int y = radio;
            int p = 1 - radio;

            AgregarPuntos(puntos, x, y);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                AgregarPuntos(puntos, x, y);
            }

            return puntos;
        }

        private static void AgregarPuntos(List<Point> puntos, int x, int y)
        {
            puntos.Add(new Point(x, y));
            puntos.Add(new Point(-x, y));
            puntos.Add(new Point(x, -y));
            puntos.Add(new Point(-x, -y));
            puntos.Add(new Point(y, x));
            puntos.Add(new Point(-y, x));
            puntos.Add(new Point(y, -x));
            puntos.Add(new Point(-y, -x));
        }
    }
}
