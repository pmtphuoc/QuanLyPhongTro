using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class InHoaDon : Form
    {
        public string MaKh;
        public string SDT;
        public string TenKhachHang;
        public string CMND;
        public string Sophong;
        public string TienPhong;
        public string TienDien;
        public string TienNuoc;
        public string TongTien;
        public InHoaDon()
        {
            
            InitializeComponent();
        }
        private void load()
        {
            lb_MaKhachHang.Text = MaKh;
            lb_hoten.Text = TenKhachHang;
            lb_cmnd.Text = CMND;
            lb_SDT.Text = SDT;
            lb_SoPhong.Text = Sophong;
            lb_TienPhong.Text = TienPhong;
            lb_TienDien.Text = TienDien;
            lb_TienNuoc.Text = TienNuoc;
            label20.Text = TongTien;
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Print");
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel2 = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private Bitmap memoryimg;

        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel2.Width / 2 ), this.panel2.Location.Y);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Print(this.panel2);
        }

        private void loadhoadon(object sender, EventArgs e)
        {
            load();
        }
    }
}
