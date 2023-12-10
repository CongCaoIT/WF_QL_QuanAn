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
    public partial class FoodRecipes : DevExpress.XtraEditors.XtraForm
    {
        #region Method
        BindingSource IngredientList = new BindingSource();
        BindingSource FoodRecipesList = new BindingSource();
        bool Add = false;
        Notification notitfy = new Notification(); //Thông báo
        public string Check { get; set; }
        private int selectedFoodCategoryId = -1;
        private int selectedFoodRecipesID = -1;
        Dictionary<int, string> foodCategoryMap = new Dictionary<int, string>();
        #endregion Method

        public FoodRecipes()
        {
            InitializeComponent();
            LoadIngredient();
            LoadFoodRecipes();
        }

        #region Ingredient
        public void LoadIngredient()
        {
            dtgvIngredient.DataSource = IngredientList;
            LoadListIngredient();

            btnSaveIngredient.Enabled = false;
            btnRemoveIngredient.Enabled = false;

            txbIngredirentID.Enabled = false;
            txbIngredientName.Enabled = false;
        }

        void LoadListIngredient()
        {
            dtgvIngredient.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            IngredientList.DataSource = IngredientDAO.Instance.GetListIngredient();

            // Đặt các thuộc tính của các cột để canh giữa
            foreach (DataGridViewColumn column in dtgvIngredient.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dtgvIngredient.Columns[0].HeaderText = "Mã nguyên liệu";
            dtgvIngredient.Columns[0].Width = 100;

            dtgvIngredient.Columns[1].HeaderText = "Tên nguyên liệu";
            dtgvIngredient.Columns[1].Width = 205;


            // Tô màu tiêu đề cột và thay đổi chiều cao
            dtgvIngredient.EnableHeadersVisualStyles = false;
            dtgvIngredient.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dtgvIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dtgvIngredient.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dtgvIngredient.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dtgvIngredient.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }
        #endregion Ingredient

        #region FoodRecipes
        public void LoadFoodRecipes()
        {
            dtgvFoodRecipes.DataSource = FoodRecipesList;
            LoadListFoodRecipes();
            LoadFoodNameIntoCombobox(cbFoodName);
            LoadIngredientNameIntoCombobox(cbIngredients);

            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            cbFoodName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIngredients.DropDownStyle = ComboBoxStyle.DropDownList;
            txbContent.ReadOnly = true;
        }

        void LoadListFoodRecipes()
        {
            List<FoodDTO> food = FoodDAO.Instance.GetListFood();
            List<IngredientDTO> ingredient = IngredientDAO.Instance.GetListIngredient();

            dtgvFoodRecipes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            var foodRecipesList = FoodRecipesDAO.Instance.GetListFoodRecipes();

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
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

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
            dtgvFoodRecipes.Columns["FoodName"].Width = 250;
            dtgvFoodRecipes.Columns["IngredientName"].Width = 250;
            dtgvFoodRecipes.Columns["FoodContent"].Width = 168;
 
            int currentFoodID = -1;

            foreach (var foodRecipe in foodRecipesList)
            {
                var foodID = foodRecipe.FoodID;
                var ingredientID = foodRecipe.IngredientID;

                var foodName = food.FirstOrDefault(f => f.FoodID == foodID)?.FoodName;
                var ingredientName = ingredient.FirstOrDefault(row => row.IngredientID == ingredientID)?.IngredientName;

                if (currentFoodID != foodID)
                {
                    dtgvFoodRecipes.Rows.Add(foodRecipe.FoodRecipesID, foodName, ingredientName, foodRecipe.FoodContent);

                    currentFoodID = foodID;
                }
                else
                {
                    var row = dtgvFoodRecipes.Rows.Add(null, null, ingredientName, foodRecipe.FoodContent);
                }
            }
        }

        void LoadFoodNameIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            {
                // Lấy danh sách tất cả các trạng thái từ dữ liệu
                List<string> allWorkShifts = FoodDAO.Instance.GetListFood().Select(f => f.FoodName).ToList();

                // Tạo danh sách duy nhất bằng cách sử dụng Distinct()
                List<string> uniqueWorkShift = allWorkShifts.Distinct().ToList();

                // Gán danh sách duy nhất cho ComboBox
                cb.DataSource = uniqueWorkShift;
            }
        }

        void LoadIngredientNameIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            {
                // Lấy danh sách tất cả các trạng thái từ dữ liệu
                List<string> allWorkShifts = IngredientDAO.Instance.GetListIngredient().Select(f => f.IngredientName).ToList();

                // Tạo danh sách duy nhất bằng cách sử dụng Distinct()
                List<string> uniqueWorkShift = allWorkShifts.Distinct().ToList();

                // Gán danh sách duy nhất cho ComboBox
                cb.DataSource = uniqueWorkShift;
            }
        }

        // Helper method to get the selected food ID from the ComboBox
        private int GetSelectedFoodID(System.Windows.Forms.ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedFoodName = comboBox.SelectedItem.ToString();
                // Assuming that you have a list of FoodDTO objects in the ComboBox's DataSource
                FoodDTO selectedFood = FoodDAO.Instance.GetListFood().FirstOrDefault(f => f.FoodName == selectedFoodName);
                if (selectedFood != null)
                {
                    return selectedFood.FoodID;
                }
            }

            // Return a default value or handle the case where no selection is made
            return -1; // You can choose an appropriate default value
        }

        // Helper method to get the selected ingredient ID from the ComboBox
        private int GetSelectedIngredientID(System.Windows.Forms.ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedIngredientName = comboBox.SelectedItem.ToString();
                IngredientDTO selectedIngredient = IngredientDAO.Instance.GetListIngredient().FirstOrDefault(i => i.IngredientName == selectedIngredientName);
                // Assuming that you have a list of IngredientDTO objects in the ComboBox's DataSource
                if (selectedIngredient != null)
                {
                    return selectedIngredient.IngredientID;
                }
            }

            // Return a default value or handle the case where no selection is made
            return -1; // You can choose an appropriate default value
        }
        #endregion FoodRecipes

        #region EV_Ingredient
        private void dtgvIngredient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Đặt giá trị canh giữa cho các ô trong từng dòng
                dtgvIngredient.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgvIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dtgvIngredient.Rows[e.RowIndex];
                selectedFoodCategoryId = Convert.ToInt32(selectedRow.Cells["IngredientID"].Value);

                int row = dtgvIngredient.CurrentCell.RowIndex;
                txbIngredirentID.Text = dtgvIngredient.Rows[row].Cells[0].Value.ToString();
                txbIngredientName.Text = dtgvIngredient.Rows[row].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Add = true;

            btnAddIngredient.Enabled = false;
            btnEditIngredient.Enabled = false;
            btnDeleteIngredient.Enabled = false;

            btnReloadIngredient.Enabled = true;
            btnSaveIngredient.Enabled = true;
            btnRemoveIngredient.Enabled = true;

            txbIngredientName.Enabled = true;
            txbIngredirentID.Clear();
            txbIngredientName.Clear();
        }

        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            Add = false;

            if (txbIngredirentID.Text == "")
            {
                notitfy.Show("Vui lòng chọn nguyên liệu cần sửa!!!");
                return;
            }

            btnAddIngredient.Enabled = false;
            btnEditIngredient.Enabled = false;
            btnDeleteIngredient.Enabled = false;

            btnReloadIngredient.Enabled = true;
            btnSaveIngredient.Enabled = true;
            btnRemoveIngredient.Enabled = true;

            txbIngredientName.Enabled = true;
        }

        private void btnReloadIngredient_Click(object sender, EventArgs e)
        {
            LoadIngredient();
        }

        private void btnRemoveIngredient_Click(object sender, EventArgs e)
        {
            LoadIngredient();
        }

        private void btnSaveIngredient_Click(object sender, EventArgs e)
        {           
            string ingredientName = txbIngredientName.Text;

            if (Add)
            {
                try
                {
                    if (IngredientDAO.Instance.InsertIngredient(ingredientName))
                    {
                        notitfy.Show("Thêm nguyên liệu thành công!!!");
                        LoadListIngredient();
                        LoadIngredientNameIntoCombobox(cbIngredients);
                        txbIngredirentID.Clear();
                        txbIngredientName.Clear();

                        btnAddIngredient.Enabled = true;
                        btnEditIngredient.Enabled = true;
                        btnDeleteIngredient.Enabled = true;

                        btnSaveIngredient.Enabled = false;
                        btnRemoveIngredient.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Thêm nguyên liệu thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên nguyên liệu không được trùng!!!");
                }
            }
            else
            {
                try
                {
                    int ingredientID = int.Parse(txbIngredirentID.Text);
                    if (IngredientDAO.Instance.UpdateIngredient(ingredientID, ingredientName))
                    {
                        notitfy.Show("Sửa nguyên liệu thành công!!!");
                        LoadListIngredient();
                        LoadIngredientNameIntoCombobox(cbIngredients);
                        txbIngredirentID.Clear();
                        txbIngredientName.Clear();

                        btnAddIngredient.Enabled = true;
                        btnEditIngredient.Enabled = true;
                        btnDeleteIngredient.Enabled = true;

                        btnSaveIngredient.Enabled = false;
                        btnReloadIngredient.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Sửa nguyên liệu thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tên nguyên liệu không được trùng!!!");
                }
            }
        }

        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (txbIngredirentID.Text == "")
            {
                notitfy.Show("Vui lòng chọn nguyên liệu cần xóa!!!");
                return;
            }   

            try
            {
                int ingerdientid = int.Parse(txbIngredirentID.Text);

                if (IngredientDAO.Instance.DeleteIngredient(ingerdientid))
                {
                    notitfy.Show("Xóa nguyên liệu thành công!!!");
                    LoadListIngredient();
                    LoadIngredientNameIntoCombobox(cbIngredients);
                }
                else
                {
                    notitfy.Show("Xóa nguyên liệu thất bại!!!");
                }
            }
            catch 
            {
                notitfy.Show("Nguyên liệu không thể xóa vì nó có trong món ăn!!!");
            }
        }

        #endregion EV_Ingredient

        #region EV_FoodRecipes
        private void dtgvFoodRecipes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Left-align content in columns 1 and 2
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    dtgvFoodRecipes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    // Center-align content in other columns
                    dtgvFoodRecipes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void dtgvFoodRecipes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị mã công thức từ cột ẩn "FoodRecipesID" của dòng đã chọn
                selectedFoodRecipesID = Convert.ToInt32(dtgvFoodRecipes.Rows[e.RowIndex].Cells["FoodRecipesID"].Value);

                int row = dtgvFoodRecipes.CurrentCell.RowIndex;
                object foodNameValue = dtgvFoodRecipes.Rows[row].Cells["FoodName"].Value;

                // Kiểm tra nếu tên món ăn là null, thì gán giá trị tương ứng vào ComboBox
                if (foodNameValue != null)
                {
                    cbFoodName.Text = foodNameValue.ToString();
                }
                else
                {
                    // Nếu tên món ăn là null, thì bạn có thể gán một giá trị mặc định hoặc thực hiện xử lý khác ở đây
                    cbFoodName.Text = "Giá trị mặc định hoặc xử lý khác";
                }

                cbIngredients.Text = dtgvFoodRecipes.Rows[row].Cells[2].Value.ToString();
                txbContent.Text = dtgvFoodRecipes.Rows[row].Cells[3].Value.ToString();
            }
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

            txbContent.ReadOnly = false;
            txbContent.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int foodrecipesid = selectedFoodRecipesID;
            int foodid = GetSelectedFoodID(cbFoodName);
            int ingredientid = GetSelectedIngredientID(cbIngredients);
            string content = txbContent.Text;

            if (content == "")
            {
                notitfy.Show("Vui lòng nhập hàm lượng!!!");
                return;
            }

            int check = FoodRecipesDAO.Instance.CheckIngredientExists(foodid, ingredientid);

            if (Add)
            {
                try
                {
                    if (check != 0)
                    {
                        notitfy.Show("Tên của nguyên liệu đã tồn tại!!!");
                        return;
                    }
                    else
                    {
                        if (FoodRecipesDAO.Instance.InsertFoodRecipes(foodid, ingredientid, content))
                        {
                            notitfy.Show("Thêm công thức thành công!!!");
                            LoadListFoodRecipes();

                            btnAdd.Enabled = true;
                            btnEdit.Enabled = true;
                            btnDelete.Enabled = true;

                            btnSave.Enabled = false;
                            btnRemove.Enabled = false;
                        }
                        else
                        {
                            notitfy.Show("Thêm công thức thất bại!!!");
                        }
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    if (FoodRecipesDAO.Instance.UpdateFoodRecipes(foodrecipesid, foodid, ingredientid, content))
                    {
                        notitfy.Show("Sửa công thức thành công!!!");
                        LoadListFoodRecipes();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Sửa công thức thất bại!!!");
                    }
                }
                catch { }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Add = false;

            if (txbContent.Text == "")
            {
                notitfy.Show("Vui lòng chọn công thức cần sửa!!!");
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;

            txbContent.ReadOnly = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int foodid = GetSelectedFoodID(cbFoodName);
            int ingredientid = GetSelectedIngredientID(cbIngredients);

            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.Notify = "Bạn có muốn xóa không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            Check = msgyn.Check;

            if (Check == "Có")
            {
                try
                {
                    if (FoodRecipesDAO.Instance.DeleteFoodRecipes(foodid, ingredientid))
                    {
                        notitfy.Show("Xóa công thức thành công!!!");
                        LoadListFoodRecipes();
                    }
                    else
                    {
                        notitfy.Show("Xóa công thức thất bại!!!");
                    }
                }
                catch { }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadListIngredient();
            LoadFoodRecipes();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

            btnSaveIngredient.Enabled = false;
            btnRemoveIngredient.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            LoadListIngredient();
            LoadFoodRecipes();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

            btnSaveIngredient.Enabled = false;
            btnRemoveIngredient.Enabled = false;
        }
        #endregion EV_FoodRecipes
    }
}