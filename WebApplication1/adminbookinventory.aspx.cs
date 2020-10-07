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

namespace WebApplication1
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }

            GridView1.DataBind();
        }

        protected void LinkBtnGo_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        //User define Function
        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                SqlConnection con = new SqlConnection();
                try
                {
                    con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + TextBoxBookID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBookByID()
        {

            if (checkIfBookExists())
            {
                SqlConnection con = new SqlConnection();

                try
                {

                    int actual_stock = Convert.ToInt32(TextBoxActualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBoxCurrentStock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBoxCurrentStock.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBoxGenre.GetSelectedIndices())
                    {
                        genres = genres + ListBoxGenre.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBoxBookID.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBoxBookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownListAuthorName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownListPublisherName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBoxPublishDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownListLanguage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBoxEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBoxBookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBoxPages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBoxBookDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }


        void getBookByID()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                  con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='" + TextBoxBookID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBoxBookName.Text = dt.Rows[0]["book_name"].ToString();
                    TextBoxPublishDate.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBoxEdition.Text = dt.Rows[0]["edition"].ToString();
                    TextBoxBookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBoxPages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBoxActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBoxCurrentStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBoxBookDescription.Text = dt.Rows[0]["book_description"].ToString();
                    TextBoxIssuedBooks.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownListLanguage.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownListPublisherName.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownListAuthorName.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBoxGenre.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBoxGenre.Items.Count; j++)
                        {
                            if (ListBoxGenre.Items[j].ToString() == genre[i])
                            {
                                ListBoxGenre.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                    
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        bool checkIfBookExists()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBoxBookID.Text.Trim() + "' OR book_name='" + TextBoxBookName.Text.Trim() + "';", con);
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void fillAuthorPublisherValues()
        {
                SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownListAuthorName.DataSource = dt;
                DropDownListAuthorName.DataValueField = "author_name";
                DropDownListAuthorName.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownListPublisherName.DataSource = dt;
                DropDownListPublisherName.DataValueField = "publisher_name";
                DropDownListPublisherName.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        void addNewBook()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                string genres = "";
                foreach (int i in ListBoxGenre.GetSelectedIndices())
                {
                    genres = genres + ListBoxGenre.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBoxBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownListAuthorName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownListPublisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBoxPublishDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownListLanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBoxEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBoxBookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBoxPages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBoxBookDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBoxActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBoxActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }


    }
}