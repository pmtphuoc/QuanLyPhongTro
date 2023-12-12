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
    public partial class Phong : Form
    {
        int x = 38;
        int y = 15;
        int Sodem = 0;
        string sql;
        public string MaNhanVien;
        public Phong()
        {
            InitializeComponent();
        }
        //public void KetNoiDuLieu()
        //{
        //    KetNoiCSDL.open();
        //    sql = "select Phong.SoPhong,Phong.TrangThai,KhachHang.HoTen,KhachHang.Id_KhachHang,LoaiPhong.SoTien from(( Phong Full join KhachHang on Phong.SoPhong = KhachHang.SoPhong) full join LoaiPhong on Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong) where KhachHang.Id_KhachHang=dbo.gomphong1(Phong.SoPhong)";
        //    DataTable abc = KetNoiCSDL.FillDataTable(sql);
        //    KetNoiCSDL.close();
        //    for (int i = 0; i <= abc.Rows.Count - 1; i++)
        //    {
        //        if(abc.Rows[i][0].ToString()!="")
        //        Taogroupbox((String)abc.Rows[i][1], Convert.ToString(abc.Rows[i][0]), Convert.ToString(abc.Rows[i][2]), abc.Rows[i][3].ToString(), Convert.ToString(abc.Rows[i][4]));
        //    }
        //}
        public void KetNoiDuLieu()
        {
            KetNoiCSDL.open();
            sql = "select Phong.SoPhong,Phong.TrangThai,LoaiPhong.SoTien from Phong,LoaiPhong where Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong";           
            DataTable abc = KetNoiCSDL.FillDataTable(sql);
            for (int i = 0; i <= abc.Rows.Count - 1; i++)
            {
                if (abc.Rows[i][1].ToString() != "Trống")
                {
                    DataTable xyz = KetNoiCSDL.FillDataTable("select HoTen,Id_KhachHang  from KhachHang where KhachHang.PhongTruong = 'yes' and KhachHang.SoPhong = " + abc.Rows[i][0].ToString() + "");
                    //MessageBox.Show("Trạng Thại :" + abc.Rows[i][1].ToString());
                    //MessageBox.Show("Số Phòng: " + abc.Rows[i][0].ToString());
                    //MessageBox.Show("Khách Hàng: " + xyz.Rows[0][0].ToString());
                    //MessageBox.Show("Mã KH: " + xyz.Rows[0][1].ToString());
                    //MessageBox.Show("Số tiền: " + abc.Rows[i][2].ToString());
                    Taogroupbox(abc.Rows[i][1].ToString(), abc.Rows[i][0].ToString(), xyz.Rows[0][0].ToString(), xyz.Rows[0][1].ToString(), abc.Rows[i][2].ToString());
                }
                else
                {
                    Taogroupbox(abc.Rows[i][1].ToString(), abc.Rows[i][0].ToString(), null, null, abc.Rows[i][2].ToString());
                }
            }
            KetNoiCSDL.close();
        }
        private void Phong_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(300);
            KetNoiDuLieu();

        }
        public void Taogroupbox(String TrangThai, String SoPhong, String KhachHang,String MaKH ,String SoTien)
        {
            Panel abc = new Panel();
            abc.BackColor = Color.FromArgb(133, 193, 233);
            abc.Width = 231;
            abc.Height = 237;
            if (Sodem == 5)
            {
                y = y + 30 + abc.Height;
                x = 38;
                Sodem = 0;

            }
            abc.Location = new Point(x, y);
            this.panel_Phong_body.Controls.Add(abc);
            x = x + 33 + abc.Width;
            Sodem = Sodem + 1;
            if (TrangThai == "Trống")
            {
                abc.BackColor = Color.White;
                abc.Controls.Add(AddPictureBox());
                abc.Controls.Add(AddLabel("Phòng "+SoPhong, 50, 20, 12));
                abc.Controls.Add(AddButtonThemKhach(MaKH,SoPhong, SoTien));
                abc.Controls.Add(Icon_user());
                abc.Controls.Add(AddLabel("", 35, 110, 8));
                abc.Controls.Add(Money());
                abc.Controls.Add(AddLabel(SoTien, 35, 143, 8));
                abc.Controls.Add(AddButton_ChinhSua(MaKH, SoPhong, SoTien));
                abc.Controls.Add(AddButton_Xoa(MaKH, SoPhong, SoTien));
            }
            else
            {
                abc.Controls.Add(AddPictureBox());
                abc.Controls.Add(AddLabel("Phòng "+SoPhong, 50, 20, 12));
                abc.Controls.Add(AddButtonTra(MaKH,SoPhong));
                abc.Controls.Add(AddButtonXem(MaKH, SoPhong, SoTien));
                abc.Controls.Add(AddButtonSua(MaKH, SoPhong, SoTien));
                abc.Controls.Add(Icon_user());
                abc.Controls.Add(AddLabel(KhachHang, 35, 110, 8));
                abc.Controls.Add(Money());
                abc.Controls.Add(AddLabel(SoTien, 35, 143, 8));
                abc.Controls.Add(AddButton_ChinhSua(MaKH, SoPhong, SoTien));
                abc.Controls.Add(AddButton_Xoa(MaKH, SoPhong, SoTien));
            }    
        }
        public ButtonRadius AddButton_ChinhSua(string makh, string sophong, string sotien)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(15, 180);
            abc.Size = new Size(98, 35);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh + "," + sophong + "," + sotien;
            abc.Text = "Thêm KH";
            abc.TextAlign = ContentAlignment.MiddleLeft;
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(51, 122, 183);
            abc.BorderColor = Color.FromArgb(51, 122, 183);
            abc.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
            abc.Image = Properties.Resources.setting__1_;
            abc.ImageAlign = ContentAlignment.MiddleRight;
            abc.Click += Abc_Click1;
            return abc;
        }
        public ButtonRadius AddButton_Xoa(string makh, string sophong, string sotien)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(120, 180);
            abc.Size = new Size(90, 35);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh + "," + sophong + "," + sotien;
            abc.Text = "Xóa KH";
            abc.TextAlign = ContentAlignment.MiddleCenter;
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(217, 83, 79);
            abc.BorderColor = Color.FromArgb(217, 83, 79);
            abc.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
            abc.Image = Properties.Resources.delete__1_;
            abc.ImageAlign = ContentAlignment.MiddleRight;
            abc.Click += Abc_Click1;
            return abc;
        }

        public PictureBox AddPictureBox()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Properties.Resources.house;
            abc.Size = new Size(35, 35);
            abc.Location = new Point(15, 10);
            return abc;
        }
        public Label AddLabel(String content, int x, int y, int size)
        {
            Label abc = new Label();
            abc.AutoSize = true;
            abc.Location = new Point(x, y);
            abc.Size = new Size(71, 20);
            abc.Text = content;
            abc.Font = new Font("Microsoft Sans Serif", size, FontStyle.Bold, GraphicsUnit.Point);
            abc.ForeColor = Color.FromArgb(38, 45, 57);
            return abc;

        }
        public ButtonRadius AddButtonThemKhach(string makh,string sophong,string sotien)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(15, 60);
            abc.Size = new Size(200, 35);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh+','+sophong+','+ sotien;
            abc.TextAlign = ContentAlignment.MiddleCenter;
            abc.Text = "Thêm Khách Hàng";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(133, 193, 233);
            abc.BorderColor = Color.FromArgb(133, 193, 233);
            abc.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold, GraphicsUnit.Point);
            abc.Click += Abc_Click1;
            return abc;
        }

        private void Abc_Click1(object sender, EventArgs e)
        {
            ThongTinKhachHang abc = new ThongTinKhachHang();
            Button aa = sender as Button;
            string bb = aa.Name;
            string[] arrlist = bb.Split(',');
            abc.MaKhachHang = arrlist[0];
            abc.Loaibutton = aa.Text;
            abc.SoPhong = arrlist[1];
            abc.SoTien = arrlist[2];

            abc.ShowDialog();
        }

        public ButtonRadius AddButtonTra(string makh, string sophong)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(15, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh+","+sophong;
            abc.Text = "Trả";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.MediumSpringGreen;
            abc.BorderColor = Color.MediumSpringGreen;
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            abc.Click += Abc_Click2;
            return abc;
        }

        private void Abc_Click2(object sender, EventArgs e)
        {
            Button aa = sender as Button;
            string bb = aa.Name;
            string[] arrlist = bb.Split(',');
            DialogResult abc = MessageBox.Show("Bạn có muốn trả phòng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(abc == DialogResult.Yes )
            {

                KetNoiCSDL.open();
                DataTable bala = KetNoiCSDL.FillDataTable("select * from HoaDon where Id_KhachHang='" + arrlist[0] + "' and MONTH(NgayThanhToan)='"+DateTime.Now.Month+"'");
                if(bala.Rows.Count>0)
                {
                    KetNoiCSDL.FillDataTable("update KhachHang Set SoPhong=NUll where Id_KhachHang='" + arrlist[0] + "'");
                    KetNoiCSDL.FillDataTable(" update Phong Set TrangThai=N'Trống' where SoPhong=" + arrlist[1] + "");
                    MessageBox.Show("Trả Phòng Thành Công");
                }
                else
                {
                    MessageBox.Show("Vui lòng thanh toán tiền phòng tháng này trước khi trả");
                }
                KetNoiCSDL.close();
            }    
        }

        public ButtonRadius AddButtonXem(string makh, string sophong, string sotien)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(78, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh + "," + sophong + "," + sotien;
            abc.Text = "Xem";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(75, 95, 113);
            abc.BorderColor = Color.FromArgb(75, 95, 113);
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            abc.Click += Abc_Click1;
            return abc;
        }

        public ButtonRadius AddButtonSua(string makh, string sophong, string sotien)
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(141, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = makh+","+sophong+","+sotien;
            abc.Text = "Sửa";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(91, 192, 222);
            abc.BorderColor = Color.FromArgb(91, 192, 222);
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            abc.Click += Abc_Click1;
            return abc;
        }

        public PictureBox Icon_user()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Properties.Resources.user;
            abc.Size = new Size(20, 20);
            abc.Location = new Point(15, 106);
            abc.SizeMode = PictureBoxSizeMode.Zoom;
            return abc;
        }

        public PictureBox Money()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Properties.Resources.money;
            abc.Size = new Size(20, 20);
            abc.Location = new Point(15, 140);
            abc.SizeMode = PictureBoxSizeMode.Zoom;
            return abc;
        }
        public void TinhLoacation(int x, int y)
        {

        }
        private void comboBox_TrangThaiPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {

        }

        private void panel_Phong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_trangthai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonRadius1_Click(object sender, EventArgs e)
        {
            KetNoiDuLieu();
        }
    }
}
