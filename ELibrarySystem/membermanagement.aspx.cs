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
    public partial class membermanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {
           // Response.Write("<script>alert('go')</script>");
            getMemberByID();
        }

        //success
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateStatus("Active");
        }

        //pending
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateStatus("Pending");
        }

        //deactive
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateStatus("Deactve");
        }


        //delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            deleteMember();
        }

        //get Userdetails
        void getMemberByID()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "'",con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox1.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox5.Text = dr.GetValue(7).ToString();
                    }
                }
            }catch(Exception ex)
            {



            }
        }

       //update status
       void updateStatus(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("UPDATE * FROM member_master_tbl SET account_status='"+ status +"' WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member Status Updated');</script>");

                


            }
            catch (Exception ex)
            {



            }

        }

        void deleteMember()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "' ", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Delete is successful......');</script>");
                GridView1.DataBind();
            }
            catch
            {

            }
        }
    }
}