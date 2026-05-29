using System;
using System.Windows.Forms;

namespace fitnessclub
{
    public partial class Form1 : Form
    {
        // Создаем репозитории для сбора статистики с базы данных
        private readonly ClientRepository _clientRepo = new ClientRepository();
        private readonly TrainerRepository _trainerRepo = new TrainerRepository();
        private readonly VisitRepository _visitRepo = new VisitRepository();

        public Form1()
        {
            InitializeComponent();
        }

        // Событие загрузки главной формы — сразу обновляем цифры на панели
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStats();
        }

        // Метод для вывода актуальной статистики из PostgreSQL
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

        // КНОПКА: Открыть форму клиентов
        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
            RefreshStats(); // Пересчитываем статистику после закрытия окна
        }

        // КНОПКА: Открыть форму тренеров
        private void btnTrainers_Click(object sender, EventArgs e)
        {
            TrainerForm trainerForm = new TrainerForm();
            trainerForm.ShowDialog();
            RefreshStats();
        }

        // КНОПКА: Открыть форму регистрации на занятия
        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassRegistrationForm registrationForm = new ClassRegistrationForm(1, "Загальне заняття");
            registrationForm.ShowDialog();
            RefreshStats();
        }

        // КНОПКА: Открыть форму визитов
        private void btnVisits_Click(object sender, EventArgs e)
        {
            VisitForm visitForm = new VisitForm();
            visitForm.ShowDialog();
            RefreshStats();
        }
    }
}