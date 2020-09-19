<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto"  >
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col img-container">
                                  
                                     <img width="100" src="imgs/generaluser.png" />
                                   
                            </div>
                        </div>
                         
                        <div class="row">
                            <div class="col img-container">
                                 
                                     <h4>Member Sign Up</h4>
                                   
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                 <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">                                   
                                    <label>Full Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxFullName" runat="server" placeholder="Full Name"></asp:TextBox>                                 
                                    </div>
                            </div>
                            <div class="col-md-6">                                 
                                    <label>Date of Birth</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxDateOfBirth" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>                                
                                    </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">                                   
                                    <label>Contact No</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxContactNo" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>                                 
                                    </div>
                            </div>
                            <div class="col-md-6">                                 
                                    <label>Email ID</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxEmaiID" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>                                
                                    </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">                                   
                                    <label>State</label>
                                    <div class="form-group">
                                        <asp:DropDownList Class="form-control" ID="DropDownListState" runat="server">
                                         <asp:ListItem Text="Select" Value="select"/>
                                         <asp:ListItem Text="Αττική" Value="Αττική" />
                                         <asp:ListItem Text="Στερεά Ελλάδα" Value="Στερεά Ελλάδα" />
                                         <asp:ListItem Text="Κεντρική Μακεδονία" Value="Κεντρική Μακεδονία" />
                                         <asp:ListItem Text="Κρήτη" Value="Κρήτη" />
                                         <asp:ListItem Text="Ανατολική Μακεδονία & Θράκη" Value="Ανατολική Μακεδονία & Θράκη" />
                                         <asp:ListItem Text="Ήπειρος" Value="Ήπειρος" />
                                         <asp:ListItem Text="Ιόνιοι Νήσοι" Value="Ιόνιοι Νήσοι" />
                                         <asp:ListItem Text="Βόρειο Αιγαίο" Value="Βόρειο Αιγαίο" />
                                         <asp:ListItem Text="Πελοπόννησος" Value="Πελοπόννησος" />
                                         <asp:ListItem Text="Νότιο Αιγαίο" Value="Νότιο Αιγαίο" />
                                         <asp:ListItem Text="Θεσσαλία" Value="Θεσσαλία" />
                                         <asp:ListItem Text="Δυτική Ελλάδα" Value="Δυτική Ελλάδα" />
                                         <asp:ListItem Text="Δυτική Μακεδονία" Value="Δυτική Μακεδονία" />
                                         
                                    </asp:DropDownList>
                                    </div>
                            </div>
                            <div class="col-md-4">                                 
                                    <label>City</label>
                                    <div class="form-group">
                                        <asp:TextBox Class="form-control" ID="TextBoxCity" runat="server" placeholder="City" ></asp:TextBox>                                
                                    </div>
                            </div>
                            <div class="col-md-4">                                 
                                    <label>Pin Code</label>
                                    <div class="form-group">
                                        <asp:TextBox Class="form-control" ID="TextBoxPinCode" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>                                
                                    </div>
                            </div>
                        </div>
                        

                       <div class="row">
                            <div class="col">                                   
                                    <label>Full Address</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxFullAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>                                 
                                     </div>
                            </div>                            
                        </div>

                        <div class="row">        
                            <div class="col"> 
                                  <center>
                                    <span class="badge badge-pill badge-info">Login Credentials</span>
                                  </center>
                             </div> 
                         </div>
                        

                        <div class="row">
                            <div class="col-md-6">                                   
                                    <label>Member ID</label>
                                    <div class="form-group">
                                         <asp:TextBox Class="form-control" ID="TextBoxMemberID" runat="server" placeholder="User ID" ></asp:TextBox>                                 
                                    </div>
                            </div>
                            <div class="col-md-6">                                 
                                    <label>Password</label>
                                     <div class="form-group">
                                        <asp:TextBox Class="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>                                
                                    </div>
                             </div>
                        </div>
                        
                        
                         <div class="row">
                             <div class="col"> 
                                <div class="form-group">
                                    <asp:Button class="btn btn-success  btn-block  btn-lg" ID="BtnSignUp" runat="server" Text="SignUp" OnClick="BtnSignUp_Click"   />
                                 </div>
                            </div>
                        </div>



                     </div>
                  
                </div>
                 <a href="homepage.aspx"><< Back to Home</a><br ><br >
            </div>
        </div>
    </div>

</asp:Content>
