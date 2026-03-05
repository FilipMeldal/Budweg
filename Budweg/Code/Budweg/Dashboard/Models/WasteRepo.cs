using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;


namespace Dashboard.Models
{
    public class WasteRepo : DatabaseConnector
    {
        private Waste waste;



        public List<Waste> WasteGetAll()
        {
            List<Waste> wasteList = new List<Waste>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT WasteAmount, Material FROM Waste";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Waste waste = new Waste
                        {
                            WasteAmount = reader.GetDouble(0),
                            Material = reader.GetString(1),
                        };
                        wasteList.Add(waste);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while retrieving waste data: " + ex.Message);
                }
            }
            return wasteList;
        }

        public Waste WasteGetById(int id)
        {
            Waste waste = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT w.WasteID, w.WasteAmount, w.Material, w.CaliperID 
                                 FROM Waste w 
                                 INNER JOIN BrakeCaliper b ON w.CaliperID = b.CaliperID 
                                 WHERE w.WasteID = @WasteID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@WasteID", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        waste = new Waste
                        {
                            WasteID = reader.GetInt32(0),
                            WasteAmount = reader.GetDouble(1),
                            Material = reader.GetString(2),
                            CaliperID = reader.IsDBNull(3) ? null : reader.GetInt32(3)
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while retrieving waste data: " + ex.Message);
                }
            }
            return waste;


        }




    }
}
