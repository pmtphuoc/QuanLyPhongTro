using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select * from DangNhap where TaiKhoan=" +"'" + txt_user.Text + "' and MatKhau = '"+ txt_password.Text+"'");
            KetNoiCSDL.close();
            if(abc.Rows.Count>0)
            {
                Home openform = new Home();
                this.Hide();
                int chieurong = Screen.PrimaryScreen.WorkingArea.Width;
                int chieudai = Screen.PrimaryScreen.WorkingArea.Height;
                openform.Size = new Size(chieurong-320, chieudai-110);
                openform.MaNhanVien = abc.Rows[0][4].ToString();
                openform.Show();            
            }
            else
            {
                MessageBox.Show("Sài tài khoản hoặc mật khẩu");
            }
        }
    }
}
