using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class Form1 : Form
    {
        // Створюємо репозиторії для сбору статистики з бази даних
        private readonly ClientRepository _clientRepo = new ClientRepository();
        private readonly TrainerRepository _trainerRepo = new TrainerRepository();
        private readonly VisitRepository _visitRepo = new VisitRepository();

        public Form1()
        {
            InitializeComponent();
        }

        // Завантаження головної форми 
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStats();
        }

        // Метод для виводу статистики з PostgreSQL
        private void RefreshStats()
        {
            try
            {
                lblTotalClients.Text = $"Всього клієнтів: {_clientRepo.GetTotalCount()}";
                lblTotalTrainers.Text = $"Активних тренерів: {_trainerRepo.GetTotalCount()}";
                lblTodayVisits.Text = $"Візитів сьогодні: {_visitRepo.GetTodayCount()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення статистики: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Відкрити форму клієнтів
        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
            RefreshStats(); 
        }

        //Відкрити форму тренерів
        private void btnTrainers_Click(object sender, EventArgs e)
        {
            TrainerForm trainerForm = new TrainerForm();
            trainerForm.ShowDialog();
            RefreshStats();
        }

        //Відкрити форму реєстрації
        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassRegistrationForm registrationForm = new ClassRegistrationForm(1, "Загальне заняття");
            registrationForm.ShowDialog();
            RefreshStats();
        }

        // Відкрити форму відвідувань
        private void btnVisits_Click(object sender, EventArgs e)
        {
            VisitForm visitForm = new VisitForm();
            visitForm.ShowDialog();
            RefreshStats();
        }
    }
}