using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactWeb1
{

    public partial class UserId : System.Web.UI.UserControl
    {
       public static SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
       public static SqlCommand PersonalQueryCmd = new SqlCommand("Select * from tblPerson", Conn);
        public static int nPersonId { get; internal set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {}
        }
        public static void User_id()
        {
            Conn.Open();
            using (SqlDataReader reader = PersonalQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    nPersonId = reader.GetInt32(0);
                }

            }
            Conn.Close();
        }
        public static void AddMoreUserId()
        {
            Conn.Open();
            using (SqlDataReader reader = PersonalQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                      nPersonId = reader.GetInt32(0);
                }
            }
            Conn.Close();
        }
    }
}
