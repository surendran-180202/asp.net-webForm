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
    public partial class ContactDetails : System.Web.UI.UserControl
    {
        public string ContactType { get; set; }
        public bool a { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                if (ContactType == null)
                {
                    ContactType = "Personal";
                }
            }


        }
        protected void RadioBtnChange_Event(Object sender, EventArgs e)
        {
            if (RadioButtonList_New1.SelectedValue == "1")
            {
                a = false;
                ContactType = "Personal";
                SearchContact();
            }
            else
            {
                a = true;
                ContactType = "Office";
                SearchContact();
            }



        }
        public void Contact_Save()
        {
            try
            {
                string Email = TextBox5.Text;
                long Mobile = Convert.ToInt64(this.TextBox6.Text);
                long Phone = Convert.ToInt64(this.TextBox7.Text);
                string ContactType = RadioButtonList_New1.SelectedItem.Text;
                SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string strContactQuery = "insert into tblContact(PERSONID,EMAIL,MOBILE,PHONE,CONTACTTYPE)values (@personid,@email,@mobile,@phone,@contacttype)";
                SqlCommand ContactAddQueryCmd = new SqlCommand(strContactQuery, Conn);
                ContactAddQueryCmd.Parameters.AddWithValue("@personid", UserId.nPersonId);

                ContactAddQueryCmd.Parameters.AddWithValue("@contacttype", ContactType);
                ContactAddQueryCmd.Parameters.AddWithValue("@email", Email);
                Console.WriteLine("Enter MobileNO :");
                ContactAddQueryCmd.Parameters.AddWithValue("@mobile", Mobile);
                Console.WriteLine("Enter PhoneNO :");
                ContactAddQueryCmd.Parameters.AddWithValue("@phone", Phone);
                Conn.Open();
                ContactAddQueryCmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch
            {
            }

        }
        public void SearchContact()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand ContactQueryCmd = new SqlCommand("Select * from tblContact", Conn);
            Conn.Open();
            using (SqlDataReader reader = ContactQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (UserId.nPersonId.Equals(Convert.ToInt32(reader["PERSONID"])) && ContactType.Equals(reader["CONTACTTYPE"]))
                    {
                        if (a == true)
                        {
                            RadioButtonList_New1.SelectedValue = "2";
                        }
                        else
                        {
                            RadioButtonList_New1.SelectedValue = "1";
                        }

                        TextBox5.Text = reader.GetString(2);
                        TextBox6.Text = reader.GetInt64(3).ToString();
                        TextBox7.Text = reader.GetInt64(4).ToString();
                    }
                }
            }
            Conn.Close();
        }
        public void Update_Contact()
        {
            string Email = TextBox5.Text;
            long Mobile = Convert.ToInt64(this.TextBox6.Text);
            long Phone = Convert.ToInt64(this.TextBox7.Text);
            string ContactType = RadioButtonList_New1.SelectedItem.Text;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand ContactQueryUpdate = new SqlCommand("UPDATE tblContact SET EMAIL=@email, MOBILE=@mobile, PHONE=@phone  WHERE PERSONID=@personid AND CONTACTTYPE=@contacttype", Conn);
            ContactQueryUpdate.Parameters.AddWithValue("@personid", UserId.nPersonId);
            ContactQueryUpdate.Parameters.AddWithValue("@contacttype", ContactType);
            ContactQueryUpdate.Parameters.AddWithValue("@email", Email);
            Console.WriteLine("Enter MobileNO :");
            ContactQueryUpdate.Parameters.AddWithValue("@mobile", Mobile);
            Console.WriteLine("Enter PhoneNO :");
            ContactQueryUpdate.Parameters.AddWithValue("@phone", Phone);
            Conn.Open();
            ContactQueryUpdate.ExecuteNonQuery();
            Conn.Close();

        }
        public void AddMore_Contact()
        {
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            RadioButtonList_New1.SelectedItem.Text = "";
            
        }
    }
}