using DevExpress.XtraEditors;
using QL_QuanAn.DAO;
using QL_QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanAn
{
    public partial class FoodCategory : DevExpress.XtraEditors.XtraForm
    {
        #region Method
        BindingSource foodcategorylist = new BindingSource();
        BindingSource foodlist = new BindingSource();
        bool Add = false;
        Notification notitfy = new Notification(); //Thông báo
        public string Check { get; set; }
        private int selectedFoodCategoryId = -1;
        Dictionary<int, string> foodCategoryMap = new Dictionary<int, string>();
        #endregion Method

        public FoodCategory()
        {
            InitializeComponent();
            Load();
        }

        #region FoodCategory
        private new void Load()
        {
            dtgvFoodCategory.DataSource = foodcategorylist;
            dtgvFood.DataSource = foodlist;
            LoadListFoodCatogory();
            LoadFoodCategoryNameIntoCombobox(cbFoodCategoryName);
            //LoadListFood();

            txbFoodCategoryName.Enabled = false;

            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            cbFoodCategoryName.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void LoadListFoodCatogory()
        {
            dtgvFoodCategory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            foodcategorylist.DataSource = FoodCategoryDAO.Instance.GetListFoodCategory();

            // Đặt các thuộc tính của các cột để canh giữa
            foreach (DataGridViewColumn column in dtgvFoodCategory.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dtgvFoodCategory.Columns[0].HeaderText = "Mã loại món ăn";
            dtgvFoodCategory.Columns[0].Width = 100;

            dtgvFoodCategory.Columns[1].HeaderText = "Tên loại món ăn";
            dtgvFoodCategory.Columns[1].Width = 360;


            // Tô màu tiêu đề cột và thay đổi chiều cao
            dtgvFoodCategory.EnableHeadersVisualStyles = false;
            dtgvFoodCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dtgvFoodCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dtgvFoodCategory.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dtgvFoodCategory.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dtgvFoodCategory.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }       

        void LoadFoodCategoryNameIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            // Lấy danh sách loại món ăn từ cơ sở dữ liệu
            List<FoodCategoryDTO> foodCategories = FoodCategoryDAO.Instance.GetListFoodCategory();

            // Xóa các mục cũ trong Dictionary (nếu có)
            foodCategoryMap.Clear();

            // Duyệt qua danh sách loại món ăn và thêm vào Dictionary
            foreach (FoodCategoryDTO foodCategory in foodCategories)
            {
                foodCategoryMap.Add(foodCategory.FoodCategoryID, foodCategory.FoodCategoryName);
            }

            // Gán danh sách tên loại món ăn cho ComboBox
            cb.DataSource = foodCategories.Select(fc => fc.FoodCategoryName).ToList();
        }

        int GetFoodCategoryIdFromComboBox(System.Windows.Forms.ComboBox cb)
        {
            string selectedFoodCategoryName = cb.SelectedItem as string;

            if (selectedFoodCategoryName != null)
            {
                // Tìm mã loại món ăn từ Dictionary bằng tên loại món ăn
                if (foodCategoryMap.ContainsValue(selectedFoodCategoryName))
                {
                    return foodCategoryMap.FirstOrDefault(x => x.Value == selectedFoodCategoryName).Key;
                }
            }

            return -1; // Hoặc một giá trị khác biểu thị rằng không tìm thấy
        }

        List<FoodDTO> SearchFoodByFoodCategoryName(int foodcategoryid)
        {
            List<FoodDTO> listfood = FoodDAO.Instance.SearchFoodByFoodCategoryName(foodcategoryid);

            return listfood;
        }
        #endregion FoodCategory

        #region Food
        void LoadListFood()
        {
            dtgvFood.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            foodlist.DataSource = FoodDAO.Instance.GetListFood();

            dtgvFood.Columns["FoodcategoryID"].Visible = false;
            dtgvFood.Columns["Images"].Visible = false;

            // Đặt các thuộc tính của các cột để canh giữa
            foreach (DataGridViewColumn column in dtgvFood.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dtgvFood.Columns[0].HeaderText = "Mã món ăn";
            dtgvFood.Columns[0].Width = 70;

            dtgvFood.Columns[2].HeaderText = "Tên món ăn";
            dtgvFood.Columns[2].Width = 200;

            dtgvFood.Columns[3].HeaderText = "Đơn vị tính";
            dtgvFood.Columns[3].Width = 87;

            dtgvFood.Columns[4].HeaderText = "Giá";
            dtgvFood.Columns[4].Width = 120;

            // Tô màu tiêu đề cột và thay đổi chiều cao
            dtgvFood.EnableHeadersVisualStyles = false;
            dtgvFood.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dtgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dtgvFood.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dtgvFood.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dtgvFood.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }
        #endregion Food

        #region EV_FoodCategory
        private void dtgvFoodCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    dtgvFoodCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtgvFoodCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void dtgvFoodCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dtgvFoodCategory.Rows[e.RowIndex];
                selectedFoodCategoryId = Convert.ToInt32(selectedRow.Cells["FoodCategoryID"].Value);

                int row = dtgvFoodCategory.CurrentCell.RowIndex;
                txbFoodCategoryName.Text = dtgvFoodCategory.Rows[row].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add = true;

            txbFoodCategoryName.Enabled = true;
            txbFoodCategoryName.Clear();

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Add = false;

            txbFoodCategoryName.Enabled = true;
            txbFoodCategoryName.Clear();

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedFoodCategoryId == -1)
                {
                    notitfy.Show("Vui lòng chọn loại món ăn cần xóa!!!");
                }
                else
                {
                    if (FoodCategoryDAO.Instance.DeleteFoodCategory(selectedFoodCategoryId))
                    {
                        notitfy.Show("Xóa loại món ăn thành công!!!");
                        LoadListFoodCatogory();
                        LoadFoodCategoryNameIntoCombobox(cbFoodCategoryName);
                    }
                    else
                    {
                        notitfy.Show("xóa loại món ăn thất bại!!!");
                    }
                }
            }
            catch
            {
                notitfy.Show("Không được xóa loại món ăn!!!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string foodcategoryName = txbFoodCategoryName.Text;

            if (Add)
            {
                try
                {
                    if (FoodCategoryDAO.Instance.InsertFoodCategory(foodcategoryName))
                    {
                        notitfy.Show("Thêm loại món ăn thành công!!!");
                        LoadListFoodCatogory();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Thêm loại món ăn thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên loại món ăn đã tồn tại!!!");
                }
            }
            else
            {
                try
                {
                    if (FoodCategoryDAO.Instance.UpdateFoodCategory(selectedFoodCategoryId, foodcategoryName))
                    {
                        notitfy.Show("Sửa loại món ăn thành công!!!");
                        LoadListFoodCatogory();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Sửa loại món ăn thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên loại món ăn đã tồn tại!!!");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadListFoodCatogory();
            LoadFoodCategoryNameIntoCombobox(cbFoodCategoryName);

            txbFoodCategoryName.Enabled = false;

            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnReload.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            LoadListFoodCatogory();
            LoadFoodCategoryNameIntoCombobox(cbFoodCategoryName);

            txbFoodCategoryName.Enabled = false;

            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnReload.Enabled = true;
        }

        private void cbFoodCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int foodcategoryid = GetFoodCategoryIdFromComboBox(cbFoodCategoryName);
           
            LoadListFood(); 
            foodlist.DataSource = SearchFoodByFoodCategoryName(foodcategoryid);
        }
        #endregion EV_FoodCategory

        #region EV_Food
        private void dtgvFood_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    dtgvFood.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    dtgvFood.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        #endregion EV_Food
    }
}