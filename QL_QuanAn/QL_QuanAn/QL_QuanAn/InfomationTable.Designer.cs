namespace QL_QuanAn
{
    partial class InfomationTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfomationTable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHienThi = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOrderTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnCombineTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnSwitchTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddFood = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.btnInBill = new DevExpress.XtraEditors.SimpleButton();
            this.lblBangChu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dtgvTableDetails = new System.Windows.Forms.DataGridView();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lblTTKhachDT = new DevExpress.XtraEditors.LabelControl();
            this.grctrlDSBan = new DevExpress.XtraEditors.GroupControl();
            this.tabctrlTable = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTableDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlDSBan)).BeginInit();
            this.grctrlDSBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHienThi
            // 
            this.lblHienThi.Appearance.BackColor = System.Drawing.Color.YellowGreen;
            this.lblHienThi.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHienThi.Appearance.Options.UseBackColor = true;
            this.lblHienThi.Appearance.Options.UseFont = true;
            this.lblHienThi.Appearance.Options.UseTextOptions = true;
            this.lblHienThi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblHienThi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHienThi.Location = new System.Drawing.Point(12, 464);
            this.lblHienThi.Name = "lblHienThi";
            this.lblHienThi.Size = new System.Drawing.Size(155, 142);
            this.lblHienThi.TabIndex = 5;
            this.lblHienThi.Text = "Chưa Chọn Bàn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnOrderTable);
            this.panel1.Controls.Add(this.btnCombineTable);
            this.panel1.Controls.Add(this.btnSwitchTable);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 455);
            this.panel1.TabIndex = 4;
            // 
            // btnOrderTable
            // 
            this.btnOrderTable.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderTable.Appearance.Options.UseFont = true;
            this.btnOrderTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderTable.ImageOptions.Image")));
            this.btnOrderTable.Location = new System.Drawing.Point(9, 390);
            this.btnOrderTable.Name = "btnOrderTable";
            this.btnOrderTable.Size = new System.Drawing.Size(135, 42);
            this.btnOrderTable.TabIndex = 13;
            this.btnOrderTable.Text = "Đặt Bàn";
            this.btnOrderTable.Click += new System.EventHandler(this.btnOrderTable_Click_1);
            // 
            // btnCombineTable
            // 
            this.btnCombineTable.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombineTable.Appearance.Options.UseFont = true;
            this.btnCombineTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCombineTable.ImageOptions.Image")));
            this.btnCombineTable.Location = new System.Drawing.Point(9, 298);
            this.btnCombineTable.Name = "btnCombineTable";
            this.btnCombineTable.Size = new System.Drawing.Size(135, 42);
            this.btnCombineTable.TabIndex = 12;
            this.btnCombineTable.Text = "Gộp Bàn";
            this.btnCombineTable.Click += new System.EventHandler(this.btnCombineTable_Click_1);
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.Appearance.Options.UseFont = true;
            this.btnSwitchTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchTable.ImageOptions.Image")));
            this.btnSwitchTable.Location = new System.Drawing.Point(9, 206);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(135, 42);
            this.btnSwitchTable.TabIndex = 11;
            this.btnSwitchTable.Text = "Chuyển Bàn";
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // btnReload
            // 
            this.btnReload.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Appearance.Options.UseFont = true;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.Location = new System.Drawing.Point(9, 114);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(135, 42);
            this.btnReload.TabIndex = 10;
            this.btnReload.Text = "Trả Lại";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Appearance.Options.UseFont = true;
            this.btnAddFood.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFood.ImageOptions.Image")));
            this.btnAddFood.Location = new System.Drawing.Point(9, 22);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(135, 42);
            this.btnAddFood.TabIndex = 9;
            this.btnAddFood.Text = "Chọn Món";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.txbTotal);
            this.groupControl3.Controls.Add(this.btnInBill);
            this.groupControl3.Controls.Add(this.lblBangChu);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Location = new System.Drawing.Point(174, 464);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(533, 142);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "Tính Tiền";
            // 
            // txbTotal
            // 
            this.txbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTotal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.Location = new System.Drawing.Point(127, 51);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(246, 26);
            this.txbTotal.TabIndex = 15;
            // 
            // btnInBill
            // 
            this.btnInBill.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBill.Appearance.Options.UseFont = true;
            this.btnInBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInBill.ImageOptions.Image")));
            this.btnInBill.Location = new System.Drawing.Point(406, 45);
            this.btnInBill.Name = "btnInBill";
            this.btnInBill.Size = new System.Drawing.Size(122, 92);
            this.btnInBill.TabIndex = 14;
            this.btnInBill.Text = "Xuất HD";
            this.btnInBill.Click += new System.EventHandler(this.btnInBill_Click);
            // 
            // lblBangChu
            // 
            this.lblBangChu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangChu.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBangChu.Appearance.Options.UseFont = true;
            this.lblBangChu.Appearance.Options.UseForeColor = true;
            this.lblBangChu.Appearance.Options.UseTextOptions = true;
            this.lblBangChu.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBangChu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblBangChu.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangChu.AppearancePressed.Options.UseFont = true;
            this.lblBangChu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBangChu.Location = new System.Drawing.Point(15, 81);
            this.lblBangChu.Name = "lblBangChu";
            this.lblBangChu.Size = new System.Drawing.Size(385, 56);
            this.lblBangChu.TabIndex = 2;
            this.lblBangChu.Text = "Bằng Chữ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AppearancePressed.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(15, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(87, 36);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tổng Tiền:";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.dtgvTableDetails);
            this.groupControl2.Controls.Add(this.btnRemove);
            this.groupControl2.Controls.Add(this.lblTTKhachDT);
            this.groupControl2.Location = new System.Drawing.Point(713, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(527, 602);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Chi Tiết Đặt Bàn";
            // 
            // dtgvTableDetails
            // 
            this.dtgvTableDetails.AllowUserToAddRows = false;
            this.dtgvTableDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dtgvTableDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvTableDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTableDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgvTableDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvTableDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dtgvTableDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTableDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvTableDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvTableDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvTableDetails.EnableHeadersVisualStyles = false;
            this.dtgvTableDetails.Location = new System.Drawing.Point(2, 116);
            this.dtgvTableDetails.Name = "dtgvTableDetails";
            this.dtgvTableDetails.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTableDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvTableDetails.RowTemplate.Height = 40;
            this.dtgvTableDetails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTableDetails.Size = new System.Drawing.Size(523, 484);
            this.dtgvTableDetails.TabIndex = 11;
            // 
            // btnRemove
            // 
            this.btnRemove.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Appearance.Options.UseFont = true;
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.Location = new System.Drawing.Point(436, 43);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(76, 64);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Hủy";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblTTKhachDT
            // 
            this.lblTTKhachDT.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTTKhachDT.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTKhachDT.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTTKhachDT.Appearance.Options.UseBackColor = true;
            this.lblTTKhachDT.Appearance.Options.UseFont = true;
            this.lblTTKhachDT.Appearance.Options.UseForeColor = true;
            this.lblTTKhachDT.Appearance.Options.UseTextOptions = true;
            this.lblTTKhachDT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTTKhachDT.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTTKhachDT.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTTKhachDT.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTKhachDT.AppearancePressed.Options.UseFont = true;
            this.lblTTKhachDT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTTKhachDT.Location = new System.Drawing.Point(5, 42);
            this.lblTTKhachDT.Name = "lblTTKhachDT";
            this.lblTTKhachDT.Size = new System.Drawing.Size(425, 65);
            this.lblTTKhachDT.TabIndex = 3;
            this.lblTTKhachDT.Text = "Thông Tin Khách Đặt Trước: ";
            // 
            // grctrlDSBan
            // 
            this.grctrlDSBan.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grctrlDSBan.AppearanceCaption.Options.UseFont = true;
            this.grctrlDSBan.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grctrlDSBan.CaptionImageOptions.Image")));
            this.grctrlDSBan.Controls.Add(this.tabctrlTable);
            this.grctrlDSBan.Location = new System.Drawing.Point(174, 4);
            this.grctrlDSBan.Name = "grctrlDSBan";
            this.grctrlDSBan.Size = new System.Drawing.Size(533, 454);
            this.grctrlDSBan.TabIndex = 6;
            this.grctrlDSBan.Text = "Danh Sách Bàn";
            // 
            // tabctrlTable
            // 
            this.tabctrlTable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabctrlTable.Location = new System.Drawing.Point(5, 36);
            this.tabctrlTable.Name = "tabctrlTable";
            this.tabctrlTable.SelectedIndex = 0;
            this.tabctrlTable.Size = new System.Drawing.Size(523, 413);
            this.tabctrlTable.TabIndex = 0;
            // 
            // InfomationTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 618);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grctrlDSBan);
            this.Controls.Add(this.lblHienThi);
            this.Controls.Add(this.panel1);
            this.Name = "InfomationTable";
            this.Text = "Thông tin bàn ăn";
            this.Load += new System.EventHandler(this.InfomationTable_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTableDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlDSBan)).EndInit();
            this.grctrlDSBan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnInBill;
        private DevExpress.XtraEditors.LabelControl lblBangChu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.LabelControl lblTTKhachDT;
        private DevExpress.XtraEditors.GroupControl grctrlDSBan;
        private System.Windows.Forms.TabControl tabctrlTable;
        private DevExpress.XtraEditors.LabelControl lblHienThi;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnOrderTable;
        private DevExpress.XtraEditors.SimpleButton btnCombineTable;
        private DevExpress.XtraEditors.SimpleButton btnSwitchTable;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnAddFood;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.DataGridView dtgvTableDetails;
    }
}