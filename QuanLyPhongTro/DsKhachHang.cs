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
    public partial class DsKhachHang : Form
    {
        public string MaKhachHang;
        public string SoPhong = "Null";
        public string SoTien = "Null";
        public DsKhachHang()
        {
            InitializeComponent();
        }
        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
           
            dataGridView_DsKhachHang.DataSource = KetNoiCSDL.FillDataTable("select 'Id' = Id_KhachHang,'Họ Tên' = HoTen,'Nghề Nghiệp'=NgheNghiep,'Số Điện Thoại'=SoDienThoai,CMND,Email,'Số Phòng'=SoPhong,'Ngày Thuê'=NgayThue,'Biển Số Xe'=BienSoXe from KhachHang");
            KetNoiCSDL.close();
            dataGridView_DsKhachHang.EnableHeadersVisualStyles = false;
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 41, 226);
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 12, FontStyle.Bold);
            dataGridView_DsKhachHang.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 43, 25);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_DsKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            DataGridViewRow dongchon = this.dataGridView_DsKhachHang.Rows[vt];
            MaKhachHang = dongchon.Cells[0].Value.ToString();
            if(dongchon.Cells[6].Value.ToString()!="")
                SoPhong = dongchon.Cells[6].Value.ToString();
            KetNoiCSDL.open();
            
            if (SoPhong !="Null")
            {
                DataTable abc = KetNoiCSDL.FillDataTable("select LoaiPhong.SoTien from LoaiPhong,Phong where Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong and Phong.SoPhong=" + SoPhong + "");
                SoTien = abc.Rows[0][0].ToString();
            }    
            KetNoiCSDL.close();
        }

        private void btn_Sreach_KhachHang_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            dataGridView_DsKhachHang.DataSource = KetNoiCSDL.FillDataTable("select 'Id' = Id_KhachHang,'Họ Tên' = HoTen,'Nghề Nghiệp'=NgheNghiep,'Số Điện Thoại'=SoDienThoai,CMND,Email,'Số Phòng'=SoPhong,'Ngày Thuê'=NgayThue,'Biển Số Xe'=BienSoXe from KhachHang where HoTen like '%"+textBox1.Text+ "%' or HoTen like '%" + textBox1.Text + "'or HoTen like '" + textBox1.Text + "%' or HoTen like '" + textBox1.Text + "'");
            KetNoiCSDL.close();
            dataGridView_DsKhachHang.EnableHeadersVisualStyles = false;
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 41, 226);
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridView_DsKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 12, FontStyle.Bold);
            dataGridView_DsKhachHang.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 43, 25);
        }

        private void dataGridView_DsKhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ThongTinKhachHang abc = new ThongTinKhachHang();
            abc.MaKhachHang = MaKhachHang;
            abc.SoPhong = SoPhong;
            abc.SoTien = SoTien;
            abc.Loaibutton = "Sửa";
            abc.ShowDialog();
        }
    }
}
