namespace fitnessclub 
{
    partial class TrainerForm
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
            dgvTrainers = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtSpecialization = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            btnAdd = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            

            dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainers.Location = new System.Drawing.Point(12, 61);
            dgvTrainers.Name = "dgvTrainers";
            dgvTrainers.ReadOnly = true;
            dgvTrainers.RowHeadersWidth = 62;
            dgvTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTrainers.Size = new System.Drawing.Size(420, 300);
            dgvTrainers.TabIndex = 0;
            

            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 1;
            label1.Text = "Пошук за прізвищем:";
           

            txtSearch.Location = new Point(230, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 2;
            

            btnSearch.Location = new Point(398, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Знайти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click; 
            

            groupBox1.Controls.Add(txtSpecialization);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(460, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 188);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Дані тренера";
            

            label2.AutoSize = true;
            label2.Location = new Point(22, 32);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 0;
            label2.Text = "Ім'я";
            

            txtFirstName.Location = new Point(160, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 1;
           

            label3.AutoSize = true;
            label3.Location = new Point(22, 77);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 2;
            label3.Text = "Прізвище";
            

            txtLastName.Location = new Point(160, 77);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 3;
            

            label4.AutoSize = true;
            label4.Location = new Point(22, 120);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 4;
            label4.Text = "Спеціалізація";
            

            txtSpecialization.Location = new Point(160, 120);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(150, 31);
            txtSpecialization.TabIndex = 5;
            

            btnAdd.Location = new Point(12, 381);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Додати тренера";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click; 
            

            btnDelete.Location = new Point(188, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(189, 34);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Видалити вибраного";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click; 
            

            btnRefresh.Location = new Point(398, 381);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(189, 34);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Оновити список";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click; 
            

            btnClear.Location = new Point(599, 381);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(189, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистити форму";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click; 
            

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvTrainers);
            Name = "TrainerForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Управління тренерами";
            Load += TrainerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
    }
}