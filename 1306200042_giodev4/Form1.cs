using System.Windows.Forms;
using System;
using System.Drawing;
using System.Runtime.Serialization;

//////////////////////////
/// Muhammet Sezgin
/// Görüntü İşleme Ödev 4
//////////////////////////

namespace _1306200042_giodev4
{


    // Döndürme fonksiyonu verdiğiniz matrislere uygun olarak yapıldı ama bazı sorunlar var. Sorun çizme fonksiyonumdan kaynaklanıyor olabilir. 
   
    public partial class Form1 : Form
    {

        Graphics g;
        double[] arr =
            {
                -100, -100, -100, 100, -100, -100, 100, 100, -100, -100, 100, -100, -100, -100, 100, 100, -100, 100, 100, 100, 100, -100, 100, 100
            };
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(e.Graphics!=null)
            DrawCube(e, arr);

        }

        public void DrawCube(PaintEventArgs e, double[] arr)
        {

            g=e.Graphics;
          
            Pen pen = new Pen(Color.Black, 2);

            // Küpün köşe koordinatlarını tanımlama
            Point3D[] points = new Point3D[8];

            points[0] = new Point3D(arr[0], arr[1], arr[2]);
            points[1] = new Point3D(arr[3], arr[4], arr[5]);
            points[2] = new Point3D(arr[6], arr[7], arr[8]);
            points[3] = new Point3D(arr[9], arr[10], arr[11]);
            points[4] = new Point3D(arr[12], arr[13], arr[14]);
            points[5] = new Point3D(arr[15], arr[16], arr[17]);
            points[6] = new Point3D(arr[18], arr[19], arr[20]);
            points[7] = new Point3D(arr[21], arr[22], arr[23]);

            // Küpün köşe koordinatlarını 2D noktalara dönüştürme
            Point[] points2D = new Point[8];
            for (int i = 0; i < points.Length; i++)
            {
                points2D[i] = points[i].To2D();
            }

            // Köşeleri birleştirerek küpü çizme
            g.DrawLine(pen, points2D[0], points2D[1]);
            g.DrawLine(pen, points2D[1], points2D[2]);
            g.DrawLine(pen, points2D[2], points2D[3]);
            g.DrawLine(pen, points2D[3], points2D[0]);
            g.DrawLine(pen, points2D[4], points2D[5]);
            g.DrawLine(pen, points2D[5], points2D[6]);
            g.DrawLine(pen, points2D[6], points2D[7]);
            g.DrawLine(pen, points2D[7], points2D[4]);
            g.DrawLine(pen, points2D[0], points2D[4]);
            g.DrawLine(pen, points2D[1], points2D[5]);
            g.DrawLine(pen, points2D[2], points2D[6]);
            g.DrawLine(pen, points2D[3], points2D[7]);
            
        }

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
        public double[,] DondurmeZ( double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { Math.Cos(teta), -1*Math.Sin(teta), 0, 0 }, { Math.Sin(teta), Math.Cos(teta), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

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
       
        public double[,] DondurmeX( double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(teta), -1*Math.Sin(teta), 0 }, { 0, Math.Sin(teta), Math.Cos(teta), 0 }, { 0, 0, 0, 1 } };

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
        public double[,] DondurmeY( double a, double f, double k, double teta)
        {
            double[,] matrixA = new double[4, 4] { { Math.Cos(teta), 0, Math.Sin(teta), 0 }, { 0, 1, 0, 0 }, {-1* Math.Sin(teta), 0, Math.Cos(teta), 0 }, { 0, 0, 0, 1 } };

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


        public void Tumislevler()
        {

           double Xd = Convert.ToDouble(textBox1.Text);
           double Yd = Convert.ToDouble(textBox2.Text);
           double Zd = Convert.ToDouble(textBox3.Text);
           double a= Convert.ToDouble(textBox4.Text);
           double b= Convert.ToDouble(textBox5.Text);  
           double c= Convert.ToDouble(textBox6.Text);  
           double d= Convert.ToDouble(textBox7.Text); 
           double e= Convert.ToDouble(textBox8.Text);
           double f= Convert.ToDouble(textBox9.Text);

       
                arr[0] = DondurmeX(arr[0], arr[1], arr[2], Xd)[0, 0];
                arr[1] = DondurmeX(arr[0], arr[1], arr[2], Xd)[1, 0];
                arr[2] = DondurmeX(arr[0], arr[1], arr[2], Xd)[2, 0];
                arr[3] = DondurmeX(arr[3], arr[4], arr[5], Xd)[0, 0];
                arr[4] = DondurmeX(arr[3], arr[4], arr[5], Xd)[1, 0];
                arr[5] = DondurmeX(arr[3], arr[4], arr[5], Xd)[2, 0];
                arr[6] = DondurmeX(arr[6], arr[7], arr[8], Xd)[0, 0];
                arr[7] = DondurmeX(arr[6], arr[7], arr[8], Xd)[1, 0];
                arr[8] = DondurmeX(arr[6], arr[7], arr[8], Xd)[2, 0];
                arr[9] = DondurmeX(arr[9], arr[10], arr[11], Xd)[0, 0];
                arr[10] = DondurmeX(arr[9], arr[10], arr[11], Xd)[1, 0];
                arr[11] = DondurmeX(arr[9], arr[10], arr[11], Xd)[2, 0];
                arr[12] = DondurmeX(arr[12], arr[13], arr[14], Xd)[0, 0];
                arr[13] = DondurmeX(arr[12], arr[13], arr[14], Xd)[1, 0];
                arr[14] = DondurmeX(arr[12], arr[13], arr[14], Xd)[2, 0];
                arr[15] = DondurmeX(arr[15], arr[16], arr[17], Xd)[0, 0];
                arr[16] = DondurmeX(arr[15], arr[16], arr[17], Xd)[1, 0];
                arr[17] = DondurmeX(arr[15], arr[16], arr[17], Xd)[2, 0];
                arr[18] = DondurmeX(arr[18], arr[19], arr[20], Xd)[0, 0];
                arr[19] = DondurmeX(arr[18], arr[19], arr[20], Xd)[1, 0];
                arr[20] = DondurmeX(arr[18], arr[19], arr[20], Xd)[2, 0];
                arr[21] = DondurmeX(arr[21], arr[22], arr[23], Xd)[0, 0];
                arr[22] = DondurmeX(arr[21], arr[22], arr[23], Xd)[1, 0];
                arr[23] = DondurmeX(arr[21], arr[22], arr[23], Xd)[2, 0];
            
           
                arr[0] = DondurmeY(arr[0], arr[1], arr[2], Yd)[0, 0];
                arr[1] = DondurmeY(arr[0], arr[1], arr[2], Yd)[1, 0];
                arr[2] = DondurmeY(arr[0], arr[1], arr[2], Yd)[2, 0];
                arr[3] = DondurmeY(arr[3], arr[4], arr[5], Yd)[0, 0];
                arr[4] = DondurmeY(arr[3], arr[4], arr[5], Yd)[1, 0];
                arr[5] = DondurmeY(arr[3], arr[4], arr[5], Yd)[2, 0];
                arr[6] = DondurmeY(arr[6], arr[7], arr[8], Yd)[0, 0];
                arr[7] = DondurmeY(arr[6], arr[7], arr[8], Yd)[1, 0];
                arr[8] = DondurmeY(arr[6], arr[7], arr[8], Yd)[2, 0];
                arr[9] = DondurmeY(arr[9], arr[10], arr[11], Yd)[0, 0];
                arr[10] = DondurmeY(arr[9], arr[10], arr[11], Yd)[1, 0];
                arr[11] = DondurmeY(arr[9], arr[10], arr[11], Yd)[2, 0];
                arr[12] = DondurmeY(arr[12], arr[13], arr[14], Yd)[0, 0];
                arr[13] = DondurmeY(arr[12], arr[13], arr[14], Yd)[1, 0];
                arr[14] = DondurmeY(arr[12], arr[13], arr[14], Yd)[2, 0];
                arr[15] = DondurmeY(arr[15], arr[16], arr[17], Yd)[0, 0];
                arr[16] = DondurmeY(arr[15], arr[16], arr[17], Yd)[1, 0];
                arr[17] = DondurmeY(arr[15], arr[16], arr[17], Yd)[2, 0];
                arr[18] = DondurmeY(arr[18], arr[19], arr[20], Yd)[0, 0];
                arr[19] = DondurmeY(arr[18], arr[19], arr[20], Yd)[1, 0];
                arr[20] = DondurmeY(arr[18], arr[19], arr[20], Yd)[2, 0];
                arr[21] = DondurmeY(arr[21], arr[22], arr[23], Yd)[0, 0];
                arr[22] = DondurmeY(arr[21], arr[22], arr[23], Yd)[1, 0];
                arr[23] = DondurmeY(arr[21], arr[22], arr[23], Yd)[2, 0];
            


          
                arr[0] = DondurmeZ(arr[0], arr[1], arr[2], Zd)[0, 0];
                arr[1] = DondurmeZ(arr[0], arr[1], arr[2], Zd)[1, 0];
                arr[2] = DondurmeZ(arr[0], arr[1], arr[2], Zd)[2, 0];
                arr[3] = DondurmeZ(arr[3], arr[4], arr[5], Zd)[0, 0];
                arr[4] = DondurmeZ(arr[3], arr[4], arr[5], Zd)[1, 0];
                arr[5] = DondurmeZ(arr[3], arr[4], arr[5], Zd)[2, 0];
                arr[6] = DondurmeZ(arr[6], arr[7], arr[8], Zd)[0, 0];
                arr[7] = DondurmeZ(arr[6], arr[7], arr[8], Zd)[1, 0];
                arr[8] = DondurmeZ(arr[6], arr[7], arr[8], Zd)[2, 0];
                arr[9] = DondurmeZ(arr[9], arr[10], arr[11], Zd)[0, 0];
                arr[10] = DondurmeZ(arr[9], arr[10], arr[11], Zd)[1, 0];
                arr[11] = DondurmeZ(arr[9], arr[10], arr[11], Zd)[2, 0];
                arr[12] = DondurmeZ(arr[12], arr[13], arr[14], Zd)[0, 0];
                arr[13] = DondurmeZ(arr[12], arr[13], arr[14], Zd)[1, 0];
                arr[14] = DondurmeZ(arr[12], arr[13], arr[14], Zd)[2, 0];
                arr[15] = DondurmeZ(arr[15], arr[16], arr[17], Zd)[0, 0];
                arr[16] = DondurmeZ(arr[15], arr[16], arr[17], Zd)[1, 0];
                arr[17] = DondurmeZ(arr[15], arr[16], arr[17], Zd)[2, 0];
                arr[18] = DondurmeZ(arr[18], arr[19], arr[20], Zd)[0, 0];
                arr[19] = DondurmeZ(arr[18], arr[19], arr[20], Zd)[1, 0];
                arr[20] = DondurmeZ(arr[18], arr[19], arr[20], Zd)[2, 0];
                arr[21] = DondurmeZ(arr[21], arr[22], arr[23], Zd)[0, 0];
                arr[22] = DondurmeZ(arr[21], arr[22], arr[23], Zd)[1, 0];
                arr[23] = DondurmeZ(arr[21], arr[22], arr[23], Zd)[2, 0];
            

            
            
                arr[0] = Oteleme(arr[0], arr[1], arr[2], a, b, c)[0, 0];
                arr[1] = Oteleme(arr[0], arr[1], arr[2], a, b, c)[1, 0];
                arr[2] = Oteleme(arr[0], arr[1], arr[2], a, b, c)[2, 0];
                arr[3] = Oteleme(arr[3], arr[4], arr[5], a, b, c)[0, 0];
                arr[4] = Oteleme(arr[3], arr[4], arr[5], a, b, c)[1, 0];
                arr[5] = Oteleme(arr[3], arr[4], arr[5], a, b, c)[2, 0];
                arr[6] = Oteleme(arr[6], arr[7], arr[8], a, b, c)[0, 0];
                arr[7] = Oteleme(arr[6], arr[7], arr[8], a, b, c)[1, 0];
                arr[8] = Oteleme(arr[6], arr[7], arr[8], a, b, c)[2, 0];
                arr[9] = Oteleme(arr[9], arr[10], arr[11], a, b, c)[0, 0];
                arr[10] = Oteleme(arr[9], arr[10], arr[11], a, b, c)[1, 0];
                arr[11] = Oteleme(arr[9], arr[10], arr[11], a, b, c)[2, 0];
                arr[12] = Oteleme(arr[12], arr[13], arr[14], a, b, c)[0, 0];
                arr[13] = Oteleme(arr[12], arr[13], arr[14], a, b, c)[1, 0];
                arr[14] = Oteleme(arr[12], arr[13], arr[14], a, b, c)[2, 0];
                arr[15] = Oteleme(arr[15], arr[16], arr[17], a, b, c)[0, 0];
                arr[16] = Oteleme(arr[15], arr[16], arr[17], a, b, c)[1, 0];
                arr[17] = Oteleme(arr[15], arr[16], arr[17], a, b, c)[2, 0];
                arr[18] = Oteleme(arr[18], arr[19], arr[20], a, b, c)[0, 0];
                arr[19] = Oteleme(arr[18], arr[19], arr[20], a, b, c)[1, 0];
                arr[20] = Oteleme(arr[18], arr[19], arr[20], a, b, c)[2, 0];
                arr[21] = Oteleme(arr[21], arr[22], arr[23], a, b, c)[0, 0];
                arr[22] = Oteleme(arr[21], arr[22], arr[23], a, b, c)[1, 0];
                arr[23] = Oteleme(arr[21], arr[22], arr[23], a, b, c)[2, 0];
            if (d != 0 || e != 0 || f != 0)
            {
                arr[0] = Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[0, 0];
                arr[1] = Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[1, 0];
                arr[2] = Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[2, 0];
                arr[3] = Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[0, 0];
                arr[4] = Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[1, 0];
                arr[5] = Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[2, 0];
                arr[6] = Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[0, 0];
                arr[7] = Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[1, 0];
                arr[8] = Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[2, 0];
                arr[9] = Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[0, 0];
                arr[10] = Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[1, 0];
                arr[11] = Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[2, 0];
                arr[12] = Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[0, 0];
                arr[13] = Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[1, 0];
                arr[14] = Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[2, 0];
                arr[15] = Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[0, 0];
                arr[16] = Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[1, 0];
                arr[17] = Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[2, 0];
                arr[18] = Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[0, 0];
                arr[19] = Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[1, 0];
                arr[20] = Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[2, 0];
                arr[21] = Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[0, 0];
                arr[22] = Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[1, 0];
                arr[23] = Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[2, 0];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tumislevler();
            Refresh();
        }
      

    }

    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

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
            int screenX = (int)(x + 1129 / 2);
            int screenY = (int)(724 / 2 - y);
            return new Point(screenX, screenY);
        }
      
    }
}
