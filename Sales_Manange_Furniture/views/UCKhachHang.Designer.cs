namespace Sales_Manange_Furniture.views
{
    partial class UCKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_Tim = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Them = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Tim = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dgv_KhachHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_LamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).BeginInit();
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
            this.txt_Tim.PlaceholderText = "Tìm kiếm theo số điện thoại";
            this.txt_Tim.SelectedText = "";
            this.txt_Tim.Size = new System.Drawing.Size(307, 48);
            this.txt_Tim.TabIndex = 1;
            this.txt_Tim.TextChanged += new System.EventHandler(this.txt_Tim_TextChanged);
            // 
            // btn_Them
            // 
            this.btn_Them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.White;
            this.btn_Them.Location = new System.Drawing.Point(1474, 113);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(180, 45);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm mới";
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
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
            this.btn_Tim.Location = new System.Drawing.Point(436, 75);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(86, 48);
            this.btn_Tim.TabIndex = 9;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.dgv_KhachHang);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(108, 170);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1563, 680);
            this.guna2GradientPanel1.TabIndex = 13;
            // 
            // dgv_KhachHang
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Brown;
            this.dgv_KhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_KhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_KhachHang.ColumnHeadersHeight = 30;
            this.dgv_KhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_KhachHang.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_KhachHang.GridColor = System.Drawing.Color.Silver;
            this.dgv_KhachHang.Location = new System.Drawing.Point(15, 13);
            this.dgv_KhachHang.Name = "dgv_KhachHang";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_KhachHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_KhachHang.RowHeadersVisible = false;
            this.dgv_KhachHang.RowHeadersWidth = 90;
            this.dgv_KhachHang.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_KhachHang.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_KhachHang.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_KhachHang.RowTemplate.Height = 50;
            this.dgv_KhachHang.RowTemplate.ReadOnly = true;
            this.dgv_KhachHang.Size = new System.Drawing.Size(1531, 650);
            this.dgv_KhachHang.TabIndex = 3;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_KhachHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.Height = 30;
            this.dgv_KhachHang.ThemeStyle.ReadOnly = false;
            this.dgv_KhachHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_KhachHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_KhachHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_KhachHang.ThemeStyle.RowsStyle.Height = 50;
            this.dgv_KhachHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_KhachHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            this.btn_LamMoi.Location = new System.Drawing.Point(528, 75);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(67, 48);
            this.btn_LamMoi.TabIndex = 82;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // UCKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_LamMoi);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.txt_Tim);
            this.Name = "UCKhachHang";
            this.Size = new System.Drawing.Size(1809, 919);
            this.Load += new System.EventHandler(this.UCKhachHang_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txt_Tim;
        private Guna.UI2.WinForms.Guna2Button btn_Them;
        private Guna.UI2.WinForms.Guna2Button btn_Tim;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_KhachHang;
        private Guna.UI2.WinForms.Guna2Button btn_LamMoi;
    }
}
