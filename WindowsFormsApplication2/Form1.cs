using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private static TcpClient client;
        private NetworkStream nwStream;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            ConnectClient(textBox1.Text);
          


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void ConnectClient(string machineName)
        {
           
            client = new TcpClient();
            try
            {
                client.Connect(machineName, 4000);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error in connection, verify your ip of GW",e.ToString());

            }
           
            if (client.Connected)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Enabled = true;
                button3.Enabled = true;

                nwStream = client.GetStream();
             
               

            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] msg = new byte[] { 0x0F, 0x00, 0x00, 0x32, 0x03, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x01 };
           
            nwStream.Write(msg, 0, msg.Length);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] msg = new byte[] { 0x0F, 0x00, 0x00, 0x32, 0x03, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00 };

            nwStream.Write(msg, 0, msg.Length);

        }
    }
}
