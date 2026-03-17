using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO.Enumeration;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Dashboard.Models
{
    public class InspectionRepo : DatabaseConnector
    {
 
        private List<Inspection> inspections;

        public InspectionRepo()
        {
           inspections = new List<Inspection>();
         
        }

        public void InspecAdd(Inspection inspection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Inspection " +
                    "(Date, Milestone, MilestoneReached, Inspector " +
                    "VALUES (@Date, @Milestone, @MilestoneReached, @Inspector " +
                    "SELECT @@IDENTITY", connection))
                {
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTime.Now;
                    cmd.Parameters.Add("@Milestone", SqlDbType.NVarChar).Value = inspection.Milestone;
                    cmd.Parameters.Add("@MilestoneReached", SqlDbType.NVarChar).Value = inspection.MilestoneReached;
                    cmd.Parameters.Add("@Inspector", SqlDbType.NVarChar).Value = inspection.Inspector;

                    inspection.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            inspections.Add(inspection);
        }

        public List<Inspection> InspecGetAll()
        {
            List<Inspection> inspections = new List<Inspection>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Inspection", connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inspection inspection = new Inspection()
                        {
                            Id = reader.GetInt32(0),
                            Date = (DateTime)reader["Date"],
                            Milestone = (double)reader["Milestone"],
                            MilestoneReached = (bool)reader["MilestoneReached"],
                            Inspector = (string)reader["Inspector"]
                        };
                    }
                }

            }
            return inspections;
        }

        public Inspection InspecGetById(int id)
        {
            Inspection? inspection = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * " +
                    "FROM Inspection WHERE Id = @Id", connection);

                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inspection = new Inspection
                        {
                            Id = reader.GetInt32(0),
                            Date = (DateTime)reader["Date"],
                            Milestone = (double)reader["Milestone"],
                            MilestoneReached = (bool)reader["MilestoneReached"],
                            Inspector = (string)reader["Inspector"]
                        };
                    }
                }
            }
            return inspection;
        }

        public void InspecRemove(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Inspection WHERE Id = @Id", connection);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }



    }
}
