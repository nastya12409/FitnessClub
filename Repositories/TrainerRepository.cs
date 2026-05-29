using System;
using System.Collections.Generic;
using Npgsql;
using fitnessclub.Models; // ИСПРАВЛЕНО: правильный namespace для моделей
// Жесткий алиас на подключение к базе данных, чтобы С# точно его нашел
using DbConnection = fitnessclub.Database.DbConnection;

namespace fitnessclub
{
    public class TrainerRepository
    {
        public List<Trainer> GetAll(string search = "")
        {
            var trainers = new List<Trainer>();
            // ИСПРАВЛЕНО: используем правильный DbConnection
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT id, first_name, last_name, specialization FROM trainers
                        WHERE LOWER(first_name || ' ' || last_name) LIKE LOWER(@search)
                        ORDER BY last_name, first_name";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("search", $"%{search}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                trainers.Add(new Trainer
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Specialization = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }
            return trainers;
        }

        public int Add(Trainer trainer)
        {
            using var conn = DbConnection.GetConnection();

            var sql = @"INSERT INTO trainers (first_name, last_name, specialization)
                        VALUES (@fn, @ln, @sp) RETURNING id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("fn", trainer.FirstName);
            cmd.Parameters.AddWithValue("ln", trainer.LastName);
            cmd.Parameters.AddWithValue("sp", string.IsNullOrEmpty(trainer.Specialization) ? DBNull.Value : (object)trainer.Specialization);

            return Convert.ToInt32(cmd.ExecuteScalar()); // Безопасное приведение для Postgres
        }

        public void Update(Trainer trainer)
        {
            using var conn = DbConnection.GetConnection();

            var sql = "UPDATE trainers SET first_name=@fn, last_name=@ln, specialization=@sp WHERE id=@id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("fn", trainer.FirstName);
            cmd.Parameters.AddWithValue("ln", trainer.LastName);
            cmd.Parameters.AddWithValue("sp", string.IsNullOrEmpty(trainer.Specialization) ? DBNull.Value : (object)trainer.Specialization);
            cmd.Parameters.AddWithValue("id", trainer.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("DELETE FROM trainers WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public int GetTotalCount()
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM trainers", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}