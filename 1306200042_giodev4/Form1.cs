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

        public Graphics g;
        private MatrixOperations operations;
        public double[] arr =
            {
                -100, -100, -100, 100, -100, -100, 100, 100, -100, -100, 100, -100, -100, -100, 100, 100, -100, 100, 100, 100, 100, -100, 100, 100
            };
        public Form1()
        {
            InitializeComponent();
            operations = new MatrixOperations();
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
            if (e.Graphics != null)
                DrawCube(e, arr);

        }
        public void ResetCube()
        {
            arr = new double[]
            {
                -100, -100, -100, 100, -100, -100, 100, 100, -100, -100, 100, -100, -100, -100, 100, 100, -100, 100, 100, 100, 100, -100, 100, 100

            };
            trackBar1.Value=0;
            trackBar2.Value=0;
            trackBar3.Value=0;
            trackBar4.Value=0;
            trackBar5.Value=0;
            trackBar6.Value=0;
            trackBar7.Value=0;
            trackBar8.Value=0;
            trackBar9.Value=0;
           
        }

        public void DrawCube(PaintEventArgs e, double[] arr)
        {
            if (arr.Length != 24)
            {
                throw new ArgumentException("Array length must be 24 for 8 points in 3D space.");
            }

            Graphics g = e.Graphics;

            // Define the cube's corner coordinates
            int numPoints = arr.Length / 3;
            Point3D[] points = new Point3D[numPoints];

            for (int i = 0; i < numPoints; i++)
            {
                points[i] = new Point3D(arr[i * 3], arr[i * 3 + 1], arr[i * 3 + 2]);
            }

            // Convert 3D points to 2D points
            Point[] points2D = new Point[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                points2D[i] = points[i].To2D();
            }

            // Define the edges of the cube by indices into points2D
            int[,] edges = new int[,]
            {
        {0, 1}, {1, 2}, {2, 3}, {3, 0}, // Bottom face edges
        {4, 5}, {5, 6}, {6, 7}, {7, 4}, // Top face edges
        {0, 4}, {1, 5}, {2, 6}, {3, 7}  // Vertical edges
            };

            // Draw the edges
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    int startIdx = edges[i, 0];
                    int endIdx = edges[i, 1];
                    g.DrawLine(pen, points2D[startIdx], points2D[endIdx]);
                }
            }
        }


        public void Tumislevler()
        {

            double Xd = Convert.ToDouble(trackBar1.Value);
            double Yd = Convert.ToDouble(trackBar2.Value);
            double Zd = Convert.ToDouble(trackBar3.Value);
            double a = Convert.ToDouble(trackBar4.Value);
            double b = Convert.ToDouble(trackBar5.Value);
            double c = Convert.ToDouble(trackBar6.Value);
            double d = Convert.ToDouble(trackBar7.Value);
            double e = Convert.ToDouble(trackBar8.Value);
            double f = Convert.ToDouble(trackBar9.Value);


            for (int i = 0; i < arr.Length; i += 3)
            {
                double[,] tempResult = operations.DondurmeX(arr[i], arr[i + 1], arr[i + 2], Xd);
                arr[i] = tempResult[0, 0];
                arr[i + 1] = tempResult[1, 0];
                arr[i + 2] = tempResult[2, 0];
            }


            for (int i = 0; i < arr.Length; i += 3)
            {
                double[,] tempResult = operations.DondurmeY(arr[i], arr[i + 1], arr[i + 2], Yd);
                arr[i] = tempResult[0, 0];
                arr[i + 1] = tempResult[1, 0];
                arr[i + 2] = tempResult[2, 0];
            }

            // Rotation around Z-axis
            for (int i = 0; i < arr.Length; i += 3)
            {
                double[,] tempResult = operations.DondurmeZ(arr[i], arr[i + 1], arr[i + 2], Zd);
                arr[i] = tempResult[0, 0];
                arr[i + 1] = tempResult[1, 0];
                arr[i + 2] = tempResult[2, 0];
            }




            arr[0] = operations.Oteleme(arr[0], arr[1], arr[2], a, b, c)[0, 0];
            arr[1] = operations.Oteleme(arr[0], arr[1], arr[2], a, b, c)[1, 0];
            arr[2] = operations.Oteleme(arr[0], arr[1], arr[2], a, b, c)[2, 0];
            arr[3] = operations.Oteleme(arr[3], arr[4], arr[5], a, b, c)[0, 0];
            arr[4] = operations.Oteleme(arr[3], arr[4], arr[5], a, b, c)[1, 0];
            arr[5] = operations.Oteleme(arr[3], arr[4], arr[5], a, b, c)[2, 0];
            arr[6] = operations.Oteleme(arr[6], arr[7], arr[8], a, b, c)[0, 0];
            arr[7] = operations.Oteleme(arr[6], arr[7], arr[8], a, b, c)[1, 0];
            arr[8] = operations.Oteleme(arr[6], arr[7], arr[8], a, b, c)[2, 0];
            arr[9] = operations.Oteleme(arr[9], arr[10], arr[11], a, b, c)[0, 0];
            arr[10] = operations.Oteleme(arr[9], arr[10], arr[11], a, b, c)[1, 0];
            arr[11] = operations.Oteleme(arr[9], arr[10], arr[11], a, b, c)[2, 0];
            arr[12] = operations.Oteleme(arr[12], arr[13], arr[14], a, b, c)[0, 0];
            arr[13] = operations.Oteleme(arr[12], arr[13], arr[14], a, b, c)[1, 0];
            arr[14] = operations.Oteleme(arr[12], arr[13], arr[14], a, b, c)[2, 0];
            arr[15] = operations.Oteleme(arr[15], arr[16], arr[17], a, b, c)[0, 0];
            arr[16] = operations.Oteleme(arr[15], arr[16], arr[17], a, b, c)[1, 0];
            arr[17] = operations.Oteleme(arr[15], arr[16], arr[17], a, b, c)[2, 0];
            arr[18] = operations.Oteleme(arr[18], arr[19], arr[20], a, b, c)[0, 0];
            arr[19] = operations.Oteleme(arr[18], arr[19], arr[20], a, b, c)[1, 0];
            arr[20] = operations.Oteleme(arr[18], arr[19], arr[20], a, b, c)[2, 0];
            arr[21] = operations.Oteleme(arr[21], arr[22], arr[23], a, b, c)[0, 0];
            arr[22] = operations.Oteleme(arr[21], arr[22], arr[23], a, b, c)[1, 0];
            arr[23] = operations.Oteleme(arr[21], arr[22], arr[23], a, b, c)[2, 0];
            if (d != 0 || e != 0 || f != 0)
            {
                arr[0] = operations.Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[0, 0];
                arr[1] = operations.Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[1, 0];
                arr[2] = operations.Olceklendirme(arr[0], arr[1], arr[2], d, e, f)[2, 0];
                arr[3] = operations.Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[0, 0];
                arr[4] = operations.Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[1, 0];
                arr[5] = operations.Olceklendirme(arr[3], arr[4], arr[5], d, e, f)[2, 0];
                arr[6] = operations.Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[0, 0];
                arr[7] = operations.Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[1, 0];
                arr[8] = operations.Olceklendirme(arr[6], arr[7], arr[8], d, e, f)[2, 0];
                arr[9] = operations.Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[0, 0];
                arr[10] = operations.Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[1, 0];
                arr[11] = operations.Olceklendirme(arr[9], arr[10], arr[11], d, e, f)[2, 0];
                arr[12] = operations.Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[0, 0];
                arr[13] = operations.Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[1, 0];
                arr[14] = operations.Olceklendirme(arr[12], arr[13], arr[14], d, e, f)[2, 0];
                arr[15] = operations.Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[0, 0];
                arr[16] = operations.Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[1, 0];
                arr[17] = operations.Olceklendirme(arr[15], arr[16], arr[17], d, e, f)[2, 0];
                arr[18] = operations.Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[0, 0];
                arr[19] = operations.Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[1, 0];
                arr[20] = operations.Olceklendirme(arr[18], arr[19], arr[20], d, e, f)[2, 0];
                arr[21] = operations.Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[0, 0];
                arr[22] = operations.Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[1, 0];
                arr[23] = operations.Olceklendirme(arr[21], arr[22], arr[23], d, e, f)[2, 0];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tumislevler();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetCube();
            Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "X: "+ trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Y: "+ trackBar2.Value.ToString();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Z: "+trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label8.Text = "X: "+ trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label7.Text = "Y: "+ trackBar5.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Z: " + trackBar6.Value.ToString();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            label13.Text = "X: " + trackBar7.Value.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            label12.Text = "Y: "+trackBar8.Value.ToString();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            label11.Text = "Z: "+ trackBar9.Value.ToString();
        }
    }


}
