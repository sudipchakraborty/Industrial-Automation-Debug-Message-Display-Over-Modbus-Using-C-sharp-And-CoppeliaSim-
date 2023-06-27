using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
   public class Modbus_Packet
    {
        private int device_id;
        private int function_code;
        private int start_address;
        private int length;
        private UInt16[] data;
        private UInt16 crc;

        public int DeviceId
        { 
            get
            {
                return device_id; 
            } 
            set
            {
                device_id = value;
            }
        }

        public int FunctionCode
        {
            get
            {
                return function_code;
            }
            set 
            { 
                function_code = value;
            } 
        }

        public int Start_Address
        {
            get
            {
                return start_address;
            }
            set
            {
                start_address = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public UInt16[] Data
        {
            get
            {
                return data;
            }
            set
            {

            }
        }

        public UInt16 CRC
        {
            get
            {
                return crc;
            }
            set
            {
                crc= value;
            }
        }

    }
}
