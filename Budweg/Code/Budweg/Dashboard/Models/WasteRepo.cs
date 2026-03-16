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
                string query = "SELECT * FROM WASTE";
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
                            ID = reader.GetInt32(2),
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
                string query = @"SELECT w.ID, w.WasteAmount, w.Material, w.BrakeCaliperID 
                                 FROM WASTE w 
                                 INNER JOIN BRAKECALIPER b ON w.BrakeCaliperID = b.BrakeCaliperID 
                                 WHERE w.ID = @ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        waste = new Waste
                        {
                            ID = reader.GetInt32(0),
                            WasteAmount = reader.GetDouble(1),
                            Material = reader.GetString(2),
                            BrakeCaliperID = reader.IsDBNull(3) ? null : reader.GetInt32(3)
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
