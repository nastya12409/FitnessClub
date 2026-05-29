namespace fitnessclub
{
    partial class VisitForm
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

        private void InitializeComponent()
        {
            this.lblStats = new System.Windows.Forms.Label();
            this.dgvVisits = new System.Windows.Forms.DataGridView();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.btnRegisterVisit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisits)).BeginInit();
            this.SuspendLayout();

             
            
             
            this.lblStats.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStats.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblStats.Location = new System.Drawing.Point(15, 15);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(450, 30);
            this.lblStats.TabIndex = 0;
            this.lblStats.Text = "Завантаження статистики...";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

             
            
             
            this.dgvVisits.AllowUserToAddRows = false;
            this.dgvVisits.AllowUserToDeleteRows = false;
            this.dgvVisits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisits.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisits.Location = new System.Drawing.Point(15, 60);
            this.dgvVisits.MultiSelect = false;
            this.dgvVisits.Name = "dgvVisits";
            this.dgvVisits.ReadOnly = true;
            this.dgvVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisits.Size = new System.Drawing.Size(450, 240);
            this.dgvVisits.TabIndex = 1;

             
            
             
            this.lblInput.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput.Location = new System.Drawing.Point(15, 320);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(150, 20);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Введіть ID Клієнта:";

            
           
            
            this.txtClientId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientId.Location = new System.Drawing.Point(15, 345);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(140, 23);
            this.txtClientId.TabIndex = 3;

             
            
             
            this.btnRegisterVisit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegisterVisit.Location = new System.Drawing.Point(170, 340);
            this.btnRegisterVisit.Name = "btnRegisterVisit";
            this.btnRegisterVisit.Size = new System.Drawing.Size(295, 32);
            this.btnRegisterVisit.TabIndex = 4;
            this.btnRegisterVisit.Text = "Зареєструвати прихід";
            this.btnRegisterVisit.UseVisualStyleBackColor = true;
            this.btnRegisterVisit.Click += new System.EventHandler(this.btnRegisterVisit_Click);

             
            
             
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 401);
            this.Controls.Add(this.btnRegisterVisit);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.dgvVisits);
            this.Controls.Add(this.lblStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VisitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Облік відвідувань залу";
            this.Load += new System.EventHandler(this.VisitForm_Load); 
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.DataGridView dgvVisits;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Button btnRegisterVisit;
    }
}