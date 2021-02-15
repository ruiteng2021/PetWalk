using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PetWalkSite.Pages
{
    public class EmployeeAdminModel : PageModel
    {
        public string alertMessage = null;
        public void OnGet() {}
        public void OnPostAddEmployees(string name, Int32 age, string bio, string address)
        {
            if (name == null || age == 0 || bio == null || address == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand addCustomer = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addCustomer.Parameters.AddWithValue("@name", name);
                addCustomer.Parameters.AddWithValue("@age", age);
                addCustomer.Parameters.AddWithValue("@bio", bio);
                addCustomer.Parameters.AddWithValue("@address", address);

                addCustomer.CommandText = ("[spAddVolunteer]");
                addCustomer.CommandType = System.Data.CommandType.StoredProcedure;

                addCustomer.ExecuteNonQuery();


            } // using
        } // OnPostAddEmployees()
        public void OnPostAddHours(string[] days, string[] volunteer,
            string start1, string end1, string start2, string end2,
            string start3, string end3, string start4, string end4)
        {
            if (days.Length == 0 || volunteer.Length == 0)
            {
                alertMessage = "Data input not complete";
                return;
            }


            // create 2 arrays to hold start and end times
            string[] startTimes = { start1, start2, start3, start4 };
            string[] endTimes = { end1, end2, end3, end4 };

            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                SqlCommand addHours = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                for (int d = 0; d < days.Length; d++)
                {
                    for (int h = 0; h < startTimes.Length; h++)
                    {
                        if ((Convert.ToInt32(endTimes[h]) - Convert.ToInt32(startTimes[h])) == 1)
                        {
                            addHours.Parameters.AddWithValue("@day", days[d]);
                            addHours.Parameters.AddWithValue("@startHour", Convert.ToInt32(startTimes[h]));
                            addHours.Parameters.AddWithValue("@endHour", Convert.ToInt32(endTimes[h]));
                            addHours.Parameters.AddWithValue("@volunteerID", Convert.ToInt32(volunteer[0]));

                            addHours.CommandText = ("[spAddHours]");
                            addHours.CommandType = System.Data.CommandType.StoredProcedure;

                            addHours.ExecuteNonQuery(); // runs the SP
                            addHours.Parameters.Clear(); // error is you do not clear
                        }
                    } // hours for loop
                } // day for loop 
            } // using
        } // OnPostAddHours()

    } // class
} // namespace