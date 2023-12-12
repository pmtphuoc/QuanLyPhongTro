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
    public partial class ChSoNuoc : Form
    {
        public ChSoNuoc()
        {
            InitializeComponent();
        }
        public void laydata()
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Nuoc.SoPhong,'Cs Nước Tháng Trước'= Nuoc.CsThangTruoc, 'Cs Nước Tháng này'=Nuoc.CsThangNay,'Số Khối Nước Tháng này'=Round(Nuoc.CsThangNay-Nuoc.CsThangTruoc,1),'Tiền Nước tháng này' =Round( (Nuoc.CsThangNay - Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Nuoc where MONTH(Nuoc.Ngayghi)='" + dateTimePickerCustom1.Value.Month + "' and YEAR(Nuoc.Ngayghi) = '" + dateTimePickerCustom1.Value.Year + "'");
            if (abc.Rows.Count > 1)
                dataGridView1.DataSource = abc;
            else
            {
                int thang = dateTimePickerCustom1.Value.Month;
                if (thang == 1)
                {
                    thang = 12;
                }
                else
                {
                    thang = thang - 1;
                }
                int nam = dateTimePickerCustom1.Value.Year;
                if (thang == 12)
                    nam = nam - 1;
                dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Nuoc.SoPhong,'Cs Nước Tháng Trước'= Nuoc.CsThangTruoc, 'Cs Nước Tháng này'=Nuoc.CsThangNay,'Số Khối Nước Tháng này'=Round(Nuoc.CsThangNay-Nuoc.CsThangTruoc,1),'Tiền Nước tháng này' =Round( (Nuoc.CsThangNay - Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Nuoc where MONTH(Nuoc.Ngayghi)='" + thang + "' and YEAR(Nuoc.Ngayghi) = '" + nam + "'");
            }
            DataTable xyz = KetNoiCSDL.FillDataTable("select SoTien from DichVu where TenDichVu=N'Nước'");
            txt_GiaHT.Text = xyz.Rows[0][0].ToString() + "VNĐ";
            KetNoiCSDL.close();
        }
        private void ChSoNuoc_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 186, 192);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 12, FontStyle.Bold);
            laydata();
            dataGridView1.Columns[0].Width = 80;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePickerCustom1_ValueChanged(object sender, EventArgs e)
        {
            KetNoiCSDL.open();

            DataTable abc = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Nuoc.SoPhong,'Cs Nước Tháng Trước'= Nuoc.CsThangTruoc, 'Cs Nước Tháng này'=Nuoc.CsThangNay,'Số Khối" +
                " Nước Tháng này'=Round(Nuoc.CsThangNay-Nuoc.CsThangTruoc,1),'Tiền Nước tháng này' =Round( (Nuoc.CsThangNay - Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Nuoc where MONTH(Nuoc.Ngayghi)='" + dateTimePickerCustom1.Value.Month + "' and YEAR(Nuoc.Ngayghi) = '" + dateTimePickerCustom1.Value.Year + "'");
            if (abc.Rows.Count > 1)
                dataGridView1.DataSource = abc;
            else
            {
                int thang = dateTimePickerCustom1.Value.Month;
                if (thang == 1)
                {
                    thang = 12;
                }
                else
                {
                    thang = thang - 1;
                }
                int nam = dateTimePickerCustom1.Value.Year;
                if (thang == 12)
                    nam = nam - 1;
                dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Nuoc.SoPhong,'Cs Nước Tháng Trước'= Nuoc.CsThangTruoc, 'Cs Nước Tháng này'=Nuoc.CsThangNay,'Số Khối Nước Tháng này'=Round(Nuoc.CsThangNay-Nuoc.CsThangTruoc,1),'Tiền Nước tháng này' =Round( (Nuoc.CsThangNay - Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Nuoc where MONTH(Nuoc.Ngayghi)='" + thang + "' and YEAR(Nuoc.Ngayghi) = '" + nam + "'");
            }
            KetNoiCSDL.close();
        }

        private void btn_NhapNuoc_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            int thang = dateTimePickerCustom1.Value.Month;
            int nam = dateTimePickerCustom1.Value.Year;
            DataTable b002 = KetNoiCSDL.FillDataTable("select *from Nuoc where MONTH(Ngayghi)=" + thang + " and YEAR(Ngayghi) = " + nam + "");
            if (thang == 1)
            {
                thang = 12;
                nam = nam - 1;
            }
            else
            {
                thang = thang - 1;
            }
            dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Nuoc.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Nuoc,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Nuoc.Ngayghi) = '" + nam + "' and Nuoc.SoPhong=Phong.SoPhong");

            //if (b002.Rows.Count > 0)
            //{
            //    dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Nuoc.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangTruoc,'Cs Tháng Này'='' from Nuoc,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Nuoc.Ngayghi) = '" + nam + "' and Nuoc.SoPhong=Phong.SoPhong");
            //}
            //else
            //{
            //    dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Nuoc.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Nuoc,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Nuoc.Ngayghi) = '" + nam + "' and Nuoc.SoPhong=Phong.SoPhong");
            //}
            dataGridView1.Columns["Số Phòng"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Tình Trạng"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Cs Tháng Trước"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Cs Tháng Này"].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells["Tình Trạng"].Value) == "Trống")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(243, 250, 232);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[i].ReadOnly = true;
                    dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value = dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value;
                }
            }
            KetNoiCSDL.close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataTable b001=KetNoiCSDL.FillDataTable("select *from Nuoc where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)="+ dateTimePickerCustom1.Value.Month+ " and DAY(Ngayghi)<="+ dateTimePickerCustom1.Value.Day+ " and SoPhong="+ dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                if(b001.Rows.Count<1)
                { 
                if(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString()==""||int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString())<int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString()))
                {
                    KetNoiCSDL.FillDataTable("insert into Nuoc values(" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + ",'"+ dateTimePickerCustom1.Value.ToString("yyyy/MM/dd") + "')");
                }
                else
                {
                    KetNoiCSDL.FillDataTable("insert into Nuoc values(" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() + ",'"+ dateTimePickerCustom1.Value.ToString("yyyy/MM/dd") + "')");
                }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() == "" || int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString()) < int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString()))
                    {
                        KetNoiCSDL.FillDataTable("update Nuoc set CsThangNay=" + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + " where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)=" + dateTimePickerCustom1.Value.Month + " and DAY(Ngayghi)<=" + dateTimePickerCustom1.Value.Day + " and SoPhong=" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                    }
                    else
                    {
                        KetNoiCSDL.FillDataTable("update Nuoc set CsThangNay=" + dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() + " where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)=" + dateTimePickerCustom1.Value.Month + " and DAY(Ngayghi)<=" + dateTimePickerCustom1.Value.Day + " and SoPhong=" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                    }
                }

            }
            KetNoiCSDL.close();
        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            KetNoiCSDL.FillDataTable("update DichVu set SoTien =" + txt_GiaM.Text + " where TenDichVu=N'Nước'");
            KetNoiCSDL.close();
            laydata();
        }
    }
}
