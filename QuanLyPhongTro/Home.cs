using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuanLyPhongTro
{
    public partial class Home : Form
    {
        public string MaNhanVien;
        public Home()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_Load(object sender, EventArgs e)
        {           
           
        }
        private Form currentChildForm;
        private void OpenChildForm(Form ChildForm)
        {
            if(currentChildForm!=null)
            {
                currentChildForm.Close();
            }
            currentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(ChildForm);
            panel_body.Tag = ChildForm;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void btn_toggle_Click(object sender, EventArgs e)
        {

            if (Menu_Home.Width == 188)
            {
                Menu_Home.Width = 80;
                //MessageBox.Show(Menu_Home.Width.ToString());
            }
            else
            {
                Menu_Home.Width = 188;
                //MessageBox.Show(Menu_Home.Width.ToString());
            }
        }

        private void icon_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void icon_phongto_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            icon_phongnho.Visible = true;
            icon_phongto.Visible = false;
            
        }

        private void icon_thunho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            icon_phongnho.Visible = false;
            icon_phongto.Visible = true;
        }

        private void icon_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NavTop_Home_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Home_Phong_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = new Phong();
            Phong abc = new Phong();
            abc.TopLevel = false;
            abc.Dock = DockStyle.Fill;
            this.panel_body.Controls.Add(abc);
            this.panel_body.Tag = abc;
            abc.MaNhanVien = MaNhanVien;
            abc.BringToFront();
            abc.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DsKhachHang());
        }

        private void Menu_Home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_CsDien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChiSoDien());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = new TinhTien();
            TinhTien abc = new TinhTien();
            abc.TopLevel = false;
            abc.Dock = DockStyle.Fill;
            this.panel_body.Controls.Add(abc);
            this.panel_body.Tag = abc;
            abc.MaNhanVien = MaNhanVien;
            abc.BringToFront();
            abc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChSoNuoc());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            //TaiKhoan abc = new TaiKhoan();
            //abc.TopLevel = false;
            //abc.Dock = DockStyle.Fill;
            //this.panel_body.Controls.Add(abc);
            //this.panel_body.Tag = abc;
            //abc.MaNhanVien = MaNhanVien;
            //abc.Show();
            TaiKhoan abc = new TaiKhoan();
            abc.MaNhanVien = MaNhanVien;
            abc.ShowDialog();
        }
    }
}
