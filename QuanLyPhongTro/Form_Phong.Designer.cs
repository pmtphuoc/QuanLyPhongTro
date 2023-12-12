
namespace QuanLyPhongTro
{
    partial class Form_Phong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Phong));
            this.comboBox_TrangThaiPhong = new System.Windows.Forms.ComboBox();
            this.comboBox_TrangThaiPhi = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel_Phong_body = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_TrangThaiPhong
            // 
            this.comboBox_TrangThaiPhong.FormattingEnabled = true;
            this.comboBox_TrangThaiPhong.Items.AddRange(new object[] {
            "Trạng thái phòng",
            "Phòng trống",
            "Phồng không trống"});
            this.comboBox_TrangThaiPhong.Location = new System.Drawing.Point(11, 28);
            this.comboBox_TrangThaiPhong.Name = "comboBox_TrangThaiPhong";
            this.comboBox_TrangThaiPhong.Size = new System.Drawing.Size(121, 24);
            this.comboBox_TrangThaiPhong.TabIndex = 0;
            this.comboBox_TrangThaiPhong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_TrangThaiPhong_KeyPress);
            // 
            // comboBox_TrangThaiPhi
            // 
            this.comboBox_TrangThaiPhi.FormattingEnabled = true;
            this.comboBox_TrangThaiPhi.Items.AddRange(new object[] {
            "Trạng thái phí",
            "Đã đóng tiền",
            "Chưa đóng tiền"});
            this.comboBox_TrangThaiPhi.Location = new System.Drawing.Point(155, 28);
            this.comboBox_TrangThaiPhi.Name = "comboBox_TrangThaiPhi";
            this.comboBox_TrangThaiPhi.Size = new System.Drawing.Size(121, 24);
            this.comboBox_TrangThaiPhi.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_TimKiem);
            this.panel1.Controls.Add(this.comboBox_TrangThaiPhong);
            this.panel1.Controls.Add(this.comboBox_TrangThaiPhi);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 100);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Còn trống 14 | Đã cho thuê 11 | Chưa thu phí 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_TimKiem.ForeColor = System.Drawing.Color.White;
            this.btn_TimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.Image")));
            this.btn_TimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.Location = new System.Drawing.Point(442, 28);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(100, 25);
            this.btn_TimKiem.TabIndex = 3;
            this.btn_TimKiem.Text = "   Tìm kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = false;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = "";
            this.textBox1.AccessibleName = "";
            this.textBox1.Location = new System.Drawing.Point(310, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 2;
            // 
            // panel_Phong_body
            // 
            this.panel_Phong_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Phong_body.AutoScroll = true;
            this.panel_Phong_body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel_Phong_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Phong_body.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Phong_body.Location = new System.Drawing.Point(11, 106);
            this.panel_Phong_body.Name = "panel_Phong_body";
            this.panel_Phong_body.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel_Phong_body.Size = new System.Drawing.Size(1104, 599);
            this.panel_Phong_body.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "akjsdajksdsa",
            "hagsdhjdas",
            "djasgdasgdasd",
            "jasgdasgdhagdhas"});
            this.comboBox1.Location = new System.Drawing.Point(654, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 717);
            this.Controls.Add(this.panel_Phong_body);
            this.Controls.Add(this.panel1);
            this.Name = "Phong";
            this.Text = "Phong";
            this.Load += new System.EventHandler(this.Phong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_TrangThaiPhong;
        private System.Windows.Forms.ComboBox comboBox_TrangThaiPhi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Phong_body;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}