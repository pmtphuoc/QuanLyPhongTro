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
    public partial class TinhTien : Form
    {
        public string MaNhanVien;
        public string MaKH;
        int x = 68;
        int y = 35;
        int Sodem = 0;
        public TinhTien()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TinhTien_Load(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select * from Phong Full outer join KhachHang on Phong.SoPhong=KhachHang.SoPhong");
            KetNoiCSDL.close();
            for (int i = 0; i <= abc.Rows.Count - 1; i++)
            {
               if(abc.Rows[i][3].ToString() !="")
                {
                    if (i > 0)
                    {
                        if ((Convert.ToString(abc.Rows[i][0])) != (Convert.ToString(abc.Rows[i - 1][0])))
                            Taogroupbox((Convert.ToString(abc.Rows[i][0])), (Convert.ToString(abc.Rows[i][3])), "MistyRose");
                    }
                    else {
                        Taogroupbox((Convert.ToString(abc.Rows[i][0])), (Convert.ToString(abc.Rows[i][3])), "MistyRose");
                    }
                    
                }
                else
                {
                    Taogroupbox1((Convert.ToString(abc.Rows[i][0])));
                }
            }
        }
        public void Taogroupbox(String Sophong, String MaKhachHang,string color)
        {
            Panel abc = new Panel();
            abc.BackColor = Color.MistyRose;
            abc.Width = 198;
            abc.Height = 195;
            if (Sodem == 5)
            {
                y = y + 30 + abc.Height;
                x = 68;
                Sodem = 0;

            }
            abc.Location = new Point(x, y);
            this.panel2.Controls.Add(abc);
            x = x + 53 + abc.Width;
            Sodem = Sodem + 1;
            abc.Controls.Add(TaoPicturebox());
            abc.Controls.Add(Taolabel(Sophong));
            abc.Controls.Add(Taobutton(Sophong,MaKhachHang));
            
        }
        public void Taogroupbox1(string sophong)
        {
            Panel abc = new Panel();
            abc.BackColor = Color.DarkGray;
            abc.Width = 198;
            abc.Height = 195;
            if (Sodem == 5)
            {
                y = y + 30 + abc.Height;
                x = 68;
                Sodem = 0;

            }
            abc.Location = new Point(x, y);
            this.panel2.Controls.Add(abc);
            x = x + 53 + abc.Width;
            Sodem = Sodem + 1;
            abc.Controls.Add(TaoPicturebox());
            abc.Controls.Add(Taolabel(sophong));
            abc.Controls.Add(Taobutton1());

        }
        public PictureBox TaoPicturebox()
        {
            PictureBox abc = new PictureBox();
            abc.Image = Properties.Resources.house_2;
            abc.Size = new Size(97, 89);
            abc.Location = new Point(49, 18);
            abc.SizeMode = PictureBoxSizeMode.Zoom;
            return abc;
        }
        public Label Taolabel(String Sophong)
        {
            Label abc = new Label();
            abc.AutoSize = true;
            abc.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular, GraphicsUnit.Point);
            abc.Location = new Point(47, 116);
            abc.Text = "Phòng Số : " + Sophong;
            abc.Name = "txt_SoPhong";
            return abc;
        }
        public ButtonRadius Taobutton(String Sophong,String MaKhachHang)
        {
            KetNoiCSDL.open();
            DataTable xyz = KetNoiCSDL.FillDataTable("select * from HoaDon where Id_KhachHang='" + MaKhachHang + "'  and MONTH(NgayThanhToan)='" + DateTime.Now.Month + "'");
            KetNoiCSDL.close();
            ButtonRadius abc = new ButtonRadius();
            abc.Size = new Size(111, 30);
            abc.BorderRadius = 20;
            abc.Text = "Tính Tiền";
            abc.Location = new Point(42, 146);
            abc.Cursor = Cursors.Hand;
            abc.Name = Sophong + "," + MaKhachHang;
            if (xyz.Rows.Count>0)
            {
                abc.BackColor = Color.Black;
                abc.Click += Abc_Click;   
            }
            else
            {
                abc.BackColor = Color.Red;
                abc.Click += Abc_Click;
            }                                 
            return abc;
        }
        public ButtonRadius Taobutton1()
        {
            ButtonRadius abc = new ButtonRadius();
            abc.Size = new Size(111, 30);
            abc.BorderRadius = 20;
            abc.Text = "Tính Tiền";
            abc.Location = new Point(42, 146);
            abc.Cursor = Cursors.Hand;
            abc.Enabled = false;
            return abc;
        }
        private void Abc_Click(object sender, EventArgs e)
        {
            Button abc = sender as Button;
            HoaDon xyz = new HoaDon();
            string str = abc.Name;
            string[] arrListStr = str.Split(',');
            xyz.SoPhong = arrListStr[0];
            xyz.MaKH = arrListStr[1];
            xyz.MaNV = MaNhanVien;
            xyz.ShowDialog();

        }

    }
}
