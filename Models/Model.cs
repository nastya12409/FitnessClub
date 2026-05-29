using System;

namespace fitnessclub.Models 
{
    //Модель клієнта
    public class Client 
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string Name => $"{LastName} {FirstName}".Trim();
    }

    //Модель тренера
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty;
        public string Name => $"{LastName} {FirstName}".Trim();
    }

    //Модель абономента
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public int DurationDays { get; set; }           
    }

    //Модель абонемента, який купили
    public class ClientMembership
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MembershipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }

    //Модель тренувань
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? TrainerId { get; set; }
        public DateTime VisitDate { get; set; }
        public string ClassType { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
    }
}