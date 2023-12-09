using QL_QuanAn.Properties;

namespace QL_QuanAn
{
    partial class OrderFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderFood));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.dtgvOrderInfor = new System.Windows.Forms.DataGridView();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.grcontrlUpdate = new DevExpress.XtraEditors.GroupControl();
            this.nmrUpdateCount = new System.Windows.Forms.NumericUpDown();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblUpdateFoodname = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grctrlHandle = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.nmrCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new DevExpress.XtraEditors.SimpleButton();
            this.lblFoodName = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateBill = new DevExpress.XtraEditors.SimpleButton();
            this.pbImg = new DevExpress.XtraEditors.PictureEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabList = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dtgvFoods = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbbCategoryName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvOrderInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcontrlUpdate)).BeginInit();
            this.grcontrlUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUpdateCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlHandle)).BeginInit();
            this.grctrlHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabList)).BeginInit();
            this.xtraTabList.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.dtgvOrderInfor);
            this.groupControl4.Controls.Add(this.btnDelete);
            this.groupControl4.Controls.Add(this.btnUpdate);
            this.groupControl4.Controls.Add(this.grcontrlUpdate);
            this.groupControl4.Location = new System.Drawing.Point(917, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(459, 594);
            this.groupControl4.TabIndex = 31;
            this.groupControl4.Text = "Bàn đã đặt";
            // 
            // dtgvOrderInfor
            // 
            this.dtgvOrderInfor.AllowUserToAddRows = false;
            this.dtgvOrderInfor.AllowUserToDeleteRows = false;
            this.dtgvOrderInfor.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvOrderInfor.Location = new System.Drawing.Point(5, 248);
            this.dtgvOrderInfor.Name = "dtgvOrderInfor";
            this.dtgvOrderInfor.ReadOnly = true;
            this.dtgvOrderInfor.RowHeadersWidth = 51;
            this.dtgvOrderInfor.RowTemplate.Height = 40;
            this.dtgvOrderInfor.Size = new System.Drawing.Size(449, 337);
            this.dtgvOrderInfor.TabIndex = 15;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(240, 193);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(195, 50);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUpdate.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Appearance.Options.UseForeColor = true;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(28, 193);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(195, 50);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grcontrlUpdate
            // 
            this.grcontrlUpdate.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcontrlUpdate.AppearanceCaption.Options.UseFont = true;
            this.grcontrlUpdate.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grcontrlUpdate.CaptionImageOptions.Image")));
            this.grcontrlUpdate.Controls.Add(this.nmrUpdateCount);
            this.grcontrlUpdate.Controls.Add(this.labelControl4);
            this.grcontrlUpdate.Controls.Add(this.lblUpdateFoodname);
            this.grcontrlUpdate.Location = new System.Drawing.Point(6, 43);
            this.grcontrlUpdate.Name = "grcontrlUpdate";
            this.grcontrlUpdate.Size = new System.Drawing.Size(446, 144);
            this.grcontrlUpdate.TabIndex = 11;
            this.grcontrlUpdate.Text = "Cập nhập số lượng";
            // 
            // nmrUpdateCount
            // 
            this.nmrUpdateCount.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrUpdateCount.Location = new System.Drawing.Point(223, 94);
            this.nmrUpdateCount.Name = "nmrUpdateCount";
            this.nmrUpdateCount.Size = new System.Drawing.Size(177, 40);
            this.nmrUpdateCount.TabIndex = 25;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(51, 95);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 29);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Số lượng";
            // 
            // lblUpdateFoodname
            // 
            this.lblUpdateFoodname.Appearance.BackColor = System.Drawing.Color.DarkSalmon;
            this.lblUpdateFoodname.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateFoodname.Appearance.Options.UseBackColor = true;
            this.lblUpdateFoodname.Appearance.Options.UseFont = true;
            this.lblUpdateFoodname.Appearance.Options.UseTextOptions = true;
            this.lblUpdateFoodname.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUpdateFoodname.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUpdateFoodname.Location = new System.Drawing.Point(6, 42);
            this.lblUpdateFoodname.Name = "lblUpdateFoodname";
            this.lblUpdateFoodname.Size = new System.Drawing.Size(435, 43);
            this.lblUpdateFoodname.TabIndex = 25;
            this.lblUpdateFoodname.Text = "Tên món";
            this.lblUpdateFoodname.TextChanged += new System.EventHandler(this.lblUpdateFoodname_TextChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.grctrlHandle);
            this.groupControl1.Controls.Add(this.nmrCount);
            this.groupControl1.Controls.Add(this.btnAddFood);
            this.groupControl1.Controls.Add(this.lblFoodName);
            this.groupControl1.Controls.Add(this.btnCreateBill);
            this.groupControl1.Controls.Add(this.pbImg);
            this.groupControl1.Location = new System.Drawing.Point(661, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(249, 594);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Nhà hàng";
            // 
            // grctrlHandle
            // 
            this.grctrlHandle.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grctrlHandle.AppearanceCaption.Options.UseFont = true;
            this.grctrlHandle.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("grctrlHandle.CaptionImageOptions.SvgImage")));
            this.grctrlHandle.Controls.Add(this.btnCancel);
            this.grctrlHandle.Controls.Add(this.btnSubmit);
            this.grctrlHandle.Location = new System.Drawing.Point(10, 447);
            this.grctrlHandle.Name = "grctrlHandle";
            this.grctrlHandle.Size = new System.Drawing.Size(230, 138);
            this.grctrlHandle.TabIndex = 24;
            this.grctrlHandle.Text = "Xác nhận đặt bàn";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(40, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 39);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Appearance.Options.UseFont = true;
            this.btnSubmit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.ImageOptions.Image")));
            this.btnSubmit.Location = new System.Drawing.Point(40, 46);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(144, 39);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // nmrCount
            // 
            this.nmrCount.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrCount.Location = new System.Drawing.Point(6, 345);
            this.nmrCount.Name = "nmrCount";
            this.nmrCount.Size = new System.Drawing.Size(232, 40);
            this.nmrCount.TabIndex = 23;
            this.nmrCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Appearance.Options.UseFont = true;
            this.btnAddFood.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFood.ImageOptions.Image")));
            this.btnAddFood.Location = new System.Drawing.Point(6, 390);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(232, 42);
            this.btnAddFood.TabIndex = 22;
            this.btnAddFood.Text = "Thêm món ăn";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // lblFoodName
            // 
            this.lblFoodName.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblFoodName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodName.Appearance.Options.UseBackColor = true;
            this.lblFoodName.Appearance.Options.UseFont = true;
            this.lblFoodName.Appearance.Options.UseTextOptions = true;
            this.lblFoodName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFoodName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFoodName.Location = new System.Drawing.Point(8, 96);
            this.lblFoodName.Name = "lblFoodName";
            this.lblFoodName.Size = new System.Drawing.Size(234, 43);
            this.lblFoodName.TabIndex = 21;
            this.lblFoodName.Text = "Tên món";
            this.lblFoodName.TextChanged += new System.EventHandler(this.lblFoodName_TextChanged);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBill.Appearance.Options.UseFont = true;
            this.btnCreateBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.ImageOptions.Image")));
            this.btnCreateBill.Location = new System.Drawing.Point(8, 42);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(234, 42);
            this.btnCreateBill.TabIndex = 20;
            this.btnCreateBill.Text = "Tạo phiếu";
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // pbImg
            // 
            this.pbImg.EditValue = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
            this.pbImg.Location = new System.Drawing.Point(8, 151);
            this.pbImg.Name = "pbImg";
            this.pbImg.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbImg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pbImg.Size = new System.Drawing.Size(232, 179);
            this.pbImg.TabIndex = 19;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.xtraTabList);
            this.groupControl3.Location = new System.Drawing.Point(12, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(642, 594);
            this.groupControl3.TabIndex = 29;
            this.groupControl3.Text = "Nhà hàng Baretie";
            // 
            // xtraTabList
            // 
            this.xtraTabList.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabList.Appearance.Options.UseFont = true;
            this.xtraTabList.Location = new System.Drawing.Point(7, 43);
            this.xtraTabList.Name = "xtraTabList";
            this.xtraTabList.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabList.Size = new System.Drawing.Size(630, 546);
            this.xtraTabList.TabIndex = 0;
            this.xtraTabList.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.dtgvFoods);
            this.xtraTabPage1.Controls.Add(this.cbbCategoryName);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl13);
            this.xtraTabPage1.Controls.Add(this.txtSearch);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(628, 511);
            this.xtraTabPage1.Text = "Danh sách món ăn";
            // 
            // dtgvFoods
            // 
            this.dtgvFoods.AllowUserToAddRows = false;
            this.dtgvFoods.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dtgvFoods.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvFoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFoods.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgvFoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvFoods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dtgvFoods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvFoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvFoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.DVT,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvFoods.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvFoods.EnableHeadersVisualStyles = false;
            this.dtgvFoods.Location = new System.Drawing.Point(3, 58);
            this.dtgvFoods.Name = "dtgvFoods";
            this.dtgvFoods.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvFoods.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvFoods.RowHeadersVisible = false;
            this.dtgvFoods.RowHeadersWidth = 51;
            this.dtgvFoods.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvFoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvFoods.Size = new System.Drawing.Size(621, 454);
            this.dtgvFoods.TabIndex = 26;
            this.dtgvFoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvFoods_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MAMON";
            this.Column1.HeaderText = "Mã món";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENMON";
            this.Column2.HeaderText = "Tên món";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // DVT
            // 
            this.DVT.HeaderText = "Đơn vị tính";
            this.DVT.MinimumWidth = 6;
            this.DVT.Name = "DVT";
            this.DVT.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DONGIA";
            this.Column3.HeaderText = "Đơn giá";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "HINHANH";
            this.Column4.HeaderText = "Hình";
            this.Column4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cbbCategoryName
            // 
            this.cbbCategoryName.EditValue = "Tất cả";
            this.cbbCategoryName.Location = new System.Drawing.Point(437, 18);
            this.cbbCategoryName.Name = "cbbCategoryName";
            this.cbbCategoryName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategoryName.Properties.Appearance.Options.UseFont = true;
            this.cbbCategoryName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbCategoryName.Properties.Items.AddRange(new object[] {
            "Tất Cả"});
            this.cbbCategoryName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbbCategoryName.Size = new System.Drawing.Size(174, 30);
            this.cbbCategoryName.TabIndex = 25;
            this.cbbCategoryName.SelectedIndexChanged += new System.EventHandler(this.cbbCategoryName_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(344, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 23);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Loại món";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(15, 21);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(88, 23);
            this.labelControl13.TabIndex = 23;
            this.labelControl13.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(111, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txtSearch.Size = new System.Drawing.Size(227, 30);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // OrderFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 618);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl3);
            this.IconOptions.Image = global::QL_QuanAn.Properties.Resources.logo;
            this.Name = "OrderFood";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn món ăn";
            this.Load += new System.EventHandler(this.OrderFood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvOrderInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcontrlUpdate)).EndInit();
            this.grcontrlUpdate.ResumeLayout(false);
            this.grcontrlUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUpdateCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grctrlHandle)).EndInit();
            this.grctrlHandle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabList)).EndInit();
            this.xtraTabList.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.GroupControl grcontrlUpdate;
        private System.Windows.Forms.NumericUpDown nmrUpdateCount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblUpdateFoodname;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl grctrlHandle;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private System.Windows.Forms.NumericUpDown nmrCount;
        private DevExpress.XtraEditors.SimpleButton btnAddFood;
        private DevExpress.XtraEditors.LabelControl lblFoodName;
        private DevExpress.XtraEditors.SimpleButton btnCreateBill;
        private DevExpress.XtraEditors.PictureEdit pbImg;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraTab.XtraTabControl xtraTabList;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbCategoryName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private System.Windows.Forms.DataGridView dtgvFoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridView dtgvOrderInfor;
    }
}