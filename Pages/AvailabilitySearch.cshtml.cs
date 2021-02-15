using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace PetWalkSite.Pages
{
    public class AvailabilitySearchModel : PageModel
    {
        public string alertMessage = null;
        public DataTable table = new DataTable();
        public void OnGet()
        {
        }
        public void OnPostFindAvailability(string volunteer)
        {
            if (volunteer == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT availableID, day, starthour, endhour, availability.volunteerID, name " +
                    "FROM availability " +
                    "JOIN volunteer " +
                    "ON availability.volunteerID = volunteer.volunteerID " +
                    "WHERE volunteer.name = '" + volunteer + "' " +
                    "ORDER BY day";
                SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                table.Load(displayCommand.ExecuteReader());
                myConn.Close(); 
            } // using
        } // OnPostFindAvailability()
        public void OnPostUpdateAvailability(int[] available_id, string[] week_days, int[] startHour, int[] endHour, int[] volunteer_id, int[] delete)
        {
            if (delete.Length > 0)
            {
                foreach (int s in delete)
                {
                    using (SqlConnection myConn = new SqlConnection(Program.da.cs))
                    {
                        string searchQuery = "DELETE FROM availability WHERE availability.availableID =" + s;
                        SqlCommand findApp = new SqlCommand(searchQuery, myConn);
                        myConn.Open();
                        using (SqlDataReader reader = findApp.ExecuteReader())
                        {
                        }
                        myConn.Close();
                    } // using
                }
                return;
            }

            if (available_id.Length == 0 || week_days.Length == 0 || startHour.Length == 0 || endHour.Length == 0)
            {
                alertMessage = "Data input not complete"; // check when nothing select at beginning
                return;
            }
            int noSelectedItems = 0;
            for (int i = 0; i < available_id.Length; i++)
            {
                if (available_id[i] == 0 ||
                     week_days[i] == "0")
                {
                    if (noSelectedItems == (available_id.Length - 1))
                    {
                        alertMessage = "Data input not complete"; // retrun when one of row is not complete
                        return;
                    }
                    noSelectedItems++;
                    continue;
                }
                if ((endHour[i] - startHour[i]) != 1)
                {
                    alertMessage = "only 1 hour please"; // retrun when one of row is not complete
                    return;
                }

                using (SqlConnection myConn = new SqlConnection(Program.da.cs))
                {
                    SqlCommand updateAailability = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    updateAailability.Parameters.AddWithValue("@availableID", available_id[i]);
                    updateAailability.Parameters.AddWithValue("@day", week_days[i]);
                    updateAailability.Parameters.AddWithValue("@start", startHour[i]);
                    updateAailability.Parameters.AddWithValue("@end", endHour[i]);
                    updateAailability.Parameters.AddWithValue("@volunteerID", volunteer_id[i]);

                    updateAailability.CommandText = ("[spUpdateAvailability]");
                    updateAailability.CommandType = System.Data.CommandType.StoredProcedure;

                    updateAailability.ExecuteNonQuery();
                    updateAailability.Parameters.Clear(); // error is you do not clear
                    myConn.Close();
                    //continue; // finish display when one of the item complete
                } // using
            }
        } // OnPostUpdateAvailability()
    }
}
