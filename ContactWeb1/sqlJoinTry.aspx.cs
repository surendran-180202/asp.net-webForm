using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ContactWeb1.ViewTable;

namespace ContactWeb1
{
    public partial class sqlJoinTry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand PersonalQueryCmd = new SqlCommand(" SELECT * FROM tblPerson LEFT JOIN tblContact ON tblPerson.PERSONID = tblContact.PERSONID LEFT JOIN tblAddress  ON tblContact.PERSONID = tblAddress.PERSONID;", Conn);
            Conn.Open();
            using (SqlDataReader reader = PersonalQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //GridView1.DataSource = reader;
                    //GridView1.DataBind();


                    //   SELECT * FROM tblPerson JOIN tblContact ON tblPerson.PERSONID = tblContact.PERSONID JOIN tblAddress  ON tblPerson.PERSONID = tblAddress.PERSONID;
                }
            }
    }
    }
}