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
    public partial class ThemTaiKhoan : Form
    {
        public ThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            LayMaNV();
        }
        public void LayMaNV()
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select dbo.AutoMaNV()");
            txt_MaNV.Text = abc.Rows[0][0].ToString();
            KetNoiCSDL.close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            if (txt_BienSoXe.Text != null && txt_CMND.Text != null && txt_DiaChi.Text != null && txt_email.Text != null && txt_HoTen.Text != null && txt_MaNV.Text != null && txt_Mk.Text != null && txt_NgaySinh.Text != null && txt_NoiCap.Text!=  null && txt_sdt.Text != null && txt_TaiKhoan.Text != null)
            {
                KetNoiCSDL.FillDataTable("set dateformat dmy insert into NhanVien values('" + txt_MaNV.Text + "', N'" + txt_HoTen.Text + "', N'" + txt_DiaChi.Text + "', '" + txt_sdt.Text + "', '" + txt_email.Text + "', '" + txt_NgaySinh.Text + "', '" + txt_CMND.Text + "', N'" + txt_NoiCap.Text + "', '" + txt_BienSoXe.Text + "', '')");
                KetNoiCSDL.FillDataTable("insert into DangNhap values ('" + txt_TaiKhoan.Text + "','" + txt_Mk.Text + "',N'" + comboBox1.SelectedItem.ToString() + "','" + txt_MaNV.Text + "')");
            }
            else
            {
                MessageBox.Show("Không được để trống");
            }
            KetNoiCSDL.close();
        }
    }
}
