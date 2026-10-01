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
            dgvTrainers = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            txtSpecialization = new TextBox();
            label4 = new Label();
            txtLastName = new TextBox();
            btnAdd = new Button();
            label3 = new Label();
            txtFirstName = new TextBox();
            label2 = new Label();
            btnDelete = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrainers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTrainers
            // 
            dgvTrainers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvTrainers.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvTrainers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainers.Location = new Point(12, 61);
            dgvTrainers.Name = "dgvTrainers";
            dgvTrainers.ReadOnly = true;
            dgvTrainers.RowHeadersWidth = 62;
            dgvTrainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainers.Size = new Size(442, 337);
            dgvTrainers.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 1;
            label1.Text = "Пошук за прізвищем:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(230, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = SystemColors.MenuBar;
            btnSearch.Location = new Point(398, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Знайти";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(txtSpecialization);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(460, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 260);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Дані тренера";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = SystemColors.MenuBar;
            btnClear.Location = new Point(121, 215);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(189, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистити форму";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtSpecialization
            // 
            txtSpecialization.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSpecialization.Location = new Point(160, 120);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(150, 31);
            txtSpecialization.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(22, 120);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 4;
            label4.Text = "Спеціалізація";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLastName.Location = new Point(160, 77);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = SystemColors.MenuBar;
            btnAdd.Location = new Point(6, 175);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Додати тренера";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(22, 77);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 2;
            label3.Text = "Прізвище";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFirstName.Location = new Point(160, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(22, 32);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 0;
            label2.Text = "Ім'я";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = SystemColors.MenuBar;
            btnDelete.Location = new Point(12, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(189, 34);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Видалити вибраного";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = SystemColors.MenuBar;
            btnRefresh.Location = new Point(271, 404);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(189, 34);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Оновити список";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // TrainerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(groupBox1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvTrainers);
            Name = "TrainerForm";
            StartPosition = FormStartPosition.CenterScreen;
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