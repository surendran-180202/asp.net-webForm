using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static ContactWeb1.ViewTable;
namespace ContactWeb1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                UserId.nPersonId = 0;
            }
        }
        protected  void Save_data(object sender, EventArgs e)
        {
            Person1.persion_data();
            UserId.User_id();
            Contact.Contact_Save();
            Address.Address_save();
        }
        protected void AddMore(object sender, EventArgs e)
        {
            Response.Redirect("AddMore.aspx");
            //Contact.AddMore_Contact();
            //Address.AddMore_Address();
            //string title = "Greetings";
            //string body = "Welcome to ASPSnippets.com";
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
 }