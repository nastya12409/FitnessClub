namespace fitnessclub 
{
    partial class ClientForm
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
            dgvClients = new DataGridView();
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtLastName = new TextBox();
            label2 = new Label();
            txtFirstName = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
          

            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(416, 37);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 62;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(360, 272);
            dgvClients.TabIndex = 0;
            

            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 284);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Дані клієнта";
            

            txtEmail.Location = new Point(131, 171);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 6;
            

            txtPhone.Location = new Point(131, 128);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 5;
            

            label4.AutoSize = true;
            label4.Location = new Point(24, 174);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 2;
            label4.Text = "Email";
            

            label3.AutoSize = true;
            label3.Location = new Point(24, 131);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 4;
            label3.Text = "Телефон";
            

            txtLastName.Location = new Point(131, 80);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 3;
            

            label2.AutoSize = true;
            label2.Location = new Point(24, 86);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 2;
            label2.Text = "Прізвище";
            

            txtFirstName.Location = new Point(131, 35);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 1;
            

            label1.AutoSize = true;
            label1.Location = new Point(24, 38);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 0;
            label1.Text = "Ім'я";
           

            btnAdd.Location = new Point(241, 386);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(153, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Додати клієнта";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            

            btnDelete.Location = new Point(12, 386);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(189, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити вибраного";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            

            btnRefresh.Location = new Point(433, 386);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(172, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Обновити список";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            

            btnClear.Location = new Point(623, 386);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(153, 34);
            btnClear.TabIndex = 5;
            btnClear.Text = "Очистити форму";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(dgvClients);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управління клієнтами";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
    }
}