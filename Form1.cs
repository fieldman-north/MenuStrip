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
            BtnStat = !BtnStat;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //string[] serialPorts;
            try
            {
                // Get a list of serial port names.
              this.serialPorts = SerialPort.GetPortNames();
                comboBox1.Items.AddRange(items: serialPorts);
            }
            catch (Win32Exception)
            {
                
            }

        }
    }
}
