namespace winsoap_client
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_start = new System.Windows.Forms.Button();
            this.cmbbox_country = new System.Windows.Forms.ComboBox();
            this.cmbbox_city = new System.Windows.Forms.ComboBox();
            this.cmbbox_hotel = new System.Windows.Forms.ComboBox();
            this.cmbbox_specialoffer = new System.Windows.Forms.ComboBox();
            this.lbl_country = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_hotel = new System.Windows.Forms.Label();
            this.lbl_specialoffer = new System.Windows.Forms.Label();
            this.data_gr_1 = new System.Windows.Forms.DataGridView();
            this.btn_toexcel = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.cmbbox_created = new System.Windows.Forms.ComboBox();
            this.lbl_created = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chckbx_period_till = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_gr_1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(950, 156);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(133, 34);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Загрузить данные";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cmbbox_country
            // 
            this.cmbbox_country.FormattingEnabled = true;
            this.cmbbox_country.Location = new System.Drawing.Point(32, 116);
            this.cmbbox_country.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbbox_country.Name = "cmbbox_country";
            this.cmbbox_country.Size = new System.Drawing.Size(121, 21);
            this.cmbbox_country.TabIndex = 1;
            this.cmbbox_country.SelectedIndexChanged += new System.EventHandler(this.cmbbox_country_SelectedIndexChanged);
            // 
            // cmbbox_city
            // 
            this.cmbbox_city.FormattingEnabled = true;
            this.cmbbox_city.Location = new System.Drawing.Point(194, 117);
            this.cmbbox_city.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbbox_city.Name = "cmbbox_city";
            this.cmbbox_city.Size = new System.Drawing.Size(121, 21);
            this.cmbbox_city.TabIndex = 2;
            this.cmbbox_city.SelectedIndexChanged += new System.EventHandler(this.cmbbox_city_SelectedIndexChanged);
            // 
            // cmbbox_hotel
            // 
            this.cmbbox_hotel.FormattingEnabled = true;
            this.cmbbox_hotel.Location = new System.Drawing.Point(361, 117);
            this.cmbbox_hotel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbbox_hotel.Name = "cmbbox_hotel";
            this.cmbbox_hotel.Size = new System.Drawing.Size(248, 21);
            this.cmbbox_hotel.TabIndex = 3;
            this.cmbbox_hotel.SelectedIndexChanged += new System.EventHandler(this.cmbbox_hotel_SelectedIndexChanged);
            // 
            // cmbbox_specialoffer
            // 
            this.cmbbox_specialoffer.FormattingEnabled = true;
            this.cmbbox_specialoffer.Location = new System.Drawing.Point(659, 117);
            this.cmbbox_specialoffer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbbox_specialoffer.Name = "cmbbox_specialoffer";
            this.cmbbox_specialoffer.Size = new System.Drawing.Size(392, 21);
            this.cmbbox_specialoffer.TabIndex = 4;
            this.cmbbox_specialoffer.SelectedIndexChanged += new System.EventHandler(this.cmbbox_specialoffer_SelectedIndexChanged);
            // 
            // lbl_country
            // 
            this.lbl_country.AutoSize = true;
            this.lbl_country.Location = new System.Drawing.Point(29, 86);
            this.lbl_country.Name = "lbl_country";
            this.lbl_country.Size = new System.Drawing.Size(43, 13);
            this.lbl_country.TabIndex = 8;
            this.lbl_country.Text = "Страна";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Location = new System.Drawing.Point(191, 85);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(37, 13);
            this.lbl_city.TabIndex = 9;
            this.lbl_city.Text = "Город";
            // 
            // lbl_hotel
            // 
            this.lbl_hotel.AutoSize = true;
            this.lbl_hotel.Location = new System.Drawing.Point(358, 85);
            this.lbl_hotel.Name = "lbl_hotel";
            this.lbl_hotel.Size = new System.Drawing.Size(38, 13);
            this.lbl_hotel.TabIndex = 10;
            this.lbl_hotel.Text = "Отель";
            // 
            // lbl_specialoffer
            // 
            this.lbl_specialoffer.AutoSize = true;
            this.lbl_specialoffer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_specialoffer.Location = new System.Drawing.Point(656, 86);
            this.lbl_specialoffer.Name = "lbl_specialoffer";
            this.lbl_specialoffer.Size = new System.Drawing.Size(66, 13);
            this.lbl_specialoffer.TabIndex = 11;
            this.lbl_specialoffer.Text = "Special offer";
            // 
            // data_gr_1
            // 
            this.data_gr_1.AllowUserToAddRows = false;
            this.data_gr_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_gr_1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.data_gr_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_gr_1.Location = new System.Drawing.Point(12, 198);
            this.data_gr_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_gr_1.Name = "data_gr_1";
            this.data_gr_1.Size = new System.Drawing.Size(1270, 554);
            this.data_gr_1.TabIndex = 18;
            // 
            // btn_toexcel
            // 
            this.btn_toexcel.Location = new System.Drawing.Point(1126, 156);
            this.btn_toexcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_toexcel.Name = "btn_toexcel";
            this.btn_toexcel.Size = new System.Drawing.Size(133, 34);
            this.btn_toexcel.TabIndex = 20;
            this.btn_toexcel.Text = "Выгрузить в Excel";
            this.btn_toexcel.UseVisualStyleBackColor = true;
            this.btn_toexcel.Click += new System.EventHandler(this.btn_toexcel_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(559, 37);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(89, 13);
            this.lbl_title.TabIndex = 21;
            this.lbl_title.Text = "Alkhalidiah prices";
            // 
            // cmbbox_created
            // 
            this.cmbbox_created.FormattingEnabled = true;
            this.cmbbox_created.Location = new System.Drawing.Point(1081, 116);
            this.cmbbox_created.Name = "cmbbox_created";
            this.cmbbox_created.Size = new System.Drawing.Size(178, 21);
            this.cmbbox_created.TabIndex = 22;
            // 
            // lbl_created
            // 
            this.lbl_created.AutoSize = true;
            this.lbl_created.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_created.Location = new System.Drawing.Point(1078, 85);
            this.lbl_created.Name = "lbl_created";
            this.lbl_created.Size = new System.Drawing.Size(44, 13);
            this.lbl_created.TabIndex = 23;
            this.lbl_created.Text = "Created";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chckbx_period_till);
            this.panel1.Location = new System.Drawing.Point(12, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 36);
            this.panel1.TabIndex = 24;
            // 
            // chckbx_period_till
            // 
            this.chckbx_period_till.AutoSize = true;
            this.chckbx_period_till.Location = new System.Drawing.Point(20, 4);
            this.chckbx_period_till.Name = "chckbx_period_till";
            this.chckbx_period_till.Size = new System.Drawing.Size(154, 17);
            this.chckbx_period_till.TabIndex = 10;
            this.chckbx_period_till.Text = "Period_till > текущей даты";
            this.chckbx_period_till.UseVisualStyleBackColor = true;
            this.chckbx_period_till.CheckedChanged += new System.EventHandler(this.chckbx_period_till_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1294, 765);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_created);
            this.Controls.Add(this.cmbbox_created);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_toexcel);
            this.Controls.Add(this.data_gr_1);
            this.Controls.Add(this.lbl_specialoffer);
            this.Controls.Add(this.lbl_hotel);
            this.Controls.Add(this.lbl_city);
            this.Controls.Add(this.lbl_country);
            this.Controls.Add(this.cmbbox_specialoffer);
            this.Controls.Add(this.cmbbox_hotel);
            this.Controls.Add(this.cmbbox_city);
            this.Controls.Add(this.cmbbox_country);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Alhalidiah";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.data_gr_1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox cmbbox_country;
        private System.Windows.Forms.ComboBox cmbbox_city;
        private System.Windows.Forms.ComboBox cmbbox_hotel;
        private System.Windows.Forms.ComboBox cmbbox_specialoffer;
        private System.Windows.Forms.Label lbl_country;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_hotel;
        private System.Windows.Forms.Label lbl_specialoffer;
        private System.Windows.Forms.DataGridView data_gr_1;
        private System.Windows.Forms.Button btn_toexcel;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ComboBox cmbbox_created;
        private System.Windows.Forms.Label lbl_created;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chckbx_period_till;
    }
}

