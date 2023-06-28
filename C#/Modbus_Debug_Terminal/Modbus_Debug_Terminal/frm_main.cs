using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;

namespace Modbus_Debug_Terminal
{
    public partial class frm_main : Form
    {
        MSG msg;
        ModbusRtuClient client;
        string msg_prev = "";
        int msg_repeat_count = 0;
       
        public frm_main()
        {
            InitializeComponent();
            msg = new MSG(lst_msg);
            client=new ModbusRtuClient(Convert.ToByte(txt_device_ID.Text),0xff);
 

        }

        private void frm_main_Load(object sender, EventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            RS232_Minimal.open(txt_port.Text, Convert.ToInt16(txt_baud_rate.Text));
            if (RS232_Minimal.IsOpen)
            {
                btn_connect.BackColor = Color.Green;
            }
            else
            {
                btn_connect.BackColor = Color.Gray;
                msg.push("Unable to Open device");
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            RS232_Minimal.close();
            msg.push("Port Closed");
        }

        private void timer_data_read_Tick(object sender, EventArgs e)
        {
           // if (!RS232_Minimal.IsOpen) return;

            byte[] b=new byte[100];

            b[0] = 200;
            b[1] = 0x10;

            b[2] = 0x00;
            b[3] =0x00;

            b[4] =0x00;
            b[5] =0x05;

            b[6] =0x0A;

            b[7] = 0;
            b[8] = 1;
            b[9] = 2;
            b[10] = 3;
            b[11] = 4;
            b[12] = 5;
            b[13] = 6;
            b[14] = 7;
            b[15] = 8;
            b[16] = 9;
            b[17] = 0x83;
            b[18] = 0xD4;

            for (int i = 0; i < 19; i++) 
            {
                RS232_Minimal.bfr_rx[i] = b[i];
            }
            RS232_Minimal.ptr_rx = 19;
          //  if (RS232_Minimal.received)
          //  {
              string s=  client.Get_String(RS232_Minimal.bfr_rx, RS232_Minimal.ptr_rx);
              if(msg_prev !=s)
                {
                    msg.push(s);
                    msg_prev = s;
                    msg_repeat_count = 0;
                }
                else
                {
                    msg_repeat_count++;
                    msg.Update_first_line(s+"-"+msg_repeat_count.ToString());
                }
                
          //  }
        }

        private void tb_font_size_Scroll(object sender, EventArgs e)
        {
           
        }

        private void btn_start_reading_Click(object sender, EventArgs e)
        {
            timer_data_read.Enabled = true;
        }

        private void btn_stop_reading_Click(object sender, EventArgs e)
        {
            timer_data_read.Enabled = false;
        }
    }
}
