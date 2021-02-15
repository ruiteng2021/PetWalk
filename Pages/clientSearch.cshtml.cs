using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class clientSearchModel : PageModel
    {
        public int clientID;
        public string name;
        public string phone;
        public string email;
        public string address;
        //public DataTable table;
        public string alertMessage = null;

        public void OnGet()
        {
        }
        public void OnPostClientSearch(string search)
        {
            if (search == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM client WHERE name = '" +
                    search + "'";
                SqlCommand findCustomer = new SqlCommand(searchQuery, myConn);
                myConn.Open();

                using (SqlDataReader reader = findCustomer.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int clientID_Idx = reader.GetOrdinal("clientID");
                        int nameIdx = reader.GetOrdinal("name");
                        int phoneIdx = reader.GetOrdinal("phone");
                        int emailIdx = reader.GetOrdinal("email");
                        int addressIdx = reader.GetOrdinal("address");

                        clientID = reader.GetInt32(clientID_Idx);
                        name = reader.GetString(nameIdx);
                        phone = reader.GetString(phoneIdx);
                        email = reader.GetString(emailIdx);
                        address = reader.GetString(addressIdx);
                    }
                    else
                    {
                        alertMessage = "No client found";
                        return;
                    }
                } 
                myConn.Close();
            } // using
        } // OnPostClientSearch()

        public void OnPostUpdateClient(int client_id, string name, string phone, string email,
            string address)
        {
            if (client_id == 0 || name == null || phone == null || email == null || address == null)
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

                updateClient.Parameters.AddWithValue("@clientID", client_id);
                updateClient.Parameters.AddWithValue("@name", name);
                updateClient.Parameters.AddWithValue("@phone", phone);
                updateClient.Parameters.AddWithValue("@email", email);
                updateClient.Parameters.AddWithValue("@address", address);

                updateClient.CommandText = ("[spUpdateClient]");
                updateClient.CommandType = System.Data.CommandType.StoredProcedure;

                updateClient.ExecuteNonQuery();
                updateClient.Parameters.Clear(); // error is you do not clear
                myConn.Close();

            } // using
        } // OnPostUpdateClient()
    }
}
