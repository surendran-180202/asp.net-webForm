using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;
using System.Web.Services.Description;
using System.Drawing;

namespace ContactWeb1
{
    public partial class PersonalDetails : System.Web.UI.UserControl
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        int nPersonId;
        public static int nPersonIdCheck { get; set; }
        //= UserId.nPersonId;
        protected void Page_Load(object sender, EventArgs e)
        {}
        public void persion_data()
        {
            try
            {
                // nPersonId = UserId.nPersonId;
                string Fname = TextBox1.Text;
                string Lname = TextBox2.Text;
                string Gender = RadioButtonList_New.SelectedItem.Text;
                DateTime Dob = DateTime.Parse(TextBox4.Text);
                string strPersonalQuery = "insert into tblPerson(FIRSTNAME,LASTNAME,GENDER,DOB)values (@fname,@lname,@gender,@dob)";
                SqlCommand PersonalAddQuerycmd = new SqlCommand(strPersonalQuery, Conn);
               // PersonalAddQuerycmd.Parameters.AddWithValue("@personid", nPersonId);
                PersonalAddQuerycmd.Parameters.AddWithValue("@fname", Fname);
                PersonalAddQuerycmd.Parameters.AddWithValue("@lname", Lname);
                PersonalAddQuerycmd.Parameters.AddWithValue("@gender", Gender);
                PersonalAddQuerycmd.Parameters.AddWithValue("@dob", Dob);
                Conn.Open();
                PersonalAddQuerycmd.ExecuteNonQuery();
                Conn.Close();
            }

            catch
            {
                string message = "Enter the Person Details in Crt format";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
            }
        }
       
            //public  void Show(this Page Page, String Message)
            //{
            //    Page.ClientScript.RegisterStartupScript(
            //       Page.GetType(),
            //       "MessageBox",
            //       "<script language='javascript'>alert('" + Message + "');</script>"
            //    );
            //}
        
        public void SearchPerson()
        {
            bool result = false;
            SqlCommand PersonalQueryCmd = new SqlCommand("Select * from tblPerson", Conn);
            Conn.Open();
            using (SqlDataReader reader = PersonalQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (UserId.nPersonId.Equals(Convert.ToInt32(reader["PERSONID"])) || Update.strUserId.Equals(reader["FIRSTNAME"]))
                    {
                        result = true;
                        UserId.nPersonId = reader.GetInt32(0);
                        TextBox1.Text = reader.GetString(1);
                        TextBox2.Text = reader.GetString(2);
                        if (reader.GetString(3) == "Male")
                        {
                            RadioButtonList_New.SelectedValue = "1";
                        }
                        else if (reader.GetString(3) == "Female")
                        {
                            RadioButtonList_New.SelectedValue = "2";
                        }
                        else
                        {
                            RadioButtonList_New.SelectedValue = "3";
                        }
                        TextBox4.Text = reader.GetDateTime(4).ToString("yyyy/MM/dd");
                    }
                }
            }
              if(result == false)
               {
                  string Message = "Invalide data";
                  Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox","<script language='javascript'>alert('" + Message + "');</script>");
               }
        }
        public void Update_Person()
        {
            string Fname = TextBox1.Text;
            string Lname = TextBox2.Text;
            string Gender = RadioButtonList_New.SelectedItem.Text;
            DateTime Dob = DateTime.Parse(TextBox4.Text);
            SqlCommand PersonalQueryUpate = new SqlCommand("UPDATE tblPerson SET FIRSTNAME=@fname, LASTNAME=@lname, GENDER=@gender ,DOB=@date WHERE PERSONID=@personid", Conn);
            PersonalQueryUpate.Parameters.AddWithValue("@personid", nPersonId);
            PersonalQueryUpate.Parameters.AddWithValue("@fname", Fname);
            PersonalQueryUpate.Parameters.AddWithValue("@lname", Lname);
            PersonalQueryUpate.Parameters.AddWithValue("@gender", Gender);
            PersonalQueryUpate.Parameters.AddWithValue("@date", Dob);
            Conn.Open();
            PersonalQueryUpate.ExecuteNonQuery();
            Conn.Close();
        }

    }
}