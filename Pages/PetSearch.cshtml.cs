using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class PetSearchModel : PageModel
    {
        public int petId;
        public string name;
        public string age;
        public string note;
        public string alertMessage = null;

        public void OnGet()
        {
        }
        public void OnPostFindPet(string search)
        {
            if (search == null)
            {
                alertMessage = "Data input not complete";
                return;
            }

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM pet WHERE name LIKE '%" +
                    search + "%'";
                SqlCommand findpet = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = findpet.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        petId = (Int32)reader["petID"];
                        name = (string)reader["name"];
                        age = ((Int32)reader["age"]).ToString();
                        note = (string)reader["notes"];
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

        public void OnPostUpdatePet(int pet_id, string name, string age, string note)
        {
            if (pet_id == 0 || name==null || age == null || note == null)
            {
                alertMessage = "Data input not complete";
                return;
            }

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand updatePet = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                updatePet.Parameters.AddWithValue("@petID", pet_id);
                updatePet.Parameters.AddWithValue("@name", name);
                updatePet.Parameters.AddWithValue("@age", Convert.ToInt32(age));
                updatePet.Parameters.AddWithValue("@note", note);

                updatePet.CommandText = ("[spUpdatePet]");
                updatePet.CommandType = System.Data.CommandType.StoredProcedure;

                updatePet.ExecuteNonQuery();
                updatePet.Parameters.Clear(); // error is you do not clear
                myConn.Close();

            } // using
        } // OnPostUpdatePet()
    }
}
