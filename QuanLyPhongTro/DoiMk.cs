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
    public partial class DoiMk : Form
    {
        public string MaNhanVien;
        public DoiMk()
        {
            InitializeComponent();
        }

        private void DoiMk_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select MatKhau from DangNhap where MaNV='" + MaNhanVien + "'");
            if (abc.Rows[0][0].ToString() == txt_MKcu.Text)
            {
                if(textBox2.Text == textBox3.Text)
                {
                    KetNoiCSDL.FillDataTable("update DangNhap Set MatKhau='" + textBox2.Text + "' where MaNV='" + MaNhanVien + "'");
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không trùng nhau");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu củ không chính xác");
            }
            KetNoiCSDL.close();
        }
    }
}
