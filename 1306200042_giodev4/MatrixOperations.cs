using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1306200042_giodev4
{
    internal class MatrixOperations
    {
        public double[,] Olceklendirme(double x, double y, double z, double a, double f, double k)
        {
            double[,] matrixA = new double[4, 4] { { x, 0, 0, 0 }, { 0, y, 0, 0 }, { 0, 0, z, 0 }, { 0, 0, 0, 1 } };

            // 4x1 boyutunda bir matris tanımlama
            double[,] matrixB = new double[4, 1] { { a }, { f }, { k }, { 1 } };

            // Matrisleri çarpma
            double[,] resultMatrix = new double[4, 1];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += matrixA[i, j] * matrixB[j, 0];
                }
                resultMatrix[i, 0] = sum;
            }
            return resultMatrix;
        }
        public double[,] Oteleme(double x, double y, double z, double a, double f, double k)
        {
            double[,] matrixA = new double[4, 4] { { 1, 0, 0, x }, { 0, 1, 0, y }, { 0, 0, 1, z }, { 0, 0, 0, 1 } };

            // 4x1 boyutunda bir matris tanımlama
            double[,] matrixB = new double[4, 1] { { a }, { f }, { k }, { 1 } };

            // Matrisleri çarpma
            double[,] resultMatrix = new double[4, 1];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += matrixA[i, j] * matrixB[j, 0];
                }
                resultMatrix[i, 0] = sum;
            }
            return resultMatrix;
        }
        public double[,] DondurmeZ(double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { Math.Cos(teta), -1 * Math.Sin(teta), 0, 0 }, { Math.Sin(teta), Math.Cos(teta), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            // 4x1 boyutunda bir matris tanımlama
            double[,] matrixB = new double[4, 1] { { a }, { f }, { k }, { 1 } };

            // Matrisleri çarpma
            double[,] resultMatrix = new double[4, 1];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += matrixA[i, j] * matrixB[j, 0];
                }
                resultMatrix[i, 0] = sum;
            }
            return resultMatrix;
        }

        public double[,] DondurmeX(double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(teta), -1 * Math.Sin(teta), 0 }, { 0, Math.Sin(teta), Math.Cos(teta), 0 }, { 0, 0, 0, 1 } };

            // 4x1 boyutunda bir matris tanımlama
            double[,] matrixB = new double[4, 1] { { a }, { f }, { k }, { 1 } };

            // Matrisleri çarpma
            double[,] resultMatrix = new double[4, 1];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += matrixA[i, j] * matrixB[j, 0];
                }
                resultMatrix[i, 0] = sum;
            }
            return resultMatrix;
        }
        public double[,] DondurmeY(double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { Math.Cos(teta), 0, Math.Sin(teta), 0 }, { 0, 1, 0, 0 }, { -1 * Math.Sin(teta), 0, Math.Cos(teta), 0 }, { 0, 0, 0, 1 } };

            // 4x1 boyutunda bir matris tanımlama
            double[,] matrixB = new double[4, 1] { { a }, { f }, { k }, { 1 } };

            // Matrisleri çarpma
            double[,] resultMatrix = new double[4, 1];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += matrixA[i, j] * matrixB[j, 0];
                }
                resultMatrix[i, 0] = sum;
            }
            return resultMatrix;
        }
    }
}
