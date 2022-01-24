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
    public partial class adminauthor : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                Response.Write("<script>alert('Author Id is in the Data Base')</script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID')</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                deleteAuthor();
                
            }
            else
            {
                Response.Write("<script>alert('Invalid ID')</script>");
            }
        }

        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getAuthor();
        }

        //check author id is same or not
        bool checkIfAuthorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='"+TextBox3.Text.Trim()+"';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               

            }catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        //add new author to db

        void addNewAuthor()
        {
            try {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                    SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Adding is successful......');</script>");
                GridView1.DataBind();
            }
            catch
            {

            }
        }

        //update author details
        void updateAuthor()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+TextBox3.Text.Trim()+"' ", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);

                
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update is successful......');</script>");
                GridView1.DataBind();
            }
            catch
            {

            }
        }

        //delete author details

        void deleteAuthor()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "' ", con);
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

        //go button
        void getAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
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