<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="WebApplication1.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto"  >
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col img-container">
                                 
                                     <img width="150" src="imgs/generaluser.png" />
                                   
                            </div>
                        </div>
                         
                        <div class="row">
                            <div class="col img-container">
                                  
                                     <h3>Member Login</h3>
                                  
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                 <hr />
                            </div>
                        </div>

                         <div class="row">
                             <div class="col">
                                <div class="form-group">
                                    <label>Member ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBoxMemberId" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                
                                <div class="form-group">
                                    <asp:Button class="btn btn-success  btn-block  btn-lg" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                                 </div>
                                <div class="form-group">
                                    <a href="usersignup.aspx"  style="text-decoration:none;"><input class="btn btn-info  btn-block  btn-lg " id="BtnSignUp" type="button" value="Sign Up" /></a>
                                 </div>
                       

                            </div>
                        </div>



                     </div>
                    <a href="homepage.aspx"><< Back to Home</a><br><br>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
