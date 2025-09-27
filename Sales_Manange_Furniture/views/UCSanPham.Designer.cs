namespace Sales_Manange_Furniture.views
{
    partial class UCSanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_Tim = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgv_SanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btn_Tim = new Guna.UI2.WinForms.Guna2Button();
            this.btn_LamMoi = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
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
            this.txt_Tim.PlaceholderText = "Tìm kiếm mã sản phẩm";
            this.txt_Tim.SelectedText = "";
            this.txt_Tim.Size = new System.Drawing.Size(307, 48);
            this.txt_Tim.TabIndex = 4;
            // 
            // dgv_SanPham
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Brown;
            this.dgv_SanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_SanPham.ColumnHeadersHeight = 30;
            this.dgv_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SanPham.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_SanPham.GridColor = System.Drawing.Color.Silver;
            this.dgv_SanPham.Location = new System.Drawing.Point(15, 13);
            this.dgv_SanPham.Name = "dgv_SanPham";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_SanPham.RowHeadersVisible = false;
            this.dgv_SanPham.RowHeadersWidth = 150;
            this.dgv_SanPham.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_SanPham.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_SanPham.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_SanPham.RowTemplate.Height = 200;
            this.dgv_SanPham.RowTemplate.ReadOnly = true;
            this.dgv_SanPham.Size = new System.Drawing.Size(1531, 650);
            this.dgv_SanPham.TabIndex = 3;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_SanPham.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_SanPham.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_SanPham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Height = 30;
            this.dgv_SanPham.ThemeStyle.ReadOnly = false;
            this.dgv_SanPham.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_SanPham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_SanPham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_SanPham.ThemeStyle.RowsStyle.Height = 200;
            this.dgv_SanPham.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_SanPham.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_SanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KhachHang_CellContentClick);
            this.dgv_SanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KhachHang_CellContentClick);
            this.dgv_SanPham.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_SanPham_CellMouseDoubleClick);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.dgv_SanPham);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(108, 170);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1563, 680);
            this.guna2GradientPanel1.TabIndex = 11;
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
            this.btn_Tim.Size = new System.Drawing.Size(93, 48);
            this.btn_Tim.TabIndex = 9;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
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
            this.btn_LamMoi.Location = new System.Drawing.Point(535, 75);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(67, 48);
            this.btn_LamMoi.TabIndex = 83;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // UCSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_LamMoi);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_Tim);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UCSanPham";
            this.Size = new System.Drawing.Size(1743, 919);
            this.Load += new System.EventHandler(this.UCSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_Tim;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_Tim;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btn_LamMoi;
    }
}
