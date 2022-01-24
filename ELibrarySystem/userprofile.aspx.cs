using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrarySystem
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserData();
            
            if (!Page.IsPostBack)
            {
                getUserDatails();
            }

        }

        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        //get book details to table
        void getUserData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl WHERE member_id='" + Session["username"].ToString() + "';", con);
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //get user details

        void getUserDatails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl WHERE member_id='" + Session["username"].ToString() + "';", con);
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                //TextBox2.Text = dt.Rows[0]["dob"].ToString();
                //TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                //TextBox4.Text = dt.Rows[0]["email"].ToString();
                //DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                //TextBox6.Text = dt.Rows[0]["city"].ToString();
                //TextBox9.Text = dt.Rows[0]["pincode"].ToString();
                //TextBox7.Text = dt.Rows[0]["full_address"].ToString();
                //TextBox5.Text = dt.Rows[0]["member_id"].ToString();
                //TextBox8.Text = dt.Rows[0]["password"].ToString();

               
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox2.Text = dt.Rows[0]["dob"].ToString();
                    TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox4.Text = dt.Rows[0]["email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["city"].ToString();
                    TextBox9.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox7.Text = dt.Rows[0]["full_address"].ToString();
                    TextBox5.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox8.Text = dt.Rows[0]["password"].ToString();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                    if (dt.Rows[0]["account_status"].ToString().Trim() == "Active")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-success");

                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-warning");

                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "Deactive")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-danger");

                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-secondary");
                    }
                
                    

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //checkin row for some proper values
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //date condition
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}