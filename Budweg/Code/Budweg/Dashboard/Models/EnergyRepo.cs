using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;



namespace Dashboard.Models
{
    public class EnergyRepo
    {
        private EnergyUse energyuse;
        private string connectionString = config.GetConnectionString("Navn af json db fil");


        public void EnergyAdd(EnergyUse energy)
        {

        }


        public List<EnergyUse> EnergyGetAll()
        {
            List<EnergyUse> energyList = new List<EnergyUse>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Watt FROM EnergyUse";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    SqlDataReader reader = command.ExectuteReader();
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
                    throw new Exception($"Der var fejl ved hentelse af energidata{ex.Message}", ex);



                }
                return energyList;
            }
        }

        public EnergyRemove(EnergyUse energy)
        {

        }

        public EnergyUse EnergyGetById(int id)
        {

        }

    }
}


