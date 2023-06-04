using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_graficos
{
    public partial class Form2 : Form
    {
        private int value;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) 
        {
            while (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
            {
                string serialData=serialPort1.ReadLine();
                int value = Convert.ToInt32(serialData); 
            }
            chart1.Invoke((MethodInvoker)(() => chart1.Series["Sensor Datos"].Points.AddY(value)));
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosing(object sender, EventArgs e) 
        { 
        if (serialPort1.IsOpen) 
            {
                serialPort1.Close();
            }
        }
    }
}
