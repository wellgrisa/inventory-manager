namespace Reports.Moviments
{
    partial class MovimentsReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.movimentsViewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryManagerDataSet1 = new Reports.InventoryManagerDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.movimentsViewTableAdapter1 = new Reports.InventoryManagerDataSet1TableAdapters.MovimentsViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.movimentsViewBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagerDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // movimentsViewBindingSource1
            // 
            this.movimentsViewBindingSource1.DataMember = "MovimentsView";
            this.movimentsViewBindingSource1.DataSource = this.inventoryManagerDataSet1;
            // 
            // inventoryManagerDataSet1
            // 
            this.inventoryManagerDataSet1.DataSetName = "InventoryManagerDataSet1";
            this.inventoryManagerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MovimentsView";
            reportDataSource1.Value = this.movimentsViewBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Moviments.Moviments.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // movimentsViewTableAdapter1
            // 
            this.movimentsViewTableAdapter1.ClearBeforeFill = true;
            // 
            // MovimentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MovimentsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovimentsReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MovimentsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movimentsViewBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagerDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;        
        private System.Windows.Forms.BindingSource movimentsViewBindingSource;        
        private InventoryManagerDataSet1 inventoryManagerDataSet1;
        private System.Windows.Forms.BindingSource movimentsViewBindingSource1;
        private InventoryManagerDataSet1TableAdapters.MovimentsViewTableAdapter movimentsViewTableAdapter1;
    }
}