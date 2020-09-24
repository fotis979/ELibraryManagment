using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["role"]!=null && Session["role"].Equals("") || Session["role"] == null)
                {
                    LinkBtnUserLogin.Visible = true; // user login link button
                    LinkBtnSignUp.Visible = true; // sign up link button

                    LinkBtnLogout.Visible = false; // logout link button
                    LinkBtnHelloUser.Visible = false; // hello user link button


                    LinkBtnAdminLogin.Visible = true; // admin login link button
                    LinkBtnAuthorManagment.Visible = false; // author management link button
                    LinkBtnPublisherManagement.Visible = false; // publisher management link button
                    LinkBtnBookInvetory.Visible = false; // book inventory link button
                    LinkBtnBookIssuing.Visible = false; // book issuing link button
                    LinkBtnMemberManagement.Visible = false; // member management link button

                }
                else if (Session["role"] != null &&  Session["role"].Equals("user"))
                {
                    LinkBtnUserLogin.Visible = false; // user login link button
                    LinkBtnSignUp.Visible = false; // sign up link button

                    LinkBtnLogout.Visible = true; // logout link button
                    LinkBtnHelloUser.Visible = true; // hello user link button
                    LinkBtnHelloUser.Text = "Hello " + Session["username"].ToString();


                    LinkBtnAdminLogin.Visible = true; // admin login link button
                    LinkBtnAuthorManagment.Visible = false; // author management link button
                    LinkBtnPublisherManagement.Visible = false; // publisher management link button
                    LinkBtnBookInvetory.Visible = false; // book inventory link button
                    LinkBtnBookIssuing.Visible = false; // book issuing link button
                }
                else if (Session["role"] != null && Session["role"].Equals("admin"))
                {
                    LinkBtnUserLogin.Visible = false; // user login link button
                    LinkBtnSignUp.Visible = false; // sign up link button

                    LinkBtnLogout.Visible = true; // logout link button
                    LinkBtnHelloUser.Visible = true; // hello user link button
                    LinkBtnHelloUser.Text = "Hello Admin";


                    LinkBtnAdminLogin.Visible = false; // admin login link button
                    LinkBtnAuthorManagment.Visible = true; // author management link button
                    LinkBtnPublisherManagement.Visible = true; // publisher management link button
                    LinkBtnBookInvetory.Visible = true; // book inventory link button
                    LinkBtnBookIssuing.Visible = true; // book issuing link button
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkBtnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkBtnAuthorManagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkBtnPublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkBtnBookInvetory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkBtnBookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkBtnMemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkBtnViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkBtnUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkBtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkBtnLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkBtnUserLogin.Visible = true; // user login link button
            LinkBtnSignUp.Visible = true; // sign up link button

            LinkBtnLogout.Visible = false; // logout link button
            LinkBtnHelloUser.Visible = false; // hello user link button


            LinkBtnAdminLogin.Visible = true; // admin login link button
            LinkBtnAuthorManagment.Visible = false; // author management link button
            LinkBtnPublisherManagement.Visible = false; // publisher management link button
            LinkBtnBookInvetory.Visible = false; // book inventory link button
            LinkBtnBookIssuing.Visible = false; // book issuing link button
            LinkBtnMemberManagement.Visible = false; // member management link button

            Response.Redirect("homepage.aspx");
        }

        protected void LinkBtnHelloUser_Click(object sender, EventArgs e)
        {

        }
    }
}