using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace Dashboard.Models
{
    public class InspectionRepo
    {
        private Inspection inspection;


        public void InspecAdd(Inspection inspec)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Inspection " +
                    "(Date, Milestone, MilestoneReached, Inspector " +
                    "VALUES (@Date, @Milestone, @MilestoneReached, @Inspector " +
                    "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTime.Now;
                    cmd.Parameters.Add("@Milestone", SqlDbType.NVarChar).Value = inspection.Milestone;
                    cmd.Parameters.Add("@MilestoneReached", SqlDbType.NVarChar).Value = inspection.MilestoneReached;
                    cmd.Parameters.Add("@Inspector", SqlDbType.NVarChar).Value = inspection.Inspector;

                    inspection.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

        }

        public List<Inspection> InspecGetAll()
        {

        }
        public void InspecRemove(Inspection inspection)
        {

        }
        
        public Inspection InspecGetById(int id)
        {

        }

    }
}
