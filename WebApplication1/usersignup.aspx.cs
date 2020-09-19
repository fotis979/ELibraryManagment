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
    public partial class usersignup : System.Web.UI.Page

    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // sign up button click event
        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
           
            if (checkMemberExists())
            {

                Response.Write("<script>alert('member already exist with this member id, try other id');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }

        // user defined method
        bool checkMemberExists()
        {
             SqlConnection con = new SqlConnection();
           
            try
            {
                con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBoxMemberID.Text.Trim() + "';", con);
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

        /// <summary>
        /// Void signUpMember
        /// </summary>
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            SqlConnection con= new SqlConnection();
            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBoxFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBoxDateOfBirth.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBoxContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email",  TextBoxEmaiID.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownListState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBoxCity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBoxPinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBoxFullAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBoxMemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");                
                cmd.ExecuteNonQuery();               
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
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