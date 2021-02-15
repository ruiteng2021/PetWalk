using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace PetWalkSite.Pages
{
    public class CustomerAdminModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostAddClient(string name, string phone, string email, string address)
        {
            if (name == null || phone == null || email == null || address == null)
                return;

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand addCustomer = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addCustomer.Parameters.AddWithValue("@name", name);
                addCustomer.Parameters.AddWithValue("@phone", phone.ToString());
                addCustomer.Parameters.AddWithValue("@email", email.ToString());
                addCustomer.Parameters.AddWithValue("@address", address);

                addCustomer.CommandText = ("[spAddCustomer]");
                addCustomer.CommandType = System.Data.CommandType.StoredProcedure;

                addCustomer.ExecuteNonQuery();   


            } // using
        } // OnPostAddClient()
    }
}
