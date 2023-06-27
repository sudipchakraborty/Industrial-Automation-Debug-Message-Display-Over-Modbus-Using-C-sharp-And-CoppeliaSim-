 using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
//--------------------------------
namespace Tools
{
    public static class utility
    {

        //--------------------------------------------------------------------
        public static Image img_rotate(Image img)
        {
            img.RotateFlip(RotateFlipType.Rotate90FlipXY);
            return img;
        }
        //-------------------------------------------------------------------
        public static byte[] GetUint_2_bytes(UInt16 val)
        {
            byte[] ret_val = new byte[2];
            ret_val[0] = (byte)(val >> 8);
            ret_val[1] = (byte)(val & 0x00ff);
            return ret_val;
        }
        //---------------------------------------------------------------------------------------------
        public static UInt16 Get_Uint16(Byte Hi, Byte Lo)
        {
            UInt32 val = 0;
            val = Hi;
            val = val << 8;
            val |= Lo;
            return (UInt16)(val);
        }
        //---------------------------------------------------------------------------------------------
        public static UInt16[] Get_Uint16(UInt32 val)
        {
            UInt16[] data = new UInt16[2];

            data[1] = (UInt16)val;
            val = (UInt16)(val >> 16);
            data[0] = (UInt16)(val & 0x0000FFFF);
            return data;
        }
        //---------------------------------------------------------------------------------------------
        public static UInt16[] GetInt16_From_ByteArray(byte[] src)
        {
            UInt16[] bfr = new UInt16[src.Length / 2];
            int len = bfr.Length;

            int i = 0;
            int j = 0;

            do
            {
                bfr[i] = Get_Uint16(src[j], src[j + 1]);
                i++;
                j = j + 2;
            } while (i < len);

            return bfr;
        }
        //---------------------------------------------------------------------------------------------


        //public byte[] GetUInt16_From_bytes(byte val;)
        //{
        //    byte[] ret_val = new byte[2];
        //    ret_val[0] = (byte)(val >> 8);
        //    ret_val[1] = (byte)(val & 0x00ff);
        //    return ret_val;
        //}
        ////-------------------------------------------------------------------------------------------
        ////-------------------------------------------------------------------------- 
        //public UInt32 GetUInt16(byte[] bytes, int index)
        //{
        //    Array.Reverse(bytes);
        //    uint value = BitConverter.ToUInt16(bytes, index);
        //    return value;
        //}
        ////-------------------------------------------------------------------------- 
        //public UInt32 GetUInt32(byte[] bytes, int index)
        //{
        //    Array.Reverse(bytes);
        //    uint value = BitConverter.ToUInt32(bytes, index);
        //    return value;
        //}
        ////-------------------------------------------------------------------------- 
        //public byte[] GetUint_2_bytes(uint val)
        //{
        //    byte[] ret_val = new byte[2];
        //    ret_val[0] = (byte)(val >> 8);
        //    ret_val[1] = (byte)(val & 0x00ff);
        //    return ret_val;

        //    //byte[] byteArray = BitConverter.GetBytes(val);
        //    //Array.Reverse(byteArray, 0, byteArray.Length);
        //    //return byteArray;
        //}
        ////---------------------------------------------------------------------------     
        public static UInt32 Get_Uint32_From_UInt16(UInt16 Hi, UInt16 Lo)
        {
            UInt32 ret_val = 0;

            ret_val = Hi;
            ret_val = ret_val << 16;

            ret_val = ret_val | Lo;
            return ret_val;
        }
        //-----------------------------------------------------------------------------
        public static Int32 Get_Int32_From_UInt16(UInt16 Hi, UInt16 Lo)
        {
            Int32 ret_val = 0;

            ret_val = Hi;
            ret_val = ret_val << 16;

            ret_val = ret_val | Lo;
            return ret_val;
        }
        //-----------------------------------------------------------------------------

