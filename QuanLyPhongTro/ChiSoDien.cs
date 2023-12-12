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
    public partial class ChiSoDien : Form
    {
        public ChiSoDien()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Laydata()
        {
            KetNoiCSDL.open();
            DataTable abc = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Dien.SoPhong,'Cs Điện Tháng Trước'= Dien.CsThangTruoc, 'Cs Điện Tháng này'=Dien.CsThangNay,'Số Kg Điện Tháng này'=Round(Dien.CsThangNay-Dien.CsThangTruoc,1),'Tiền điện tháng này' =Round( (Dien.CsThangNay - Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Dien where MONTH(Dien.Ngayghi)='" + dateTimePickerCustom1.Value.Month + "' and YEAR(Dien.Ngayghi) = '" + dateTimePickerCustom1.Value.Year + "'");
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
                dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Dien.SoPhong,'Cs Điện Tháng Trước'= Dien.CsThangTruoc, 'Cs Điện Tháng này'=Dien.CsThangNay,'Số Kg Điện Tháng này'=Round(Dien.CsThangNay-Dien.CsThangTruoc,1),'Tiền điện tháng này' =Round( (Dien.CsThangNay - Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Dien where MONTH(Dien.Ngayghi)='" + thang + "' and YEAR(Dien.Ngayghi) = '" + nam + "'");
            }
            DataTable xyz = KetNoiCSDL.FillDataTable("select SoTien from DichVu where TenDichVu=N'Điện'");
            txt_GiaHT.Text = xyz.Rows[0][0].ToString() + "VNĐ";
            KetNoiCSDL.close();
        }
        private void ChiSoDien_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 186, 192);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 12, FontStyle.Bold);
            Laydata();
            dataGridView1.Columns[0].Width = 80;
            //MessageBox.Show(abc.Columns.Count.ToString()+"-"+abc.Rows[0][0]);         
            //tableLayoutPanel1.RowCount = abc.Rows.Count-1;
            //tableLayoutPanel2.Controls.Add(TaoLable(Convert.ToString(abc.Rows[0][0])), 0, 1);
            //tableLayoutPanel2.Controls.Add(TaoLable(Convert.ToString(abc.Rows[0][1])), 1, 1);
            //tableLayoutPanel2.Controls.Add(TaoLable(Convert.ToString(abc.Rows[0][2])), 2, 1);
            //tableLayoutPanel2.Controls.Add(TaoLable(Convert.ToString(abc.Rows[0][3])), 3, 1);
            //tableLayoutPanel2.Controls.Add(TaoLable(Convert.ToString(abc.Rows[0][4])), 4, 1);
            //for (int i = 1; i <= abc.Rows.Count; i++)
            //{
            //    for (int j = 0; j <= abc.Columns.Count - 1; j++)
            //    {
            //        //MessageBox.Show(j.ToString());
            //        tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i-1][j])), j, xyz);
            //    }
            //    xyz += 1;
            //}
            //for (int i = 1; i <= abc.Rows.Count; i++)
            //{
            //    tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i - 1][0])), 0, i);
            //    tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i - 1][1])), 1, i);
            //    tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i - 1][2])), 2, i);
            //    tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i - 1][3])), 3, i);
            //    tableLayoutPanel1.Controls.Add(TaoLable(Convert.ToString(abc.Rows[i - 1][4])), 4, i);
            //}
        }


        private void dateTimePickerCustom1_ValueChanged(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            
            DataTable abc = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Dien.SoPhong,'Cs Điện Tháng Trước'= Dien.CsThangTruoc, 'Cs Điện Tháng này'=Dien.CsThangNay,'Số Kg Điện Tháng này'=Round(Dien.CsThangNay-Dien.CsThangTruoc,1),'Tiền điện tháng này' =Round( (Dien.CsThangNay - Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Dien where MONTH(Dien.Ngayghi)='" + dateTimePickerCustom1.Value.Month + "' and YEAR(Dien.Ngayghi) = '" + dateTimePickerCustom1.Value.Year + "'");
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
                dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Phòng Số' =Dien.SoPhong,'Cs Điện Tháng Trước'= Dien.CsThangTruoc, 'Cs Điện Tháng này'=Dien.CsThangNay,'Số Kg Điện Tháng này'=Round(Dien.CsThangNay-Dien.CsThangTruoc,1),'Tiền điện tháng này' =Round( (Dien.CsThangNay - Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Dien where MONTH(Dien.Ngayghi)='" + thang + "' and YEAR(Dien.Ngayghi) = '" + nam + "'");
            } 
            KetNoiCSDL.close();
        }

        private void btn_NhapDien_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            int thang = dateTimePickerCustom1.Value.Month;
            int nam = dateTimePickerCustom1.Value.Year;
            DataTable b002 = KetNoiCSDL.FillDataTable("select *from Dien where MONTH(Ngayghi)=" + thang + " and YEAR(Ngayghi) = " + nam + "");
            if (thang == 1)
            {
                thang = 12;
                nam = nam - 1;
            }
            else
            {
                thang = thang - 1;
            }
            dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Dien.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Dien,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Dien.Ngayghi) = '" + nam + "' and Dien.SoPhong=Phong.SoPhong");

            //if (b002.Rows.Count > 0)
            //{
            //    dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Dien.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangTruoc,'Cs Tháng Này'='' from Dien,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Dien.Ngayghi) = '" + nam + "' and Dien.SoPhong=Phong.SoPhong");
            //}
            //else
            //{
            //    dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Dien.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Dien,Phong where MONTH(Ngayghi)='" + thang + "' and YEAR(Dien.Ngayghi) = '" + nam + "' and Dien.SoPhong=Phong.SoPhong");
            //}
            //if (thang == 1)
            //{
            //    thang = 12;
            //    nam=nam-1;
            //}
            //else
            //{
            //    thang = thang - 1;
            //}
            //dataGridView1.DataSource = KetNoiCSDL.FillDataTable("select 'Số Phòng'=Dien.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangTruoc,'Cs Tháng Này'='' from Dien,Phong where MONTH(Ngayghi)='" + thang+ "' and YEAR(Dien.Ngayghi) = '"+ nam + "' and Dien.SoPhong=Phong.SoPhong");
            dataGridView1.Columns["Số Phòng"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Tình Trạng"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Cs Tháng Trước"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Cs Tháng Này"].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i =0; i< dataGridView1.Rows.Count-1;i++)
            {
                if(Convert.ToString(dataGridView1.Rows[i].Cells["Tình Trạng"].Value)=="Trống")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(243, 250, 232);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[i].ReadOnly = true;
                    dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value = dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value;
                }    
            }    
            KetNoiCSDL.close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {
                //MessageBox.Show(dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString());
                //KetNoiCSDL.FillDataTable("insert into Dien values(" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() + ",current_timestamp)");
                DataTable b001 = KetNoiCSDL.FillDataTable("select *from Dien where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)=" + dateTimePickerCustom1.Value.Month + " and DAY(Ngayghi)<=" + dateTimePickerCustom1.Value.Day + " and SoPhong=" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                if (b001.Rows.Count < 1)
                {
                    if (dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() == "" || int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString()) < int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString()))
                    {
                        KetNoiCSDL.FillDataTable("insert into Dien values(" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + ",'" + dateTimePickerCustom1.Value.ToString("yyyy/MM/dd") + "')");
                    }
                    else
                    {
                        KetNoiCSDL.FillDataTable("insert into Dien values(" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() + ",'" + dateTimePickerCustom1.Value.ToString("yyyy/MM/dd") + "')");
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() == "" || int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString()) < int.Parse(dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString()))
                    {
                        KetNoiCSDL.FillDataTable("update Dien set CsThangNay=" + dataGridView1.Rows[i].Cells["Cs Tháng Trước"].Value.ToString() + " where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)=" + dateTimePickerCustom1.Value.Month + " and DAY(Ngayghi)<=" + dateTimePickerCustom1.Value.Day + " and SoPhong=" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                    }
                    else
                    {
                        KetNoiCSDL.FillDataTable("update Dien set CsThangNay=" + dataGridView1.Rows[i].Cells["Cs Tháng Này"].Value.ToString() + " where YEAR(Ngayghi)=" + dateTimePickerCustom1.Value.Year + " and MONTH(Ngayghi)=" + dateTimePickerCustom1.Value.Month + " and DAY(Ngayghi)<=" + dateTimePickerCustom1.Value.Day + " and SoPhong=" + dataGridView1.Rows[i].Cells["Số Phòng"].Value.ToString() + "");
                    }
                }
            }
            KetNoiCSDL.close();
        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            KetNoiCSDL.open();
            KetNoiCSDL.FillDataTable("update DichVu set SoTien =" + txt_GiaM.Text + " where TenDichVu=N'Điện'");
            KetNoiCSDL.close();
            Laydata();

        }
    }
}
