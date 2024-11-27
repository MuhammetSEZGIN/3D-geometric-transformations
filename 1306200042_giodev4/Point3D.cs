using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1306200042_giodev4
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        private const int WindowSizeX= 1129;

        private const int WindowSizeY= 724;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // 3D noktayı 2D noktaya dönüştürme
        public Point To2D()
        {
            double fov = 1000;
            double z = 1 + (Z / fov);
            double x = X / z;
            double y = Y / z;

            // 2D noktayı oluşturma
            int screenX = (int)(x + WindowSizeX / 2);
            int screenY = (int)(WindowSizeY / 2 - y);
            return new Point(screenX, screenY);
        }

    }
}
