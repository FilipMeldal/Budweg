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
                            WasteAmount = reader.GetDouble(1),
                            Material = reader.GetString(2),
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


        }




    }
}
