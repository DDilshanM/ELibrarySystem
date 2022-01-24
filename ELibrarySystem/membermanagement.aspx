<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="membermanagement.aspx.cs" Inherits="ELibrarySystem.membermanagement" %>
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
                                <center>`
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/generaluser.png" />
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
                              <div class="col-md-3">
                                <label>Member Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button  class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                 
                                </div>
                            </div>
                                <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Name" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                               <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Status" ReadOnly="true" ></asp:TextBox>
                                        <asp:LinkButton  class="btn btn-primary" ID="Button3" runat="server" Text="A" OnClick="Button3_Click" ><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton  class="btn btn-warning" ID="LinkButton1" runat="server" Text="S" OnClick="LinkButton1_Click"  ><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton  class="btn btn-danger" ID="LinkButton2" runat="server" Text="S" OnClick="LinkButton2_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                 
                                </div>
                            </div>
                           

                        </div>

                         <br />
                        
                         <div class="row">
                                <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="DOB" TextMode="Date" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Contact Number" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>
                               <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Email ID"  ReadOnly="true"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>

                        </div>

                        <br />
                        <div class="row">
                                <div class="col-md-3">
                                <label>State</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="State" ReadOnly="true"  ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>
                               <div class="col-md-5">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pin Code" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>

                        </div>
                        <div class="row">
                                <div class="col-md-12">
                                <label>Full Postal ID</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Member Name" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                           

                        </div>
                        <br />
                         <div class="row">
                            
                             
                             <div class="col-12">
                                <asp:Button width="100%" class="btn btn-danger btn-lg" ID="Button4" runat="server" Text="Delete Parmenently" OnClick="Button4_Click" />
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
                                <center>`
                                    <h4>Member List</h4>

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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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
