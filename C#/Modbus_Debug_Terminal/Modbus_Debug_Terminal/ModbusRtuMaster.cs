using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;

namespace Tools
{
    class ModbusRtuMaster
    {
        const byte Illegal_function= 0x01;
        const byte Illegal_data_address= 0x02;
        const byte Illegal_data_value= 0x03;
        const byte Slave_device_failure= 0x04;
        const byte Acknowledge= 0x05;
        const byte Slave_device_busy= 0x06;
        const byte Negative_acknowledgment= 0x07;
        const byte Memory_parity_error   = 0x08;
        const byte Gateway_path_unavailable= 0x0A;
        const byte Gateway_target_device_failed_to_respond= 0x0B;

        byte[] bfr_rx;
        List<string> data = new List<string>();

        public byte Device_ID = 0x01;
        public byte slave_addr_TX;
        public byte Function_Code_TX;
        public UInt16 addr_read_start_TX;
        public UInt16 int16_Count_TX;

        public byte slave_addr_RX;
        public byte Function_Code_RX;
        public UInt16 addr_read_start_RX;
        public UInt16 int16_Count_RX;


        UInt16 CRC_Calculated;
        UInt16 CRC_in_Message;

        byte bfr_ptr_tx;
        byte receive_packet_length;

        public string str_Request_Packet;
        public string str_Response_Packet;

        public ModbusRtuMaster()
        {            
            bfr_ptr_tx = 0;
        }

      public void To_Modbus(string address, string value, double multiplication_factor)
        {
            //UInt16 addr = Convert.ToUInt16(prj_global.Get_MB_Addr(address));
            //UInt16 data = (UInt16)(Convert.ToDouble(value) * multiplication_factor);
            //UInt16[] val = new UInt16[]
            //{
            //   data
            //};

            //bool status = Multiple_Register_write_16(addr, val, 1);

            //if (!status)
            //{
            //    //System.Console.WriteLine("Failing");
            //}
        }

        public List<UInt16> purse_packet(byte[] bfr)
        {
            List<UInt16> data = new List<ushort>();

            bfr_rx = new byte[bfr.Length];
            Array.Copy(bfr, bfr_rx, bfr.Length);
      
            slave_addr_RX = bfr_rx[0];
            Function_Code_RX = bfr_rx[1]; 
            int16_Count_RX = bfr_rx[2];
            int i = 3;
            do
            {                      
                UInt16 val = bfr_rx[i];
                val =(UInt16)(val << 8);
                val |= bfr_rx[i+1];                            
                data.Add(val);
                i += 2;
            } while (i < int16_Count_RX + 3);

            byte[] bb = new byte[2];
            bb[0]= bfr_rx[bfr_rx.Length - 1];
            bb[1]= bfr_rx[bfr_rx.Length - 2];
            CRC_in_Message = (UInt16)BitConverter.ToInt16(bb, 0);
            CRC_Calculated = (UInt16)Modbus_Common.Get_CRC(bfr_rx,(ushort)(bfr_rx.Length-2));
           
            return data;
        }
        //__________________________________________________________________________________________________________________________________ 
        public void Update_Parameter(string slave_addr, string function, string addr, string count)
        {
            this.slave_addr_TX = Convert.ToByte(slave_addr);
          //  string s = function.Substring(0, 2);
            this.Function_Code_TX = Convert.ToByte(function);
            
            UInt16 k=Convert.ToUInt16(addr);
            if (k == 0) { }
            else this.addr_read_start_TX = (UInt16) (k - 1);
            
            this.int16_Count_TX = Convert.ToUInt16(count);
        }
        //________________________________________________________________________________________
        public byte[] Get_Request_Packet_For_Read_Holding_Reg_03(byte device_id,UInt16 addr, UInt16 count)
        {
            byte[] pkt = new byte[8];
            byte[] b;

            pkt[0]=device_id;
            pkt[1]=0x03;
          
            b= BitConverter.GetBytes(addr);
            if (BitConverter.IsLittleEndian) Array.Reverse(b); 
            pkt[2]=b[0];
            pkt[3]=b[1];

            b = BitConverter.GetBytes(count);
            pkt[4]=b[1];
            pkt[5]=b[0];

            int temp =Modbus_Common.Get_CRC(pkt,6);
            b = BitConverter.GetBytes(temp);
            pkt[6]=b[1];
            pkt[7]=b[0];
            return pkt;
        }

        public byte[] Get_Request_Packet_For_Single_Register_write_06(byte device_id, UInt16 addr, UInt16 val)
        {
            UInt16 data = Convert.ToUInt16(val);

            byte[] pkt = new byte[8];

            pkt[0] = device_id;
            pkt[1] = 0x06;
            byte[] b = BitConverter.GetBytes(addr);
            if (BitConverter.IsLittleEndian) Array.Reverse(b);

            pkt[2] = b[0];
            pkt[3] = b[1];

            b = BitConverter.GetBytes(data);
            pkt[4] = b[1];
            pkt[5] = b[0];

            int temp = Modbus_Common.Get_CRC(pkt, 6);
            b = BitConverter.GetBytes(temp);
            pkt[6] = b[1];
            pkt[7] = b[0];
            ////////////////////////////////
            return pkt;
        }

