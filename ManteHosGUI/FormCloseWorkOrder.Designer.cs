namespace ManteHosGUI
{
    partial class FormCloseWorkOrder
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvWorkOrders;
        private System.Windows.Forms.TextBox txtIncident;
        private System.Windows.Forms.TextBox txtPartsCost;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.DateTimePicker dtpCloseDate;
        private System.Windows.Forms.Button btnCloseOrder;
        private System.Windows.Forms.Label lblIncident;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvWorkOrders = new System.Windows.Forms.DataGridView();
            this.txtIncident = new System.Windows.Forms.TextBox();
            this.txtPartsCost = new System.Windows.Forms.TextBox();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.dtpCloseDate = new System.Windows.Forms.DateTimePicker();
            this.btnCloseOrder = new System.Windows.Forms.Button();
            this.lblIncident = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkOrders
            // 
            this.dgvWorkOrders.ColumnHeadersHeight = 29;
            this.dgvWorkOrders.Location = new System.Drawing.Point(248, 115);
            this.dgvWorkOrders.Name = "dgvWorkOrders";
            this.dgvWorkOrders.RowHeadersWidth = 51;
            this.dgvWorkOrders.Size = new System.Drawing.Size(600, 150);
            this.dgvWorkOrders.TabIndex = 0;
            this.dgvWorkOrders.SelectionChanged += new System.EventHandler(this.dgvWorkOrders_SelectionChanged);
            // 
            // txtIncident
            // 
            this.txtIncident.Location = new System.Drawing.Point(347, 275);
            this.txtIncident.Name = "txtIncident";
            this.txtIncident.ReadOnly = true;
            this.txtIncident.Size = new System.Drawing.Size(501, 22);
            this.txtIncident.TabIndex = 2;
            // 
            // txtPartsCost
            // 
            this.txtPartsCost.Location = new System.Drawing.Point(347, 310);
            this.txtPartsCost.Name = "txtPartsCost";
            this.txtPartsCost.ReadOnly = true;
            this.txtPartsCost.Size = new System.Drawing.Size(116, 22);
            this.txtPartsCost.TabIndex = 4;
            // 
            // txtReport
            // 
            this.txtReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtReport.Location = new System.Drawing.Point(248, 400);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(600, 80);
            this.txtReport.TabIndex = 8;
            // 
            // dtpCloseDate
            // 
            this.dtpCloseDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpCloseDate.Location = new System.Drawing.Point(347, 345);
            this.dtpCloseDate.Name = "dtpCloseDate";
            this.dtpCloseDate.Size = new System.Drawing.Size(272, 22);
            this.dtpCloseDate.TabIndex = 6;
            // 
            // btnCloseOrder
            // 
            this.btnCloseOrder.Location = new System.Drawing.Point(522, 508);
            this.btnCloseOrder.Name = "btnCloseOrder";
            this.btnCloseOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCloseOrder.TabIndex = 9;
            this.btnCloseOrder.Text = "Cerrar orden";
            this.btnCloseOrder.Click += new System.EventHandler(this.btnCloseOrder_Click);
            // 
            // lblIncident
            // 
            this.lblIncident.Location = new System.Drawing.Point(248, 275);
            this.lblIncident.Name = "lblIncident";
            this.lblIncident.Size = new System.Drawing.Size(100, 23);
            this.lblIncident.TabIndex = 1;
            this.lblIncident.Text = "Incidencia:";
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(248, 310);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 3;
            this.lblCost.Text = "Coste piezas:";
            // 
            // lblReport
            // 
            this.lblReport.Location = new System.Drawing.Point(248, 380);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(100, 23);
            this.lblReport.TabIndex = 7;
            this.lblReport.Text = "Trabajo realizado:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(248, 345);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Fecha cierre:";
            // 
            // FormCloseWorkOrder
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1109, 569);
            this.Controls.Add(this.dgvWorkOrders);
            this.Controls.Add(this.lblIncident);
            this.Controls.Add(this.txtIncident);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtPartsCost);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpCloseDate);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.btnCloseOrder);
            this.Name = "FormCloseWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cerrar orden de trabajo";
            this.Load += new System.EventHandler(this.FormCloseWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
