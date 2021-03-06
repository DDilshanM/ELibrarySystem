using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrarySystem
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAuthorPublisherValue();
            GridView1.DataBind();
        }

        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        //get data
        void fillAuthorPublisherValue()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd=new SqlCommand("SELECT publisher_name from publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch(Exception ex)
            {
                
            }

        }

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "'OR book_name='"+ TextBox2.Text.Trim()+ "';", con);
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

        //add new book
        //void addNewBook()
        //{
        //    try 
        //    {
        //        string genres = "";
        //        foreach(int i in ListBox1.GetSelectedIndices())
        //        {
        //            genres = genres + ListBox1.Items[i] + ",";
        //        }
        //        genres = genres.Remove(genres.Length - 1);

        //        string filepath = "~/book_inventory/books1.png";
        //       string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
        //        filepath= "~/book_inventory/"+filename;


        //        SqlConnection con = new SqlConnection(strcon);
        //        if(con.State==ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        //SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genere,author_name,publisher_name," +
        //        // "publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link)" +
        //        //"VALUES(@book_id,@book_name,@genere,@author_name,@publisher_name,@publish_date,@language,@edition," +
        //        //"@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
        //        SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genere,author_name,publisher_name,publish_date,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock) " +
        //            "values(@book_id,@book_name,@genere,@author_name,@publisher_name,@publish_date,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

        //        cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
        //        cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
        //        cmd.Parameters.AddWithValue("@genere", genres);
        //        cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
        //        cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
        //        cmd.Parameters.AddWithValue("@publish_date", TextBox8.Text.Trim());
        //        //cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
        //        cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
        //        cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
        //        cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
        //        cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
        //        cmd.Parameters.AddWithValue("@actual_stock", TextBox1.Text.Trim());
        //        cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
        //        cmd.Parameters.AddWithValue("@book_img_link", filepath);

        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        Response.Write("<script>alert('User Register is successful......');</script>");



        //    }
        //    catch(Exception ex) 
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }
        //}

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                                                   
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genere,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock) VALUES (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox1.Text.Trim());
                //cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}