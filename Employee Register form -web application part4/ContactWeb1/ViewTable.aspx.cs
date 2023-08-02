using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using static ContactWeb1.ViewTable;
using System.Runtime.Remoting.Messaging;
using System.Web.Security;

namespace ContactWeb1
{
    public partial class ViewTable : Page
    {
        public class Person
        {
            public int PERSONID { get; set; }
            public string FIRSTNAME { get; set; }
            public string LASTNAME { get; set; }
            public string GENDER { get; set; }
            public string DOB { get; set; }
            public List<Contact> contact
            {
                get
                {
                    return ContactDataAccessLayer.GetContactByPerson(this.PERSONID);
                }
            }
            public List<Address> address
            {
                get
                {
                    return AddressDataAccessLayer.GetAddressByPerson(this.PERSONID);
                }
            }
        }
        public class Contact
        {
            public int PERSONID { get; set; }
            public string CONTACTTYPE { get; set; }
            public string EMAIL { get; set; }
            public long MOBILE { get; set; }
            public long PHONE { get; set; }

        }
        public class Address
        {
            public int PERSONID { get; set; }
            public string ADDRESSTYPE { get; set; }
            public int DOORNO { get; set; }
            public string STREET { get; set; }
            public string CITY { get; set; }
            public string DISTRICT { get; set; }
            public string STATE { get; set; }
            public string COUNTRY { get; set; }
            public int PINCODE { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1_RowDataBound();
            if (!IsPostBack)
            {
                GridView1.DataSource = PersonDataAccessLayer.GetAllPerson();
                GridView1.DataBind();
            }
        }
        public class PersonDataAccessLayer
        {
            public static List<Person> GetAllPerson()
            {
                List<Person> PersonDetails = new List<Person>();

                string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * from tblPerson", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person data = new Person();
                        data.PERSONID = reader.GetInt32(0);
                        data.FIRSTNAME = reader.GetString(1);
                        data.LASTNAME = reader.GetString(2);
                        data.GENDER = reader.GetString(3);
                        data.DOB = reader.GetDateTime(4).ToString("yyyy/MM/dd");
                        PersonDetails.Add(data);
                    }
                }

                return PersonDetails;
            }
        }
        public class ContactDataAccessLayer
        {
            public static List<Contact> GetContactByPerson(int ContactPersonId)
            {
                List<Contact> ContactDetails = new List<Contact>();

                string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * from  tblContact where PERSONID = @ContinentId", con);
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@ContinentId";
                    parameter.Value = ContactPersonId;
                    cmd.Parameters.Add(parameter);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Contact contact = new Contact();
                        //country.PersonId = Convert.ToInt32(rdr["CountryId"]);
                        contact.PERSONID = reader.GetInt32(0);
                        contact.CONTACTTYPE = reader.GetString(1);
                        contact.EMAIL = reader.GetString(2);
                        contact.MOBILE = reader.GetInt64(3);
                        contact.PHONE = reader.GetInt64(4);

                        ContactDetails.Add(contact);
                    }
                }

                return ContactDetails;
            }
        }
        public class AddressDataAccessLayer
        {
            public static List<Address> GetAddressByPerson(int PersonId)
            {
                List<Address> AddressDetails = new List<Address>();

                string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * from  tblAddress where PERSONID = @ContinentId", con);
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@ContinentId";
                    parameter.Value = PersonId;
                    cmd.Parameters.Add(parameter);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Address address = new Address();
                        //country.PersonId = Convert.ToInt32(rdr["CountryId"]);
                        address.PERSONID = reader.GetInt32(0);
                        address.ADDRESSTYPE = reader.GetString(1);
                        address.DOORNO = reader.GetInt32(2);
                        address.STREET = reader.GetString(3);
                        address.CITY = reader.GetString(4);
                        address.DISTRICT = reader.GetString(5);
                        address.STATE = reader.GetString(6);
                        address.COUNTRY = reader.GetString(7);
                        address.PINCODE = reader.GetInt32(8);
                        AddressDetails.Add(address);
                    }
                }

                return AddressDetails;
            }

        }



        //protected void GridViewGroup_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    GridView gvOrders = sender as GridView;

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (User.IsInRole("Konferanse_Read") || User.IsInRole("Konferanse_Update") || User.IsInRole("Konferanse_Delete"))
        //        {
        //            string constr = ConfigurationManager.ConnectionStrings["DatabaseVestConnectionString1"].ConnectionString;
        //            SqlConnection con = new SqlConnection(constr);

        //            SqlCommand cmd;

        //            con.Open();

        //            string courseId = GridView1.DataKeys[0].Values["CourseID"].ToString();


        //            string checkChildOwner = "SELECT AdminOfficerOfCaseEmail FROM konferanse_Register WHERE CourseID =@CourseID";

        //            cmd = new SqlCommand(checkChildOwner, con);
        //            cmd.Parameters.AddWithValue("@CourseID", courseId);

        //            string valueChildOwner = cmd.ExecuteScalar() as string;

        //            MembershipUser memberEmail = Membership.GetUser();
        //            string AdminEmail = memberEmail.Email.Trim();

        //            if (valueChildOwner != null && !valueChildOwner.Equals(AdminEmail))
        //            {
        //                gvOrders.Columns[1].Visible = false;
        //                gvOrders.Columns[3].Visible = false;
        //                gvOrders.Columns[4].Visible = false;

        //            }

        //            con.Close();
        //        }
        //    }
        //}
    }

}









