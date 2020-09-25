using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                Response.Write("<script>alert('Publisher with this ID already Exist. You cannot add another Author with the same Author ID');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }

        //User Define Publisher

        void getPublisherByID()
        {
            SqlConnection con = new SqlConnection();

            try
            {
                con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBoxPublisherId.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBoxPublisherName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                    clearForm();
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


        void deletePublisher()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from publisher_master_tbl  WHERE publisher_id='" + TextBoxPublisherId.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Succesfully');</script>");
                clearForm();
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


        void updatePublisher()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();


                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBoxPublisherId.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBoxPublisherName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Succesfully');</script>");
                clearForm();
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

        void addNewPublisher()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();


                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBoxPublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBoxPublisherName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher added Succesfully');</script>");
                clearForm();
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



        bool checkIfPublisherExist()
        {

            SqlConnection con = new SqlConnection();

            try
            {
                con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBoxPublisherId.Text.Trim() + "';", con);
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

      
        void clearForm()
        {
            TextBoxPublisherId.Text = "";
            TextBoxPublisherName.Text = "";
        }








    }
}