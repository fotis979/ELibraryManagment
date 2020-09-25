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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Go Button
        protected void LinkButtonID_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        //Active Button
        protected void LinkButtonActive_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }

        //Pending Button
        protected void LinkButtonPending_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }

        //Deactive Button
        protected void LinkButtonDeactive_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }

        //Delete Button
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }


        //User Define Function
        bool checkIfMemberExists()
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


        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                SqlConnection con = new SqlConnection();
                try
                {
                    con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBoxMemberID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
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
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }



        void getMemberByID()
        {
            SqlConnection con = new SqlConnection();

            try
            {
                con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBoxMemberID.Text.Trim() +"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        TextBoxFullName.Text = dr.GetValue(1).ToString();
                        TextBoxAccountStatus.Text= dr.GetValue(10).ToString();
                        TextBoxDOB.Text = dr.GetValue(2).ToString();
                        TextBoxContactNo.Text = dr.GetValue(3).ToString();
                        TextBoxEmailID.Text = dr.GetValue(4).ToString();
                        TextBoxState.Text = dr.GetValue(5).ToString();
                        TextBoxCity.Text = dr.GetValue(6).ToString();
                        TextBoxPinCode.Text = dr.GetValue(7).ToString();
                        TextBoxFullAddress.Text = dr.GetValue(8).ToString();

                       
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
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

        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                SqlConnection con = new SqlConnection();
                try
                {
                    con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBoxMemberID.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");


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

        void clearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxFullName.Text = "";
            TextBoxAccountStatus.Text = "";
            TextBoxDOB.Text = "";
            TextBoxContactNo.Text = "";
            TextBoxEmailID.Text = "";
            TextBoxState.Text = "";
            TextBoxCity.Text = "";
            TextBoxPinCode.Text = "";
            TextBoxFullAddress.Text = "";

          
        }




    }     
}