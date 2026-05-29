using System;
using System.Collections.Generic;
using Npgsql;
// Жестко привязываем класс подключения, чтобы у компилятора не было шансов запутаться
using DbConnection = fitnessclub.Database.DbConnection;

namespace fitnessclub
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TrainerId { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public DateTime Schedule { get; set; }
        public int MaxParticipants { get; set; }
        public int RegisteredCount { get; set; }
    }

    public class ClassRegistration
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime ClassSchedule { get; set; }
    }

    public class VisitRepository
    {
        public List<Visit> GetAll(string search = "")
        {
            var list = new List<Visit>();
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT v.id, v.client_id,
                               c.first_name || ' ' || c.last_name AS client_name,
                               v.visit_date
                        FROM visits v
                        JOIN clients c ON v.client_id = c.id
                        WHERE LOWER(c.first_name || ' ' || c.last_name) LIKE LOWER(@search)
                        ORDER BY v.visit_date DESC
                        LIMIT 500";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("search", $"%{search}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Visit
                {
                    Id = reader.GetInt32(0),
                    ClientId = reader.GetInt32(1),
                    ClientName = reader.GetString(2),
                    VisitDate = reader.GetDateTime(3)
                });
            }
            return list;
        }

        public List<Visit> GetByClient(int clientId)
        {
            var list = new List<Visit>();
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT v.id, v.client_id,
                               c.first_name || ' ' || c.last_name AS client_name,
                               v.visit_date
                        FROM visits v
                        JOIN clients c ON v.client_id = c.id
                        WHERE v.client_id = @cid
                        ORDER BY v.visit_date DESC";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", clientId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Visit
                {
                    Id = reader.GetInt32(0),
                    ClientId = reader.GetInt32(1),
                    ClientName = reader.GetString(2),
                    VisitDate = reader.GetDateTime(3)
                });
            }
            return list;
        }

        public int RegisterVisit(int clientId)
        {
            using var conn = DbConnection.GetConnection();

            var sql = "INSERT INTO visits (client_id, visit_date) VALUES (@cid, @vd) RETURNING id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", clientId);
            cmd.Parameters.AddWithValue("vd", DateTime.Now);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Delete(int id)
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("DELETE FROM visits WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public int GetTodayCount()
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM visits WHERE visit_date::date = CURRENT_DATE", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetMonthCount()
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT COUNT(*) FROM visits
                  WHERE EXTRACT(YEAR FROM visit_date) = EXTRACT(YEAR FROM CURRENT_DATE)
                    AND EXTRACT(MONTH FROM visit_date) = EXTRACT(MONTH FROM CURRENT_DATE)", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public class ClassRepository
    {
        public List<Class> GetAll(string search = "")
        {
            var list = new List<Class>();
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT cl.id, cl.name, cl.trainer_id,
                               COALESCE(t.first_name || ' ' || t.last_name, 'Не призначений') AS trainer_name,
                               cl.schedule, cl.max_participants,
                               COUNT(cr.id) AS registered_count
                        FROM classes cl
                        LEFT JOIN trainers t ON cl.trainer_id = t.id
                        LEFT JOIN class_registrations cr ON cl.id = cr.class_id
                        WHERE LOWER(cl.name) LIKE LOWER(@search)
                        GROUP BY cl.id, t.first_name, t.last_name, cl.name, cl.schedule, cl.max_participants
                        ORDER BY cl.schedule";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("search", $"%{search}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Class
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    TrainerId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                    TrainerName = reader.GetString(3),
                    Schedule = reader.GetDateTime(4),
                    MaxParticipants = reader.GetInt32(5),
                    RegisteredCount = Convert.ToInt32(reader[6])
                });
            }
            return list;
        }

        public int Add(Class c)
        {
            using var conn = DbConnection.GetConnection();

            var sql = @"INSERT INTO classes (name, trainer_id, schedule, max_participants)
                        VALUES (@nm, @tid, @sch, @mx) RETURNING id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("nm", c.Name);
            cmd.Parameters.AddWithValue("tid", (object)c.TrainerId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("sch", c.Schedule);
            cmd.Parameters.AddWithValue("mx", c.MaxParticipants);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(Class c)
        {
            using var conn = DbConnection.GetConnection();

            var sql = "UPDATE classes SET name=@nm, trainer_id=@tid, schedule=@sch, max_participants=@mx WHERE id=@id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("nm", c.Name);
            cmd.Parameters.AddWithValue("tid", (object)c.TrainerId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("sch", c.Schedule);
            cmd.Parameters.AddWithValue("mx", c.MaxParticipants);
            cmd.Parameters.AddWithValue("id", c.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("DELETE FROM classes WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public class ClassRegistrationRepository
    {
        public List<ClassRegistration> GetByClass(int classId)
        {
            var list = new List<ClassRegistration>();
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT cr.id, cr.class_id, cl.name AS class_name, cr.client_id,
                               c.first_name || ' ' || c.last_name AS client_name,
                               cl.schedule
                        FROM class_registrations cr
                        JOIN classes cl ON cr.class_id = cl.id
                        JOIN clients c ON cr.client_id = c.id
                        WHERE cr.class_id = @cid
                        ORDER BY c.last_name";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", classId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassRegistration
                {
                    Id = reader.GetInt32(0),
                    ClassId = reader.GetInt32(1),
                    ClassName = reader.GetString(2),
                    ClientId = reader.GetInt32(3),
                    ClientName = reader.GetString(4),
                    ClassSchedule = reader.GetDateTime(5)
                });
            }
            return list;
        }

        public List<ClassRegistration> GetByClient(int clientId)
        {
            var list = new List<ClassRegistration>();
            using var conn = DbConnection.GetConnection();

            var sql = @"SELECT cr.id, cr.class_id, cl.name AS class_name, cr.client_id,
                               c.first_name || ' ' || c.last_name AS client_name,
                               cl.schedule
                        FROM class_registrations cr
                        JOIN classes cl ON cr.class_id = cl.id
                        JOIN clients c ON cr.client_id = c.id
                        WHERE cr.client_id = @cid
                        ORDER BY cl.schedule";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", clientId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassRegistration
                {
                    Id = reader.GetInt32(0),
                    ClassId = reader.GetInt32(1),
                    ClassName = reader.GetString(2),
                    ClientId = reader.GetInt32(3),
                    ClientName = reader.GetString(4),
                    ClassSchedule = reader.GetDateTime(5)
                });
            }
            return list;
        }

        public bool Register(int classId, int clientId)
        {
            using var conn = DbConnection.GetConnection();

            var checkSql = @"SELECT cl.max_participants - COUNT(cr.id)
                             FROM classes cl
                             LEFT JOIN class_registrations cr ON cl.id = cr.class_id
                             WHERE cl.id = @cid
                             GROUP BY cl.max_participants";

            using var checkCmd = new NpgsqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("cid", classId);
            var freeSlots = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (freeSlots <= 0)
                throw new Exception("Немає вільних місць на заняття.");

            var sql = "INSERT INTO class_registrations (class_id, client_id) VALUES (@cid, @clid) RETURNING id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("cid", classId);
            cmd.Parameters.AddWithValue("clid", clientId);

            cmd.ExecuteScalar();
            return true;
        }

        public void Unregister(int id)
        {
            using var conn = DbConnection.GetConnection();
            using var cmd = new NpgsqlCommand("DELETE FROM class_registrations WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}