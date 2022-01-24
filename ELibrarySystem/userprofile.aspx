<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ELibrarySystem.userprofile" %>
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
            <div class="col-md-5 ">
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
                                    <h4>Your Profile</h4>
                                    <span>Account Status</span>
                                    <asp:Label ID="Label1" class="badge bg-info text-dark" runat="server" Text="Your Status"></asp:Label>
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
                            <div class="col-md-4">
                                <label>User Id</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="User Id" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Password" TextMode="Password" ReadOnly="false"></asp:TextBox>
                                </div>
                            </div>
                                <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="New Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         

                        <br />
                         <div class="row">
                            <div class="col">
                                
                                <div class="form-group">
                                <asp:Button width="100%" class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                </div>
                                <br />
                                
                                
                            </div>
                        </div>

                    </div>

                </div>
              
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/books1.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col"> 
                                <center>`
                                    <h4>Your Issuued Books</h4>

                                    <asp:Label ID="Label2" class="badge bg-info text-dark" runat="server" Text="Your Book Info"></asp:Label>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                          

                          

                        
                       

                    </div>

                </div>
              
            </div>
            

        </div>
    </div>
</asp:Content>
