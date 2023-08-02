using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactWeb1
{
    public partial class Address : System.Web.UI.UserControl
    {
        public string addressTypeupdate { get; set; }
        public bool a { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (addressTypeupdate == null)
                {
                    addressTypeupdate = "Permanent";
                }
            }
        }
        public void Address_save()
        {
            try
            {
                int nPersonId = UserId.nPersonId;
                int DoorNo = Convert.ToInt32(this.TextBox8.Text);
                string Street = TextBox9.Text;
                string City = TextBox10.Text;
                string District = TextBox11.Text;
                string State = TextBox12.Text;
                string Country = TextBox13.Text;
                string addressType = RadioButtonList_New.SelectedItem.Text;
                int PinCode = Convert.ToInt32(this.TextBox14.Text);
                SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string strAddressQuery = "insert into tblAddress(PERSONID,ADDRESSTYPE,DOORNO,STREET,CITY,DISTRICT,STATE,COUNTRY,PINCODE)values (@personid,@addresstype,@doorno,@street,@city,@district,@state,@country,@pincode)";
                SqlCommand AddressAddQueryCmd = new SqlCommand(strAddressQuery, Conn);
                AddressAddQueryCmd.Parameters.AddWithValue("@personid", nPersonId);
                AddressAddQueryCmd.Parameters.AddWithValue("@addresstype", addressType);
                AddressAddQueryCmd.Parameters.AddWithValue("@doorno", DoorNo);
                AddressAddQueryCmd.Parameters.AddWithValue("@street", Street);
                AddressAddQueryCmd.Parameters.AddWithValue("@city", City);
                AddressAddQueryCmd.Parameters.AddWithValue("@district", District);
                AddressAddQueryCmd.Parameters.AddWithValue("@state", State);
                AddressAddQueryCmd.Parameters.AddWithValue("@country", Country);
                AddressAddQueryCmd.Parameters.AddWithValue("@pincode", PinCode);
                Conn.Open();
                AddressAddQueryCmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception e)
            {
                string message = "enter the address in crt format";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
            }
        }
        protected void RadioBtnChange_Event(Object sender, EventArgs e)
        {
            if (RadioButtonList_New.SelectedValue == "1")
            {
                a = false;
                addressTypeupdate = "Permanent";
                SearchAddress();
            }
            else
            {
                a = true;
                addressTypeupdate = "Residential";
                SearchAddress();
            }
        }
        public void SearchAddress()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand AddressQueryCmd = new SqlCommand("Select * from tblAddress", Conn);
            Conn.Open();
            using (SqlDataReader reader = AddressQueryCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   
                   if (UserId.nPersonId.Equals(Convert.ToInt32(reader["PERSONID"])) && addressTypeupdate.Equals(reader["ADDRESSTYPE"]) )
                   {
                        if (a == true)
                        {
                            RadioButtonList_New.SelectedValue = "2";
                        }
                        else 
                        {
                            RadioButtonList_New.SelectedValue = "1";
                        }
                        TextBox8.Text = reader.GetInt32(2).ToString();
                        TextBox9.Text = reader.GetString(3);
                        TextBox10.Text = reader.GetString(4);
                        TextBox11.Text = reader.GetString(5);
                        TextBox12.Text = reader.GetString(6);
                        TextBox13.Text = reader.GetString(7);
                        TextBox14.Text = reader.GetInt32(8).ToString();
                   }
                }
            }
            Conn.Close();
        }
        public void Update_Address()
        {
            int nPersonId = UserId.nPersonId;
            int DoorNo = Convert.ToInt32(this.TextBox8.Text);
            string Street = TextBox9.Text;
            string City = TextBox10.Text;
            string District = TextBox11.Text;
            string State = TextBox12.Text;
            string Country = TextBox13.Text;
            string addressType = RadioButtonList_New.SelectedItem.Text;
            int PinCode = Convert.ToInt32(this.TextBox14.Text);
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand AddressAddQueryCmd = new SqlCommand("UPDATE tblAddress SET ADDRESSTYPE=@addresstype,DOORNO=@doorno, STREET=@street, CITY=@city ,DISTRICT=@district ,STATE=@state,COUNTRY=@country, PINCODE=@pincode WHERE PERSONID=@personid AND ADDRESSTYPE=@addresstype ", Conn);
           // SqlCommand AddressAddQueryCmd = new SqlCommand(AddressQueryUpdate, Conn);
            AddressAddQueryCmd.Parameters.AddWithValue("@personid", nPersonId);
            AddressAddQueryCmd.Parameters.AddWithValue("@addresstype", addressType);
            AddressAddQueryCmd.Parameters.AddWithValue("@doorno", DoorNo);
            AddressAddQueryCmd.Parameters.AddWithValue("@street", Street);
            AddressAddQueryCmd.Parameters.AddWithValue("@city", City);
            AddressAddQueryCmd.Parameters.AddWithValue("@district", District);
            AddressAddQueryCmd.Parameters.AddWithValue("@state", State);
            AddressAddQueryCmd.Parameters.AddWithValue("@country", Country);
            AddressAddQueryCmd.Parameters.AddWithValue("@pincode", PinCode);
            Conn.Open();
            AddressAddQueryCmd.ExecuteNonQuery();
            Conn.Close();
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string json = (new WebClient()).DownloadString("https://localhost:44377/api/PostalCode");
            JToken result = JsonConvert.DeserializeObject("[" + json + "]") as JToken;
            List<ZipCode> roots = new List<ZipCode>();

            foreach (var item in result)
            {
                foreach (var i in item)
                {
                    if (i["zipCode"].ToString().Equals(Convert.ToString(TextBox14.Text)))
                    {
                        TextBox14.Text = i["zipCode"].ToString();
                        TextBox10.Text = i["City"].ToString();
                        TextBox11.Text = i["District"].ToString();
                        TextBox12.Text = i["State"].ToString();
                        TextBox13.Text = i["Country"].ToString();
                    }
                }
            }
        }
        public void AddMore_Address()
        {
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            RadioButtonList_New.SelectedItem.Text = "";
            TextBox14.Text = "";
        }
    }
}