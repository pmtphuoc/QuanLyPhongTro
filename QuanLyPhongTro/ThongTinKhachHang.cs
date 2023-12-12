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
    public partial class ThongTinKhachHang : Form
    {
        public string MaKhachHang;
        public string Loaibutton ;
        public string SoPhong;
        public string SoTien;
        public ThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadComboBox()
        {
            DataTable abc = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong="+SoPhong+"");
            for( int i = 0;i<= abc.Rows.Count-1;i++)
            {
                if(abc.Rows[i][0].ToString()==MaKhachHang)
                {
                    comboBox1.Text = abc.Rows[i][1].ToString();
                }
                comboBox1.Items.Add(abc.Rows[i][1].ToString());
            }    
        }
        public void LoadData(string sql)
        {
            KetNoiCSDL.open();
            //DataTable abc = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,KhachHang.SoPhong,LoaiPhong.SoTien,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang,Phong,LoaiPhong where KhachHang.SoPhong=Phong.SoPhong and Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong and Id_KhachHang = '" + MaKhachHang + "'");
            DataTable abc = KetNoiCSDL.FillDataTable(sql);
            KetNoiCSDL.close();
            if (abc.Rows.Count > 0 && Loaibutton != "Thêm KH")
            {
                txt_MaKH.Text = abc.Rows[0][0].ToString();
                txt_Ten.Text = abc.Rows[0][1].ToString();
                txt_DiaChi.Text = abc.Rows[0][2].ToString();
                txt_sdt.Text = abc.Rows[0][3].ToString();
                txt_email.Text = abc.Rows[0][4].ToString();
                DateTime a = Convert.ToDateTime(abc.Rows[0][5]);
                txt_ngaysinh.Text = a.ToString("dd/MM/yyyy");
                txt_nghenghiep.Text = abc.Rows[0][6].ToString();
                txt_sophong.Text = SoPhong;
                txt_TienPhong.Text = SoTien;
                DateTime aa = Convert.ToDateTime(abc.Rows[0][7]);
                txt_Ngaythue.Text = aa.ToString("dd/MM/yyyy");
                txt_cmnd.Text = abc.Rows[0][8].ToString();
                txt_NoiCap.Text = abc.Rows[0][9].ToString();
                txt_BSX.Text = abc.Rows[0][10].ToString();
                txt_DatCoc.Text = abc.Rows[0][11].ToString();
            }
            else
            {
                txt_MaKH.Text = TaoMAKH();
                txt_sophong.Text = SoPhong;
                txt_TienPhong.Text = SoTien;
                txt_Ngaythue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            txt_MaKH.Enabled = false;
            txt_sophong.Enabled = false;
            txt_TienPhong.Enabled = false;

        }
        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            if(Loaibutton == "Thêm Khách Hàng" || Loaibutton == "Thêm KH")
            {
                btn_Sua.Enabled = false;
                buttonRadius1.Enabled = false;
                btn_Sua.Cursor = Cursors.No;
            }
            else if(Loaibutton == "Sửa")
            {
                buttonRadius1.Enabled = false;
                btn_Luu.Cursor = Cursors.No;
                btn_Luu.Enabled = false;
            }
            else if (Loaibutton == "Xóa KH")
            {
                btn_Sua.Enabled = false;
                btn_Luu.Cursor = Cursors.No;
                btn_Luu.Enabled = false;
            }
            else
            {
                buttonRadius1.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Sua.Cursor = Cursors.No;
                btn_Luu.Cursor = Cursors.No;
            }
            LoadComboBox();
            LoadData("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where Id_KhachHang = '" + MaKhachHang + "'");
        }

        public string TaoMAKH()
        {
            string makh;
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select dbo.AutoMaKH()");
            KetNoiCSDL.close();
            return makh = abc.Rows[0][0].ToString();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiCSDL.open();
                DataTable abc = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong=" + SoPhong + "");
                if (abc.Rows.Count > 0)
                    KetNoiCSDL.FillDataTable("set dateformat dmy insert into KhachHang values ('" + txt_MaKH.Text + "',N'" + txt_Ten.Text + "',N'" + txt_DiaChi.Text + "','" + txt_sdt.Text + "','" + txt_email.Text + "','" + txt_ngaysinh.Text + "',N'" + txt_nghenghiep.Text + "'," + txt_sophong.Text + ",'" + txt_Ngaythue.Text + "'," + txt_cmnd.Text + ",N'" + txt_NoiCap.Text + "','" + txt_BSX.Text + "','" + txt_DatCoc.Text + "','no')");
                else
                    KetNoiCSDL.FillDataTable("set dateformat dmy insert into KhachHang values ('" + txt_MaKH.Text + "',N'" + txt_Ten.Text + "',N'" + txt_DiaChi.Text + "','" + txt_sdt.Text + "','" + txt_email.Text + "','" + txt_ngaysinh.Text + "',N'" + txt_nghenghiep.Text + "'," + txt_sophong.Text + ",'" + txt_Ngaythue.Text + "'," + txt_cmnd.Text + ",N'" + txt_NoiCap.Text + "','" + txt_BSX.Text + "','" + txt_DatCoc.Text + "','yes')");
                KetNoiCSDL.FillDataTable("update Phong set TrangThai = 'Full' where SoPhong =" + txt_sophong.Text + "");
                MessageBox.Show("Thêm Thành Công Khách Hàng");
                KetNoiCSDL.close();
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi là: " + loi);
            }
           
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiCSDL.open();
            KetNoiCSDL.FillDataTable("set dateformat dmy update KhachHang set HoTen=N'" + txt_Ten.Text + "',DiaChi=N'" + txt_DiaChi.Text + "',SoDienThoai='" + txt_sdt.Text + "',Email='" + txt_email.Text + "',NgaySinh='" + txt_ngaysinh.Text + "',NgheNghiep=N'" + txt_nghenghiep.Text + "',SoPhong=" + txt_sophong.Text + ",NgayThue='" + txt_Ngaythue.Text + "',CMND=" + txt_cmnd.Text + ",NoiCap=N'" + txt_NoiCap.Text + "',BienSoXe='" + txt_BSX.Text + "',DatCoc='"+txt_DatCoc.Text+"' where  Id_KhachHang='" + txt_MaKH.Text + "'");
            KetNoiCSDL.close();
            MessageBox.Show("Sữa Thành Công Khách Hàng");
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi là: " + loi);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable abc = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong=" + SoPhong + "");
            int luuso = Convert.ToInt32(comboBox1.SelectedIndex);
            MaKhachHang = abc.Rows[luuso][0].ToString();
            LoadData("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where Id_KhachHang = '" + MaKhachHang + "'");
        }

        private void buttonRadius1_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiCSDL.open();
                KetNoiCSDL.FillDataTable("update KhachHang set SoPhong=null where Id_KhachHang = '" + txt_MaKH.Text + "'");
                DataTable abc = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong=" + SoPhong + "");
                if (abc.Rows.Count < 1)
                {
                    KetNoiCSDL.FillDataTable("update  Phong Set TrangThai = N'Trống' where SoPhong=" + SoPhong + "");
                }
                else
                {
                    DataTable abcf = KetNoiCSDL.FillDataTable("select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong=" + SoPhong + "and PhongTruong='yes'");
                    if (abcf.Rows.Count < 1)
                    {
                        KetNoiCSDL.FillDataTable("update KhachHang set PhongTruong='yes' where Id_KhachHang = '" + abc.Rows[0][0].ToString() + "'");
                    }
                }
                KetNoiCSDL.close();
                MessageBox.Show("Xóa thành công Khách Hàng: "+txt_Ten.Text);
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi là: "+loi);
            }
           
        }
    }
}
