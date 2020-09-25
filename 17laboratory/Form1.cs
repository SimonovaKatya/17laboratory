using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17laboratory
{
    public partial class Form1 : Form
    {

        int n;
        List<double> first = new List<double>();
        List<double> third = new List<double>();

        List<double> lenght1 = new List<double>();

        List<double> lenght3 = new List<double>();

        int i;
        Random rnd = new Random();
        double lamda1;
        double lamda2;
        double lamda3;
        double price1 = 0;
        double price2 = 0;
        double price3 = 0;

        public Form1()
        {
            InitializeComponent();
        }

      
        private void button_Start_Click(object sender, EventArgs e)
        {

            lamda1 = Convert.ToDouble(textBox_lamda1.Text);
            lamda2 = Convert.ToDouble(textBox_lamda2.Text);
            lamda3 = lamda1 + lamda2;

            price1 = 0;
            price2 = 0;
            price3 = 0;
            i = 0;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            n = Convert.ToInt32(textBox_Num.Text);
            chart1.ChartAreas[0].AxisX.Maximum = n;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;


            chart1.Series[0].Points.AddXY(price1, 0);
            chart1.Series[1].Points.AddXY(price2, 0);

            first.Add(price1);
            third.Add(price3);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double r = rnd.NextDouble();
            double a = -1 * (Math.Log(r) / lamda1);
            double b = -1 * (Math.Log(r) / lamda2);
            double c = -1 * (Math.Log(r) / lamda3);

            price1 = price1 + a;
            price2 = price2 + b;
            price3 = price3 + c;

            if (price1 > price2)
            {
                first.Add(price2);
                first.Add(price1);

            }
            else
            {
                first.Add(price1);
                first.Add(price2);

            }

            double eqq = third[third.Count - 1];
            third.Add(price3);
            lenght3.Add(price3 - eqq);

            chart1.Series[0].Points.AddXY(price1, 0);
            chart1.Series[1].Points.AddXY(price2, 0);
            chart1.Series[1].Color = Color.Red;

            i++;
            if (i - 1 == n)
            {
                timer1.Stop();
            }
        }
    }
}
