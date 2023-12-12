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
    public partial class TaiKhoan : Form
    {
        public string MaNhanVien;
        public TaiKhoan()
        {
            InitializeComponent();
        }
        private void UploadImage()
        {
           try
            {
                openFileDialog1.Filter = "JPG FILES(*.jpg)|*.jpg| PNG FILES(*.png)|*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Image Upload. \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    
        private void btn_image_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select * from NhanVien where MaNV='" + MaNhanVien + "'");
            txt_MaNV.Text = abc.Rows[0][0].ToString();
            txt_HoTen.Text = abc.Rows[0][1].ToString();
            txt_DiaChi.Text = abc.Rows[0][2].ToString();
            txt_SDT.Text = abc.Rows[0][3].ToString();
            txt_email.Text = abc.Rows[0][4].ToString();
            DateTime a = Convert.ToDateTime(abc.Rows[0][5]);
            txt_ngaysinh.Text = a.ToString("dd/MM/yyyy");
            txt_cmnd.Text = abc.Rows[0][6].ToString();
            txt_BienSoXe.Text = abc.Rows[0][8].ToString();
            if (abc.Rows[0][9].ToString() != "")
            {
                pictureBox1.Image = GetImageFromString(abc.Rows[0][9].ToString());
            }
            DataTable xyz = KetNoiCSDL.FillDataTable("select LoaiTk from DangNhap where MaNV='" + MaNhanVien + "'");
            if (xyz.Rows[0][0].ToString() != "admin")
                btn_themuser.Enabled = false;
            KetNoiCSDL.close();
        }

        private void btn_image_Click_1(object sender, EventArgs e)
        {
            UploadImage();
           
        }
        public static string GetStringFromImage(Image image)
        {
            if (image != null)
            {
                ImageConverter ic = new ImageConverter();
                byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
                return Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);
            }
            else
                return null;
        }
        public static Image GetImageFromString(string base64String)
        {
            byte[] buffer = Convert.FromBase64String(base64String);

            if (buffer != null)
            {
                ImageConverter ic = new ImageConverter();
                return ic.ConvertFrom(buffer) as Image;
            }
            else
                return null;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            try
            {
                KetNoiCSDL.FillDataTable("update NhanVien set HoTen=N'" + txt_HoTen.Text + "',DiaChi=N'" + txt_DiaChi.Text + "',SoDienThoai = '" + txt_SDT.Text + "',Email = '" + txt_email.Text + "',NgaySinh ='" + txt_ngaysinh.Text + "',CMND = '" + txt_cmnd.Text + "',BienSoXe='" + txt_BienSoXe.Text + "',image ='" + GetStringFromImage(pictureBox1.Image) + "' where MaNV='" + txt_MaNV.Text + "'");
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            KetNoiCSDL.close();
        }

        private void buttonRadius1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetStringFromImage(pictureBox1.Image));
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMk abc = new DoiMk();
            abc.MaNhanVien = MaNhanVien;
            abc.Show();
        }

        private void btn_themuser_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan abc = new ThemTaiKhoan();
            abc.Show();
        }
    }
}
