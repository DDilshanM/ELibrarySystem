<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="ELibrarySystem.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img width="100%" src="images/home-bg.jpg" <%--class="img-fluid"--%> />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                    <%--  --%>
                </div>
            </div>
            
             <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="images/digital-inventory.png" />
                    <h4>Digital Book Inventory</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>

                  <div class="col-md-4">
                    <center>
                    <img width="150px"  src="images/search-online.png"  />
                    <h4>Search Books</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>

                  <div class="col-md-4">
                    <center>
                    <img width="150px"  src="images/defaulters-list.png" />
                    <h4>Default List</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>
            </div>

        </div>
    </section>
    <section>
        <img width="100%" src="images/in-homepage-banner.jpg" <%--class="img-fluid"--%> />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Process</h2>
                        <p><b>We have simple 3 process</b></p>
                    </center>
                    
                </div>
            </div>
            
             <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="images/sign-up.png" />
                    <h4>Sign Up</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>

                  <div class="col-md-4">
                    <center>
                    <img width="150px"  src="images/search-online.png"  />
                    <h4>Search Books</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>

                  <div class="col-md-4">
                    <center>
                    <img width="150px"  src="images/library.png" />
                    <h4>Visit Us</h4>
                    <p class="text-justify">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                        xxxxxxxxxxxxxxxxxxxxxxxxxxx
                    </p>
                    </center>
                    
                </div>
            </div>

        </div>
    </section>
</asp:Content>
