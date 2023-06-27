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

            if(RS232_Minimal.received)
            {
                client.purse_packet(RS232_Minimal.bfr_rx, RS232_Minimal.ptr_rx);
            }



        }
    }
}
