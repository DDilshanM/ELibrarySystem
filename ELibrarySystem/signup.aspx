<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="ELibrarySystem.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col"> 
                                <center>`
                                    <h4>User Sign Up</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr/>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Date Of Birth</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                     <asp:ListItem Text="Uva" Value="Uva"></asp:ListItem>
                                     <asp:ListItem Text="Western" Value="Western"></asp:ListItem>
                                     <asp:ListItem Text="Central" Value="Central"></asp:ListItem>
                                     <asp:ListItem Text="Sabaragamuwa" Value="Select"></asp:ListItem>
                                     <asp:ListItem Text="North Western" Value="North Western"></asp:ListItem>
                                     <asp:ListItem Text="North Central" Value="North Central"></asp:ListItem>
                                     <asp:ListItem Text="Nothern" Value="Nothern"></asp:ListItem>
                                     <asp:ListItem Text="Eastern" Value="Eastern"></asp:ListItem>
                                     <asp:ListItem Text="Southern Province" Value="Southern Province" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                                </div>
                            </div>
                                <div class="col-md-4">
                                <label>Pin Number</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                        <br />
                         <div class="row">
                            <div class="col">
                                <center>
                                     <span class="badge bg-info text-dark">Login Credentials</span>
                                </center>
                             
                                
                                
                            </div>
                        </div>
                           <div class="row">
                            <div class="col-md-6">
                                <label>User Id</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="User Id"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />
                         <div class="row">
                            <div class="col">
                                
                                <div class="form-group">
                                <asp:Button width="100%" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                                <br />
                                
                                
                            </div>
                        </div>

                    </div>

                </div>
              
            </div>

        </div>
    </div>
</asp:Content>
