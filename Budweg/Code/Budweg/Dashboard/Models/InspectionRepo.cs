using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class InspectionRepo : DatabaseConnector
    {
        private Inspection inspection;


        public void InspecAdd(Inspection inspec)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

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
