using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;




namespace Dashboard.Models
{
    public class EnergyRepo : DatabaseConnector
    {
        private EnergyUse energyuse;


        public List<EnergyUse> EnergyGetAll()
        {
            List<EnergyUse> energyList = new List<EnergyUse>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Watt FROM ENERGYUSE";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EnergyUse energy = new EnergyUse
                        {
                            Watt = reader.GetDouble(0)
                        };
                        energyList.Add(energy);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving Energydata{ex.Message}", ex);
                }
                return energyList;
            }
        }

     

        public EnergyUse EnergyGetById(int id)
        {
            EnergyUse energy = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT e.EnergyID, e.Watt, e.CaliperIDFk 
                                 FROM ENERGYUSE e 
                                 INNER JOIN BRAKECALIPER b ON e.CaliperIDFk = b.CaliperID 
                                 WHERE e.EnergyID = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        energy = new EnergyUse
                        {
                            EnergyID = reader.GetInt32(0),
                            Watt = reader.GetDouble(1),
                            CaliperIDFk = reader.IsDBNull(2) ? null : reader.GetInt32(2)
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"There was an error retrieving Energydata by Id{ex.Message}", ex);
                }
                return energy;
            }

        }

    }
}



