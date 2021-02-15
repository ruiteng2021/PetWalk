using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class PetAdminModel : PageModel
    {
        public string alertMessage = null;
        public void OnGet()
        {
        }
        public void OnPostAddBreed(string breedName)
        {
            if (breedName == null)         
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand addBreed = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addBreed.Parameters.AddWithValue("@name", breedName);

                addBreed.CommandText = ("[spAddBreed]");
                addBreed.CommandType = System.Data.CommandType.StoredProcedure;

                addBreed.ExecuteNonQuery();
                addBreed.Parameters.Clear(); // error is you do not clear
                myConn.Close();

            } // using
        } // OnPostAddBreed()

        int clientID;
        int breedID;
        public void OnPostAddPet(string name, string age, string breed, string client, string notes)
        {
            if (name == null || age == null || breed == null || client == null || notes == null)
            {
                alertMessage = "Data input not complete";
                return;
            }

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM client WHERE  client.name = '" + client + "'";
                SqlCommand clientCommand = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = clientCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        clientID = (Int32)reader["clientID"];
                    }
                    else
                    {
                        alertMessage = "No client found";
                        return;
                    }
                }
                myConn.Close();

                searchQuery = "SELECT * FROM breed WHERE  breed.name = '" + breed + "'";
                SqlCommand breedCommand = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = breedCommand.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        breedID = (Int32)reader["breedID"];
                    }
                    else
                    {
                        alertMessage = "No breed found";
                        return;
                    }
                }
                myConn.Close();
            }

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand addPet = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addPet.Parameters.AddWithValue("@name", name);
                addPet.Parameters.AddWithValue("@age", age);
                addPet.Parameters.AddWithValue("@breedID", breedID);
                addPet.Parameters.AddWithValue("@clientID", clientID);
                addPet.Parameters.AddWithValue("@notes", notes);

                addPet.CommandText = ("[spAddPet]");
                addPet.CommandType = System.Data.CommandType.StoredProcedure;

                addPet.ExecuteNonQuery();
                addPet.Parameters.Clear(); // error is you do not clear
                myConn.Close();
            } // using
        } // OnPostAddPet()
    }
}
