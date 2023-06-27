using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
   public static class Modbus_Common
    {
        public static char CalculateLRC(string toEncode)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(toEncode);
            byte LRC = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return Convert.ToChar(LRC);
        }

        public static byte calculateLRC(byte[] bytes, int start, int count)
        {
            int LRC = 0;
            for (int i = start; i < 20; i++)
            {
                LRC -= bytes[i];
            }
            return (byte)LRC;
        }

        public static string Get_Function_Code(string index)
        {
            string ret_str = "";
            switch(index)
            {
                case "0": ret_str = "1";  break;           //01 READ COIL STATUS
                case "1": ret_str = "2";  break;           //02 READ INPUT STATUS
                case "2": ret_str = "3";  break;           //03 READ HOLDING REGISTERS
                case "3": ret_str = "4";  break;           //04 READ INPUT REGISTERS
                case "4": ret_str = "5";  break;           //05 WRITE SINGLE COIL
                case "5": ret_str = "6";  break;           //06 WRITE SINGLE REGISTER
                case "6": ret_str = "15"; break;           //15 WRITE MULTIPLE COILS
                case "7": ret_str = "16"; break;           //16 WRITE MULTIPLE REGISTERS
                default: break;
            }
            return ret_str;
        }

        public static string Get_string_from_packet(byte[] b, int count)
        {
            string result = DateTime.Now.ToString() + ">";
            for (int i = 0; i < count; i++)
            {
                result += b[i].ToString("X") + " ";
            }
            return result;
        }

        public static int Get_CRC(byte[] pkt, UInt16 length)
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

        public static void Insert_bytes_from_Uint16(UInt16 val, ref byte[] b, int pos)
        {
            byte msb, lsb;

            lsb = (byte)val;
            val = (UInt16)(val >> 8);
            msb = (byte)val;

            b[pos] = msb;
            b[pos + 1] = lsb;
        }
        //__________________________________________________________________________________________________________________________________________
        





        //public static byte Get_Byte_From_Hex(byte )
        //{
        //    //unsigned char decimal;
        //    //decimal= Get_int_from_Hex(*bfr) * 16;
        //    //bfr++;
        //    //decimal += Get_int_from_Hex(*bfr);
        //    //return decimal;
        //}

        //unsigned char Get_int_from_Hex(unsigned char hex)
        //{
        //    if (hex >= '0' && hex <= '9')
        //    {
        //        return (hex - 48);
        //    }
        //    else if (hex >= 'a' && hex <= 'f')
        //    {
        //        return (hex - 97 + 10);
        //    }
        //    else if (hex >= 'A' && hex <= 'F')
        //    {
        //        return (hex - 65 + 10);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}





























    }
}
