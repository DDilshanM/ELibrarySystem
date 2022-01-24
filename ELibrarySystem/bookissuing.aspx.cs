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
    public partial class bookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            details();
        }

        //issue book
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookExist()&& checkMemberExist())
            {
                if (checkIssuebook())
                {
                    Response.Write("<script>alert('Cannot issue this book .....')</script>");
                }
                else
                {
                    issueBook();
                }
                
            }
            else
            {
                Response.Write("<script>alert('Invalid details .....')</script>");
            }
            //issueBook();
        }

        //return book
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkBookExist() && checkMemberExist())
            {
                if (checkIssuebook())
                {
                    returnBook();
                }
                else
                {
                    issueBook();
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid details .....')</script>");
            }

        }

        //get member name and book name
        void details()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book Id')</script>");
                }

               

                cmd = new SqlCommand("select full_name from member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");

                }
            }
            catch (Exception ex)
            {

            }
        }

        //check book in the library
        bool checkBookExist()
        {
            try
            {


                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "'AND current_stock>0 ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            
        }

        bool checkMemberExist()
        {
            try
            {


                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("SELECT full_name from member_master_tbl WHERE member_id'" + TextBox2.Text.Trim() + "' ", con);

                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        //check same book issued or not
        bool checkIssuebook()
        {
            try
            {


                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("SELECT full_name from member_master_tbl WHERE member_id'" + TextBox2.Text.Trim() + "' ", con);

                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='" + TextBox3.Text.Trim() + "'", con); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        //book issue
        void issueBook()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);

                //check connection success or not
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,,book_name,issue_date,due_date) " +
                //    "values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
               

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update book_master_tbl  set current_stock=current_stock-1 WHERE book_id='" + TextBox3.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book issued successful......');</script>");
                GridView1.DataBind();
            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void returnBook()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE  book_issue_tbl WHERE book_id='" + TextBox3.Text.Trim() + "' ", con);


                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("update book_master_tbl  set current_stock=current_stock+1 WHERE book_id='" + TextBox3.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Return Book....');</script>");
                GridView1.DataBind();
            }
            catch
            {

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
