using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Tools
{
   public class MSG
    {
        ListBox lst;
        public bool top = true;
        public bool repeat_same_message = true;
        string msg_prev = "";
        public int msg_repeat_count = 0;
        public int count = 0;

        public MSG(ListBox lst)// constructor
        {
            this.lst = lst;   
        }
        //--------------------------------------------------
        public void push(string str)
        {
            count++;

            if(repeat_same_message==true)
            {
                display(str);             
            }
            else
            {
                if(msg_prev != str)
                {
                    msg_prev = str;
                    msg_repeat_count = 0;
                    display(str);
                }
                else
                {
                    Update_first_line(str + "-" + msg_repeat_count.ToString());
                    msg_repeat_count++;
                }           
            }
        }

        public void display(string str)
        {
            if (top)
            {
                lst.Items.Insert(0, DateTime.Now.ToString() + ">" + str + "\r\n");
            }
            else
            {
                lst.Items.Insert(lst.Items.Count - 1, DateTime.Now.ToString() + ">" + str + "\r\n");
                lst.SetSelected(lst.Items.Count - 1, true);
            }
        }

        public void Update_first_line(string str) 
        {
            lst.Items[0] = str;
        }

        public void Find_String(string searchString)
        {
            for (int i = 0; i < lst.Items.Count; ++i)
            {
                string lbString = lst.Items[i].ToString();
                if (lbString.Contains(searchString))
                {
                    lst.SetSelected(i, true);
                }
                     
            }
            
        }





    }// class MessageScroll
}//namespace Formation_Charger
