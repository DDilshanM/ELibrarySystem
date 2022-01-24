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
    public partial class bookInventory : System.Web.UI.Page

    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string ifilepath;
        static int act_stock, cur_stock,iss_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }
        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            addNewBook();
        }

        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBook();
        }

        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBook();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            getdetails();
        }

        //fill author name and pulisher name
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        //add new book
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
                string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genere,author_name,publisher_name,publish_date,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genere,@author_name,@publisher_name,@publish_date,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genere", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                //cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

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

        //go button
        void getdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='"+TextBox1.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();

                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    ListBox1.ClearSelection();

                    string[] genere = dt.Rows[0]["genere"].ToString().Trim().Split(',');
                    //how mny elemnts in genre
                    for(int i=0;i<genere.Length; i++)
                    {
                        //check every ite in the check box
                        for(int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genere[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            else
                            {
                                ListBox1.Items[j].Selected = false;
                            }
                        }
                    }

                    act_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    cur_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    iss_books = act_stock - cur_stock;
                    ifilepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid book id.');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        //update book

        void updateBook()
        {
            try
            {
                int bact_stock = Convert.ToInt32(TextBox4.Text.Trim());
                int bcurr_stock = Convert.ToInt32(TextBox5.Text.Trim());

                if (act_stock == bact_stock)
                {
                    TextBox5.Text = "" + bact_stock;
                }
                else
                {
                    if (act_stock < bcurr_stock)
                    {
                        Response.Write("<script>alert('Added wrong.');</script>");
                    }
                    else
                    {
                        bcurr_stock = bact_stock - iss_books;
                        TextBox5.Text = "" + bcurr_stock;
                    }
                }

                        string generes = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    generes = generes + ListBox1.Items[i] + ",";
                }
                generes = generes.Remove(generes.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if(filename=="" || filename == null)
                {
                    filepath = ifilepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/"+filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("UPDATE * FROM member_master_tbl SET account_status='"+ status +"' WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genere=@genere, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, " +
                    "edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock," +
                    " book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genere", generes);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock",bact_stock.ToString());
                cmd.Parameters.AddWithValue("@current_stock",bcurr_stock.ToString());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Updated Successfully');</script>");
               




            }
            catch (Exception ex)
            {



            }
        }

        void deleteBook()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' ", con);
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