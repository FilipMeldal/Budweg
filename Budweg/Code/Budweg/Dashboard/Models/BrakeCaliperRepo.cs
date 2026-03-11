using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;


namespace Dashboard.Models
{
    public class BrakeCaliperRepo : DatabaseConnector
    {

        private BrakeCaliper bc;

        public List<BrakeCaliper> BcGetAll()
        {
            List<BrakeCaliper> bcList = new List<BrakeCaliper>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Weight, RawMaterial, Component FROM BRAKECALIPERS";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BrakeCaliper bc = new BrakeCaliper
                        {
                            Weight = reader.GetDouble(0),
                            RawMaterial = reader.GetString(1),
                            Component = reader.GetString(2)

                        };
                        bcList.Add(bc);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving BrakecaliperData{ex.Message}", ex);
                }
            }
            return bcList;
        }


        public BrakeCaliper BcGetById(int id)
        {
            BrakeCaliper bc = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CaliperID, Weight, RawMaterial, Component FROM BRAKECALIPERS WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bc = new BrakeCaliper
                        {
                            CaliperID = reader.GetInt32(0),
                            Weight = reader.GetDouble(1),
                            RawMaterial = reader.GetString(2),
                            Component = reader.GetString(3)

                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving BrakecaliperData by Id{ex.Message}", ex);
                }
                return bc;
            }

        }
    }
}
