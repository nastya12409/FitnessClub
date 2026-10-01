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
            lblStats = new Label();
            dgvVisits = new DataGridView();
            lblInput = new Label();
            txtClientId = new TextBox();
            btnRegisterVisit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).BeginInit();
            SuspendLayout();
            
            lblStats.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblStats.ForeColor = Color.MidnightBlue;
            lblStats.Location = new Point(25, 29);
            lblStats.Margin = new Padding(5, 0, 5, 0);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(750, 58);
            lblStats.TabIndex = 0;
            lblStats.Text = "Завантаження статистики...";
            lblStats.TextAlign = ContentAlignment.MiddleLeft;
            
            dgvVisits.AllowUserToAddRows = false;
            dgvVisits.AllowUserToDeleteRows = false;
            dgvVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisits.BackgroundColor = SystemColors.InactiveBorder;
            dgvVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisits.Location = new Point(25, 115);
            dgvVisits.Margin = new Padding(5, 6, 5, 6);
            dgvVisits.MultiSelect = false;
            dgvVisits.Name = "dgvVisits";
            dgvVisits.ReadOnly = true;
            dgvVisits.RowHeadersWidth = 62;
            dgvVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisits.Size = new Size(750, 462);
            dgvVisits.TabIndex = 1;
            dgvVisits.CellContentClick += dgvVisits_CellContentClick;
            
            lblInput.Font = new Font("Arial", 9F);
            lblInput.Location = new Point(206, 610);
            lblInput.Margin = new Padding(5, 0, 5, 0);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(250, 38);
            lblInput.TabIndex = 2;
            lblInput.Text = "Введіть ID Клієнта:";
           
            txtClientId.Font = new Font("Arial", 10F);
            txtClientId.Location = new Point(440, 610);
            txtClientId.Margin = new Padding(5, 6, 5, 6);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(172, 30);
            txtClientId.TabIndex = 3;
            
            btnRegisterVisit.BackColor = SystemColors.ActiveBorder;
            btnRegisterVisit.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnRegisterVisit.Location = new Point(156, 682);
            btnRegisterVisit.Margin = new Padding(5, 6, 5, 6);
            btnRegisterVisit.Name = "btnRegisterVisit";
            btnRegisterVisit.Size = new Size(492, 62);
            btnRegisterVisit.TabIndex = 4;
            btnRegisterVisit.Text = "Зареєструвати прихід";
            btnRegisterVisit.UseVisualStyleBackColor = false;
            btnRegisterVisit.Click += btnRegisterVisit_Click;
            
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 771);
            Controls.Add(btnRegisterVisit);
            Controls.Add(txtClientId);
            Controls.Add(lblInput);
            Controls.Add(dgvVisits);
            Controls.Add(lblStats);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "VisitForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Облік відвідувань залу";
            Load += VisitForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVisits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.DataGridView dgvVisits;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Button btnRegisterVisit;
    }
}