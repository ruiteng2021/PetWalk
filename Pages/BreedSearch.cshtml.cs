using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class BreedSearchModel : PageModel
    {
        public Int32 breedId;
        public string breedName;
        public string alertMessage = null;
        public void OnGet()
        {
        }
        public void OnPostFindBreed(string search)
        {
            if (search == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM breed WHERE name = '" +
                    search + "'";
                SqlCommand findpet = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = findpet.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        breedId = (Int32)reader["breedID"];
                        breedName = (string)reader["name"];
                    }
                    else
                    {
                        alertMessage = "No client found";
                        return;
                    }
                }
                myConn.Close();
            } // using
        } // OnPostFindBreed()
        public void OnPostUpdateBreed(int breed_id, string name)
        {
            if (breed_id == 0 || name == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand updateClient = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                updateClient.Parameters.AddWithValue("@breedID", breed_id);
                updateClient.Parameters.AddWithValue("@name", name);

                updateClient.CommandText = ("[spUpdateBreed]");
                updateClient.CommandType = System.Data.CommandType.StoredProcedure;

                updateClient.ExecuteNonQuery();
                updateClient.Parameters.Clear(); // error is you do not clear
                myConn.Close();

            } // using
        } // OnPostUpdateClient()

    }
}
