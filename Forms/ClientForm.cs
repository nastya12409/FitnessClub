using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class ClientForm : Form
    {
        private readonly ClientRepository _clientRepo = new ClientRepository();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Загружаем список из базы данных PostgreSQL
                dgvClients.DataSource = _clientRepo.GetAll();

                // Переименовываем шапки колонок в таблице, чтобы они выглядели красиво
                if (dgvClients.Columns["Id"] != null) dgvClients.Columns["Id"].HeaderText = "ID";
                if (dgvClients.Columns["FirstName"] != null) dgvClients.Columns["FirstName"].HeaderText = "Ім'я";
                if (dgvClients.Columns["LastName"] != null) dgvClients.Columns["LastName"].HeaderText = "Прізвище";
                if (dgvClients.Columns["Phone"] != null) dgvClients.Columns["Phone"].HeaderText = "Телефон";
                if (dgvClients.Columns["Email"] != null) dgvClients.Columns["Email"].HeaderText = "Email";
                if (dgvClients.Columns["RegistrationDate"] != null) dgvClients.Columns["RegistrationDate"].HeaderText = "Дата реєстрації";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження клієнтів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: Добавить клиента
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та прізвище клієнта!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Создаем объект Client, упаковывая туда данные из полей ввода
                fitnessclub.Models.Client newClient = new fitnessclub.Models.Client
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RegistrationDate = DateTime.Now // Присваиваем текущую дату
                };

                // Передаем собранный объект в метод Add твоего репозитория
                _clientRepo.Add(newClient);

                MessageBox.Show("Клієнта успішно додано до бази!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем текстовые поля и обновляем таблицу на экране
                btnClear_Click(sender, e);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося додати клієнта: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: Удалить выбранного
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Если в таблице ничего не выбрано — выходим
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Оберіть клієнта у таблиці для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Достаем ID и имя клиента из выделенной строки таблицы
                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["Id"].Value);
                string clientName = dgvClients.CurrentRow.Cells["FirstName"].Value?.ToString() ?? "клієнта";

                var result = MessageBox.Show($"Ви впевнені, що хочете видалити {clientName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _clientRepo.Delete(clientId);
                    MessageBox.Show("Клієнта видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Перезагружаем таблицу
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: Обновить список
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // КНОПКА: Очистить поля ввода
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}