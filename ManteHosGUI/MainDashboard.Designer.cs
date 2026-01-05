namespace ManteHosGUI
{
    partial class MainDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnReportIncident = new System.Windows.Forms.Button();
            this.btnReviewIncidents = new System.Windows.Forms.Button();
            this.btnAssignWorkOrders = new System.Windows.Forms.Button();
            this.btnCloseWorkOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Navy;
            this.lblWelcome.Location = new System.Drawing.Point(740, 93);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(196, 39);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bienvenido";
            // 
            // btnReportIncident
            // 
            this.btnReportIncident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReportIncident.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportIncident.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportIncident.ForeColor = System.Drawing.Color.White;
            this.btnReportIncident.Location = new System.Drawing.Point(738, 209);
            this.btnReportIncident.Name = "btnReportIncident";
            this.btnReportIncident.Size = new System.Drawing.Size(244, 63);
            this.btnReportIncident.TabIndex = 1;
            this.btnReportIncident.Text = "Reportar Incidente";
            this.btnReportIncident.UseVisualStyleBackColor = false;
            this.btnReportIncident.Click += new System.EventHandler(this.btnReportIncident_Click);
            // 
            // btnReviewIncidents
            // 
            this.btnReviewIncidents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReviewIncidents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReviewIncidents.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewIncidents.ForeColor = System.Drawing.Color.White;
            this.btnReviewIncidents.Location = new System.Drawing.Point(738, 278);
            this.btnReviewIncidents.Name = "btnReviewIncidents";
            this.btnReviewIncidents.Size = new System.Drawing.Size(244, 63);
            this.btnReviewIncidents.TabIndex = 2;
            this.btnReviewIncidents.Text = "Revisar Incidentes";
            this.btnReviewIncidents.UseVisualStyleBackColor = false;
            this.btnReviewIncidents.Click += new System.EventHandler(this.btnReviewIncidents_Click);
            // 
            // btnAssignWorkOrders
            // 
            this.btnAssignWorkOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAssignWorkOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignWorkOrders.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignWorkOrders.ForeColor = System.Drawing.Color.White;
            this.btnAssignWorkOrders.Location = new System.Drawing.Point(738, 347);
            this.btnAssignWorkOrders.Name = "btnAssignWorkOrders";
            this.btnAssignWorkOrders.Size = new System.Drawing.Size(244, 63);
            this.btnAssignWorkOrders.TabIndex = 3;
            this.btnAssignWorkOrders.Text = "Asignar Órdenes";
            this.btnAssignWorkOrders.UseVisualStyleBackColor = false;
            this.btnAssignWorkOrders.Click += new System.EventHandler(this.btnAssignWorkOrders_Click);
            // 
            // btnCloseWorkOrders
            // 
            this.btnCloseWorkOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCloseWorkOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseWorkOrders.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseWorkOrders.ForeColor = System.Drawing.Color.White;
            this.btnCloseWorkOrders.Location = new System.Drawing.Point(738, 416);
            this.btnCloseWorkOrders.Name = "btnCloseWorkOrders";
            this.btnCloseWorkOrders.Size = new System.Drawing.Size(244, 63);
            this.btnCloseWorkOrders.TabIndex = 4;
            this.btnCloseWorkOrders.Text = "Cerrar Órdenes";
            this.btnCloseWorkOrders.UseVisualStyleBackColor = false;
            this.btnCloseWorkOrders.Click += new System.EventHandler(this.btnCloseWorkOrders_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(12, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(56, 56);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.TabStop = false;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(671, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "¿Qué servicio podemos ofrecerte hoy?";
            // 
            // MainDashboard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCloseWorkOrders);
            this.Controls.Add(this.btnAssignWorkOrders);
            this.Controls.Add(this.btnReviewIncidents);
            this.Controls.Add(this.btnReportIncident);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main Dashboard";
            this.Load += new System.EventHandler(this.MainDashboard_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // 2. Declaraciones de Variables
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnReportIncident;
        private System.Windows.Forms.Button btnReviewIncidents;
        private System.Windows.Forms.Button btnAssignWorkOrders;
        private System.Windows.Forms.Button btnCloseWorkOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
    }
}