        public static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }
        //=============================================================================
        public static String Convert_Int32_To_FormatData(UInt32 Val, int preCount, int Post_count)
        {
            String retStr = "";

            float f = (float)(Val / 100.00f);

            UInt16 t = (UInt16)f;
            String str_int_part = t.ToString();
            str_int_part = str_int_part.PadLeft(preCount, '0');

            f = f - t;
            String str_flt_part = f.ToString();
            int pos = str_flt_part.IndexOf('.');

            if (pos == -1)
            {
                str_flt_part = "00";
            }
            else
            {
                str_flt_part = str_flt_part + "000000";
            }

            str_flt_part = str_flt_part.Substring(pos + 1, Post_count);
            retStr = str_int_part + "." + str_flt_part;

            return retStr;
        }
        //===============================================================================
        public static String Convert_Int32_To_FormatData_div36000(UInt32 Val, int preCount, int Post_count)
        {
            String retStr = "";
            float f;
            try
            {
                f = (float)(Val / 36000.00f);
            }
            catch
            {
                f = 0.0f;
            }

            UInt32 t = (UInt32)f;
            String str_int_part = t.ToString();
            str_int_part = str_int_part.PadLeft(preCount, '0');

            f = f - t;
            String str_flt_part = f.ToString();
            int pos = str_flt_part.IndexOf('.');

            if (pos == -1)
            {
                str_flt_part = "00";
            }
            else
            {
                str_flt_part = str_flt_part + "000000";
                str_flt_part = str_flt_part.Substring(pos + 1, Post_count);
                retStr = str_int_part + "." + str_flt_part;
            }
            return retStr;
        }
        //===============================================================================
        public static String Convert_Int32_To_FormatData_div3600(UInt32 Val, int preCount, int Post_count)
        {
            String retStr = "";

            float f = (float)(Val / 3600.00f);

            UInt32 t = (UInt32)f;
            String str_int_part = t.ToString();
            str_int_part = str_int_part.PadLeft(preCount, '0');

            f = f - t;
            String str_flt_part = f.ToString();
            int pos = str_flt_part.IndexOf('.');

            if (pos == -1)
            {
                str_flt_part = "00";
            }
            else
            {
                str_flt_part = str_flt_part + "000000";
                str_flt_part = str_flt_part.Substring(pos + 1, Post_count);
                retStr = str_int_part + "." + str_flt_part;
            }
            return retStr;
        }
        //===============================================================================
        public static String Convert_Int32_To_FormatData_div360(UInt32 Val, int preCount, int Post_count)
        {
            String retStr = "";

            float f = (float)(Val / 360.00f);

            UInt32 t = (UInt32)f;
            String str_int_part = t.ToString();
            str_int_part = str_int_part.PadLeft(preCount, '0');

            f = f - t;
            String str_flt_part = f.ToString();
            int pos = str_flt_part.IndexOf('.');

            if (pos == -1)
            {
                str_flt_part = "00";
            }
            else
            {
                str_flt_part = str_flt_part + "000000";
                str_flt_part = str_flt_part.Substring(pos + 1, Post_count);
                retStr = str_int_part + "." + str_flt_part;
            }
            return retStr;
        }

        public static bool Successfully_Exported_To_Excel(DataGridView dg, String FileName)
        {
            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //int i = 0;
            //int j = 0;

            //for (i = 0; i <= dg.RowCount - 1; i++)
            //{
            //    for (j = 0; j <= dg.ColumnCount - 1; j++)
            //    {
            //        DataGridViewCell cell = dg[j, i];
            //        try
            //        {
            //            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value.ToString();
            //        }
            //        catch
            //        {
            //            xlWorkSheet.Cells[i + 1, j + 1] = "";
            //        }

            //    }
            //}

            //xlWorkBook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);
            return true;
        }
        //--------------------------------------------------------------------------------------------------
        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        //-------------------------------------------------------------------------------------------------------
        public static String Get_Random_Uint16_as_String()
        {
            String retStr;

            Random rnd = new Random();
            UInt16 n = (UInt16)(rnd.Next(1, 0xffff));
            retStr = n.ToString();
            retStr = retStr.PadLeft(5, '0');
            return retStr;
        }
        //----------------------------------------------------------------------------------------------------------
        public static String Get_Random_Uint16_as_HEX_String()
        {
            String retStr;

            Random rnd = new Random();
            UInt16 n = (UInt16)(rnd.Next(1, 0xffff));
            retStr = n.ToString("X");
            return retStr;
        }
        //----------------------------------------------------------------------------------------------------------
        public static String Get_Random_2digit_fraction_string()
        {
            Random rnd = new Random();
            byte k = (byte)(rnd.Next(10, 99));
            String s = "." + k.ToString();
            return s;
        }
        //----------------------------------------------------------------------------------------------------------
        public static String Get_Updated_Cell_Value(int ch, String val)
        {
            String retStr = "";
            //String s, t;

            //switch (My_Global_Variable.cell_cursor_pos)
            //{
            //    case 0:
            //        s = val.Substring(1);
            //        retStr = Get_Key_Code_String_Val(ch) + s;
            //        My_Global_Variable.cell_cursor_pos++;
            //        break;

            //    case 1:
            //        s = val.Substring(0, 1);
            //        t = val.Substring(2);
            //        retStr = s + Get_Key_Code_String_Val(ch) + t;
            //        My_Global_Variable.cell_cursor_pos++;
            //        My_Global_Variable.cell_cursor_pos++;
            //        break;

            //    case 2:
            //        break;

            //    case 3:
            //        s = val.Substring(0, 2);
            //        t = val.Substring(4);
            //        retStr = s + ":" + Get_Key_Code_String_Val(ch) + t;
            //        My_Global_Variable.cell_cursor_pos++;
            //        break;

            //    case 4:
            //        s = val.Substring(0, 4);
            //        t = val.Substring(5);
            //        retStr = s + Get_Key_Code_String_Val(ch) + t;
            //        My_Global_Variable.cell_cursor_pos++;
            //        My_Global_Variable.cell_cursor_pos++;
            //        break;

            //    case 5:
            //        break;

            //    case 6:
            //        s = val.Substring(0, 6);
            //        t = val.Substring(6, 1);
            //        retStr = s + Get_Key_Code_String_Val(ch) + t;
            //        My_Global_Variable.cell_cursor_pos++;
            //        break;

            //    case 7:
            //        s = val.Substring(0, 7);
            //        retStr = s + Get_Key_Code_String_Val(ch);
            //        My_Global_Variable.cell_cursor_pos = 0;
            //        break;

            //    default:
            //        retStr = val;
            //        break;

            //}
            return retStr;
        }
        //------------------------------------------------------------------------------------------------
        public static String Get_Key_Code_String_Val(int ch)
        {
            String retStr = "";

            if ((ch >= 96) && (ch < 104))
            {
                ch = ch - 96;
            }
            retStr = ch.ToString();
            return retStr;
        }
        //------------------------------------------------------------------------------------------------

