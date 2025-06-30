using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CDDA
    {
        public static List<Point> CalcularPuntosDDA(int x1, int y1, int x2, int y2, int escala = 20, int alturaCanvas = 480)
        {
            List<Point> puntos = new List<Point>();

            y1 = (alturaCanvas / escala) - y1;
            y2 = (alturaCanvas / escala) - y2;

            x1 *= escala;
            y1 *= escala;
            x2 *= escala;
            y2 *= escala;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int pasos = Math.Max(Math.Abs(dx / escala), Math.Abs(dy / escala));
            float incX = dx / (float)pasos;
            float incY = dy / (float)pasos;

            float x = x1;
            float y = y1;

            for (int i = 0; i <= pasos; i++)
            {
                puntos.Add(new Point((int)x, (int)y));
                x += incX;
                y += incY;
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
