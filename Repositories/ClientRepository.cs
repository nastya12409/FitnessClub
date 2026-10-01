using fitnessclub.Database; 
using fitnessclub.Models;   
using Npgsql;
using System;
using System.Collections.Generic;

namespace fitnessclub
{
    public class ClientRepository
    {
        public List<Client> GetAll(string search = "")
        {
            var clients = new List<Client>();
            // Викликаємо DbConnection
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT id, first_name, last_name, phone, email, registration_date
                        FROM clients
                        WHERE LOWER(first_name || ' ' || last_name) LIKE LOWER(@search)
                        ORDER BY last_name, first_name";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("search", $"%{search}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    RegistrationDate = reader.GetDateTime(5)
                });
            }
            return clients;
        }

        public Client GetById(int id)
        {
            using var conn = DbConnection.GetConnection();

            var sql = "SELECT id, first_name, last_name, phone, email, registration_date FROM clients WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Client
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    RegistrationDate = reader.GetDateTime(5)
                };
            }
            return null;
        }

        public int Add(Client client)
        {
            using var conn = DbConnection.GetConnection();

            var sql = @"INSERT INTO clients (first_name, last_name, phone, email, registration_date)
                        VALUES (@fn, @ln, @ph, @em, @rd) RETURNING id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("fn", client.FirstName);
            cmd.Parameters.AddWithValue("ln", client.LastName);
            cmd.Parameters.AddWithValue("ph", (object)client.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("em", (object)client.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("rd", client.RegistrationDate.Date);

            return Convert.ToInt32(cmd.ExecuteScalar()); // Безопасное приведение типа для PostgreSQL
        }

        public void Update(Client client)
        {
            using var conn = DbConnection.GetConnection();

            var sql = @"UPDATE clients SET first_name=@fn, last_name=@ln, phone=@ph, email=@em
                        WHERE id=@id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("fn", client.FirstName);
            cmd.Parameters.AddWithValue("ln", client.LastName);
            cmd.Parameters.AddWithValue("ph", (object)client.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("em", (object)client.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id", client.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = DbConnection.GetConnection();

            using var cmd = new NpgsqlCommand("DELETE FROM clients WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public int GetTotalCount()
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM clients", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}