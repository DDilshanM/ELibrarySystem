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
    public partial class adminpublisher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfPublisher())
            {
                Response.Write("<script>alert('Publisher Id is in the Data Base')</script>");
            }
            else
            {
                addNewPublisher();
            }

        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisher())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID')</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisher())
            {
                deletePublisher();

            }
            else
            {
                Response.Write("<script>alert('Invalid ID')</script>");
            }
        }

        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getPublisher();

        }

        bool checkIfPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE pulisher_id='" + TextBox3.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        //add new publisher
        void addNewPublisher()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(pulisher_id,publisher_name) values(@pulisher_id,@publisher_name)", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@pulisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Adding is successful......');</script>");
                GridView1.DataBind();
            }
            catch
            {

            }
        }

        //update new publisher

        void updatePublisher()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE  publisher_master_tbl SET publisher_name=@pulisher_name WHERE pulisher_id='" + TextBox3.Text.Trim() + "' ", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);


                cmd.Parameters.AddWithValue("@pulisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update is successful......');</script>");
                GridView1.DataBind();
            }
            catch
            {

            }
        }

        //delete button

        void deletePublisher()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE publisher_master_tbl WHERE pulisher_id='" + TextBox3.Text.Trim() + "' ", con);
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

        //get publisher
        void getPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE pulisher_id='" + TextBox3.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }


    }
}