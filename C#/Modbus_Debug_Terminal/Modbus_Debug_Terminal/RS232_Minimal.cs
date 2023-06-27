using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Tools
{
    public static class RS232_Minimal
    {
        public static SerialPort sp;
        public static byte[] bfr_rx = new byte[1024];
        public static int ptr_rx = 0;
        public static bool IsOpen=false;
        public static bool exit=false;
        public static bool received = false;
        public static Thread th;

    public static bool open(String p_name, Int32 b_rate)
            {
                try
                {
                    sp = new SerialPort(p_name, b_rate, Parity.None, 8, StopBits.One);
                    sp.ReadTimeout = 5000;
                    sp.WriteTimeout = 5000;
                    sp.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    if (!sp.IsOpen)
                        sp.Open();
                    sp.DiscardInBuffer();
                    IsOpen = true;
               //     th=new Thread(Timeout); 
               //     th.Start();
                    return true;
                }
                catch (Exception ex)
                {
                    if (sp.IsOpen)
                    {
                        sp.Close();
                        sp.DiscardInBuffer();
                        IsOpen = false;
                        return false;
                    }
                }
                return false;
            }

        private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int k = sp.BytesToRead;

                for (int i = 0; i < k; i++)
                {
                    bfr_rx[ptr_rx]=(byte)sp.ReadByte();
                    if (ptr_rx<1024) ptr_rx++;
                }
                received=true;
            }
            catch (Exception ex)
            {
            }
        }

        public static void send(byte[] b)
        {
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            int intBuffer = sp.BytesToRead;

            try
            {
                sp.Write(b,0,b.Length);       
            }
            catch (Exception ex)
            {
                String s = ex.ToString();
            }
        }

        public static void purge()
        {
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            ptr_rx= 0;
        }

        public static bool Receive_Any_Bytes()
        {
            if(ptr_rx==0) return false;
            else return true;
        }

        public static byte[] Get_Bytes()
        {
            if (ptr_rx>0)
            {
                byte[] b = new byte[ptr_rx];

                for (int i = 0; i<ptr_rx; i++)
                {
                    b[i]=bfr_rx[i];
                }
                purge();
                return b;
            }
            else
            {
                return null;
            }
        }

        public static void close()
        {
            Dispose();
            exit=true;
        }

        public static void Dispose()
            {
                if (sp.IsOpen)
                {
                    try
                    {
                        sp.DiscardInBuffer();
                        sp.Dispose();
                        sp.Close();
                    }
                    catch (Exception ex)
                    {
                        String s = ex.ToString();
                    }
                    finally
                    {
                        IsOpen = false;
                    }
                }
                sp.Dispose();
            }

        public static void Timeout()
        {
            while(!exit)
            {
                if(ptr_rx>4)
                {
                    Thread.Sleep(1000);
                    received=true;
                }
                Thread.Sleep(1);
            }
        }




    }// class
}// namespace
