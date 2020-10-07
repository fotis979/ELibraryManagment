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
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString().Equals("")  || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        //Update Button Click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString().Equals("") || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }


        //User Define Publisher
        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBoxNewPassword.Text.Trim() == "")
            {
                password = TextBoxOldPassword.Text.Trim();
            }
            else
            {
                password = TextBoxNewPassword.Text.Trim();
            }
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBoxFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBoxDateOfBirthDay.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBoxContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBoxEmailID.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownListState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBoxCity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBoxPinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBoxAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
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

        void getUserPersonalDetails()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBoxFullName.Text = dt.Rows[0]["full_name"].ToString();
                TextBoxDateOfBirthDay.Text = dt.Rows[0]["dob"].ToString();
                TextBoxContactNo.Text = dt.Rows[0]["contact_no"].ToString();
                TextBoxEmailID.Text = dt.Rows[0]["email"].ToString();
                DropDownListState.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBoxCity.Text = dt.Rows[0]["city"].ToString();
                TextBoxPinCode.Text = dt.Rows[0]["pincode"].ToString();
                TextBoxAddress.Text = dt.Rows[0]["full_address"].ToString();
                TextBoxUserID.Text = dt.Rows[0]["member_id"].ToString();
                TextBoxOldPassword.Text = dt.Rows[0]["password"].ToString();

                LabelAccountState.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    //Response.Write("<script>alert('active');</script>");
                    LabelAccountState.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    //Response.Write("<script>alert('pending');</script>");
                    LabelAccountState.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    //Response.Write("<script>alert('deactive');</script>");
                    LabelAccountState.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    //Response.Write("<script>alert('Nothing');</script>");
                    LabelAccountState.Attributes.Add("class", "badge badge-pill badge-info");
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


        void getUserBookData()
        {
            SqlConnection con = new SqlConnection();

            try
            {
                con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                GridView1.DataSource = dt;
                GridView1.DataBind();


                //if (dt.Rows.Count >= 1)
                //{
                //    TextBoxPublisherName.Text = dt.Rows[0][1].ToString();
                //}
                //else
                //{
                //    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                //    clearForm();
                //}
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}