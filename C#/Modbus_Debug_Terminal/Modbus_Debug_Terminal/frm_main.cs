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
            if (!RS232_Minimal.IsOpen) return;
            
            if (RS232_Minimal.received)
            {
                txt_receive_count.Text = msg.count.ToString();
                RS232_Minimal.received = false;
                string s=  client.Get_String(RS232_Minimal.bfr_rx, RS232_Minimal.ptr_rx);
                msg.push(s);
                RS232_Minimal.purge();
            }
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

        private void chk_top_CheckedChanged(object sender, EventArgs e)
        {          
           msg.top = chk_top.Checked; 
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer_data_read.Enabled=false;
                msg.Find_String(txt_search.Text);   
            }
        }

        private void chk_same_msg_CheckedChanged(object sender, EventArgs e)
        {
            msg.repeat_same_message = chk_same_msg.Checked; 
        }

        private void chk_do_not_process_CRC_CheckedChanged(object sender, EventArgs e)
        {
            client.Check_CRC=chk_do_not_process_CRC.Checked;
        }
    }
}
