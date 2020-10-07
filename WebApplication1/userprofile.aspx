<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                     <img width="100px" src="imgs/generaluser.png" />
                                  </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Your profile</h4>
                                     <span>Account Status - </span>
                                     <asp:Label Class="badge badge-pill badge-info" ID="LabelAccountState" runat="server" Text="Your Status"></asp:Label>
                                  </center>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBoxDateOfBirthDay" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEmailID" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownListState" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
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
                                    <asp:TextBox Class="form-control" ID="TextBoxCity" runat="server" placeholder="City"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBoxAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="TextBoxUserID" runat="server" placeholder="User ID" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="TextBoxOldPassword" runat="server" placeholder="Password" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="TextBoxNewPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="ButtonUpdate" runat="server" Text="Update" OnClick="Button1_Click" />
                                     </div>
                                 </center>
                            </div>
                        </div>



                    </div>



                </div>
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>


            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                     <img width="100px" src="imgs/books1.png" />
                                  </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Your Issued Books</h4>
                                     <asp:Label CssClass="badge badge-pill badge-info" ID="Label2" runat="server" Text="Your Books info"></asp:Label>
                                  </center>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <%--<asp:GridView AlternatingRowStyle-CssClass="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>--%>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                    
                            </div>

                        </div>


                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
