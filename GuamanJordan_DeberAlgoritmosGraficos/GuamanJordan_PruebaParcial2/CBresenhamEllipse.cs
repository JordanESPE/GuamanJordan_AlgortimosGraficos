using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    internal class CBresenhamEllipse
    {
        public static List<Point> CalcularPuntosElipse(int cx, int cy, int rx, int ry, int escala = 10, int alturaCanvas = 480)
        {
            List<Point> puntos = new List<Point>();

            cy = (alturaCanvas / escala) - cy;
            cx *= escala;
            cy *= escala;
            rx *= escala;
            ry *= escala;

            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int twoRx2 = 2 * rx2;
            int twoRy2 = 2 * ry2;

            int x = 0;
            int y = ry;
            int px = 0;
            int py = twoRx2 * y;

            int p1 = (int)(ry2 - (rx2 * ry) + (0.25 * rx2));

            while (px < py)
            {
                AgregarPuntosElipse(puntos, cx, cy, x, y);

                x++;
                px += twoRy2;

                if (p1 < 0)
                    p1 += ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p1 += ry2 + px - py;
                }
            }

            int p2 = (int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);

            while (y > 0)
            {
                AgregarPuntosElipse(puntos, cx, cy, x, y);

                y--;
                py -= twoRx2;

                if (p2 > 0)
                    p2 += rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p2 += rx2 - py + px;
                }
            }

            return puntos;
        }

        private static void AgregarPuntosElipse(List<Point> puntos, int cx, int cy, int x, int y)
        {
            puntos.Add(new Point(cx + x, cy + y));
            puntos.Add(new Point(cx - x, cy + y));
            puntos.Add(new Point(cx + x, cy - y));
            puntos.Add(new Point(cx - x, cy - y));
        }

        public static bool ValidarParametros(int cx, int cy, int rx, int ry, int maxX, int maxY, int escala = 10)
        {
            int maxCoordX = maxX / escala;
            int maxCoordY = maxY / escala;

            return cx >= rx && cx <= (maxCoordX - rx) &&
                   cy >= ry && cy <= (maxCoordY - ry) &&
                   rx > 0 && ry > 0;
        }
    }
}
