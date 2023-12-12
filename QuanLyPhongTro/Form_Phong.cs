using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QuanLyPhongTro
{
    public partial class Form_Phong : Form
    {
        int x = 38;
        int y = 15;
        int Sodem = 0;
        DataClasses1DataContext data = new DataClasses1DataContext();
        public Form_Phong()
        {
            InitializeComponent();
        }
        private void Phong_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(300);
            var TenPhong = data.Phongs.Select(b => b);
            var fibNumbers = new List<int> { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,2
            };
            foreach (var abc in TenPhong)
            {
               
                Taogroupbox(abc.SoPhong);
            }
        }
        public void Taogroupbox(int TenPhong)
        {
            Panel abc = new Panel();
            abc.BackColor = Color.FromArgb(133, 193, 233);
            abc.Width = 231;
            abc.Height = 237;
            if (Sodem == 5)
            {
                y = y + 20 + abc.Height;
                x = 38;
                Sodem = 0;
               
            }
            abc.Location = new Point(x, y);
            this.panel_Phong_body.Controls.Add(abc);
            x = x + 23 + abc.Width;
            Sodem = Sodem + 1;
            
            abc.Controls.Add(AddPictureBox);
            abc.Controls.Add(AddLabel("Phòng"+TenPhong,50,20,12));
            abc.Controls.Add(AddButtonTra());
            abc.Controls.Add(AddButtonXem());
            abc.Controls.Add(AddButtonSua());
            abc.Controls.Add(Icon_user());
            abc.Controls.Add(AddLabel("Nguyễn Minh Nhật", 35, 110,8));
            abc.Controls.Add(Money());
            abc.Controls.Add(AddLabel("1,800,000", 35, 143, 8));
            abc.Controls.Add(AddButton_ChinhSua());
            abc.Controls.Add(AddButton_Xoa());
        }
        public ButtonRadius AddButton_ChinhSua()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(15, 180);
            abc.Size = new Size(108, 35);
            abc.Cursor = Cursors.Hand;
            abc.Name = "btn_Chinh_Sua";
            abc.Text = "Chỉnh Sữa";
            abc.TextAlign = ContentAlignment.MiddleLeft;
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(51, 122, 183);
            abc.BorderColor = Color.FromArgb(51, 122, 183);
            abc.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
            abc.Image = Image.FromFile("C:\\Users\\DaiManThau\\Desktop\\Home_Work\\BaiTap\\DoAn_HeQuanTriCSDL_Nhom4\\HinhAnh\\setting (1).png");
            abc.ImageAlign = ContentAlignment.MiddleRight;
            return abc;
        }
        public ButtonRadius AddButton_Xoa()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(130, 180);
            abc.Size = new Size(80, 35);
            abc.Cursor = Cursors.Hand;
            abc.Name = "btn_Chinh_Xoa";
            abc.Text = "Xóa";
            abc.TextAlign = ContentAlignment.MiddleCenter;
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(217,83,79);
            abc.BorderColor = Color.FromArgb(217, 83, 79);
            abc.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
            abc.Image = Image.FromFile("C:\\Users\\DaiManThau\\Desktop\\Home_Work\\BaiTap\\DoAn_HeQuanTriCSDL_Nhom4\\HinhAnh\\delete (1).png");
            abc.ImageAlign = ContentAlignment.MiddleRight;
            return abc;
        }
        public PictureBox AddPictureBox
        {
            get
            {
                PictureBox abc = new PictureBox();
                abc.Image = Image.FromFile("C:\\Users\\DaiManThau\\Desktop\\Home_Work\\BaiTap\\DoAn_HeQuanTriCSDL_Nhom4\\HinhAnh\\House.png");
                abc.Size = new Size(35, 35);
                abc.Location = new Point(15, 10);
                return abc;
            }
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
        public ButtonRadius AddButtonTra()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(15, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = "btn_Tra";
            abc.Text = "Trả";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.MediumSpringGreen;
            abc.BorderColor = Color.MediumSpringGreen;
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            return abc;
        }


        public ButtonRadius AddButtonXem()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(78, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = "btn_Xem";
            abc.Text = "Xem";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(75, 95, 113);
            abc.BorderColor = Color.FromArgb(75, 95, 113);
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            return abc;
        }
        public ButtonRadius AddButtonSua()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.FlatStyle = FlatStyle.Flat;
            abc.Location = new Point(141, 60);
            abc.Size = new Size(54, 33);
            abc.Cursor = Cursors.Hand;
            abc.Name = "btn_Sua";
            abc.Text = "Sửa";
            abc.BorderSize = 2;
            abc.BorderRadius = 20;
            abc.ForeColor = Color.White;
            abc.BackColor = Color.FromArgb(91, 192, 222);
            abc.BorderColor = Color.FromArgb(91, 192, 222);
            abc.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point);
            return abc;
        }

        public PictureBox Icon_user()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Image.FromFile("C:\\Users\\DaiManThau\\Desktop\\Home_Work\\BaiTap\\DoAn_HeQuanTriCSDL_Nhom4\\HinhAnh\\user.png");
            abc.Size = new Size(20, 20);
            abc.Location = new Point(15, 106);
            abc.SizeMode = PictureBoxSizeMode.Zoom;
            return abc;
        }

        public PictureBox Money()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Image.FromFile("C:\\Users\\DaiManThau\\Desktop\\Home_Work\\BaiTap\\DoAn_HeQuanTriCSDL_Nhom4\\HinhAnh\\money.png");
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
    }
}
