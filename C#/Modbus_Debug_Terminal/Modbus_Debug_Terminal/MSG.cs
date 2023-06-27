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

        public MSG(ListBox lst)// constructor
        {
            this.lst = lst;   
        }
        //--------------------------------------------------
        public void push(string str)
        {
            lst.Items.Insert(0, DateTime.Now.ToString() + ">" + str + "\r\n");
        }


    }// class MessageScroll
}//namespace Formation_Charger
