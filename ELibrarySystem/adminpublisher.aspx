<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublisher.aspx.cs" Inherits="ELibrarySystem.adminpublisher" %>
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
     <div class="container">
        <div class="row">
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col"> 
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/publisher.png" />
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
                            <div class="col-md-4">
                                <label>Publisher Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Id"></asp:TextBox>
                                        <asp:Button  class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                 
                                </div>
                            </div>
                             <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         
                         

                        <br />
                         <div class="row">
                            <div class="col-4">
                                <asp:Button width="100%" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>
                             <div class="col-4">
                                <asp:Button width="100%" class="btn btn-warning btn-lg" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                             <div class="col-4">
                                <asp:Button width="100%" class="btn btn-danger btn-lg" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
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
                                    <h4>Publisher List</h4>

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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="pulisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="pulisher_id" HeaderText="pulisher_id" ReadOnly="True" SortExpression="pulisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
