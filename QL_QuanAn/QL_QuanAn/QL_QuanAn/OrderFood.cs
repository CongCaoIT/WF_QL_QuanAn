using DevExpress.XtraEditors;
using QL_QuanAn.DAO;
using QL_QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanAn
{
    public partial class OrderFood : DevExpress.XtraEditors.XtraForm
    {
        #region Method
        Notification notification = new Notification();

        public string CurrentlySelectedTableId { get; set; }
        public string EmployeeId { get; set; }
        public string FoodIdInMenu { get; set; }
        public string FoodIdInBillInfo { get; set; }
        public string CurrentlySelectedBillId { get; set; }
        public string Check { get; set; }
        public string FoodName { get; set; }

        string StatusTable;
        DateTime BillCreateDate = DateTime.Now;
        #endregion Method
        public OrderFood()
        {
            InitializeComponent();
        }

        #region OrtherFood
        public void LoadData()
        {
            GetMenu(dtgvFoods);
            LoadComboboxFoodCategory(cbbCategoryName);
            LoadInfomationTable(CurrentlySelectedTableId, dtgvOrderInfor);

            FoodIdInMenu = "0";

            StatusTable = TableDAO.Instance.GetStatusByTable(Int32.Parse(CurrentlySelectedTableId));

            if (StatusTable == "Đã đặt")
            {
                xtraTabList.Enabled = true;
                nmrCount.Enabled = true;
                grctrlHandle.Enabled = true;
                btnAddFood.Enabled = false;
                btnCreateBill.Enabled = false;
            }
            else
            {
                xtraTabList.Enabled = false;
                nmrCount.Enabled = false;
                grctrlHandle.Enabled = false;
                btnAddFood.Enabled = false;
                btnCreateBill.Enabled = true;
            }
        }

        public void GetMenu(DataGridView dataGridView)
        {
            Image img = null;

            List<FoodDTO> foods = new List<FoodDTO>();

            foods = FoodDAO.Instance.GetListFood();

            DataTable data = new DataTable();

            data.Columns.Add("Mã món");
            data.Columns.Add("Tên món");
            data.Columns.Add("Đơn vị tính");
            data.Columns.Add("Đơn giá");
            data.Columns.Add("Hình ảnh");

            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows.Clear();
            }

            foreach (var food in foods)
            {
                dataGridView.RowTemplate.Height = 110;

                try
                {
                    if (food.Images.Trim() != "No Image" || food.Images.Trim() == "NULL")
                    {
                        img = Image.FromFile(food.Images);
                    }
                    else
                    {
                        img = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
                    }
                    dataGridView.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch
                {
                    img = img = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
                    dataGridView.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            // Đặt các thuộc tính của các cột để canh giữa và in đậm
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dataGridView.Columns[0].Width = 40;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 40;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 100;

            // Tô màu tiêu đề cột và thay đổi chiều cao
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dataGridView.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dataGridView.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dataGridView.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }

        public void LoadComboboxFoodCategory(ComboBoxEdit cbb)
        {
            for (int i = cbb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbb.Properties.Items.RemoveAt(i);
            }

            List<FoodCategoryDTO> foodCategorys = new List<FoodCategoryDTO>();

            foodCategorys = FoodCategoryDAO.Instance.GetListFoodCategory();

            cbb.Properties.Items.Add("Tất cả");
            foreach (var foodCategory in foodCategorys)
            {
                cbb.Properties.Items.Add(foodCategory.FoodCategoryName.Trim());
            }
        }

        public void LoadInfomationTable(string tableId, DataGridView dataGridView)
        {
            BillDTO bill = new BillDTO();

            bill = BillDAO.Instance.GetBillByTable(Int32.Parse(tableId));

            List<BillInfoDTO> billInfos = new List<BillInfoDTO>();

            billInfos = BillInfoDAO.Instance.GetBillInfoByBill(bill.BillID);

            DataTable data = new DataTable();

            data.Columns.Add("Mã món");
            data.Columns.Add("Tên món");
            data.Columns.Add("Đơn giá");
            data.Columns.Add("Số lượng");

            foreach (var billInfo in billInfos)
            {
                data.Rows.Add(billInfo.FoodID, FoodDAO.Instance.GetFoodNameByFoodId(billInfo.FoodID), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", FoodDAO.Instance.GetUnitPriceByFoodId(billInfo.FoodID)), billInfo.Quanlity);
            }

            dataGridView.DataSource = data;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Đặt các thuộc tính của các cột để canh giữa và in đậm
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 60;
            dataGridView.Columns[3].Width = 50;

            // Tô màu tiêu đề cột và thay đổi chiều cao
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dataGridView.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dataGridView.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dataGridView.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }

        public void GetImage(int foodId, PictureEdit picFood)
        {
            List<FoodDTO> foods = new List<FoodDTO>();

            foods = FoodDAO.Instance.GetListFood();

            foreach (var food in foods)
            {
                try
                {
                    if (food.FoodID == foodId)
                    {
                        if (food.Images.Trim() != "No Image" || food.Images.Trim() == "NULL")
                        {
                            picFood.Image = Image.FromFile(food.Images);
                        }
                        else
                        {
                            picFood.Image = Image.FromFile(food.Images);
                        }
                    }
                }
                catch
                {
                    picFood.Image = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
                }
            }
        }

        public void SearchFood(DataGridView dtvFoods, TextEdit txbSearch, ComboBoxEdit cbbCategory)
        {
            Image img = null;

            if (cbbCategory.Text == "Tất cả")
            {
                List<FoodDTO> searchFoods = new List<FoodDTO>();

                searchFoods = FoodDAO.Instance.SearchFood(txbSearch.Text.Trim());

                DataTable data = new DataTable();

                data.Columns.Add("Mã món");
                data.Columns.Add("Tên món");
                data.Columns.Add("Đơn vị tính");
                data.Columns.Add("Đơn giá");
                data.Columns.Add("Hình ảnh");

                dtvFoods.Rows.Clear();

                foreach (var food in searchFoods)
                {
                    dtvFoods.RowTemplate.Height = 110;

                    try
                    {
                        if (food.Images.Trim() != "No Image" )
                        {
                            img = Image.FromFile(food.Images);
                        }
                        else
                        {
                            img = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
                        }

                        dtvFoods.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                        dtvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    catch
                    {
                        //img = Image.FromFile("");
                        dtvFoods.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                        dtvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            else
            {
                List<FoodDTO> searchFoods = new List<FoodDTO>();

                searchFoods = FoodDAO.Instance.SearchFoodByCategoty(txbSearch.Text.Trim(), cbbCategory.Text.Trim());

                DataTable data = new DataTable();

                data.Columns.Add("Mã món");
                data.Columns.Add("Tên món");
                data.Columns.Add("Đơn vị tính");
                data.Columns.Add("Đơn giá");
                data.Columns.Add("Hình ảnh");

                dtvFoods.Rows.Clear();

                foreach (var food in searchFoods)
                {
                    //dtvFoods.RowTemplate.Resizable = DataGridViewTriState.True;
                    dtvFoods.RowTemplate.Height = 110;

                    try
                    {
                        if (food.Images.Trim() != "No Image")
                        {
                            img = Image.FromFile(food.Images);
                        }
                        else
                        {
                            img = global::QL_QuanAn.Properties.Resources._191_170_AnhMeNu;
                        }

                        dtvFoods.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                        dtvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    catch
                    {
                        //img = Image.FromFile("");
                        dtvFoods.Rows.Add(food.FoodID, food.FoodName.Trim(), food.FoodUnit.Trim(), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", food.Price), img);
                        dtvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
        }
        #endregion OrtherFood

        #region EV_OrtherFood

        private void OrderFood_Load(object sender, EventArgs e)
        {
            LoadData();

            nmrCount.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                BillDAO.Instance.InsertBill(BillCreateDate, Int32.Parse(CurrentlySelectedTableId), EmployeeId);
                TableDAO.Instance.UpdateStatusTable(Int32.Parse(CurrentlySelectedTableId), "Đã đặt");

                xtraTabList.Enabled = true;
                grctrlHandle.Enabled = true;
                btnCreateBill.Enabled = false;
            }
            catch
            {
                notification.Show("Lỗi rồi!!!");
            }
        }

        private void dtgvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnAddFood.Enabled = true;

                int row = dtgvFoods.CurrentCell.RowIndex;

                lblFoodName.Text = dtgvFoods.Rows[row].Cells[1].Value.ToString().Trim();
                nmrCount.Enabled = true;

                FoodIdInMenu = dtgvFoods.Rows[row].Cells[0].Value.ToString().Trim();

                GetImage(Int32.Parse(FoodIdInMenu), pbImg);
            }
            catch { }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            BillDTO bill = new BillDTO();

            bill = BillDAO.Instance.GetBillByTable(Int32.Parse(CurrentlySelectedTableId));

            CurrentlySelectedBillId = bill.BillID.ToString().Trim();

            List<BillInfoDTO> billInfos = new List<BillInfoDTO>();

            billInfos = BillInfoDAO.Instance.GetBillInfoByBill(Int32.Parse(CurrentlySelectedBillId));

            if (billInfos.Any(row => row.FoodID.ToString() == FoodIdInMenu))
            {
                notification.Show("Không thể thêm món trùng nhau!!!");
                return;
            }

            if (BillInfoDAO.Instance.InsertBillInfo(Int32.Parse(CurrentlySelectedBillId), Int32.Parse(FoodIdInMenu), Int32.Parse(nmrCount.Value.ToString().Trim())))
            {
                LoadInfomationTable(CurrentlySelectedTableId, dtgvOrderInfor);
                notification.Show("Thêm món ăn thành công.");
                btnSubmit.Enabled = true;
            }
            else
            {
                notification.Show("Lỗi rồi!!!");
                return;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                notification.Show("Đã đặt món thành công.");
                this.Hide();
            }
            catch
            {
                notification.Show("Lỗi rồi!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int row = dtgvOrderInfor.CurrentCell.RowIndex;

            MessageBoxYesNo messageBoxYesNo = new MessageBoxYesNo();

            messageBoxYesNo.Notify = "Bạn có muốn xóa " + dtgvOrderInfor.Rows[row].Cells[1].Value.ToString().Trim() + " không?";
            messageBoxYesNo.ShowDialog();
            messageBoxYesNo.Hide();

            Check = messageBoxYesNo.Check;

            if (Check == "Có")
            {
                try
                {
                    BillDTO bill = new BillDTO();

                    bill = BillDAO.Instance.GetBillByTable(Int32.Parse(CurrentlySelectedTableId));

                    BillInfoDAO.Instance.DeleteBillInfoByBillIdAndFoodId(bill.BillID, Int32.Parse(FoodIdInBillInfo));

                    notification.Show("Xóa khỏi danh sách thành công.");

                    LoadData();

                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                catch
                {
                    notification.Show("Lỗi rồi!!!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TableDTO table = new TableDTO();

            table = TableDAO.Instance.GetTableByTableId(Int32.Parse(CurrentlySelectedTableId));

            MessageBoxYesNo messageBoxYesNo = new MessageBoxYesNo();

            messageBoxYesNo.Notify = "Bạn có muốn hủy bàn " + table.Tablename + " không?";
            messageBoxYesNo.ShowDialog();
            messageBoxYesNo.Hide();

            Check = messageBoxYesNo.Check;

            if (Check == "Có")
            {
                try
                {
                    BillDTO bill = new BillDTO();

                    bill = BillDAO.Instance.GetBillByTable(Int32.Parse(CurrentlySelectedTableId));

                    BillDAO.Instance.DeleteBill(bill.BillID);

                    TableDAO.Instance.UpdateStatusTable(Int32.Parse(CurrentlySelectedTableId), "Trống");

                    notification.Show("Xóa bàn thành công.");

                    this.Hide();
                }
                catch
                {
                    notification.Show("Lỗi rồi!!!");
                }
            }
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            SearchFood(dtgvFoods, txtSearch, cbbCategoryName);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BillDTO bill = new BillDTO();

                bill = BillDAO.Instance.GetBillByTable(Int32.Parse(CurrentlySelectedTableId));

                BillInfoDAO.Instance.UpdateCountInBillInfo(bill.BillID, Int32.Parse(FoodIdInBillInfo), Int32.Parse(nmrUpdateCount.Value.ToString()));

                notification.Show("Cập nhật bàn thành công.");

                LoadData();

                LoadInfomationTable(CurrentlySelectedTableId, dtgvOrderInfor);
            }
            catch
            {
                notification.Show("Lỗi rồi!!!");
            }
        }

        private void cbbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFood(dtgvFoods, txtSearch, cbbCategoryName);
        }

        private void lblFoodName_TextChanged(object sender, EventArgs e)
        {
            nmrCount.Enabled = true;
        }

        private void lblUpdateFoodname_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void dtgvOrderInfor_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = dtgvOrderInfor.CurrentCell.RowIndex;

            FoodIdInBillInfo = dtgvOrderInfor.Rows[row].Cells[0].Value.ToString().Trim();
            FoodName = dtgvOrderInfor.Rows[row].Cells[1].Value.ToString().Trim();

            nmrUpdateCount.Value = Int32.Parse(dtgvOrderInfor.Rows[row].Cells[3].Value.ToString().Trim());
            lblUpdateFoodname.Text = FoodName;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        #endregion EV_OrtherFood
    }
}