        public bool Single_Register_write_06(string address, string val)
        {
            UInt16 addr =(UInt16)( Convert.ToUInt16(address));
            UInt16 data = Convert.ToUInt16(val);

            byte[] pkt = new byte[8];

            pkt[0] = slave_addr_TX;
            pkt[1] = 0x06;  
            byte[] b = BitConverter.GetBytes(addr);
            if (BitConverter.IsLittleEndian)    Array.Reverse(b);
                     
            pkt[2] = b[0];
            pkt[3] = b[1];

            b = BitConverter.GetBytes(data);
            pkt[4] = b[1];
            pkt[5] = b[0];

            int temp = Modbus_Common.Get_CRC(pkt, 6);
            b = BitConverter.GetBytes(temp);
            pkt[6] = b[1];
            pkt[7] = b[0];
            ////////////////////////////////
            //if (rs232Sync.IsOpen)
            //{
            //    str_Request_Packet = DateTime.Now.ToString() + ">" + BitConverter.ToString(pkt);
            //  //  rs232Sync.Byte_Write(pkt, pkt.Length);
            //    bfr_rx = rs232Sync.byteBfr;

            //    if (rs232Sync.packet_received)
            //    {
            //        str_Response_Packet = DateTime.Now.ToString() + ">" + Encoding.Default.GetString(bfr_rx);
            //    }
            //}
            return true;
        }

        public bool Multiple_Register_write_16(UInt16 addr, UInt16[] val, UInt16 register_length)
        {

            int num_bytes = (register_length * 2) + 9;
            byte[] pkt = new byte[num_bytes];

            pkt[0] = Device_ID;
            pkt[1] = 0x10;
            
            // address
            byte[] b = BitConverter.GetBytes(addr);
            if (BitConverter.IsLittleEndian) Array.Reverse(b);

            pkt[2] = b[0];
            pkt[3] = b[1];

            // register length
            b = BitConverter.GetBytes(register_length);
            pkt[4] = b[1];
            pkt[5] = b[0];

            pkt[6] = (byte)(register_length * 2);

            for (int i = 0; i < register_length; i++)
            {
                b = BitConverter.GetBytes(val[i]);
                pkt[7 + (2*i)] = b[1];
                pkt[8 + (2*i)] = b[0];
            }

            int temp = Modbus_Common.Get_CRC(pkt,(UInt16)(num_bytes-2));
            b = BitConverter.GetBytes(temp);
            pkt[num_bytes - 2] = b[1];
            pkt[num_bytes - 1] = b[0];

            //pkt[num_bytes - 1] = 0x00;

            ////////////////////////////////
            byte[] response = new byte[8];

            //if (rs232Sync.IsOpen)
            //{
            //    rs232Sync.Byte_Write(pkt, ref response);
            //}

            UInt16 calc_CRC = Get_CRC(response, 6);

            ushort rec_crc = response[7];
            rec_crc=(ushort)(rec_crc<<8);
            rec_crc |=response[6];

            if (rec_crc==calc_CRC)
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public UInt16 Modbus_Single_Reg_Read(byte device_id, UInt16 addr)
        {
            // unsigned char bfr[]={0x15,0x03,0x00,0x31,0x00,0x01,0xd6,0xd1,0x00};

            byte[] temp=new byte[9];
            UInt16 crc;

            temp[0] = device_id;        // slave address
            temp[1] = 0x03;             // function code

            temp[3] =(byte) addr;       // addr Lo
            addr =(UInt16) (addr >> 8);
            temp[2] =(byte)addr;        // Addr Hi

            temp[4] = 0x00;             // Reg count Hi
            temp[5] = 0x01;             // Reg. count Lo

            crc = Get_CRC(temp, 6);

            temp[6] =(byte) crc;        // CRC Lo
            crc =(UInt16) (crc >> 8);
            temp[7] =(byte) crc;        // CRC Hi

            temp[8] = 0x00;

            byte[] response = new byte[7];

            //if (rs232Sync.IsOpen)
            //{
            //    rs232Sync.Byte_Write(temp, ref response);
            //}
            if(Error_Found(response)) return 0xFFFF;

            UInt16 resp_CRC = Get_CRC(response, 5);

            ushort val = response[6];
            val=(ushort)(val<<8);
            val |=response[5];

            if(val==resp_CRC)
            {
                val = response[3];
                val=(ushort)(val<<8);
                val |=response[4];                
                return val;
            }
            else
            {
                return 0xFFFF;
            }           
        }

        UInt16 Get_CRC(byte[] data, byte len)
        {
            byte i = 0;
            UInt16 crc = 0xFFFF;
            for (i = 0; i < len; i++)
                crc = process_crc16(crc, data[i]);
            return crc; // must be 0
        }
      
        UInt16 process_crc16(UInt16 crc, byte a)
        {
            int i;
            crc ^= a;
            for (i = 0; i < 8; ++i)
            {
                if ((crc & 1)==1)
                    crc =(UInt16) ((crc >> 1) ^ 0xA001);
                else
                    crc =(UInt16) (crc >> 1);
            }
            return crc;
        }

        /// <summary>
        /// Modbus receive packet error check
        /// </summary>
        /// <param name="pkt">the receive packet</param>
        /// <returns>modbus error code</returns>
        public static bool Error_Found(byte[] pkt)
        {
            byte b = (byte)(pkt[1] & 0x80);
            if (b==0x80)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }// class
}// Namespace


 