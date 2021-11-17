using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Login : Form
    {
        string taikhoan = "admin";
        string matkhau = "admin";
        public Login()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkDangnhap(txbTaiKhoan.Text, txbMatKhau.Text))
            {
                Server f = new Server();
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

        private void F_dangxuat(object sender, EventArgs e)
        {
            (sender as Server).isThoat = false;
            (sender as Server).Close();
            this.Show();
        }

        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        bool checkDangnhap(string taikhoan, string matkhau)
        {
            if (taikhoan == this.taikhoan && matkhau == this.matkhau)
            {
                return true;
            }
            return false;
        }
    }
}
