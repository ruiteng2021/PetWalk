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
    public class Index1Model : PageModel
    {
        public int appointmentId;
        public int petId;
        public string dateBooked;
        public string appointmentDate;
        public int volunteerId;
        public int duration;
        public string volunteerName;
        public string petName = null;
        public string alertMessage = null;

        public void OnGet()
        {
        }
        public void OnPostFindAppointment(string search)
        {
            if (search == null)
            {
                alertMessage = "Data input not complete";
                return;
            }
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT * FROM pet WHERE name = '" +
                    search + "'";
                SqlCommand findpet = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                using (SqlDataReader reader = findpet.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        petId = (Int32)reader["petID"];
                        petName = (string)reader["name"];
                    }
                    else
                    {
                        alertMessage = "No Pet found";
                        return;
                    }
                }

                searchQuery = "SELECT * FROM appointment WHERE petID = " + petId;
                SqlCommand findAppointment = new SqlCommand(searchQuery, myConn);

                using (SqlDataReader reader = findAppointment.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        appointmentId = (Int32)reader["AppointmentID"];
                        petId = (Int32)reader["petID"];
                        dateBooked = reader["dateBooked"].ToString();
                        //DateTime date = Convert.ToDateTime(dateBooked);
                        //dateBooked = date.DayOfWeek.ToString();
                        appointmentDate = reader["appointmentDate"].ToString();
                        volunteerId = (Int32)reader["volunteerID"];
                        duration = (Int32)reader["duration"];
                    }
                    else
                    {
                        alertMessage = "No Pet ID found";
                        return;
                    }
                }

                searchQuery = "SELECT name FROM volunteer WHERE volunteerID = " +
                    volunteerId;
                SqlCommand findvolunteer = new SqlCommand(searchQuery, myConn);

                using (SqlDataReader reader = findvolunteer.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        volunteerName = (string)reader["name"];
                    }
                    else
                    {
                        alertMessage = "No volunteer ID found";
                        return;
                    }
                }
                myConn.Close();
            } // using
        } // OnPostFindAppointment()

        public void OnPostChangeDate(string[] appointment_id, DateTime[] dateBooked, string[] volTimeTable, string[] pet_name, int[] delete)
        {
            string volName;
            int startHour;

            if (delete.Length > 0)
            {
                foreach (int s in delete)
                {
                    using (SqlConnection myConn = new SqlConnection(Program.da.cs))
                    {
                        string searchQuery = "DELETE FROM appointment WHERE appointment.appointmentID =" + s;
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

            if (appointment_id.Length == 0 || dateBooked.Length == 0 || volTimeTable.Length == 0)
            {
                alertMessage = "Data input not complete"; // check when nothing select at beginning
                return;
            }

            int noSelectedItems = 0;
            for (int i=0; i < appointment_id.Length; i++)
            {
                if (appointment_id[i] == "0" ||
                     volTimeTable[i] == "0" ||
                    dateBooked[i].Year == 1900 && dateBooked[i].Month == 1 && dateBooked[i].Day == 1)
                {
                    if (noSelectedItems == (appointment_id.Length-1))
                    {
                        alertMessage = "Data input not complete"; // retrun when one of row is not complete
                        return;
                    }
                    noSelectedItems++;
                    continue;
                }

                using (SqlConnection myConn = new SqlConnection(Program.da.cs))
                {
                    string searchQuery = "SELECT * FROM appointment " +
                                "JOIN pet " +
                                "ON pet.petID = appointment.petID " +
                                "JOIN volunteer " +
                                "ON volunteer.volunteerID = appointment.volunteerID " +
                                "WHERE pet.name = '" + pet_name[i] + "'" + " AND appointment.appointmentID = " + appointment_id[i];
                    SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
                    myConn.Open();
                    using (SqlDataReader reader = displayCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            petId = (Int32)reader["petID"];
                            string[] volData = volTimeTable[i].Split(' ');
                            volName = (String)volData[3].Clone();
                            startHour = Convert.ToInt32(volData[0]);
                            string weekDay = (String)volData[4].Clone();

                            if (!Equals(dateBooked[i].DayOfWeek.ToString(), weekDay))
                            {
                                alertMessage = "Please select same week day"; // retrun when one of row is not complete
                                return;
                            }
                        }
                        else
                        {
                            alertMessage = "No pet or appointment found";
                            return;
                        }
                    }
                    myConn.Close();

                    searchQuery = "SELECT volunteerID FROM volunteer WHERE  volunteer.name = '" + volName + "'";
                    SqlCommand volCommand = new SqlCommand(searchQuery, myConn);
                    myConn.Open();
                    using (SqlDataReader reader = volCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            volunteerId = (Int32)reader["volunteerID"];
                        }
                        else
                        {
                            alertMessage = "No volunteer ID found";
                            return;
                        }
                    }
                    myConn.Close();

                    SqlCommand updateAppointment = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    updateAppointment.Parameters.AddWithValue("@volunteerID", volunteerId);
                    updateAppointment.Parameters.AddWithValue("@AppointmentID", appointment_id[i]);
                    updateAppointment.Parameters.AddWithValue("@dateBooked", dateBooked[i]);
                    updateAppointment.Parameters.AddWithValue("@appointmentDate", dateBooked[i].AddHours(startHour));
                    updateAppointment.Parameters.AddWithValue("@duration", 1);
                    updateAppointment.Parameters.AddWithValue("@petID", petId);

                    updateAppointment.CommandText = ("[spUpdateAppointment]");
                    updateAppointment.CommandType = System.Data.CommandType.StoredProcedure;

                    updateAppointment.ExecuteNonQuery();
                    updateAppointment.Parameters.Clear(); // error is you do not clear
                    myConn.Close();
                    //break; // finish display when one of the item complete
                } // using
            }
        } // OnPostChangeDate()
    }
}
