<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="ELibrarySystem.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0])
            }
    }

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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" height="150px" width="100px" src="book_inventory/books1.png"/>
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
                            <div class="col">
                            <asp:FileUpload onChange="readURL(this);"  CssClass="form-control"  ID="FileUpload1" runat="server" />
                            </div>
                        </div>


                         <div class="row">
                              <div class="col-md-4">
                                <label>Book Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button  class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                    </div>
                                 
                                </div>
                            </div>
                                <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name" ></asp:TextBox>
                                </div>
                            </div>
                           
                           

                        </div>

                         <br />
                        
                         <div class="row">
                                <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                 <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                     <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                     <asp:ListItem Text="Sinhala" Value="Sinhala"></asp:ListItem>
                                     <asp:ListItem Text="Tamil" Value="Tamil"></asp:ListItem>
                                 </asp:DropDownList>
                                </div>

                                     <label>Publisher Name</label>
                                <div class="form-group">
                                 <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                     <asp:ListItem Text="Gunasena" Value="Gunasena"></asp:ListItem>
                                     <asp:ListItem Text="Sunila" Value="Sunila"></asp:ListItem>
                                     <asp:ListItem Text="Sarasavi" Value="Sarasavi"></asp:ListItem>
                                 </asp:DropDownList>
                                </div>


                            </div>
                            <div class="col-md-4">
                                       <label>Author Name</label>
                                       <div class="form-group">
                                      <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                     <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                     <asp:ListItem Text="A2" Value="A2"></asp:ListItem>
                                     <asp:ListItem Text="A3" Value="A3"></asp:ListItem>
                                 </asp:DropDownList>
                                </div>
                                <label>Publisher Date</label>
                                <div class="form-group">
                                    
                                  <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Email ID" TextMode="Date"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>
                               <div class="col-md-4">
                                   <label>Genere</label>
                                   <div class="form-group">
                                   <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server">
                                       <asp:ListItem Text="d1" Value="d1"></asp:ListItem>
                                       <asp:ListItem Text="d2" Value="d3"></asp:ListItem>
                                       <asp:ListItem Text="d3" Value="d3"></asp:ListItem>
                                        <asp:ListItem Text="d4" Value="d4"></asp:ListItem>
                                       <asp:ListItem Text="d5" Value="d5"></asp:ListItem>
                                       <asp:ListItem Text="d6" Value="d6"></asp:ListItem>
                                   </asp:ListBox>
                                   
                            </div>

                        </div>

                        <br />
                        <div class="row">
                                <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Edition"  ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Book Cost" TextMode="Number"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>
                               <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>

                        </div>
                             <br />
                             <div class="row">
                                <div class="col-md-4">
                                <label>Actual Stoke</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Actual Stoke"  ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stoke</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Cost" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>
                               <div class="col-md-4">
                                <label>Issued</label>
                                <div class="form-group">
                                    
                                        <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Pin Code" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                     
                                 
                                </div>
                            </div>

                        </div>
                        <div class="row">
                                <div class="col-md-12">
                                <label>Discription</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Discription"  TextMode="MultiLine"></asp:TextBox>
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
                </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                      
                        <div class="row">
                            <div class="col"> 
                                <center>`
                                    <h4>Book List</h4>

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
                            
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" >
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="genere" HeaderText="genere" SortExpression="genere" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                        <asp:BoundField DataField="publish_date" HeaderText="publish_date" SortExpression="publish_date" />
                                        <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                        <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                        <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                        <asp:BoundField DataField="no_of_pages" HeaderText="no_of_pages" SortExpression="no_of_pages" />
                                        <asp:BoundField DataField="book_description" HeaderText="book_description" SortExpression="book_description" />
                                        <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                        <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                        <asp:BoundField DataField="book_img_link" HeaderText="book_img_link" SortExpression="book_img_link" />
                                    </Columns>
                                    
                                </asp:GridView>
                            </div>
                        </div>

                          

                          

                        
                       

                    </div>

                </div>
              
            </div>
            

        </div>
             </div>
         </div>
    
</asp:Content>
