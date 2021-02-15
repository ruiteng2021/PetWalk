using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class VolunteerSearchModel : PageModel
    {
        public int volunteerId;
        public string name;
        public string age;
        public string bio;
        public string address;
        public string alertMessage = null;
        public void OnGet()
        {
        }
        public void OnPostFindVolunteer(string search)
        {
            if (search == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM volunteer WHERE name = '" +
                    search + "'";
                SqlCommand findVolunteer = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = findVolunteer.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        volunteerId = (Int32)reader["volunteerID"];
                        name = (string)reader["name"];
                        age = ((Int32)reader["age"]).ToString();
                        bio = (string)reader["bio"];
                        address = (string)reader["address"];
                    }
                    else
                    {
                        alertMessage = "No pet found";
                        return;
                    }
                }
                myConn.Close();
            } // using
        } // OnPostFindPet()

        public void OnPostUpdateVolunteer(int volunteer_id, string name, string age, string bio, string address)
        {
            if (volunteer_id == 0 || name ==  null || age == null || bio == null || address == null)
            {
                alertMessage = "Data input not complete";
                return;
            }

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand updateVolunteer = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                updateVolunteer.Parameters.AddWithValue("@volunteerID", volunteer_id);
                updateVolunteer.Parameters.AddWithValue("@name", name);
                updateVolunteer.Parameters.AddWithValue("@age", Convert.ToInt32(age));
                updateVolunteer.Parameters.AddWithValue("@bio", bio);
                updateVolunteer.Parameters.AddWithValue("@address", address);

                updateVolunteer.CommandText = ("[spUpdateVolunteer]");
                updateVolunteer.CommandType = System.Data.CommandType.StoredProcedure;

                updateVolunteer.ExecuteNonQuery();
                updateVolunteer.Parameters.Clear(); // error is you do not clear
                myConn.Close();

            } // using
        } // OnPostUpdatePet()
    }
}
