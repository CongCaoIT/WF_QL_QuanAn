using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraBars;
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
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Method
        private bool userConfirmedExit = false;
        public string Check { get; set; }
        private AccountDTO loginAccount; //Biến toàn cục để lưu tài khoản

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
            }
        }

        #endregion Method

        public Home(AccountDTO accountDTO)
        {
            InitializeComponent();
            this.LoginAccount = accountDTO;

            if (loginAccount.PermissionGroupId == AccountDAO.Instance.GetPermissionGroupId("Nhân viên"))
            {
                btnAccount.Enabled = false;
                ribbonPageManament.Visible = false;
                ribbonPageStatistical.Visible = false;
            }
        }

        #region Home
        public void CloseAllTab()
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }
        #endregion Home
         
        #region EV_Home

        private void Home_Load(object sender, EventArgs e)
        {
            ItemUserName.Caption = LoginAccount.UserName;
            ItemGrantPermissions.Caption = AccountDAO.Instance.GetPermissionGroupById(LoginAccount.PermissionGroupId);
            ItemDisplayName.Caption = LoginAccount.DisplayName;

            CloseAllTab();
            baraa.Caption = LoginAccount.StaffID;
            int width = 0;
            int height = 0;
            InfomationTable infomationTable = new InfomationTable();
            infomationTable.EmployeeIdSelected = LoginAccount.StaffID;
            width = infomationTable.Size.Width;
            height = infomationTable.Size.Height;
            infomationTable.MdiParent = this;
            infomationTable.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnHome_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            baraa.Caption = LoginAccount.StaffID;
            int width = 0;
            int height = 0;
            InfomationTable infomationTable = new InfomationTable();
            infomationTable.EmployeeIdSelected = LoginAccount.StaffID;
            width = infomationTable.Size.Width;
            height = infomationTable.Size.Height;
            infomationTable.MdiParent = this;
            infomationTable.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnResetPassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangePassWord changpassword = new ChangePassWord(LoginAccount);
            changpassword.Show();
        }

        private void btnAccount_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            AccountManagement account = new AccountManagement(LoginAccount);

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.Notify = "Bạn có muốn đăng xuất không?";
            this.Show();
            msgyn.ShowDialog();
            msgyn.Hide();
            Check = msgyn.Check;
            if (Check == "Có")
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void btnEmployeeManager_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            EmployeeManagement account = new EmployeeManagement();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnTimeKeeping_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            TimeKeeping account = new TimeKeeping();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnFoodCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            FoodCategory account = new FoodCategory();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            Food account = new Food();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnRecipes_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            FoodRecipes account = new FoodRecipes();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }
        private void btnTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            Table account = new Table();

            width = account.Size.Width;
            height = account.Size.Height;
            account.MdiParent = this;
            account.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            SalaryCalculation salaryCalculation = new SalaryCalculation();

            salaryCalculation.Show();
        }

        private void btnDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Revenue revenue = new Revenue();

            revenue.Show();
        }

        private void btnInvoiceStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            Bill bill = new Bill();

            width = bill.Size.Width;
            height = bill.Size.Height;
            bill.MdiParent = this;
            bill.Show();
            this.ClientSize = new Size(width, height + 170);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnBillByStaffid_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllTab();
            int width = 0;
            int height = 0;
            Statistical statistical = new Statistical(loginAccount);

            width = statistical.Size.Width;
            height = statistical.Size.Height;
            statistical.MdiParent = this;
            statistical.Show();
            this.ClientSize = new Size(width, height + 170);
        }
        #endregion EV_Home        
    }
}