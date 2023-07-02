namespace Modbus_Debug_Terminal
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lst_msg = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_do_not_process_CRC = new System.Windows.Forms.CheckBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_stop_reading = new System.Windows.Forms.Button();
            this.btn_start_reading = new System.Windows.Forms.Button();
            this.chk_same_msg = new System.Windows.Forms.CheckBox();
            this.chk_top = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_baud_rate = new System.Windows.Forms.TextBox();
            this.txt_device_ID = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_data_read = new System.Windows.Forms.Timer(this.components);
            this.txt_receive_count = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_msg
            // 
            this.lst_msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_msg.ForeColor = System.Drawing.Color.White;
            this.lst_msg.FormattingEnabled = true;
            this.lst_msg.ItemHeight = 20;
            this.lst_msg.Location = new System.Drawing.Point(18, 35);
            this.lst_msg.Name = "lst_msg";
            this.lst_msg.Size = new System.Drawing.Size(1177, 504);
            this.lst_msg.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_msg);
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1215, 567);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MESSAGE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_do_not_process_CRC);
            this.groupBox2.Controls.Add(this.txt_search);
            this.groupBox2.Controls.Add(this.btn_stop_reading);
            this.groupBox2.Controls.Add(this.btn_start_reading);
            this.groupBox2.Controls.Add(this.chk_same_msg);
            this.groupBox2.Controls.Add(this.chk_top);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_disconnect);
            this.groupBox2.Controls.Add(this.btn_connect);
            this.groupBox2.Controls.Add(this.txt_baud_rate);
            this.groupBox2.Controls.Add(this.txt_device_ID);
            this.groupBox2.Controls.Add(this.txt_port);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1233, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 567);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONFIGURATION";
            // 
            // chk_do_not_process_CRC
            // 
            this.chk_do_not_process_CRC.AutoSize = true;
            this.chk_do_not_process_CRC.Location = new System.Drawing.Point(9, 532);
            this.chk_do_not_process_CRC.Name = "chk_do_not_process_CRC";
            this.chk_do_not_process_CRC.Size = new System.Drawing.Size(89, 17);
            this.chk_do_not_process_CRC.TabIndex = 8;
            this.chk_do_not_process_CRC.Text = "Process CRC";
            this.chk_do_not_process_CRC.UseVisualStyleBackColor = true;
            this.chk_do_not_process_CRC.CheckedChanged += new System.EventHandler(this.chk_do_not_process_CRC_CheckedChanged);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(6, 490);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(185, 20);
            this.txt_search.TabIndex = 7;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // btn_stop_reading
            // 
            this.btn_stop_reading.ForeColor = System.Drawing.Color.Black;
            this.btn_stop_reading.Location = new System.Drawing.Point(108, 327);
            this.btn_stop_reading.Name = "btn_stop_reading";
            this.btn_stop_reading.Size = new System.Drawing.Size(81, 71);
            this.btn_stop_reading.TabIndex = 6;
            this.btn_stop_reading.Text = "STOP READING";
            this.btn_stop_reading.UseVisualStyleBackColor = true;
            this.btn_stop_reading.Click += new System.EventHandler(this.btn_stop_reading_Click);
            // 
            // btn_start_reading
            // 
            this.btn_start_reading.ForeColor = System.Drawing.Color.Black;
            this.btn_start_reading.Location = new System.Drawing.Point(21, 327);
            this.btn_start_reading.Name = "btn_start_reading";
            this.btn_start_reading.Size = new System.Drawing.Size(81, 71);
            this.btn_start_reading.TabIndex = 6;
            this.btn_start_reading.Text = "START READING";
            this.btn_start_reading.UseVisualStyleBackColor = true;
            this.btn_start_reading.Click += new System.EventHandler(this.btn_start_reading_Click);
            // 
            // chk_same_msg
            // 
            this.chk_same_msg.AutoSize = true;
            this.chk_same_msg.Checked = true;
            this.chk_same_msg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_same_msg.Location = new System.Drawing.Point(20, 285);
            this.chk_same_msg.Name = "chk_same_msg";
            this.chk_same_msg.Size = new System.Drawing.Size(134, 17);
            this.chk_same_msg.TabIndex = 5;
            this.chk_same_msg.Text = "Repeat same message";
            this.chk_same_msg.UseVisualStyleBackColor = true;
            this.chk_same_msg.CheckedChanged += new System.EventHandler(this.chk_same_msg_CheckedChanged);
            // 
            // chk_top
            // 
            this.chk_top.AutoSize = true;
            this.chk_top.Checked = true;
            this.chk_top.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_top.Location = new System.Drawing.Point(20, 253);
            this.chk_top.Name = "chk_top";
            this.chk_top.Size = new System.Drawing.Size(48, 17);
            this.chk_top.TabIndex = 4;
            this.chk_top.Text = "TOP";
            this.chk_top.UseVisualStyleBackColor = true;
            this.chk_top.CheckedChanged += new System.EventHandler(this.chk_top_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "DEVICE ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SEARCH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PORT";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_disconnect.Location = new System.Drawing.Point(108, 127);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(83, 40);
            this.btn_disconnect.TabIndex = 1;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_connect.Location = new System.Drawing.Point(20, 127);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(83, 40);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_baud_rate
            // 
            this.txt_baud_rate.Location = new System.Drawing.Point(91, 86);
            this.txt_baud_rate.Name = "txt_baud_rate";
            this.txt_baud_rate.Size = new System.Drawing.Size(100, 20);
            this.txt_baud_rate.TabIndex = 0;
            this.txt_baud_rate.Text = "9600";
            // 
            // txt_device_ID
            // 
            this.txt_device_ID.Location = new System.Drawing.Point(83, 196);
            this.txt_device_ID.Name = "txt_device_ID";
            this.txt_device_ID.Size = new System.Drawing.Size(100, 20);
            this.txt_device_ID.TabIndex = 0;
            this.txt_device_ID.Text = "200";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(91, 60);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 20);
            this.txt_port.TabIndex = 0;
            this.txt_port.Text = "COM7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(495, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modbus Debug Message Display";
            // 
            // timer_data_read
            // 
            this.timer_data_read.Enabled = true;
            this.timer_data_read.Interval = 1;
            this.timer_data_read.Tick += new System.EventHandler(this.timer_data_read_Tick);
            // 
            // txt_receive_count
            // 
            this.txt_receive_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_receive_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_receive_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_receive_count.Location = new System.Drawing.Point(1048, 12);
            this.txt_receive_count.Name = "txt_receive_count";
            this.txt_receive_count.Size = new System.Drawing.Size(159, 38);
            this.txt_receive_count.TabIndex = 9;
            this.txt_receive_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(948, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "RECEIVE COUNT";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1456, 641);
            this.Controls.Add(this.txt_receive_count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frm_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_msg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_baud_rate;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_data_read;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_device_ID;
        private System.Windows.Forms.CheckBox chk_top;
        private System.Windows.Forms.CheckBox chk_same_msg;
        private System.Windows.Forms.Button btn_stop_reading;
        private System.Windows.Forms.Button btn_start_reading;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_do_not_process_CRC;
        private System.Windows.Forms.TextBox txt_receive_count;
        private System.Windows.Forms.Label label6;
    }
}

