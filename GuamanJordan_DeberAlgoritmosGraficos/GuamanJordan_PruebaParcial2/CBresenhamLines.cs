using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CBresenhamLines
    {
        public static List<Point> CalcularPuntosBresenham(int x1, int y1, int x2, int y2, int escala = 20, int alturaCanvas = 480)
        {
            List<Point> puntos = new List<Point>();

            y1 = (alturaCanvas / escala) - y1;
            y2 = (alturaCanvas / escala) - y2;

            x1 *= escala;
            y1 *= escala;
            x2 *= escala;
            y2 *= escala;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int err = dx - dy;
            int x = x1;
            int y = y1;

            while (true)
            {
                puntos.Add(new Point(x, y));

                if (x == x2 && y == y2)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx * escala; // mover de nodo en nodo
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy * escala; // mover de nodo en nodo
                }
            }

            return puntos;
        }

        public static bool ValidarCoordenadas(int x1, int y1, int x2, int y2, int maxX, int maxY, int escala = 20)
        {
            return x1 >= 0 && x1 <= (maxX / escala) && y1 >= 0 && y1 <= (maxY / escala) &&
                   x2 >= 0 && x2 <= (maxX / escala) && y2 >= 0 && y2 <= (maxY / escala);
        }
    }
}
