using Sales_Manage_Furniture.models;

namespace Sales_Manange_Furniture
{
    partial class Mainform
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
            this.topbar1 = new Sales_Manange_Furniture.Topbar();
            this.ucBanHang1 = new Sales_Manange_Furniture.views.UCBanHang(new NhanVien());
            this.sidebar1 = new Sales_Manange_Furniture.Sidebar();
            this.SuspendLayout();
            // 
            // topbar1
            // 
            this.topbar1.BackColor = System.Drawing.Color.Azure;
            this.topbar1.Location = new System.Drawing.Point(222, 2);
            this.topbar1.Name = "topbar1";
            this.topbar1.Size = new System.Drawing.Size(1696, 120);
            this.topbar1.TabIndex = 1;
            // 
            // ucBanHang1
            // 
            this.ucBanHang1.Location = new System.Drawing.Point(222, 107);
            this.ucBanHang1.Name = "ucBanHang1";
            this.ucBanHang1.Size = new System.Drawing.Size(1696, 960);
            this.ucBanHang1.TabIndex = 2;
            // 
            // sidebar1
            // 
            this.sidebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(74)))), ((int)(((byte)(98)))));
            this.sidebar1.Location = new System.Drawing.Point(12, 2);
            this.sidebar1.Name = "sidebar1";
            this.sidebar1.Size = new System.Drawing.Size(214, 1080);
            this.sidebar1.TabIndex = 3;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.sidebar1);
            this.Controls.Add(this.ucBanHang1);
            this.Controls.Add(this.topbar1);
            this.Name = "Mainform";
            this.Text = "Mainform";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private Topbar topbar1;
        private views.UCBanHang ucBanHang1;
        private Sidebar sidebar1;
    }
}