        public static void Save_LogOut()
        {
            //String[,] data = new string[5, 2];
            //data[0, 0] = "user_id"; data[0, 1] = My_Global_Variable.User_ID;
            //data[1, 0] = "logIn_date"; data[1, 1] = My_Global_Variable.logIn_date;
            //data[2, 0] = "logIn_time"; data[2, 1] = My_Global_Variable.logIn_time;
            //data[3, 0] = "logOut_date"; data[3, 1] = Get_SQL_Date();
            //data[4, 0] = "logOut_time"; data[4, 1] = Get_SQL_Time();
            //database.User_Log_Update("tbl_user_log", data);

            //My_Global_Variable.User_ID = "";
            //My_Global_Variable.logIn_date = "";
            //My_Global_Variable.logIn_time = "";
            //My_Global_Variable.logOut_date = "";
            //My_Global_Variable.logOut_time = "";
        }
        //-----------------------------------------------------------------
        //---------------------------------------------------------------------
        public static String Textbox_Cursor_Handle(int cursorPos, String txt, String Format, int keyVal)
        {
            String text = txt;
            return txt + "1";
        }
        //===============================================================================================
        public static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }
        //===============================================================================================
        public static Color Get_colour(String val, String hi, String lo)
        {
            Color ret_colour;

            decimal param_val = Convert.ToDecimal(val);
            decimal high_val = Convert.ToDecimal(hi);
            decimal lo_val = Convert.ToDecimal(lo);

            if (param_val >= high_val)
            {
                ret_colour = Color.Red;
            }
            else if (param_val <= lo_val)
            {
                ret_colour = Color.Yellow;
            }
            else
            {
                ret_colour = Color.LightGreen;
            }
            return ret_colour;
        }
        //_________________________________________________________________________________________________________
        public static decimal Get_decimal_from_string(String val)
        {
            decimal d = 0;
            try
            {
                d = decimal.Parse(val, CultureInfo.InvariantCulture);

            } catch (Exception ex)
            {
                string s = ex.ToString();
            }

            return d;
        }
        //__________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________________
        public static void push_to_Point_buffer(Point[] bfr, String val)
        {
            for (int i = 0; i < bfr.Length - 1; i++)
            {
                bfr[i].Y = bfr[i + 1].Y;
            }

            Int16 k = Convert.ToInt16(val);
            bfr[bfr.Length - 1].Y = k;
        }

        //__________________________________________________________________________________________________________
        //public static DataTable DateTimePicker_Get_Data_Between_DateTime(DateTimePicker dt_st, DateTimePicker time_st, DateTimePicker dt_end, DateTimePicker time_end, string orderby, String table_name, string search_type)
        //{
        //    // orderby = ASC or DESC
        //    // search_type= all or between_date_time
        //    DataTable dt;
        //    String cmd = "";

        //    try
        //    {
        //        if (search_type == "all")
        //        {
        //            cmd = "select* from " + table_name + " order by Date_Time ";
        //        }
        //        else if (search_type == "between_date_time")
        //        {
        //            String str_dt_st = dt_st.Value.ToString("yyyy-MM-dd");
        //            String str_time_st = time_st.Value.ToString("HH:mm:ss");

        //            string st_dt = " '" + str_dt_st + " " + str_time_st + "' ";
        //            ///////////////////
        //            String str_dt_end = dt_end.Value.ToString("yyyy-MM-dd");
        //            String str_time_end = time_end.Value.ToString("HH:mm:ss");

        //            string end_dt = " '" + str_dt_end + " " + str_time_end + "' ";

        //            cmd = "select* from " + table_name + " where Date_Time >=" + st_dt + " AND Date_Time<" + end_dt + " order by Date_Time ";
        //        }
        //        else
        //        {

        //        }

        //        cmd += orderby;
        //      //  dt = database.Get_DataTable(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        String s = ex.ToString();
        //        dt = null;
        //    }

        //    return dt;
        //}
        //______________________________________________________________________________________________________
        public static bool multiple_instance_running()
        {
            Mutex m;
            bool first = false;
            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if ((first))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        //__________________________________________________________________________________________
        public static int Get_first_Not_Null_index_From_Str_Buffer(String[] bfr)
        {
            int i = 0;

            for (i = 0; i < bfr.Length; i++)
            {
                try
                {
                    if (bfr[i] != null)
                    {
                        return i;
                    }
                }
                catch
                {

                }
            }
            return -1;
        }
        //________________________________________________________________________________________________________
        public static int Get_Not_Null_Count_From_Str_Buffer(String[] bfr)
        {
            int count = 0;

            for (int i = 0; i < bfr.Length; i++)
            {
                try
                {
                    if (bfr[i] != null)
                    {
                        count++;
                    }
                }
                catch
                {

                }
            }
            return count;
        }

        //____________________________________________________________________________________________________________________
        public static string Get_My_String(string source, char search_char, int string_pos)
        {
            String ret_str = "";
            int i = source.IndexOf(search_char);
            ret_str = source.Substring(0, i);
            return ret_str;
        }
        //_________________________________________________________________________________
        public static string Get_My_String_end_with_coma(string source, string search_char)
        {
            String ret_str = "";
            int i = source.IndexOf(search_char);
            i += search_char.Length;

            int j = source.IndexOf(',', i);
            ret_str = source.Substring(i, j - i);
            return ret_str;
        }
        //_________________________________________________________________________________
        public static UInt16[] Convert_str32_To_Uint16_Hi_Lo(String val)
        {
            UInt16[] ret_val = new UInt16[2];

            UInt32 tot = Convert.ToUInt32(val);

            ret_val[1] = (UInt16)tot;
            tot = tot >> 16;
            tot = tot & 0x0000ffff;
            ret_val[0] = (UInt16)(tot);

            return ret_val;
        }
        //_________________________________________________________________________________________________________________
        public static string FileName_using_DialogBox()
        {
            String FileName = "";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Program File";
            theDialog.Filter = "Program files|*.csv|*.ini|";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = theDialog.FileName.ToString();
            }
            return FileName;
        }

        //_________________________________________________________________________________________________________________
        public static void CheckDB_File_Size(String path, int max_file_size_in_MB)
        {
            try
            {
                // Create new FileInfo object and get the Length.
                FileInfo f = new FileInfo(path);
                long s1 = f.Length;
                s1 = s1 / 1000000;

                if (s1 > max_file_size_in_MB)
                {
                    MessageBox.Show("Database size increased. " + s1 + " MB. Please Backup for faster Operation", "WARNING !!!");
                }
            }
            catch (Exception ex)
            {
                String s = ex.ToString();
            }
        }
        //_________________________________________________________________________________________________________________
        public static byte[] Get_Bytes_from_string(string msg)
        {
            byte[] b;
            b = new byte[msg.Length];
            b = Encoding.Default.GetBytes(msg);
            return b;
        }
        //_________________________________________________________________________________________________________________
        public static int purse_array_value_from_str(string find_str, string packet, int start_index, ref List<string> dest_bfr)
        {
            string temp_str = "";
            int var_start_idx = 0;
            int bracket_st = 0;
            int bracket_end = 0;

            var_start_idx = packet.IndexOf(find_str, start_index);
            bracket_st = packet.IndexOf('[', var_start_idx);
            bracket_end = packet.IndexOf(']', bracket_st);

            temp_str = packet.Substring(bracket_st + 1, bracket_end - bracket_st - 1);

            var charsToRemove = new string[] { "@", "'", "\n", " " };
            foreach (var c in charsToRemove)
            {
                temp_str = temp_str.Replace(c, string.Empty);
            }
            string[] val = temp_str.Split(',');


            for (int i = 0; i < val.Length; i++)
            {
                dest_bfr.Add(val[i]);
            }
            return bracket_end;
        }
        //_________________________________________________________________________________________________________________
        public static void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
        }
        //_________________________________________________________________________________________________________________
        public static List<string> Get_division_buffer(float min, float max, float no_of_division)
        {
            List<string> bfr = new List<string>();

            float unit = (max - min) / no_of_division;
            float running_val = min;
            bfr.Add(running_val.ToString());

            for (int i = 0; i < no_of_division; i++)
            {
                running_val += unit;
                bfr.Add(running_val.ToString());
            }
            return bfr;

        }
        //_________________________________________________________________________________________________________________
        public static void allign_str(ref List<string> bfr, int decimal_pos)
        {
            for (int i = 0; i < bfr.Count; i++)
            {
                int k = 0;
                k = bfr[i].IndexOf('.');

                if (k != -1)
                {
                    int p = bfr[i].IndexOf('.');
                    string prev_str = bfr[i].Substring(0, p);
                    string post_str = bfr[i].Substring(p + 1);
                    if (post_str.Length < decimal_pos)
                    {
                        post_str = post_str.PadRight(2, '0');
                        bfr[i] = prev_str + "." + post_str;
                    }
                }
                else
                {
                    bfr[i] = bfr[i] + ".00";


                }
            }
        }
        //_________________________________________________________________________________________________________________
        public static string allign_str(string val, int decimal_pos)
        {
            int k = 0;
            k = val.IndexOf('.');
            string ret_str = "";

            if (k != -1)
            {
                int p = val.IndexOf('.');
                string prev_str = val.Substring(0, p);
                string post_str = val.Substring(p + 1);
                if (post_str.Length < decimal_pos)
                {
                    post_str = post_str.PadRight(2, '0');
                    ret_str = prev_str + "." + post_str;

                }
                else
                {
                    post_str = post_str.Substring(0, 2);
                    ret_str = prev_str + "." + post_str;
                }
            }
            else
            {
                ret_str = val + ".00";
            }

            return ret_str;
        }
        //_________________________________________________________________________________________________________________
        public static void convert_value(ref List<string> bfr, float src_min, float src_max, int dst_min, int dst_max)
        {
            if (src_min < 0)
            {
                float src_diff = src_max - src_min;
                float dst_diff = dst_max - dst_min;
                float unit = dst_diff / src_diff;

                float zero = dst_max + ((dst_min - dst_max) / 2);

                for (int i = 0; i < bfr.Count; i++)
                {
                    decimal d = Convert.ToDecimal(bfr[i]);
                    d *= (decimal)unit;
                    d += (decimal)zero;
                    bfr[i] = d.ToString();
                }
            }
            else
            {
                float src_diff = src_max - src_min;
                float dst_diff = dst_max - dst_min;
                float unit = dst_diff / src_diff;

                for (int i = 0; i < bfr.Count; i++)
                {
                    decimal d = Convert.ToDecimal(bfr[i]);
                    d *= (decimal)unit;
                    d += (decimal)dst_min;
                    bfr[i] = d.ToString();
                }
            }
        }
        //_________________________________________________________________________________________________________________
        public static Point[] convert_str_list_to_point(List<string> bfr_X, List<string> bfr_Y)
        {
            Point[] pt = new Point[bfr_X.Count];
            for (int i = 0; i < bfr_X.Count; i++)
            {
                string str_x = bfr_X[i].Replace(',', '.');
                string str_y = bfr_Y[i].Replace(',', '.');
                decimal x = Convert.ToDecimal(str_x);
                decimal y = Convert.ToDecimal(str_y);
                pt[i] = new Point((int)x, (int)y);
            }
            return pt;
        }
        //__________________________________________________________________________________________________________________
        public static decimal convert_Exp_value(string val)
        {
            decimal dec = decimal.Parse(val, System.Globalization.NumberStyles.Any);
            return dec;
        }
        //__________________________________________________________________________________________________________________
        public static string convert_Exp_value(string val, decimal compare_val, int decimal_place)
        {
            string result = "";
            decimal dec = decimal.Parse(val, System.Globalization.NumberStyles.Any);
            string str_val = dec.ToString();
            if (dec < compare_val)
            {
                if (decimal_place == 1) result = "0.0";
                else if (decimal_place == 2) result = "0.00";
                else if (decimal_place == 3) result = "0.000";
                else result = "0.0";
            }
            else
            {
                int k = str_val.IndexOf('.');
                string s = str_val.Substring(k + 1);
                result = allign_str(s, decimal_place);
            }

            return result;
        }
        //__________________________________________________________________________________________________________________
        public static int get_str_upto_non_digit(string find_str, string packet, int index, ref string str_result)
        {
            int str_idx = packet.IndexOf(find_str, index);
            if (str_idx == -1) return index;

            str_idx += find_str.Length;

            int running_index = str_idx;

            for (int i = index; i < packet.Length; i++)
            {
                string s = packet.Substring(running_index, 1);
                if ((s != "0") && (s != "1") && (s != "2") && (s != "3") && (s != "4") &&
                   (s != "5") && (s != "6") && (s != "7") && (s != "8") && (s != "9"))
                {
                    str_result = packet.Substring(str_idx, running_index - str_idx);
                    return str_idx;
                }
                else
                {
                    running_index++;
                }
            }
            return str_idx;
        }
        //_____________________________________________________________________________________________________________________________
        public static bool parameter_Not_Within_Range(string max_val, string min_val, string running_val)
        {
            try
            {
                decimal max = Convert.ToDecimal(max_val);
                decimal min = Convert.ToDecimal(min_val);
                decimal running = Convert.ToDecimal(running_val);

                if ((running > max) || (running < min))
                {
                    // MessageBox.Show("")
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex)
            {

            }
            return true;
        }
        //____________________________________________________________________________________________________________________
        public static string Get_Error_percentage(string s1, string s2)
        {
            string result = "";

            try
            {
                decimal v1 = Convert.ToDecimal(s1);
                decimal v2 = Convert.ToDecimal(s2);

                decimal error = ((v1 - v2) / v1) * 100;
                result = error.ToString();
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                result = "0.00";
            }
            return result;
        }
        //_____________________________________________________________________________________________________________________
        public static void combo_fill(DataTable dt, string field_name, ComboBox cb)
        {
            try
            {
                cb.Items.Clear();
            }
            catch (Exception ex)
            {

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][field_name].ToString();
                cb.Items.Add(s);
            }
        }
        //_____________________________________________________________________________________________________________________
        public static double[] String_2_Values(string strvalues)
        {
            double[] dvalues = null;
            try
            {
                dvalues = Array.ConvertAll(strvalues.Split(','), Double.Parse);
            }
            catch (System.FormatException ex)
            {

            }
            return dvalues;
        }
        //___________________________________________________________________________________
        public static void draw_centered_circle(Graphics g, Point cp, Pen p, int gap, int circle_count)
        {
            int radius = 5;
            int val = 0;
            float pen_width = p.Width;
            p.Width += 1;
            int intencity = 100;
            p.Color = Color.Black; // Color.FromArgb(100, intencity, intencity, intencity);

            for (int i = 0; i < circle_count; i++)
            {
                Rectangle rect = new Rectangle(cp.X - radius, cp.Y - radius, radius * 2, radius * 2);

                g.DrawEllipse(p, rect);

                val++;
                if (val == 5)
                {
                    val = 0;
                    //  p.Width = 1.5f;
                    intencity = 200;
                    p.Color = Color.Blue;
                }
                else
                {
                    p.Width = pen_width;
                    intencity = 100;
                    p.Color = Color.FromArgb(100, intencity, intencity, intencity);
                }
                radius += gap;
            }
        }
        //_______________________________________________________________________________________
        public static void draw_centered_lines(Graphics g, Point cp, int pen_width, int radious)
        {
            Pen p = new Pen(Brushes.Gray);
            p.Width = 1;
            int intencity = 100;
            p.Color = Color.FromArgb(100, intencity, intencity, intencity);

            double ang = 0.0f;

            do
            {
                Point pp = Convert_deg_to_point(cp, radious, ang);
                g.DrawLine(p, cp, pp);

                ang += 10;
            } while (ang != 360);
        }
        //__________________________________________________________________________________________________________________
        public static void draw_centered_Text(Graphics g, Point cp, Brush b, int radious)
        {
            Font drawFont = new Font("Arial", 12);

            Point pp = Convert_deg_to_point(cp, radious, 0);
            DrawRotatedTextAt(g, 0, "0", pp.X + 5, pp.Y - 17, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 30);
            DrawRotatedTextAt(g, 0, "30", pp.X + 10, pp.Y - 15, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 60);
            DrawRotatedTextAt(g, 0, "60", pp.X, pp.Y - 25, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 90);
            DrawRotatedTextAt(g, 0, "90", pp.X, pp.Y - 25, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 120);
            DrawRotatedTextAt(g, 0, "120", pp.X - 25, pp.Y - 25, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 150);
            DrawRotatedTextAt(g, 0, "150", pp.X - 35, pp.Y - 15, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 180);
            DrawRotatedTextAt(g, 0, "180", pp.X - 35, pp.Y - 15, drawFont, b);
            //////////////////////////

            pp = Convert_deg_to_point(cp, radious, 210);
            DrawRotatedTextAt(g, 0, "210", pp.X - 30, pp.Y, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 240);
            DrawRotatedTextAt(g, 0, "240", pp.X - 30, pp.Y, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 270);
            DrawRotatedTextAt(g, 0, "270", pp.X, pp.Y, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 300);
            DrawRotatedTextAt(g, 0, "300", pp.X, pp.Y, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 330);
            DrawRotatedTextAt(g, 0, "330", pp.X + 5, pp.Y, drawFont, b);

            pp = Convert_deg_to_point(cp, radious, 360);
            DrawRotatedTextAt(g, 0, "360", pp.X, pp.Y, drawFont, b);

        }
        //__________________________________________________________________________________________________________________
        public static void draw_db_Text(Graphics g, Point cp, Brush b, int radious)
        {
            Font drawFont = new Font("Arial", 10);

            Point pp = Convert_deg_to_point(cp, radious, 0);
            DrawRotatedTextAt(g, 0, "-5", pp.X - 40, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-10", pp.X - 80, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-15", pp.X - 120, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-20", pp.X - 160, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-25", pp.X - 200, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-30", pp.X - 240, pp.Y - 17, drawFont, b);
            //////////////////////////////////////
            DrawRotatedTextAt(g, 0, "0 dB", pp.X - 490, pp.Y - 17, drawFont, b);

            DrawRotatedTextAt(g, 0, "-5", pp.X - 450, pp.Y - 17, drawFont, b);
            DrawRotatedTextAt(g, 0, "-10", pp.X - 410, pp.Y - 17, drawFont, b);
            DrawRotatedTextAt(g, 0, "-15", pp.X - 370, pp.Y - 17, drawFont, b);
            DrawRotatedTextAt(g, 0, "-20", pp.X - 330, pp.Y - 17, drawFont, b);
            DrawRotatedTextAt(g, 0, "-25", pp.X - 290, pp.Y - 17, drawFont, b);

            //DrawRotatedTextAt(g, 0, "-10", pp.X - 80, pp.Y - 17, drawFont, b);

            //DrawRotatedTextAt(g, 0, "-15", pp.X - 120, pp.Y - 17, drawFont, b);

            //DrawRotatedTextAt(g, 0, "-20", pp.X - 160, pp.Y - 17, drawFont, b);

            //DrawRotatedTextAt(g, 0, "-25", pp.X - 200, pp.Y - 17, drawFont, b);

            //DrawRotatedTextAt(g, 0, "-30", pp.X - 240, pp.Y - 17, drawFont, b);


            //pp = Convert_deg_to_point(cp, radious, 30);
            //DrawRotatedTextAt(g, 0, "30", pp.X + 10, pp.Y - 15, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 60);
            //DrawRotatedTextAt(g, 0, "60", pp.X, pp.Y - 25, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 90);
            //DrawRotatedTextAt(g, 0, "90", pp.X, pp.Y - 25, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 120);
            //DrawRotatedTextAt(g, 0, "120", pp.X - 25, pp.Y - 25, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 150);
            //DrawRotatedTextAt(g, 0, "150", pp.X - 35, pp.Y - 15, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 180);
            //DrawRotatedTextAt(g, 0, "180", pp.X - 35, pp.Y - 15, drawFont, b);
            ////////////////////////////

            //pp = Convert_deg_to_point(cp, radious, 210);
            //DrawRotatedTextAt(g, 0, "210", pp.X - 30, pp.Y, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 240);
            //DrawRotatedTextAt(g, 0, "240", pp.X - 30, pp.Y, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 270);
            //DrawRotatedTextAt(g, 0, "270", pp.X, pp.Y - 20, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 300);
            //DrawRotatedTextAt(g, 0, "300", pp.X, pp.Y, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 330);
            //DrawRotatedTextAt(g, 0, "330", pp.X + 5, pp.Y, drawFont, b);

            //pp = Convert_deg_to_point(cp, radious, 360);
            //DrawRotatedTextAt(g, 0, "360", pp.X, pp.Y, drawFont, b);

        }
        //______________________________________________________________________________________________________
        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        //__________________________________________________________________________________________________________________
        public static Point Convert_deg_to_point(Point cp, double radious, double deg)
        {
            double x_var = radious * Math.Cos(ConvertToRadians(deg));
            double y_var = radious * Math.Sin(ConvertToRadians(deg));

            Point p = new Point();
            p.X = cp.X + (int)x_var;
            p.Y = cp.Y - (int)y_var;

            return p;
        }
        //___________________________________________________________________________________________________________________
        public static Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }
                return bm;
            }
        }
        //____________________________________________________________________________________________________________
        // Return a Bitmap holding an image of the control.
        public static Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }
        //________________________________________________________________________________________________________
        public static Color color_from_RBG_string(string str_rgb)
        {
            Color c;

            try
            {
                var v = str_rgb.Split(',');
                int r = Convert.ToInt16(v[0]);
                int g = Convert.ToInt16(v[1]);
                int b = Convert.ToInt16(v[2]);

                c = Color.FromArgb(r, g, b);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                c = Color.Black;
            }

            return c;

        }
        //____________________________________________________________________________________________________
        public static string Get_Binary_8bit(string value)
        {
            byte b = Convert.ToByte(value);
            string s = Convert.ToString(b, 2);
            s = s.PadLeft(8, '0');
            return s;
        }
        //____________________________________________________________________________________________________
        public static int Get_Int_from_Binary(string value)
        {
            Int16 val = Convert.ToInt16(value, 2);
            return val;
        }
        //____________________________________________________________________________________________________
        public static string Get_string_from_Binary(string value)
        {
            Int16 val = Convert.ToInt16(value, 2);
            return val.ToString();
        }
        //___________________________________________________________________________________________________________
        public static string Get_Hex_8bit(string value)
        {
            byte b = Convert.ToByte(value);
            string s = Convert.ToString(b, 16);
            s = s.PadLeft(2, '0');
            s = s.ToUpper();
            s = "0x" + s;
            return s;
        }
        //____________________________________________________________________________________________________
        public static bool Notbin(string s)
        {
            foreach (var c in s)
                if (c != '0' && c != '1')
                    return true;
            return false;
        }

        public static string Convert_str_bytes_from_Uint16(UInt16 val)
        {
            byte[] b = new byte[2];
            byte LSB = (byte)val;
            val = (UInt16)(val >> 8);
            byte MSB = (byte)val;

            string str_MSB = MSB.ToString();
            str_MSB = str_MSB.PadLeft(2, '0');

            string str_LSB = LSB.ToString();
            str_LSB = str_LSB.PadLeft(2, '0');

            string s = str_MSB + " " + str_LSB;
            return s;
        }

        public static string Convert_str_ASCII_from_Uint16(UInt16 val)
        {
            byte[] b = new byte[2];
            char LSB = (char)val;
            val = (UInt16)(val >> 8);
            char MSB = (char)val;
            string s = MSB.ToString() + " " + LSB.ToString();
            return s;
        }

        public static byte[] Get_Bytes_From_Uint16(UInt16[] bfr)
        {
            int index = 0;
            byte[] b = new byte[bfr.Length * sizeof(UInt16)];

            foreach (UInt16 i in bfr)
            {
                byte[] bytes = BitConverter.GetBytes(i);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                b[index] = bytes[0]; index++;
                b[index] = bytes[1]; index++;
            }
            return b;
        }

        public static bool value_Not_In_Tolerance(float v1, float v2, double tolerance)
        {
            if (Math.Abs(v1 - v2) < tolerance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static List<string> Get_list_String_From_ListBox(ListBox lb)
        {
            List<string> list = new List<string>();

            foreach (var item in lb.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public static void ComboBox_Select_Item_By_Match(ComboBox cb, string match_str)
        {
            cb.SelectedIndex = cb.FindStringExact(match_str);
        }
    
    public static void ComboBox_Set_Auto_Complete(ComboBox cb)
    {
        cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cb.AutoCompleteSource = AutoCompleteSource.ListItems;
    }
 









}//class
}// Name space