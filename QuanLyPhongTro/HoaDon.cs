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
    public partial class HoaDon : Form
    {
        public string SoPhong;
        public string MaNV;
        public string MaKH;
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
           
            txt_MaNhanVien.Text = MaNV;
            KetNoiCSDL.open();
            DataTable Kiemtra = KetNoiCSDL.FillDataTable("select * from HoaDon Where Id_KhachHang='" + MaKH + "'  and MONTH(NgayThanhToan)='" + DateTime.Now.Month + "'");
            if(Kiemtra.Rows.Count>0)
            {
                txt_MaHoaDon.Text = Kiemtra.Rows[0][0].ToString();
            }
            else
            {
                txt_MaHoaDon.Text = TaoMaHD();
            }
            DataTable NV = KetNoiCSDL.FillDataTable("select HoTen from NhanVien where MaNV='"+MaNV+"'");
            DataTable KH = KetNoiCSDL.FillDataTable("select Id_KhachHang,HoTen,CMND,SoDienThoai from KhachHang where Id_KhachHang='"+MaKH+"'");
            DataTable Tien = KetNoiCSDL.FillDataTable("select Dien.SoPhong,'Tiền Phòng'=LoaiPhong.SoTien,'CS Điện'=Dien.CsThangNay-Dien.CsThangTruoc,'Tiền Điện'=Round((Dien.CsThangNay-Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0),'Cs Nước'=Nuoc.CsThangNay-Nuoc.CsThangTruoc,'Tiền Nước'=Round((Nuoc.CsThangNay-Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0),Dien.Ngayghi from Dien,Nuoc,Phong,LoaiPhong,KhachHang where MONTH(Nuoc.Ngayghi)='"+DateTime.Now.Month+"' and MONTH(Dien.Ngayghi)='"+ DateTime.Now.Month + "' and Dien.SoPhong=Nuoc.SoPhong and Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong and Dien.SoPhong=Phong.SoPhong and KhachHang.SoPhong=Phong.SoPhong and KhachHang.Id_KhachHang='"+MaKH+"'");
            KetNoiCSDL.close();
            txt_MaKH.Text = MaKH;
            txt_TenKH.Text = KH.Rows[0][1].ToString();
            Txt_CMND.Text = KH.Rows[0][2].ToString();
            txt_SDT.Text = KH.Rows[0][3].ToString();
            txt_SoPhong.Text = SoPhong;
            txt_tiendien.Text = Tien.Rows[0][3].ToString();
            txt_tiennuoc.Text = Tien.Rows[0][5].ToString();
            txt_tienphong.Text = Tien.Rows[0][1].ToString();
            txt_thang.Text = DateTime.Now.Month.ToString();
            txt_nam.Text = DateTime.Now.Year.ToString();
            txt_TongTien.Text = (Convert.ToInt32(Tien.Rows[0][3])+ Convert.ToInt32(Tien.Rows[0][5])+ Convert.ToInt32(Tien.Rows[0][1])).ToString();
        }
        public string TaoMaHD()
        {
            string MaHD;
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select dbo.AutoMAHD()");
            KetNoiCSDL.close();
            return MaHD = abc.Rows[0][0].ToString();                    
        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult abc = MessageBox.Show("Bạn có muôn lưu hóa đơn."+dateTimePicker1.Value.ToString("yyyy-MM-dd"), "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            {
                if(abc == DialogResult.Yes)
                {
                    KetNoiCSDL.open();
                    DataTable xyz = KetNoiCSDL.FillDataTable("select * from HoaDon where MaHD='" + txt_MaHoaDon.Text + "'");
                    KetNoiCSDL.close();
                    if (xyz.Rows.Count > 0)
                    {
                        MessageBox.Show("Hóa đơn đã tồn tại \n Đã tính tiền phòng tháng này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        KetNoiCSDL.FillDataTable("insert into HoaDon values ('" + txt_MaHoaDon.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + txt_MaNhanVien.Text + "','" + txt_MaKH.Text + "')");
                        MessageBox.Show("Lưu thành công");
                    }                  
                }                
            }
           
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            DataTable xyz = KetNoiCSDL.FillDataTable("select * from HoaDon where MaHD='" + txt_MaHoaDon.Text + "'");
            KetNoiCSDL.close();
            if( xyz.Rows.Count>0)
            {
                InHoaDon abc = new InHoaDon();
                abc.SDT = txt_SDT.Text;
                abc.MaKh = txt_MaKH.Text;
                abc.TenKhachHang = txt_TenKH.Text;
                abc.CMND = Txt_CMND.Text;
                abc.Sophong = txt_SoPhong.Text;
                abc.TienPhong = txt_tienphong.Text;
                abc.TienDien = txt_tiendien.Text;
                abc.TienNuoc = txt_tiennuoc.Text;
                abc.TongTien = txt_TongTien.Text;
                abc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn chưa lưu hóa đơn");
            }
           
        }
    }
}
