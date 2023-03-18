<%@ Page Title="Manager Portal" async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager_Portal.aspx.cs" Inherits="GelezaStyleWebApp.ManagerPortal" %>


<asp:Content ID="Scripts" ContentPlaceHolderID="MasterHeadPlaceHolder" runat="server">
     
    <!--Bootstrap-->
  

</asp:Content>

       

<asp:Content ID="ContentBody" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
   
		
	    <!-- Page Content  -->
      <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Notifications</h1>
          </div>
          <div class="col-sm-6">
          <%--  <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item"><a href="#">Layout</a></li>
              <li class="breadcrumb-item active">Collapsed Sidebar</li>
            </ol>--%>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
     

    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
            <!-- Default box -->
            <div class="card" id="AlertDisplayMessage" runat="server">
              
            </div>
            <!-- /.card -->
          </div>
        </div>
      </div>
    </section>
    <!-- /.content -->

  

</asp:Content>


