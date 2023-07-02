using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using System.Windows.Forms;

namespace Tools
{
    class ModbusRtuClient
    {
        public bool Check_CRC = false;
        public byte slave_addr = 1;
        public byte multicast_addr = 255;
        public byte slave_addr_rx;
        public byte function_code;
        public UInt16 starting_addr;
        public UInt16 reg16_count;
        public byte Byte_Count;
        public int crc_rx;

        public byte[] bfr_tx = new byte[1024];
        public UInt16[] Data = new UInt16[128];
        public int bfr_tx_ptr = 0;
      
        public ModbusRtuClient(byte sl_id, byte multi_addr)
        {
            this.slave_addr=sl_id;
            this.multicast_addr=multi_addr;
        }
       
        public bool healthy(byte[] pkt_rx)
        {
            char i, int_count;
            UInt16 temp;

            //<1>Check the packet is for myself
            if((pkt_rx[0] != slave_addr) && (pkt_rx[0] != multicast_addr)) return false;
            // if(pkt_rx[0] == 0) return false;
            //      if(pkt_rx[0] != multicast_addr) return false;

            //// <2> Check CRC is OK
            if (Check_CRC)
            {
                int crc_calc = Get_CRC(pkt_rx, pkt_rx.Length - 2);
                int crc_rx = utility.Get_Uint16(pkt_rx[pkt_rx.Length - 2], pkt_rx[pkt_rx.Length - 1]);
                if (crc_calc != crc_rx) return false;
            }
           
            return true;
        }

        public void purse_packet(byte[] b, int count)
        {
            slave_addr_rx = b[0];
            function_code = b[1];
            starting_addr=Get_Uint16_From_Byte(b,2);

            if (function_code==0x03) // read holding register
            {
                reg16_count = Get_Uint16_From_Byte(b, 4);
            }
            else if (function_code==0x06) // Write Single register
            {
              Data[0]= Get_Uint16_From_Byte(b, 4);
            }
            else if (function_code==0x10) // Write multiple register
            {
                reg16_count = Get_Uint16_From_Byte(b, 4);
                Byte_Count=b[6];

                int k = 0;
                int pos = 7;
                do
                {
                    Data[k]=Get_Uint16_From_Byte(b, pos);
                    pos +=2;
                    k++;
                } while (k !=reg16_count);
            }
            else
            {

            }
            crc_rx = Get_CRC(b, count-2);
        }

        public string Get_String(byte[] b, int count) 
        {
            string ret_str = "";
            int crc_calc, crc_rx;

            if (Check_CRC)
            {
                crc_calc = Get_CRC(b, count - 2);
                crc_rx = utility.Get_Uint16(b[count - 2], b[count - 1]);
                if (crc_calc != crc_rx) return "";
            }

            slave_addr_rx = b[0];
            function_code = b[1];
            starting_addr = Get_Uint16_From_Byte(b, 2);

            if (function_code == 0x03) // read holding register
            {
                reg16_count = Get_Uint16_From_Byte(b, 4);
            }
            else if (function_code == 0x06) // Write Single register
            {
                Data[0] = Get_Uint16_From_Byte(b, 4);
            }
            else if (function_code == 0x10) // Write multiple register
            {
            //    reg16_count = Get_Uint16_From_Byte(b, 4);
                Byte_Count = b[6];

                int k = 0;
                int pos = 7;
                do
                {
                    ret_str += (Convert.ToChar(b[pos])).ToString();
                    pos++;
                    k++;
                } while (k != Byte_Count);
            }
            else
            {

            }

            return ret_str;
        }
        //_________________________________________________________________________________________________________________________
        public void Prepare_Response_Packet_Header()
        {
            bfr_tx[0] = slave_addr;
            bfr_tx[1] = function_code;
            bfr_tx[2] =(byte)(reg16_count*2);
            bfr_tx_ptr = 3;
        }
        //_________________________________________________________________________________________________________________________
        public void Push(ref UInt16[] bfr)
        {
            int row = 0;
            int col = 1;
            for (int i = starting_addr; i < starting_addr+ reg16_count; i++)
            {
                //string val = dg[col, row].Value.ToString();
                //UInt16 k = Convert.ToUInt16(val);
                //col++;
                //if (col > 10)
                //{
                //    col = 1;
                //    row++;
                push_data(bfr[i]);
            }
                
          //  }
        }
        //_________________________________________________________________________________________________________________________
        public void push_data(UInt16 data)
        {
            byte lsb = (byte)data;
            data = (UInt16)(data >> 8);
            byte msb = (byte)data;
            bfr_tx[bfr_tx_ptr] = msb; bfr_tx_ptr++;
            bfr_tx[bfr_tx_ptr] = lsb; bfr_tx_ptr++;
        }
        //__________________________________________________________________________________________________________________________________________
        public void close_packet()
        {
            UInt16 data = (UInt16) Get_CRC(bfr_tx, bfr_tx_ptr);

            byte lsb = (byte)data;
            data = (UInt16)(data >> 8);
            byte msb = (byte)data;
            bfr_tx[bfr_tx_ptr] = msb; bfr_tx_ptr++;
            bfr_tx[bfr_tx_ptr] = lsb; bfr_tx_ptr++;
        }
        //______________________________________________________________________________________________________________________________________________
         public UInt16 Get_Uint16_From_Byte(byte[] b, int pos)
        {
            UInt16 result = b[pos];
            result = (UInt16)(result << 8);
            result |= b[pos + 1];
            return result;
        }
        //__________________________________________________________________________________________________________________________________________
        public void Insert_bytes_from_Uint16(UInt16 val, ref byte[] b, int pos)
        {
            byte msb, lsb;

            lsb = (byte)val;
            val = (UInt16)(val >> 8);
            msb = (byte)val;

            b[pos] = msb;
            b[pos + 1] = lsb;
        }
        //__________________________________________________________________________________________________________________________________________
       private int Get_CRC(byte[] pkt, int length)
        {
            int i, j;
            int temp, temp2, flag;

            temp = 0xFFFF;
            for (i = 0; i < length; i++)
            {
                temp = temp ^ pkt[i];
                for (j = 1; j <= 8; j++)
                {
                    flag = temp & 0x0001;
                    temp >>= 1;
                    if (flag != 0)
                        temp ^= 0xA001;
                }
            }
            temp2 = temp >> 8;
            temp = (temp << 8) | temp2;
            temp &= 0xFFFF;
            return temp;
        }
        //__________________________________________________________________________________________________________
        public byte[] Get_Response_Packet()
        {
            byte[] pkt = new byte[bfr_tx_ptr];

            for(int i=0;i<bfr_tx_ptr;i++)
            {
                pkt[i]= (byte)bfr_tx[i];
            }
            return  pkt;
        }
        
        public void clear_tx_buffer()
        {
            for(int i=0;i<bfr_tx.Count();i++)
            {
                bfr_tx[i] = 0;
                bfr_tx_ptr = 0;
            }
        }
         






    }//class
}// Namespace

 