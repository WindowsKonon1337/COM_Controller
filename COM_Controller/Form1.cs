using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace COM_Controller
{
    public partial class Form1 : Form
    {
        public static List<string> data = new List<string>{ "0", "0", "0", "0", "0", "additional" }; //  <servo>:<red>:<green>:<blue>:<orange>:<additional>

        public void GetAvaliablePorts()
        {
            var ports =  SerialPort.GetPortNames().ToList();

            if (ports.Count != 0)
            {
                foreach (var port in ports)
                {
                    checkedListBox1.Items.Add(port.ToString());
                }
            }
            else
            {
                MessageBox.Show("Нет свободных портов :(");
            }
        }

        public void SendData()
        {
            try
            {
                var ports = checkedListBox1.CheckedItems;
                if (ports.Count != 1)
                {
                    MessageBox.Show("Выберите один порт");
                    return;
                }

                var serialPort = new SerialPort(ports[0].ToString());
                serialPort.BaudRate = 9600;
                serialPort.Open();
                serialPort.Write(textBox1.Text.ToString());
                serialPort.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Что-то не так:\n" + ex.Message.ToString());
            }

        }

        public Form1()
        {
            InitializeComponent();
            GetAvaliablePorts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            var value = trackBar1.Value.ToString();
            textBox2.Text = value;
            data[0] = value;
            textBox1.Text = string.Join(":", data);

            if (!checkBox1.Checked)
                SendData();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            var value = trackBar2.Value.ToString();
            data[1] = value;
            textBox1.Text = string.Join(":", data);

            if (!checkBox1.Checked)
                SendData();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            var value = trackBar3.Value.ToString();
            data[2] = value;
            textBox1.Text = string.Join(":", data);

            if (!checkBox1.Checked)
                SendData();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            var value = trackBar4.Value.ToString();
            data[3] = value;
            textBox1.Text = string.Join(":", data);

            if (!checkBox1.Checked)
                SendData();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            var value = trackBar5.Value.ToString();
            data[4] = value;
            textBox1.Text = string.Join(":", data);

            if (!checkBox1.Checked)
                SendData();
        }
    }
}
