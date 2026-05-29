namespace fitnessclub
{
    partial class Form1
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTotalTrainers = new Label();
            lblTodayVisits = new Label();
            lblTotalClients = new Label();
            btnClients = new Button();
            btnTrainers = new Button();
            btnClasses = new Button();
            btnVisits = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(lblTotalTrainers);
            panelHeader.Controls.Add(lblTodayVisits);
            panelHeader.Controls.Add(lblTotalClients);
            panelHeader.Location = new Point(22, 119);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(427, 231);
            panelHeader.TabIndex = 0;
            // 
            // lblTotalTrainers
            // 
            lblTotalTrainers.AutoSize = true;
            lblTotalTrainers.Location = new Point(25, 173);
            lblTotalTrainers.Name = "lblTotalTrainers";
            lblTotalTrainers.Size = new Size(168, 25);
            lblTotalTrainers.TabIndex = 2;
            lblTotalTrainers.Text = "Активних тренерів:";
            // 
            // lblTodayVisits
            // 
            lblTodayVisits.AutoSize = true;
            lblTodayVisits.Location = new Point(25, 101);
            lblTodayVisits.Name = "lblTodayVisits";
            lblTodayVisits.Size = new Size(144, 25);
            lblTodayVisits.TabIndex = 1;
            lblTodayVisits.Text = "Візитів сьогодні:";
            // 
            // lblTotalClients
            // 
            lblTotalClients.AutoSize = true;
            lblTotalClients.Location = new Point(25, 29);
            lblTotalClients.Name = "lblTotalClients";
            lblTotalClients.Size = new Size(138, 25);
            lblTotalClients.TabIndex = 0;
            lblTotalClients.Text = "Всього клієнтів:";
            // 
            // btnClients
            // 
            btnClients.Location = new Point(477, 166);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(168, 34);
            btnClients.TabIndex = 1;
            btnClients.Text = "👥 Клієнти клубу";
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnTrainers
            // 
            btnTrainers.Location = new Point(477, 66);
            btnTrainers.Name = "btnTrainers";
            btnTrainers.Size = new Size(252, 34);
            btnTrainers.TabIndex = 2;
            btnTrainers.Text = "💪 Тренери та спеціалізація";
            btnTrainers.UseVisualStyleBackColor = true;
            btnTrainers.Click += btnTrainers_Click;
            // 
            // btnClasses
            // 
            btnClasses.Location = new Point(477, 395);
            btnClasses.Name = "btnClasses";
            btnClasses.Size = new Size(180, 34);
            btnClasses.TabIndex = 3;
            btnClasses.Text = "📅 Розклад занять";
            btnClasses.UseVisualStyleBackColor = true;
            btnClasses.Click += btnClasses_Click;
            // 
            // btnVisits
            // 
            btnVisits.Location = new Point(477, 283);
            btnVisits.Name = "btnVisits";
            btnVisits.Size = new Size(196, 34);
            btnVisits.TabIndex = 4;
            btnVisits.Text = "🔑 Реєстрація візитів";
            btnVisits.UseVisualStyleBackColor = true;
            btnVisits.Click += btnVisits_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 494);
            Controls.Add(btnVisits);
            Controls.Add(btnClasses);
            Controls.Add(btnTrainers);
            Controls.Add(btnClients);
            Controls.Add(panelHeader);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Фітнес-клуб \"Титан\" - панель управління";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label lblTotalTrainers;
        private System.Windows.Forms.Label lblTodayVisits;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnVisits;
    }
}