using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class ClientForm : Form
    {
        // Репозиторій для роботи з даними клієнтів 
        private readonly ClientRepository _clientRepo = new ClientRepository();

        public ClientForm()
        {
            InitializeComponent();
        }

        // Подія завантаження форми
        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// Завантажує дані клієнтів із репозиторію та відображає їх у таблиці
        private void LoadData()
        {
            try
            {
                // Прив'язуємо список клієнтів як джерело даних 
                dgvClients.DataSource = _clientRepo.GetAll();

                // Перейменовуємо шапки колонок 
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

        // Додати клієнта
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Перевіряємо заповнення обов'язкових полів 
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та прізвище клієнта!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Створюємо об'єкт Client, пакуючи туди дані з полів введення
                fitnessclub.Models.Client newClient = new fitnessclub.Models.Client
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RegistrationDate = DateTime.Now 
                };

                // Передаємо зібраний об'єкт у метод Add 
                _clientRepo.Add(newClient);

                MessageBox.Show("Клієнта успішно додано до бази!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаємо текстові поля та оновлюємо таблицю на екрані
                btnClear_Click(sender, e);
                LoadData();
            }
            catch (Exception ex)
            {
                // Обробка помилок, якщо не вдалося зберегти дані в базу
                MessageBox.Show($"Не вдалося додати клієнта: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Видалити обраного клієнта
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Якщо в таблиці нічого не вибрано — виходимо з методу
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Оберіть клієнта у таблиці для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Дістаємо ID та ім'я клієнта з виділеного рядка таблиці
                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["Id"].Value);
                string clientName = dgvClients.CurrentRow.Cells["FirstName"].Value?.ToString() ?? "клієнта";

                // Запитуємо підтвердження видалення у користувача
                var result = MessageBox.Show($"Ви впевнені, що хочете видалити {clientName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Видаляємо через репозиторій за ID
                    _clientRepo.Delete(clientId);
                    MessageBox.Show("Клієнта видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Перезавантажуємо таблицю, щоб оновити список
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
            LoadData();
        }

        //Очистити поля введення
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        // Порожній обробник події кліку на label1
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}