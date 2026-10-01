using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class TrainerForm : Form
    {
        private readonly TrainerRepository _trainerRepo = new TrainerRepository();

        public TrainerForm()
        {
            InitializeComponent();
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Завантаження даних
        private void LoadData(string searchKeyword = "")
        {
            try
            {
                // Передаємо рядок пошуку
                dgvTrainers.DataSource = _trainerRepo.GetAll(searchKeyword);

                if (dgvTrainers.Columns["Id"] != null) dgvTrainers.Columns["Id"].HeaderText = "ID";
                if (dgvTrainers.Columns["FirstName"] != null) dgvTrainers.Columns["FirstName"].HeaderText = "Ім'я";
                if (dgvTrainers.Columns["LastName"] != null) dgvTrainers.Columns["LastName"].HeaderText = "Прізвище";
                if (dgvTrainers.Columns["Specialization"] != null) dgvTrainers.Columns["Specialization"].HeaderText = "Спеціалізація";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження тренерів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Пошук за прізвищем
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadData(keyword); 
        }

        // Додати тренера 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та прізвище тренера!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Збираємо об'єкт Trainer з полей ввода
                fitnessclub.Models.Trainer newTrainer = new fitnessclub.Models.Trainer
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim()
                };

                // Відправляємо в базу
                _trainerRepo.Add(newTrainer);

                MessageBox.Show("Тренера успішно додано до бази!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

               //Обновлюємо список
                btnClear_Click(sender, e);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося додати тренера: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Видалити тренера 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.CurrentRow == null)
            {
                MessageBox.Show("Оберіть тренера у таблиці для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int trainerId = Convert.ToInt32(dgvTrainers.CurrentRow.Cells["Id"].Value);
                string trainerName = dgvTrainers.CurrentRow.Cells["FirstName"].Value?.ToString() ?? "тренера";

                var result = MessageBox.Show($"Ви впевнені, що хочете видалити {trainerName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _trainerRepo.Delete(trainerId);
                    MessageBox.Show("Тренера видалено з бази.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Оновити список
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); 
            LoadData();
        }

        //Очистити форму
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSpecialization.Clear();
            txtSearch.Clear();
        }
    }
}