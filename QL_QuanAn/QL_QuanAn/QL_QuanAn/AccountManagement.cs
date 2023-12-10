using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.Xpo.Metadata.Helpers;
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
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QL_QuanAn
{
    public partial class AccountManagement : DevExpress.XtraEditors.XtraForm
    {
        #region Method
        BindingSource accountList = new BindingSource();
        bool Add = false;
        Notification notitfy = new Notification(); //Thông báo
        public AccountDTO loginAcc; //Constructor để nhận thông tin tài khoản từ form Home
        public AccountDTO LoginAcc
        {
            get { return loginAcc; }
            set
            {
                loginAcc = value;
            }
        }
        public string Check { get; set; }
        #endregion Method

        public AccountManagement(AccountDTO acc)
        {
            InitializeComponent();
            dtgvAccount.DataSource = accountList;
            this.LoginAcc = acc;
            Load();
        }

        #region Account Management
        private new void Load()
        {
            dtgvAccount.DataSource = accountList;
            LoadListAccount();
            AddAccountBinding();
            LoadStatusAccountIntoComboBox(cbStatus);
            //LoadStaffIDIntoCombobox(cbStaffID);
            //LoadStaffNameIntoCombobox(cbStaffName);

            txbUserName.Enabled = false;
            cbStaffID.Enabled = false;
            cbStaffName.Enabled = false;
            cbStatus.Enabled = false;
            groupControlGrantPermissions.Enabled = false;

            btnSave.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void LoadListAccount()
        {
            dtgvAccount.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            accountList.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.Columns["PassWord"].Visible = false;

            // Đặt các thuộc tính của các cột để canh giữa và in đậm
            foreach (DataGridViewColumn column in dtgvAccount.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dtgvAccount.Columns[0].HeaderText = "Tên đăng nhập";
            dtgvAccount.Columns[0].Width = 152;

            dtgvAccount.Columns[1].HeaderText = "Mã thành viên";
            dtgvAccount.Columns[1].Width = 140;

            dtgvAccount.Columns[2].HeaderText = "Tên hiển thị";
            dtgvAccount.Columns[2].Width = 260;

            dtgvAccount.Columns[4].HeaderText = "Cấp quyền";
            dtgvAccount.Columns[4].Width = 100;

            dtgvAccount.Columns[5].HeaderText = "Trạng thái";
            dtgvAccount.Columns[5].Width = 100;

            dtgvAccount.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == 4 && e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int roleValue))
                    {
                        // Chuyển đổi giá trị số sang chuỗi tương ứng
                        string roleText = (roleValue == 1) ? "Admin" : (roleValue == 2) ? "Nhân viên" : e.Value.ToString();
                        e.Value = roleText;
                    }
                    else
                    {
                        string roleText = (roleValue == 1) ? "Admin" : (roleValue == 2) ? "Nhân viên" : e.Value.ToString();
                        e.Value = roleText;
                    }
                }
            };


            // Tô màu tiêu đề cột và thay đổi chiều cao
            dtgvAccount.EnableHeadersVisualStyles = false;
            dtgvAccount.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // Tô màu nền tiêu đề
            dtgvAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Cho phép thay đổi kích thước chiều cao
            dtgvAccount.ColumnHeadersHeight = 50; // Đặt kích thước chiều cao của tiêu đề cột

            // Tăng chiều cao từng dòng dữ liệu
            dtgvAccount.RowPrePaint += (sender, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.Focus; // Loại bỏ viền bôi đậm
                if (e.RowIndex >= 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, e.RowBounds); // Tô màu nền dòng
                    e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                }
            };
            dtgvAccount.RowTemplate.Height = 40; // Đặt kích thước chiều cao của từng dòng
        }

        void AddAccountBinding()
        {
            // Binding cho TextBox "Tên đăng nhập"
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));

            // Binding cho RadioButton "Quản trị" (Admin)
            Binding rbBindingAdmin = new Binding("Checked", dtgvAccount.DataSource, "PermissionGroupId", true, DataSourceUpdateMode.Never);
            rbBindingAdmin.Format += (sender, e) => e.Value = (e.Value != null && e.Value.ToString() == "1"); // Format giá trị đúng cho RadioButton "Quản trị"
            rbBindingAdmin.Parse += (sender, e) => e.Value = (bool)e.Value ? "1" : "2"; // Parse giá trị ngược lại
            radioAdmin.DataBindings.Add(rbBindingAdmin);

            // Binding cho RadioButton "Nhân viên" (Employee)
            Binding rbBindingEmployee = new Binding("Checked", dtgvAccount.DataSource, "PermissionGroupId", true, DataSourceUpdateMode.Never);
            rbBindingEmployee.Format += (sender, e) => e.Value = (e.Value != null && e.Value.ToString() == "2"); // Format giá trị đúng cho RadioButton "Nhân viên"
            rbBindingEmployee.Parse += (sender, e) => e.Value = (bool)e.Value ? "2" : "1"; // Parse giá trị ngược lại
            radioEmployee.DataBindings.Add(rbBindingEmployee);
        }

        void LoadStatusAccountIntoComboBox(System.Windows.Forms.ComboBox cb)
        {
            // Lấy danh sách tất cả các trạng thái từ dữ liệu
            List<string> allStatuses = AccountDAO.Instance.GetListAccount().Select(account => account.Status).ToList();

            // Tạo danh sách duy nhất bằng cách sử dụng Distinct()
            List<string> uniqueStatuses = allStatuses.Distinct().ToList();

            // Gán danh sách duy nhất cho ComboBox
            cb.DataSource = uniqueStatuses;
        }

        void LoadStaffIDIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            // Lấy danh sách tất cả các trạng thái từ dữ liệu
            List<string> allstaffid = EmployeeDAO.Instance.GetListEmployee().Select(staffid => staffid.StaffID).ToList();

            // Gán danh sách duy nhất cho ComboBox
            cb.DataSource = allstaffid;
        }

        void LoadStaffNameIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            // Lấy danh sách tất cả các trạng thái từ dữ liệu
            List<string> allstaffname = EmployeeDAO.Instance.GetListEmployee().Select(staffid => staffid.StaffName).ToList();

            // Gán danh sách duy nhất cho ComboBox
            cb.DataSource = allstaffname;
        }
        #endregion Account Management

        #region Event Account_Management
        private void txbEmployeeID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvAccount.SelectedCells.Count > 0 && dtgvAccount.SelectedCells[0].OwningRow.Cells["StaffID"].Value != null)
                {
                    string staffID = dtgvAccount.SelectedCells[0].OwningRow.Cells["StaffID"].Value.ToString();
                    AccountDTO acc = AccountDAO.Instance.GetAccountByStaffID(staffID);

                    // Tạo danh sách duy nhất của trạng thái
                    List<string> uniqueStatuses = AccountDAO.Instance.GetListAccount().Select(account => account.Status).Distinct().ToList();

                    // Gán danh sách duy nhất cho ComboBox
                    cbStatus.DataSource = uniqueStatuses;

                    if (uniqueStatuses.Contains(acc.Status))
                    {
                        cbStatus.SelectedItem = acc.Status;
                    }
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnResetPassWord.Enabled = false;

            btnReload.Enabled = true;
            btnSave.Enabled = true;
            btnRemove.Enabled = true;
            groupControlGrantPermissions.Enabled = true;

            txbUserName.Clear();

            cbStaffID.Enabled = true;
            txbUserName.Enabled = true;
            cbStaffName.Enabled = false;

            LoadStaffIDIntoCombobox(cbStaffID);
            LoadStaffNameIntoCombobox(cbStaffName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string staffID = cbStaffID.SelectedItem as string;
            string displayName = cbStaffName.SelectedItem as string;
            string status = cbStatus.SelectedItem as string;

            int permissionGroupId;
            if (radioAdmin.Checked == true)
            {
                permissionGroupId = AccountDAO.Instance.GetPermissionGroupId("Admin");
            }
            else
            {
                permissionGroupId = AccountDAO.Instance.GetPermissionGroupId("Nhân viên");
            }

            if (Add)
            {
                AccountDTO account = AccountDAO.Instance.GetAccountByStaffID(staffID);
                if (account != null && account.StaffID == staffID)
                {
                    notitfy.Show("Nhân viên " + displayName + " đã có tài khoản!!!");
                    return;
                }
                try
                {
                    if (AccountDAO.Instance.InsertAccount(userName, staffID, displayName, permissionGroupId, status))
                    {
                        notitfy.Show("Thêm thành công!!!");
                        LoadListAccount();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Thêm thất bại!!!");
                    }
                }
                catch
                {
                    notitfy.Show("Tài khoản đã tồn tại!!!");
                }
            }
            else
            {
                try
                {
                    if (AccountDAO.Instance.UpdateAccount(permissionGroupId, status, userName))
                    {
                        notitfy.Show("Sửa tài khoản " + userName + " thành công!!!");
                        LoadListAccount();

                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        btnSave.Enabled = false;
                        btnRemove.Enabled = false;
                    }
                    else
                    {
                        notitfy.Show("Sửa tài khoản thất bại!!!");
                    }
                }
                catch { }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (loginAcc.UserName.Equals(userName))
            {
                notitfy.Show("Lỗi xóa tài khoản? \nTài khoản đang được đăng nhập!!!");
                return;
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
                    if (AccountDAO.Instance.DeleteAccount(userName))
                    {
                        notitfy.Show("Xóa tài khoản" + userName + " thành công!!!");
                        LoadListAccount();
                    }
                    else
                    {
                        notitfy.Show("Xóa tài khoản thất bại!!!");
                    }
                }
                catch { }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == "")
            {
                notitfy.Show("Vui lòng chọn tài khoản cần sửa!!!");
                return;
            }

            if (loginAcc.UserName.Equals(txbUserName.Text))
            {
                Add = false;
                groupControlGrantPermissions.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                txbUserName.Enabled = false;
                cbStaffID.Enabled = false;
                cbStaffName.Enabled = false;
                btnResetPassWord.Enabled = false;

                btnReload.Enabled = true;
                btnSave.Enabled = true;
                btnRemove.Enabled = true;
                cbStatus.Enabled = true;
                LoadStaffIDIntoCombobox(cbStaffID);
                LoadStaffNameIntoCombobox(cbStaffName);
            }
            else
            {
                Add = false;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                txbUserName.Enabled = false;
                cbStaffID.Enabled = false;
                cbStaffName.Enabled = false;
                btnResetPassWord.Enabled = false;

                btnReload.Enabled = true;
                btnSave.Enabled = true;
                btnRemove.Enabled = true;
                cbStatus.Enabled = true;
                groupControlGrantPermissions.Enabled = true;

                LoadStaffIDIntoCombobox(cbStaffID);
                LoadStaffNameIntoCombobox(cbStaffName);
            }          
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txbUserName.Enabled = false;
            cbStaffID.Enabled = false;
            cbStaffName.Enabled = false;
            cbStatus.Enabled = false;
            groupControlGrantPermissions.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            radioAdmin.Checked = true;
            btnResetPassWord.Enabled = true;

            btnReload.Enabled = false;
            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            txbUserName.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            txbUserName.Enabled = false;
            cbStaffID.Enabled = false;
            cbStaffName.Enabled = false;
            cbStatus.Enabled = false;
            groupControlGrantPermissions.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            radioAdmin.Checked = true;
            btnResetPassWord.Enabled = true;

            btnReload.Enabled = false;
            btnSave.Enabled = false;
            btnRemove.Enabled = false;

            txbUserName.Clear();
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (AccountDAO.Instance.ResetPassWord(userName))
            {
                notitfy.Show("Đặt lại mật khẩu thành công!!!");
                LoadListAccount();
            }
            else
            {
                notitfy.Show("Đặt lại mật khẩu không thành công!!!");
            }
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txbUserName.Enabled = false;
                cbStaffID.Enabled = false;
                cbStaffName.Enabled = false;
                cbStatus.Enabled = false;
                groupControlGrantPermissions.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnResetPassWord.Enabled = true;

                btnReload.Enabled = false;
                btnSave.Enabled = false;
                btnRemove.Enabled = false;

                int row = dtgvAccount.CurrentCell.RowIndex;
                txbUserName.Text = dtgvAccount.Rows[row].Cells[0].Value.ToString();
                cbStaffID.Text = dtgvAccount.Rows[row].Cells[1].Value.ToString();
                cbStaffName.Text = dtgvAccount.Rows[row].Cells[2].Value.ToString();
                cbStatus.Text = dtgvAccount.Rows[row].Cells[5].Value.ToString();

                // Kiểm tra giá trị của cột "Cấp quyền"
                object permissionGroupIdObj = dtgvAccount.Rows[row].Cells[4].Value;
                if (permissionGroupIdObj != null)
                {
                    if (int.TryParse(permissionGroupIdObj.ToString(), out int permissionGroupId))
                    {
                        // Xử lý RadioButton "Quản trị" và "Nhân viên"
                        radioAdmin.Checked = (permissionGroupId == 1);
                        radioEmployee.Checked = (permissionGroupId == 2);
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception (hiển thị thông báo hoặc log lỗi)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã nhân viên được chọn từ ComboBox
            string selectedStaffID = cbStaffID.SelectedItem as string;

            // Tìm tên nhân viên tương ứng với mã nhân viên
            EmployeeDTO selectedEmployee = EmployeeDAO.Instance.GetEmployeeByStaffID(selectedStaffID);

            if (selectedEmployee != null)
            {
                // Gán tên nhân viên vào ComboBox cbStaffName
                cbStaffName.SelectedItem = selectedEmployee.StaffName;
            }
        }
        private void cbStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion Event Account_Management
    }
}