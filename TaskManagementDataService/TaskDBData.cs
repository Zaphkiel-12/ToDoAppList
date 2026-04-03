using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskDBData : ITaskDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=dbTaskMgmt;Integrated Security=True;TrustServerCertificate=True;";
        
        private SqlConnection connection;
        public TaskDBData()
        {
            connection = new SqlConnection(connectionString);
        }
        public void Add(Tasks task)
        {
            var insert = "INSERT INTO Tasks (Task, Date, Time, Status) VALUES (@Task, @Date, @Time, @Status)";

            SqlCommand cmd = new SqlCommand(insert, connection);

            cmd.Parameters.AddWithValue("@Task", task.Task);
            cmd.Parameters.AddWithValue("@Date", task.Date);
            cmd.Parameters.AddWithValue("@Time", task.Time);
            cmd.Parameters.AddWithValue("@Status", task.Status);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Tasks> GetAll()
        {
            List<Tasks> tasks = new List<Tasks>();
            var select = "SELECT * FROM Tasks";
            SqlCommand cmd = new SqlCommand(select, connection);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tasks task = new Tasks
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Task = reader["Task"].ToString(),
                    Date = reader["Date"].ToString(),
                    Time = reader["Time"].ToString(),
                    Status = reader["Status"].ToString()
                };
                tasks.Add(task);
            }

            connection.Close();

            return tasks;
        }

        public void Delete(int Id)
        {
            var delete = $"DELETE FROM Tasks WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(int Id, Tasks updated)
        {
            connection.Open();

            var update =  $"UPDATE Tasks SET Task = @Task, Date = @Date, Time = @Time, Status = @Status WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("@Task", updated.Task);
            cmd.Parameters.AddWithValue("@Date", updated.Date);
            cmd.Parameters.AddWithValue("@Time", updated.Time);
            cmd.Parameters.AddWithValue("@Status", updated.Status);
            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateStatus(int Id, string status)
        {
            var update = "UPDATE Tasks SET Status = @Status WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteAll()
        {
            var deleteAll = "DELETE FROM Tasks";
            SqlCommand cmd = new SqlCommand(deleteAll, connection);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
