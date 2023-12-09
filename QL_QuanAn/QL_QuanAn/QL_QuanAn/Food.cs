using DevExpress.Office.Model;
using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class Food : DevExpress.XtraEditors.XtraForm
    {
        #region Method
        BindingSource foodlist = new BindingSource();
        bool Add = false;
        Notification notitfy = new Notification(); //Thông báo
        public string Check { get; set; }
        Dictionary<int, string> foodCategoryMap = new Dictionary<int, string>();
        private int selectedFoodCategoryId = -1;
        #endregion Method

        public Food()
        {
            InitializeComponent();
            Load();
        }

        #region Food
        private new void Load()
        {
            dtgvFood.DataSource = foodlist;
            LoadListFood();
            LoadFoodCategoryNameIntoCombobox(cbFoodCategoryName);
            GetFoodCategoryIdFromComboBox(cbFoodCategoryName);

            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnReload.Enabled = true;

            txbFoodID.Enabled = false;
            txbFoodName.Enabled = false;
            txbUnit.Enabled = false;
            txbPrice.Enabled = false;
            cbFoodCategoryName.Enabled = false;
            txbLinkImages.Enabled = false;
            btnAddImages.Enabled = false;

            txbFoodID.Clear();
            txbFoodName.Clear();
            txbUnit.Clear();
            txbPrice.Clear();
            txbLinkImages.Clear();
        }

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
            dtgvFood.Columns[3].Width = 60;

            dtgvFood.Columns[4].HeaderText = "Giá";
            dtgvFood.Columns[4].Width = 90;

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
            dtgvFood.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvFood.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgvFood.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvFood.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private string GetFoodCategoryName(int foodCategoryID)
        {
            // Duyệt qua Dictionary để tìm tên loại món ăn tương ứng với mã loại món ăn
            foreach (var entry in foodCategoryMap)
            {
                if (entry.Key == foodCategoryID)
                {
                    return entry.Value;
                }
            }
            // Nếu không tìm thấy, trả về một giá trị mặc định hoặc thông báo lỗi
            return "Không tìm thấy";
        }
        #endregion Food

        #region FoodRecipes
        void LoadListFoodRecipes()
        {
            List<FoodDTO> food = FoodDAO.Instance.GetListFood();
            List<IngredientDTO> ingredient = IngredientDAO.Instance.GetListIngredient();

            dtgvFoodRecipes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            var foodRecipesList = FoodRecipesDAO.Instance.GetFoodRecipesByFoodID(int.Parse(txbFoodID.Text));

            // Clear existing columns in the DataGridView
            dtgvFoodRecipes.DataSource = null;
            dtgvFoodRecipes.Rows.Clear();
            dtgvFoodRecipes.Columns.Clear();

            // Add new columns
            dtgvFoodRecipes.Columns.Add("FoodRecipesID", "Mã công thức");
            dtgvFoodRecipes.Columns.Add("FoodName", "Tên món ăn");
            dtgvFoodRecipes.Columns.Add("IngredientName", "Tên nguyên liệu");
            dtgvFoodRecipes.Columns.Add("FoodContent", "Hàm lượng");

            // Set column properties
            foreach (DataGridViewColumn column in dtgvFoodRecipes.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;

                // Hide the "Mã công thức" column
                if (column.Name == "FoodRecipesID")
                {
                    column.Visible = false;
                }
            }

            dtgvFoodRecipes.EnableHeadersVisualStyles = false;
            dtgvFoodRecipes.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
            dtgvFoodRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvFoodRecipes.ColumnHeadersHeight = 50;
            dtgvFoodRecipes.RowTemplate.Height = 40;

            // Set column widths for "Tên món ăn," "Tên nguyên liệu," and "Hàm lượng"
            dtgvFoodRecipes.Columns["FoodName"].Width = 100;
            dtgvFoodRecipes.Columns["IngredientName"].Width = 100;
            dtgvFoodRecipes.Columns["FoodContent"].Width = 85;

            // Initialize variables to keep track of the current food ID
            int currentFoodID = -1;

            // Populate the DataGridView with data
            foreach (var foodRecipe in foodRecipesList)
            {
                var foodID = foodRecipe.FoodID;
                var ingredientID = foodRecipe.IngredientID;

                // Find food and ingredient names
                var foodName = food.FirstOrDefault(f => f.FoodID == foodID)?.FoodName;
                var ingredientName = ingredient.FirstOrDefault(row => row.IngredientID == ingredientID)?.IngredientName;

                // Check if the food ID has changed
                if (currentFoodID != foodID)
                {
                    // Add a new row with the food name
                    dtgvFoodRecipes.Rows.Add(foodRecipe.FoodRecipesID, foodName, ingredientName, foodRecipe.FoodContent);

                    // Update the current food ID
                    currentFoodID = foodID;
                }
                else
                {
                    // Add a blank row for subsequent ingredients of the same food
                    var row = dtgvFoodRecipes.Rows.Add(null, null, ingredientName, foodRecipe.FoodContent);
                }
            }
        }
        #endregion FoodRecipes

        #region EV_Food

        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dtgvFood.Rows[e.RowIndex];
                selectedFoodCategoryId = Convert.ToInt32(selectedRow.Cells["FoodCategoryID"].Value);

                int row = dtgvFood.CurrentCell.RowIndex;
                txbFoodID.Text = dtgvFood.Rows[row].Cells[0].Value.ToString();
                txbFoodName.Text = dtgvFood.Rows[row].Cells[2].Value.ToString();
                txbUnit.Text = dtgvFood.Rows[row].Cells[3].Value.ToString();
                txbPrice.Text = dtgvFood.Rows[row].Cells[4].Value.ToString();
                //txbLinkImages.Text = dtgvFood.Rows[row].Cells[5].Value.ToString();

                // Lấy mã loại món ăn từ DataGridView
                int foodCategoryID = Convert.ToInt32(selectedRow.Cells["FoodCategoryID"].Value);

                // Tìm tên loại món ăn tương ứng từ Dictionary
                string foodCategoryName = GetFoodCategoryName(foodCategoryID);

                // Gán tên loại món ăn vào ComboBox
                cbFoodCategoryName.Text = foodCategoryName;

                string imagePath = dtgvFood.Rows[row].Cells["Images"].Value.ToString();

                // Kiểm tra xem đường dẫn hình ảnh có hợp lệ không
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    // Load the image
                    Image img = Image.FromFile(imagePath);

                    // Set PictureEdit properties
                    pictureImages.Image = img;
                    pictureImages.Properties.SizeMode = PictureSizeMode.Zoom; // Adjust the property based on DevExpress control
                }
                else
                {
                    // Nếu không tìm thấy hình ảnh, bạn có thể hiển thị một hình mặc định hoặc xử lý theo ý của bạn
                    pictureImages.Image = null;
                    pictureImages.Properties.SizeMode = PictureSizeMode.Squeeze; // Adjust the property based on DevExpress control
                }
                LoadListFoodRecipes();
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;

            txbFoodID.Enabled = false;
            txbFoodID.Clear();
            txbFoodName.Clear();
            txbUnit.Clear();
            txbPrice.Clear();
            txbLinkImages.Clear();

            txbFoodID.Enabled = false;
            txbFoodName.Enabled = true;
            txbUnit.Enabled = true;
            txbPrice.Enabled = true;
            cbFoodCategoryName.Enabled = true;
            txbLinkImages.Enabled = true;
            btnAddImages.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Add = false;

            if (txbFoodID.Text == "")
            {
                notitfy.Show("Vui lòng chọn món ăn cần sửa!!!");
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;

            txbFoodID.Enabled = false;
            cbFoodCategoryName.DropDownStyle = ComboBoxStyle.DropDownList;

            txbFoodID.Enabled = true;
            txbFoodName.Enabled = true;
            txbUnit.Enabled = true;
            txbPrice.Enabled = true;
            cbFoodCategoryName.Enabled = true;
            txbLinkImages.Enabled = true;
            btnAddImages.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string foodname = txbFoodName.Text;
            string unit = txbUnit.Text;
            double price = Convert.ToDouble(txbPrice.Text);
            string images = txbLinkImages.Text;
            int foodCategoryId = GetFoodCategoryIdFromComboBox(cbFoodCategoryName);

            if (Add)
            {
                try
                {
                    if (FoodDAO.Instance.InsertFood(foodCategoryId, foodname, unit, price, images))
                    {
                        notitfy.Show("Thêm món ăn thành công!!!");
                        LoadListFood();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                        btnAddImages.Enabled = false;

                        txbFoodID.Enabled = false;
                        txbFoodName.Enabled = false;
                        txbPrice.Enabled = false;
                        txbUnit.Enabled = false;
                        cbFoodCategoryName.Enabled = false;
                        txbLinkImages.Enabled = false;

                        txbLinkImages.Clear();
                    }
                    else
                    {
                        notitfy.Show("Thêm món ăn thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên món ăn đã tồn tại!!!");
                }
            }
            else
            {
                try
                {
                    int foodid = int.Parse(txbFoodID.Text);
                    if (FoodDAO.Instance.UpdateFood(foodid, foodCategoryId, foodname, unit, price, images))
                    {
                        notitfy.Show("Sửa món ăn thành công!!!");
                        LoadListFood();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;


                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                        btnAddImages.Enabled = false;

                        txbFoodID.Enabled = false;
                        txbFoodName.Enabled = false;
                        txbPrice.Enabled = false;
                        txbUnit.Enabled = false;
                        cbFoodCategoryName.Enabled = false;
                        txbLinkImages.Enabled = false;

                        txbLinkImages.Clear();
                    }
                    else
                    {
                        notitfy.Show("Sửa món ăn thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên món ăn đã tồn tại!!!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int foodid = int.Parse(txbFoodID.Text);

            if (foodid == 0)
            {
                notitfy.Show("Vui lòng chọn món ăn cần xóa!!!");
            }

            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.Notify = "Bạn có muốn xóa không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            Check = msgyn.Check;

            if (Check == "Có")
            {
                try
                {                   
                    if (FoodDAO.Instance.DeleteFood(foodid))
                    {
                        notitfy.Show("Xóa món ăn thành công!!!");
                        LoadListFood();
                    }
                    else
                    {
                        notitfy.Show("Xóa món ăn thất bại!!!");
                    }
                }
                catch { }
            }
        }

        private void btnAddImages_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbLinkImages.Text = openFileDialog1.FileName;
                pictureImages.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion EV_Food 

        #region EV_FoodRecipes
        private void btnFoodRecipes_Click(object sender, EventArgs e)
        {
            FoodRecipes home = new FoodRecipes();
            this.Hide();
            home.ShowDialog();
            this.Show();
        }

        private void dtgvFoodRecipes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Đặt giá trị canh giữa cho các ô trong từng dòng
                dtgvFoodRecipes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion EV_FoodRecipes
    }
}