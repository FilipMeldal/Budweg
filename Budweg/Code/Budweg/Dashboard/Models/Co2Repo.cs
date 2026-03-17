using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;

namespace Dashboard.Models
{
    public class Co2Repo : DatabaseConnector
    {

        private Co2Emission Co2Emission;



        public List<Co2Emission> Co2GetAll()
        {
            List<Co2Emission> co2EmissionsList = new List<Co2Emission>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM CO2EMISSION";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Co2Emission co2Emission = new Co2Emission
                        {
                            Weight = reader.GetDouble(0),
                            ID = reader.GetInt32(1)
                        };
                        co2EmissionsList.Add(co2Emission);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving CO2Emission data{ex.Message}", ex);
                }
                return co2EmissionsList;

            }
        }



        public Co2Emission Co2GetById(int id)
        {
            Co2Emission co2Emission = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT c.ID, c.Weight, c.BrakeCaliperID 
                                 FROM CO2EMISSION c 
                                 INNER JOIN BRAKECALIPER b ON w.BrakeCaliperID = b.BrakeCaliperID 
                                 WHERE c.ID = @ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        co2Emission = new Co2Emission
                        {
                            Weight = reader.GetDouble(0),
                            ID = reader.GetInt32(1),
                            BrakeCaliperID = reader.IsDBNull(2) ? null : reader.GetInt32(2)

                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving CO2Emission data for ID {id}: {ex.Message}", ex);
                }
                return co2Emission;
            }

        }
    }
}
