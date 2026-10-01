using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class VisitForm : Form
    {
        private readonly VisitRepository _visitRepo = new VisitRepository();

        public VisitForm()
        {
            InitializeComponent();
        }

        private void VisitForm_Load(object sender, EventArgs e)
        {
            LoadVisits();
            UpdateStats();
        }

        //Метод завантаження відвідування
        private void LoadVisits()
        {
            try
            {
                dgvVisits.DataSource = _visitRepo.GetAll();


                if (dgvVisits.Columns["ClientId"] != null) dgvVisits.Columns["ClientId"].Visible = false;


                if (dgvVisits.Columns["Id"] != null) dgvVisits.Columns["Id"].HeaderText = "ID Візиту";
                if (dgvVisits.Columns["ClientName"] != null) dgvVisits.Columns["ClientName"].HeaderText = "ПІБ Клієнта";
                if (dgvVisits.Columns["VisitDate"] != null) dgvVisits.Columns["VisitDate"].HeaderText = "Дата та час";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження історії: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateStats()
        {
            try
            {
                int todayCount = _visitRepo.GetTodayCount();
                int monthCount = _visitRepo.GetMonthCount();

                lblStats.Text = $"Сьогодні відвідало: {todayCount} чол.  |  За поточний місяць: {monthCount}";
            }
            catch (Exception ex)
            {
                lblStats.Text = "Статистика тимчасово недоступна";
            }
        }


        private void btnRegisterVisit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtClientId.Text) || !int.TryParse(txtClientId.Text, out int clientId))
            {
                MessageBox.Show("Будь ласка, введіть коректний числовий ID клієнта!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                _visitRepo.RegisterVisit(clientId);

                MessageBox.Show("Візит успішно зареєстровано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtClientId.Clear();


                LoadVisits();
                UpdateStats();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Не вдалося зареєструвати візит. Перевірте, чи існує клієнт з ID = {clientId}.\nТехнічна помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVisits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}