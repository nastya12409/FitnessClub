namespace fitnessclub
{
    partial class ClassRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblClassName = new System.Windows.Forms.Label();
            cmbClients = new System.Windows.Forms.ComboBox();
            btnRegister = new System.Windows.Forms.Button();
            dgvRegistrations = new System.Windows.Forms.DataGridView();
            btnUnregister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
            SuspendLayout();
            
             
            lblClassName.AutoSize = true;
            lblClassName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblClassName.Location = new System.Drawing.Point(23, 20);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new System.Drawing.Size(126, 32);
            lblClassName.TabIndex = 0;
            lblClassName.Text = "Заняття: ";
             
            
            cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new System.Drawing.Point(23, 75);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new System.Drawing.Size(300, 33);
            cmbClients.TabIndex = 1;
             
            
       
            btnRegister.Location = new System.Drawing.Point(340, 73);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(180, 38);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Записати на заняття";
            btnRegister.UseVisualStyleBackColor = true;
             
            
             
            dgvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrations.Location = new System.Drawing.Point(23, 135);
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.RowHeadersWidth = 62;
            dgvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRegistrations.Size = new System.Drawing.Size(500, 250);
            dgvRegistrations.TabIndex = 3;
           
          
           
            btnUnregister.Location = new System.Drawing.Point(23, 405);
            btnUnregister.Name = "btnUnregister";
            btnUnregister.Size = new System.Drawing.Size(200, 38);
            btnUnregister.TabIndex = 4;
            btnUnregister.Text = "Скасувати запис";
            btnUnregister.UseVisualStyleBackColor = true;
            
           
            
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(550, 465);
            Controls.Add(btnUnregister);
            Controls.Add(dgvRegistrations);
            Controls.Add(btnRegister);
            Controls.Add(cmbClients);
            Controls.Add(lblClassName);
            Name = "ClassRegistrationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Запис на заняття";
            Load += ClassRegistrationForm_Load; 
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView dgvRegistrations;
        private System.Windows.Forms.Button btnUnregister;
    }
}