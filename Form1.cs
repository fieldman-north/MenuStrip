using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStrip
{
    public partial class Form1 : Form
    {
        private bool BtnStat;
        string[] serialPorts;
      public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                if (comboBox1.Items.Count > 0)
                {
                    BtnStat = true;

                    System.IO.Ports.SerialPort serialPort1;
                    //System.ComponentModel.IContainer components = new System.ComponentModel.Container(); // <-- ЭТО ЧТО ЗА СТРАШНЫЙ ЗВЕРЬ??? и на хрено оно нужно?;
                    serialPort1 = new System.IO.Ports.SerialPort(components);
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                }
                else
                {
                    MessageBox.Show("Выберите COM порт.");
                    BtnStat = false;
                }
                // цветовая обработка события и название кнопки
                if (BtnStat == false)
                {
                    button1.Text = "Открыть";
                    button1.BackColor = Color.LightGray;
                }
                else
                {
                    button1.Text = "Закрыть";
                    button1.BackColor = Color.Lime;
                }


            }
        }
            private void Form1_Load(object sender, EventArgs e)
            {
            //
            try
            {
                this.serialPorts = SerialPort.GetPortNames();
                comboBox1.Items.AddRange(items: serialPorts);
            }
                catch (Win32Exception) { }

            comboBox2.SelectedIndex = 9;   // устанавливаю на комбобоксе2 скорость по умолчанию 9600 (9ю строку)
            if (comboBox1.Items.Count!=0) { comboBox1.SelectedIndex = 0; } //устанавливаю COM порт, первый по списку.
            }

    }
}
