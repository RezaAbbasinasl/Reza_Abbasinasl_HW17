using Reza_Abbasinasl_HW17.Models;
using System.Data;
using System.Data.SqlClient;

namespace Reza_Abbasinasl_HW17.DAL
{
    public class StaffDAL 
    {
        private readonly string _connectionStr = "Data Source=.\\SQL2022;Initial Catalog=BikeStore;Integrated Security=True;Encrypt=False";

        public List<Staff> GetAll()
        {
            List<Staff> staffsList = new List<Staff>();

            using(SqlConnection con = new SqlConnection(_connectionStr))
            {
                string quaryStr = "SELECT ss.first_name, ss.last_name, ss.email, ss.phone, ss.store_id ,st.store_name,tblS.first_name+' '+ tblS.last_name AS Manager_Name\r\nFROM sales.staffs ss LEFT JOIN sales.stores st\r\nON ss.store_id = st.store_id\r\nLEFT JOIN sales.staffs tblS ON ss.manager_id = tblS.staff_id";
                SqlCommand command = new SqlCommand(quaryStr, con);
                command.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Staff staff = new Staff();

                    staff.First_Name = reader["First_Name"].ToString() ?? string.Empty;
                    staff.Last_Name = reader["Last_Name"].ToString() ?? string.Empty;
                    staff.Email = reader["Email"].ToString() ?? string.Empty;
                    staff.Phone = reader["Phone"].ToString() ?? string.Empty;
                    staff.Store_Id = (Int32)reader["Store_Id"];
                    staff.Store_Name = reader["Store_Name"].ToString() ?? string.Empty;
                    staff.Manager_Name = reader["Manager_Name"].ToString() ?? string.Empty;

                    staffsList.Add(staff);
                }

            };
            return staffsList;
        }
    }
}
