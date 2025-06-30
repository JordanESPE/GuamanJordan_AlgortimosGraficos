using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CBoundaryFill
    {
        /// <summary>
        /// Algoritmo tradicional de Boundary Fill usando Queue (BFS)
        /// </summary>
        /// <param name="bmp">Bitmap donde se realizará el relleno</param>
        /// <param name="x">Coordenada X del punto semilla</param>
        /// <param name="y">Coordenada Y del punto semilla</param>
        /// <param name="boundaryColor">Color del borde que no se debe cruzar</param>
        /// <param name="fillColor">Color de relleno</param>
        public static void BoundaryFill(Bitmap bmp, int x, int y, Color boundaryColor, Color fillColor)
        {
            if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height)
                return;

            Color targetColor = bmp.GetPixel(x, y);
            if (ColoresIguales(targetColor, boundaryColor) || ColoresIguales(targetColor, fillColor))
                return;

            Queue<Point> cola = new Queue<Point>();
            cola.Enqueue(new Point(x, y));

            while (cola.Count > 0)
            {
                Point p = cola.Dequeue();
                int px = p.X;
                int py = p.Y;

                if (px < 0 || py < 0 || px >= bmp.Width || py >= bmp.Height)
                    continue;

                Color actual = bmp.GetPixel(px, py);
                if (!ColoresIguales(actual, boundaryColor) && !ColoresIguales(actual, fillColor))
                {
                    bmp.SetPixel(px, py, fillColor);

                    cola.Enqueue(new Point(px + 1, py)); // Este
                    cola.Enqueue(new Point(px - 1, py)); // Oeste
                    cola.Enqueue(new Point(px, py + 1)); // Sur
                    cola.Enqueue(new Point(px, py - 1)); // Norte
                }
            }
        }

        /// <summary>
        /// Algoritmo de Boundary Fill con expansión radial (simulación de agua)
        /// </summary>
        /// <param name="bmp">Bitmap donde se realizará el relleno</param>
        /// <param name="x">Coordenada X del punto semilla</param>
        /// <param name="y">Coordenada Y del punto semilla</param>
        /// <param name="boundaryColor">Color del borde</param>
        /// <param name="fillColor">Color de relleno</param>
        /// <param name="onPixelFilled">Callback que se ejecuta por cada pixel rellenado</param>
        /// <param name="incluirDiagonales">Si incluir vecinos diagonales para expansión más suave</param>
        /// <returns>Lista de ondas con los puntos rellenados por cada expansión</returns>
        public static List<List<Point>> BoundaryFillRadial(Bitmap bmp, int x, int y, Color boundaryColor,
            Color fillColor, Action<Point, int> onPixelFilled = null, bool incluirDiagonales = true)
        {
            if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height)
                return new List<List<Point>>();

            Color targetColor = bmp.GetPixel(x, y);
            if (ColoresIguales(targetColor, boundaryColor) || ColoresIguales(targetColor, fillColor))
                return new List<List<Point>>();

            List<List<Point>> ondas = new List<List<Point>>();
            Queue<List<Point>> colaOndas = new Queue<List<Point>>();
            HashSet<Point> pixelesRellenados = new HashSet<Point>();

            // Inicializar con el punto semilla
            List<Point> primeraOnda = new List<Point> { new Point(x, y) };
            colaOndas.Enqueue(primeraOnda);

            int numeroOnda = 0;

            while (colaOndas.Count > 0)
            {
                List<Point> ondaActual = colaOndas.Dequeue();
                List<Point> pixelesOnda = new List<Point>();
                List<Point> siguienteOnda = new List<Point>();

                foreach (Point punto in ondaActual)
                {
                    if (punto.X < 0 || punto.Y < 0 || punto.X >= bmp.Width || punto.Y >= bmp.Height)
                        continue;

                    if (pixelesRellenados.Contains(punto))
                        continue;

                    Color colorActual = bmp.GetPixel(punto.X, punto.Y);

                    if (!ColoresIguales(colorActual, boundaryColor) && !ColoresIguales(colorActual, fillColor))
                    {
                        // Rellenar el pixel
                        bmp.SetPixel(punto.X, punto.Y, fillColor);
                        pixelesRellenados.Add(punto);
                        pixelesOnda.Add(punto);

                        // Ejecutar callback si existe
                        onPixelFilled?.Invoke(punto, numeroOnda);

                        // Obtener vecinos
                        List<Point> vecinos = ObtenerVecinos(punto, incluirDiagonales);

                        foreach (Point vecino in vecinos)
                        {
                            if (!pixelesRellenados.Contains(vecino) &&
                                vecino.X >= 0 && vecino.Y >= 0 &&
                                vecino.X < bmp.Width && vecino.Y < bmp.Height)
                            {
                                Color colorVecino = bmp.GetPixel(vecino.X, vecino.Y);
                                if (!ColoresIguales(colorVecino, boundaryColor) &&
                                    !ColoresIguales(colorVecino, fillColor))
                                {
                                    if (!siguienteOnda.Contains(vecino))
                                        siguienteOnda.Add(vecino);
                                }
                            }
                        }
                    }
                }

                if (pixelesOnda.Count > 0)
                {
                    ondas.Add(pixelesOnda);
                    numeroOnda++;
                }

                if (siguienteOnda.Count > 0)
                {
                    colaOndas.Enqueue(siguienteOnda);
                }
            }

            return ondas;
        }

        /// <summary>
        /// Obtiene los vecinos de un punto
        /// </summary>
        /// <param name="punto">Punto central</param>
        /// <param name="incluirDiagonales">Si incluir vecinos diagonales</param>
        /// <returns>Lista de puntos vecinos</returns>
        private static List<Point> ObtenerVecinos(Point punto, bool incluirDiagonales)
        {
            List<Point> vecinos = new List<Point>
            {
                // Vecinos cardinales (4 direcciones)
                new Point(punto.X + 1, punto.Y), // Este
                new Point(punto.X - 1, punto.Y), // Oeste
                new Point(punto.X, punto.Y + 1), // Sur
                new Point(punto.X, punto.Y - 1)  // Norte
            };

            if (incluirDiagonales)
            {
                // Vecinos diagonales
                vecinos.AddRange(new[]
                {
                    new Point(punto.X + 1, punto.Y + 1), // Sureste
                    new Point(punto.X - 1, punto.Y + 1), // Suroeste
                    new Point(punto.X + 1, punto.Y - 1), // Noreste
                    new Point(punto.X - 1, punto.Y - 1)  // Noroeste
                });
            }

            return vecinos;
        }

        /// <summary>
        /// Compara si dos colores son iguales
        /// </summary>
        /// <param name="a">Color A</param>
        /// <param name="b">Color B</param>
        /// <returns>True si son iguales</returns>
        private static bool ColoresIguales(Color a, Color b)
        {
            return a.ToArgb() == b.ToArgb();
        }

        /// <summary>
        /// Calcula la distancia euclidiana entre dos puntos
        /// </summary>
        /// <param name="p1">Punto 1</param>
        /// <param name="p2">Punto 2</param>
        /// <returns>Distancia euclidiana</returns>
        public static double DistanciaEuclidiana(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Verifica si un punto está dentro de los límites del bitmap
        /// </summary>
        /// <param name="punto">Punto a verificar</param>
        /// <param name="ancho">Ancho del bitmap</param>
        /// <param name="alto">Alto del bitmap</param>
        /// <returns>True si está dentro de los límites</returns>
        public static bool PuntoEnLimites(Point punto, int ancho, int alto)
        {
            return punto.X >= 0 && punto.Y >= 0 && punto.X < ancho && punto.Y < alto;
        }
    }
}