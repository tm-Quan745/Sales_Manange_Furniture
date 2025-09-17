namespace Sales_Manange_Furniture.views
{
    partial class UCThongKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlChart = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPercentChange = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRecent = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRecentOrder = new System.Windows.Forms.DataGridView();
            this.pnlRevenue.SuspendLayout();
            this.pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(184)))), ((int)(((byte)(163)))));
            this.pnlChart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(184)))), ((int)(((byte)(163)))));
            this.pnlChart.BorderRadius = 16;
            this.pnlChart.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(184)))), ((int)(((byte)(163)))));
            this.pnlChart.FillColor = System.Drawing.Color.White;
            this.pnlChart.Location = new System.Drawing.Point(108, 104);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(941, 398);
            this.pnlChart.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 92);
            this.label1.TabIndex = 4;
            this.label1.Text = "Overview";
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BorderRadius = 16;
            this.pnlRevenue.Controls.Add(this.lblPercentChange);
            this.pnlRevenue.Controls.Add(this.lblRevenue);
            this.pnlRevenue.Controls.Add(this.label2);
            this.pnlRevenue.FillColor = System.Drawing.Color.White;
            this.pnlRevenue.Location = new System.Drawing.Point(1096, 104);
            this.pnlRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(512, 398);
            this.pnlRevenue.TabIndex = 6;
            // 
            // lblPercentChange
            // 
            this.lblPercentChange.AutoSize = true;
            this.lblPercentChange.BackColor = System.Drawing.Color.White;
            this.lblPercentChange.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPercentChange.Location = new System.Drawing.Point(177, 319);
            this.lblPercentChange.Name = "lblPercentChange";
            this.lblPercentChange.Size = new System.Drawing.Size(158, 37);
            this.lblPercentChange.TabIndex = 5;
            this.lblPercentChange.Text = "Giảm 0.5%";
            // 
            // lblRevenue
            // 
            this.lblRevenue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.BackColor = System.Drawing.Color.White;
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(44)))), ((int)(((byte)(26)))));
            this.lblRevenue.Location = new System.Drawing.Point(102, 176);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(388, 54);
            this.lblRevenue.TabIndex = 4;
            this.lblRevenue.Text = "12,000,000 đồng";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(184, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doanh thu";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // pnlRecent
            // 
            this.pnlRecent.BorderRadius = 21;
            this.pnlRecent.Controls.Add(this.label5);
            this.pnlRecent.Controls.Add(this.dgvRecentOrder);
            this.pnlRecent.FillColor = System.Drawing.Color.White;
            this.pnlRecent.Location = new System.Drawing.Point(108, 522);
            this.pnlRecent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRecent.Name = "pnlRecent";
            this.pnlRecent.Size = new System.Drawing.Size(1500, 352);
            this.pnlRecent.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(25, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đơn hàng gần đây";
            // 
            // dgvRecentOrder
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecentOrder.Location = new System.Drawing.Point(32, 82);
            this.dgvRecentOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRecentOrder.Name = "dgvRecentOrder";
            this.dgvRecentOrder.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentOrder.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecentOrder.RowTemplate.Height = 24;
            this.dgvRecentOrder.Size = new System.Drawing.Size(1430, 238);
            this.dgvRecentOrder.TabIndex = 0;
            // 
            // UCThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlRevenue);
            this.Controls.Add(this.pnlRecent);
            this.Name = "UCThongKe";
            this.Size = new System.Drawing.Size(1696, 919);
            this.pnlRevenue.ResumeLayout(false);
            this.pnlRevenue.PerformLayout();
            this.pnlRecent.ResumeLayout(false);
            this.pnlRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlChart;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlRevenue;
        private System.Windows.Forms.Label lblPercentChange;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel pnlRecent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRecentOrder;
    }
}
