using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginClient
{
    public partial class loginClient : Form
    {
        string taikhoan = "user";
        string matkhau = "123";
        public loginClient()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void F_dangxuat(object sender, EventArgs e)
        {
            (sender as Client).isThoat = false;
            (sender as Client).Close();
            this.Show();
        }
        bool checkDangnhap(string taikhoan, string matkhau)
        {
            if (taikhoan == this.taikhoan && matkhau == this.matkhau)
            {
                return true;
            }
            return false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkDangnhap(txbTaiKhoan.Text, txbMatKhau.Text))
            {
                Client f = new Client();
                f.Show();
                this.Hide();
                f.dangxuat += F_dangxuat;
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi");
                txbTaiKhoan.Focus();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
                Application.Exit();
        }
    }
}
