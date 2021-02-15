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
    public class AppointmentAdminModel : PageModel
    {
        public List<string> names = new List<string>();
        public List<string> days = new List<string>();
        public List<string> startHours = new List<string>();
        public List<string> endHours = new List<string>();
        public List<string> nameGroup = new List<string>();
        public List<string> numOfStartHours = new List<string>();

        //public string availDay;
        public DataTable availTable = new DataTable();
        public DataTable nameGroupTable = new DataTable();
        public string alertMessage = null;

        public void OnGet()
        {
            GetData();
        }
        public void GetData()
        {
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT name, starthour, endhour, day " +
                    "FROM availability AS AV " +
                    "JOIN volunteer AS VT " +
                    "ON AV.volunteerID = VT.volunteerID ";
                //"ON AV.volunteerID = VT.volunteerID " +
                //"WHERE AV.day = '" + day + "'";
                string nameGroupQuery = "SELECT name, COUNT(starthour) AS count " +
                    "FROM availability AS AV " +
                    "JOIN volunteer AS VT " +
                    "ON AV.volunteerID = VT.volunteerID " +
                    //"WHERE AV.day = '" + day + "'" +
                    "GROUP BY VT.name";
                SqlCommand findAvailableTime = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                availTable.Load(findAvailableTime.ExecuteReader());
                SqlCommand findNameGroup = new SqlCommand(nameGroupQuery, myConn);
                nameGroupTable.Load(findNameGroup.ExecuteReader());
                myConn.Close();

                //availDay = day;
                foreach (DataRow row in availTable.Rows)
                {
                    names.Add(row["name"].ToString());
                    days.Add(row["day"].ToString());
                    startHours.Add(row["starthour"].ToString());
                    endHours.Add(row["endhour"].ToString());
                }

                foreach (DataRow row in nameGroupTable.Rows)
                {
                    nameGroup.Add(row["name"].ToString());
                    numOfStartHours.Add(row["count"].ToString());
                }
            } // using
        }
        
        string volunteer;
        int hour;
        Int32 petId;
        Int32 VolId;
        public void OnPostBookAppointment(DateTime day, string pet, string[] timeTable)
        {
            if (day == null || pet == null || timeTable.Length == 0)
            {
                alertMessage = "Data input not complete";
                GetData();
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT petID,name FROM pet WHERE name LIKE '%" +
                   pet + "%'";
                SqlCommand findpet = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = findpet.ExecuteReader())
                {                  
                    if (reader.Read())
                    {
                        petId = (Int32)reader["petID"];
                    }
                    else
                    {
                        alertMessage = "No pet found";
                        return;
                    }
                }
                myConn.Close();

                foreach (String time in timeTable)
                {                                   
                    if (time.Contains(day.DayOfWeek.ToString()))
                    {
                        string[] appData = time.Split(' ');
                        volunteer = (String)appData[4].Clone();
                        hour = Convert.ToInt32(appData[0]);
                    }
                    else
                    {
                        alertMessage = "please select " + day.DayOfWeek.ToString();
                        continue;
                    }

                    searchQuery = "SELECT volunteerID,name FROM volunteer WHERE name LIKE '%" + volunteer + "%'";
                    SqlCommand findVol = new SqlCommand(searchQuery, myConn);
                    myConn.Open();
                    using (SqlDataReader reader = findVol.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            VolId = (Int32)reader["volunteerID"];
                        }
                        else
                        {
                            alertMessage = "No volunteer found";
                            return;
                        }
                    }
                    myConn.Close();

                    SqlCommand addAppointment = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addAppointment.Parameters.AddWithValue("@petID", petId);
                    addAppointment.Parameters.AddWithValue("@dateBooked", day);
                    addAppointment.Parameters.AddWithValue("@appointmentDate", day.AddHours(hour));
                    addAppointment.Parameters.AddWithValue("@duration", 1);
                    addAppointment.Parameters.AddWithValue("@volunteerID", VolId);

                    addAppointment.CommandText = ("[spAddAppointment]");
                    addAppointment.CommandType = System.Data.CommandType.StoredProcedure;

                    addAppointment.ExecuteNonQuery();
                    addAppointment.Parameters.Clear(); // error is you do not clear
                    myConn.Close();
                }
            } // using
            GetData();
        }// OnPostBookAppointment()
    }
}
