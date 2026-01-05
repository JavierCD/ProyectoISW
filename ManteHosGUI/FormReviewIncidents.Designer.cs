namespace ManteHosGUI
{
    partial class FormReviewIncidents
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
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.gbAccept = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.gbReject = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblIncidentInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.gbAccept.SuspendLayout();
            this.gbReject.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.AllowUserToAddRows = false;
            this.dgvIncidents.AllowUserToDeleteRows = false;
            this.dgvIncidents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.Location = new System.Drawing.Point(27, 25);
            this.dgvIncidents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvIncidents.MultiSelect = false;
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.ReadOnly = true;
            this.dgvIncidents.RowHeadersWidth = 51;
            this.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidents.Size = new System.Drawing.Size(600, 615);
            this.dgvIncidents.TabIndex = 0;
            this.dgvIncidents.SelectionChanged += new System.EventHandler(this.dgvIncidents_SelectionChanged);
            // 
            // gbAccept
            // 
            this.gbAccept.Controls.Add(this.btnAccept);
            this.gbAccept.Controls.Add(this.cmbPriority);
            this.gbAccept.Controls.Add(this.lblPriority);
            this.gbAccept.Controls.Add(this.cmbArea);
            this.gbAccept.Controls.Add(this.lblArea);
            this.gbAccept.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.gbAccept.ForeColor = System.Drawing.Color.Navy;
            this.gbAccept.Location = new System.Drawing.Point(653, 228);
            this.gbAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAccept.Name = "gbAccept";
            this.gbAccept.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAccept.Size = new System.Drawing.Size(507, 222);
            this.gbAccept.TabIndex = 2;
            this.gbAccept.TabStop = false;
            this.gbAccept.Text = "Aceptar Incidencia";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Navy;
            this.btnAccept.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(307, 178);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 28);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Bold);
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(20, 142);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(160, 29);
            this.cmbPriority.TabIndex = 3;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriority.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPriority.Location = new System.Drawing.Point(20, 111);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(79, 21);
            this.lblPriority.TabIndex = 2;
            this.lblPriority.Text = "Prioridad:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Bold);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(20, 68);
            this.cmbArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(160, 29);
            this.cmbArea.TabIndex = 1;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblArea.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblArea.Location = new System.Drawing.Point(20, 37);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(116, 21);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Asignar a Área:";
            // 
            // gbReject
            // 
            this.gbReject.Controls.Add(this.btnReject);
            this.gbReject.Controls.Add(this.txtReason);
            this.gbReject.Controls.Add(this.lblReason);
            this.gbReject.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.gbReject.ForeColor = System.Drawing.Color.Navy;
            this.gbReject.Location = new System.Drawing.Point(653, 468);
            this.gbReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbReject.Name = "gbReject";
            this.gbReject.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbReject.Size = new System.Drawing.Size(507, 172);
            this.gbReject.TabIndex = 3;
            this.gbReject.TabStop = false;
            this.gbReject.Text = "Rechazar Incidencia";
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(307, 135);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 28);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Rechazar";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Bold);
            this.txtReason.Location = new System.Drawing.Point(20, 68);
            this.txtReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(452, 61);
            this.txtReason.TabIndex = 1;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblReason.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReason.Location = new System.Drawing.Point(20, 37);
            this.lblReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(143, 21);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Razón de Rechazo:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(27, 658);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 37);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblIncidentInfo);
            this.gbDetails.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.gbDetails.ForeColor = System.Drawing.Color.Navy;
            this.gbDetails.Location = new System.Drawing.Point(653, 25);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetails.Size = new System.Drawing.Size(507, 185);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Detalles de Incidencia";
            // 
            // lblIncidentInfo
            // 
            this.lblIncidentInfo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblIncidentInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIncidentInfo.Location = new System.Drawing.Point(20, 31);
            this.lblIncidentInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncidentInfo.Name = "lblIncidentInfo";
            this.lblIncidentInfo.Size = new System.Drawing.Size(467, 135);
            this.lblIncidentInfo.TabIndex = 0;
            this.lblIncidentInfo.Text = "Seleccione una incidencia";
            // 
            // FormReviewIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 705);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gbReject);
            this.Controls.Add(this.gbAccept);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.dgvIncidents);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormReviewIncidents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReviewIncidents";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.gbAccept.ResumeLayout(false);
            this.gbAccept.PerformLayout();
            this.gbReject.ResumeLayout(false);
            this.gbReject.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidents;
        private System.Windows.Forms.GroupBox gbAccept;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.GroupBox gbReject;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lblIncidentInfo;
    }
}