namespace Sales_Manange_Furniture.views
{
    partial class UCHoaDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_Tim = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Tim = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dgv_HoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.col_MaHDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ChietKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ThueVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_LamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Tim
            // 
            this.txt_Tim.BorderRadius = 10;
            this.txt_Tim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Tim.DefaultText = "";
            this.txt_Tim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Tim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Tim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Tim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Tim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Tim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Tim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Tim.Location = new System.Drawing.Point(123, 75);
            this.txt_Tim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Tim.Name = "txt_Tim";
            this.txt_Tim.PlaceholderText = "Tìm kiếm theo mã hoá đơn";
            this.txt_Tim.SelectedText = "";
            this.txt_Tim.Size = new System.Drawing.Size(321, 48);
            this.txt_Tim.TabIndex = 4;
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Tim.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Tim.BorderRadius = 10;
            this.btn_Tim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Tim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Tim.FillColor = System.Drawing.SystemColors.Highlight;
            this.btn_Tim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Tim.ForeColor = System.Drawing.Color.Black;
            this.btn_Tim.Image = global::Sales_Manange_Furniture.Properties.Resources.iconsearch1;
            this.btn_Tim.Location = new System.Drawing.Point(450, 75);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(95, 48);
            this.btn_Tim.TabIndex = 7;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.dgv_HoaDon);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(108, 170);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1563, 680);
            this.guna2GradientPanel1.TabIndex = 12;
            // 
            // dgv_HoaDon
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
            this.dgv_HoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_HoaDon.ColumnHeadersHeight = 30;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaHDB,
            this.col_MaKH,
            this.col_MaNV,
            this.col_NgayBan,
            this.col_ChietKhau,
            this.col_ThueVat,
            this.col_TongTien,
            this.col_TrangThai});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HoaDon.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_HoaDon.GridColor = System.Drawing.Color.Silver;
            this.dgv_HoaDon.Location = new System.Drawing.Point(3, 13);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_HoaDon.RowHeadersVisible = false;
            this.dgv_HoaDon.RowHeadersWidth = 90;
            this.dgv_HoaDon.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv_HoaDon.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_HoaDon.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_HoaDon.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_HoaDon.RowTemplate.Height = 50;
            this.dgv_HoaDon.RowTemplate.ReadOnly = true;
            this.dgv_HoaDon.Size = new System.Drawing.Size(1531, 650);
            this.dgv_HoaDon.TabIndex = 3;
            this.dgv_HoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_HoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_HoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_HoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_HoaDon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_HoaDon.ThemeStyle.HeaderStyle.Height = 30;
            this.dgv_HoaDon.ThemeStyle.ReadOnly = false;
            this.dgv_HoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_HoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_HoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_HoaDon.ThemeStyle.RowsStyle.Height = 50;
            this.dgv_HoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_HoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_HoaDon.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_HoaDon_CellMouseDoubleClick);
            // 
            // col_MaHDB
            // 
            this.col_MaHDB.DataPropertyName = "MaHDB";
            this.col_MaHDB.HeaderText = "Mã hoá đơn";
            this.col_MaHDB.MinimumWidth = 6;
            this.col_MaHDB.Name = "col_MaHDB";
            // 
            // col_MaKH
            // 
            this.col_MaKH.DataPropertyName = "MaKH";
            this.col_MaKH.HeaderText = "Mã khách hàng";
            this.col_MaKH.MinimumWidth = 6;
            this.col_MaKH.Name = "col_MaKH";
            // 
            // col_MaNV
            // 
            this.col_MaNV.DataPropertyName = "MaNV";
            this.col_MaNV.HeaderText = "Mã nhân viên";
            this.col_MaNV.MinimumWidth = 6;
            this.col_MaNV.Name = "col_MaNV";
            // 
            // col_NgayBan
            // 
            this.col_NgayBan.DataPropertyName = "TienTamTinh";
            dataGridViewCellStyle3.Format = "N0";
            this.col_NgayBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_NgayBan.HeaderText = "Tiền tạm tính";
            this.col_NgayBan.MinimumWidth = 6;
            this.col_NgayBan.Name = "col_NgayBan";
            // 
            // col_ChietKhau
            // 
            this.col_ChietKhau.DataPropertyName = "ChietKhau";
            dataGridViewCellStyle4.Format = "N0";
            this.col_ChietKhau.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_ChietKhau.HeaderText = "Chiết khấu";
            this.col_ChietKhau.MinimumWidth = 6;
            this.col_ChietKhau.Name = "col_ChietKhau";
            // 
            // col_ThueVat
            // 
            this.col_ThueVat.DataPropertyName = "ThueVAT";
            dataGridViewCellStyle5.Format = "N0";
            this.col_ThueVat.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ThueVat.HeaderText = "Thuế VAT";
            this.col_ThueVat.MinimumWidth = 6;
            this.col_ThueVat.Name = "col_ThueVat";
            // 
            // col_TongTien
            // 
            this.col_TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle6.Format = "N0";
            this.col_TongTien.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_TongTien.HeaderText = "Tổng tiền";
            this.col_TongTien.MinimumWidth = 6;
            this.col_TongTien.Name = "col_TongTien";
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.DataPropertyName = "TrangThai";
            this.col_TrangThai.HeaderText = "Trạng thái";
            this.col_TrangThai.MinimumWidth = 6;
            this.col_TrangThai.Name = "col_TrangThai";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.BackColor = System.Drawing.SystemColors.Control;
            this.btn_LamMoi.BorderRadius = 10;
            this.btn_LamMoi.BorderThickness = 1;
            this.btn_LamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_LamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_LamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_LamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_LamMoi.FillColor = System.Drawing.Color.White;
            this.btn_LamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_LamMoi.ForeColor = System.Drawing.Color.Black;
            this.btn_LamMoi.Image = global::Sales_Manange_Furniture.Properties.Resources.reload;
            this.btn_LamMoi.Location = new System.Drawing.Point(551, 75);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(67, 48);
            this.btn_LamMoi.TabIndex = 81;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // UCHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_LamMoi);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_Tim);
            this.Name = "UCHoaDon";
            this.Size = new System.Drawing.Size(1776, 919);
            this.Load += new System.EventHandler(this.UCHoaDon_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txt_Tim;
        private Guna.UI2.WinForms.Guna2Button btn_Tim;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaHDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ChietKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ThueVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TrangThai;
        private Guna.UI2.WinForms.Guna2Button btn_LamMoi;
    }
}
