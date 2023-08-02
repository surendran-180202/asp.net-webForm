using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ContactWeb1.ViewTable;

namespace ContactWeb1
{
    public partial class AddMore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void Save_data(object sender, EventArgs e)
        {
            UserId.AddMoreUserId();
            Contact.Contact_Save();
            Address.Address_save();
            Response.Write("Student registeration Successfully!!!thank you");
        }
    }
}