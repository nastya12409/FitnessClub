using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class ClassRegistrationForm : Form
    {
        //Підключення репозиторій
        private readonly ClassRegistrationRepository _registrationRepo;
        private readonly ClassRepository _clientRepo;
        private readonly int _classId;
        
        //Конструктор
        public ClassRegistrationForm(int classId, string className)
        {
            InitializeComponent();
            //Об'єкти для роботи з базою даних
            _registrationRepo = new ClassRegistrationRepository();
            _clientRepo = new ClassRepository();
            _classId = classId;
            //Виводимо назву заняття вгорі віконця
            lblClassName.Text = $"Заняття: {className}";

            //Прив'язуємо кліки до кнопок
            btnRegister.Click += btnRegister_Click;
            btnUnregister.Click += btnUnregister_Click;
        }

        //Спрацювання події, коли форма завантажилась вже на екрані
        private void ClassRegistrationForm_Load(object sender, EventArgs e)
        {
            LoadClients();
            LoadRegistrations();
        }
        //Метод для заповнення списку клієнтів
        private void LoadClients()
        {
            try
            {
                //дістаємо всіх наших клієнтів
                var clients = _clientRepo.GetAll();
                cmbClients.DataSource = clients;

                //спочатку шукаємо прізвище, або ж ім'я
                cmbClients.DisplayMember = "LastName";
                if (string.IsNullOrEmpty(cmbClients.DisplayMember)) cmbClients.DisplayMember = "Name";
                //працюємо з id
                cmbClients.ValueMember = "Id";
                cmbClients.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження клієнтів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRegistrations()
        {
            try
            {
                //Обираємо тих людей, хто записан на це заняття
                dgvRegistrations.DataSource = _registrationRepo.GetByClass(_classId);
                //Робимо заголовки колонок
                if (dgvRegistrations.Columns["Id"] != null) dgvRegistrations.Columns["Id"].HeaderText = "ID Запису";
                if (dgvRegistrations.Columns["ClientName"] != null) dgvRegistrations.Columns["ClientName"].HeaderText = "ПІБ Клієнта";
                //Ховаємо id
                if (dgvRegistrations.Columns["ClassId"] != null) dgvRegistrations.Columns["ClassId"].Visible = false;
                if (dgvRegistrations.Columns["ClassName"] != null) dgvRegistrations.Columns["ClassName"].Visible = false;
                if (dgvRegistrations.Columns["ClientId"] != null) dgvRegistrations.Columns["ClientId"].Visible = false;
                if (dgvRegistrations.Columns["ClassSchedule"] != null) dgvRegistrations.Columns["ClassSchedule"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Кнопка - записати клієнта
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedValue == null)
            {
                MessageBox.Show("Оберіть клієнта зі списку перед записом!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int clientId = (int)cmbClients.SelectedValue;
                _registrationRepo.Register(_classId, clientId);

                MessageBox.Show("Клієнта успішно записано на заняття!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbClients.SelectedIndex = -1;

                LoadRegistrations();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23505") || ex.InnerException?.Message.Contains("23505") == true)
                {
                    MessageBox.Show("Цей клієнт вже записаний на дане заняття!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Не вдалося виконати запис: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Кнопка видалити запис
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null)
            {
                MessageBox.Show("Оберіть запис у таблиці для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int registrationId = Convert.ToInt32(dgvRegistrations.CurrentRow.Cells["Id"].Value);

                var result = MessageBox.Show("Ви впевнені, що хочете скасувати цей запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _registrationRepo.Unregister(registrationId);
                    MessageBox.Show("Запис скасовано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegistrations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при скасуванні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}