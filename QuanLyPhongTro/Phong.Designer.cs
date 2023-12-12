
namespace QuanLyPhongTro
{
    partial class Phong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_DanhSachPhong = new System.Windows.Forms.Label();
            this.panel_Phong_body = new System.Windows.Forms.Panel();
            this.buttonRadius1 = new QuanLyPhongTro.ButtonRadius();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.buttonRadius1);
            this.panel1.Controls.Add(this.lb_DanhSachPhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 100);
            this.panel1.TabIndex = 0;
            // 
            // lb_DanhSachPhong
            // 
            this.lb_DanhSachPhong.AutoSize = true;
            this.lb_DanhSachPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.lb_DanhSachPhong.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DanhSachPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.lb_DanhSachPhong.Location = new System.Drawing.Point(11, 13);
            this.lb_DanhSachPhong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DanhSachPhong.Name = "lb_DanhSachPhong";
            this.lb_DanhSachPhong.Size = new System.Drawing.Size(301, 57);
            this.lb_DanhSachPhong.TabIndex = 3;
            this.lb_DanhSachPhong.Text = "Danh Sách Phòng";
            // 
            // panel_Phong_body
            // 
            this.panel_Phong_body.AllowDrop = true;
            this.panel_Phong_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Phong_body.AutoScroll = true;
            this.panel_Phong_body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.panel_Phong_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Phong_body.Location = new System.Drawing.Point(12, 109);
            this.panel_Phong_body.Name = "panel_Phong_body";
            this.panel_Phong_body.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.panel_Phong_body.Size = new System.Drawing.Size(1227, 518);
            this.panel_Phong_body.TabIndex = 1;
            // 
            // buttonRadius1
            // 
            this.buttonRadius1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRadius1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonRadius1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRadius1.BorderRadius = 40;
            this.buttonRadius1.BorderSize = 0;
            this.buttonRadius1.FlatAppearance.BorderSize = 0;
            this.buttonRadius1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRadius1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRadius1.ForeColor = System.Drawing.Color.White;
            this.buttonRadius1.Location = new System.Drawing.Point(1089, 30);
            this.buttonRadius1.Name = "buttonRadius1";
            this.buttonRadius1.Size = new System.Drawing.Size(150, 40);
            this.buttonRadius1.TabIndex = 4;
            this.buttonRadius1.Text = "Refresh";
            this.buttonRadius1.UseVisualStyleBackColor = false;
            this.buttonRadius1.Click += new System.EventHandler(this.buttonRadius1_Click);
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(93)))), ((int)(((byte)(143)))));
            this.ClientSize = new System.Drawing.Size(1251, 636);
            this.Controls.Add(this.panel_Phong_body);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Phong";
            this.Text = "Phong";
            this.Load += new System.EventHandler(this.Phong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Phong_body;
        private System.Windows.Forms.Label lb_DanhSachPhong;
        private ButtonRadius buttonRadius1;
    }
}