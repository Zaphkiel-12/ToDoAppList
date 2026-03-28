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
    public class TaskDBData
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=dbTaskMgmt;Integrated Security=True;TrustServerCertificate=True;";

        public TaskDBData() { }

        public List<Tasks> GetAll()
        {
            var tasks = new List<Tasks>();
            const string selectStatement = "SELECT Task, Date, Time, Status FROM Tasks";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(selectStatement, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Tasks
                        {
                            Task = reader["Task"]?.ToString(),
                            Date = reader["Date"]?.ToString(),
                            Time = reader["Time"]?.ToString(),
                            Status = reader["Status"]?.ToString()
                        });
                    }
                }
            }

            return tasks;
        }

        public void SaveAll(List<Tasks> tasks)
        {
            const string deleteStatement = "DELETE FROM Tasks";
            const string insertStatement =
                "INSERT INTO Tasks (Task, Date, Time, Status) VALUES (@Task, @Date, @Time, @Status)";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var deleteCmd = new SqlCommand(deleteStatement, conn, tran))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }

                    using (var insertCmd = new SqlCommand(insertStatement, conn, tran))
                    {
                        insertCmd.Parameters.Add("@Task", SqlDbType.NVarChar, 4000);
                        insertCmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50);
                        insertCmd.Parameters.Add("@Time", SqlDbType.NVarChar, 50);
                        insertCmd.Parameters.Add("@Status", SqlDbType.NVarChar, 100);

                        foreach (var t in tasks)
                        {
                            insertCmd.Parameters["@Task"].Value = (object?)t.Task ?? DBNull.Value;
                            insertCmd.Parameters["@Date"].Value = (object?)t.Date ?? DBNull.Value;
                            insertCmd.Parameters["@Time"].Value = (object?)t.Time ?? DBNull.Value;
                            insertCmd.Parameters["@Status"].Value = (object?)t.Status ?? DBNull.Value;
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
            }
        }
    }
}
