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
    public partial class Update : Page
    {
       public static string strUserId { get; set; }
        protected void Page_Load(object sender, EventArgs e )
        {
            if (!IsPostBack)
            {
                strUserId = "";
                UserId.nPersonId = 0;   
            }
            bool res;
            string myStr = TextBox15.Text;
            res = int.TryParse(myStr, out _);
            if (res == true)
            {
                UserId.nPersonId = Int32.Parse(this.TextBox15.Text);
            }
            else
            {
                strUserId = TextBox15.Text;
            }
        }
        protected void Check_Data(object sender, EventArgs e) 
        {
            Person.SearchPerson();
            Contact.SearchContact();
            Address.SearchAddress();
        }
        protected void Update_btn(object sender,EventArgs e)
        {
            Person.Update_Person();
            Address.Update_Address();
            Contact.Update_Contact();
        }
          protected void Delete_btn(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand DeleteCmd = new SqlCommand(" DELETE FROM tblPerson WHERE PERSONID =@idnumber ", Conn);
            DeleteCmd.Parameters.AddWithValue("@idnumber", UserId.nPersonId);
            Conn.Open();    
            DeleteCmd.ExecuteNonQuery();
            Conn.Close();

        }
    }
}