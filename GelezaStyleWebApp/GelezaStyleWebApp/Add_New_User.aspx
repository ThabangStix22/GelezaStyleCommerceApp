<%@ Page Title="Add User" Async="True" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_New_User.aspx.cs" Inherits="GelezaStyleWebApp.AddUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">

    <form runat="server" >

   <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Add New User</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Project Add</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
           
      <div class="row">
          <div>
               <div id="SuccessRegistrationAlert" runat="server" visible="false" class="alert alert-success" role="alert">
                            User has been successfully registered!
                         </div>
                    </div>

                     <div>
                        <div id="FailRegistrationAlert" runat="server" visible="false" class="alert alert-danger" role="alert">
                            Error! User email already exists.
                         </div>
                   </div>
        <div class="col-md-6">
                 
          <div class="card card-primary"  id="RegistrationBox" runat="server" Visible="true">
            <div class="card-header">
              <h3 class="card-title">New User Information</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName" >First Names</label>
                <input type="text" id="inputName" class="form-control" runat="server" required placeholder="e.g Thato">
              </div>

              <div class="form-group">
                <label for="inputSurname" >Surname</label>
                <input type="text" id="inputSurname" class="form-control" runat="server" required placeholder="e.g. Maputla">
              </div>

                 <div class="form-group">
                <label for="inputRole">User Role</label>
                <select id="inputRole" class="form-control custom-select" runat="server">
                  <option selected disabled>Select user role</option>
                  <option value="Clerk">Clerk</option>
                  <option value="Manager">Manager</option>
                </select>
              </div>

              <div class="form-group">
                <label for="inputAddress" >Address</label>
                <input type="text" id="inputAddress" class="form-control" runat="server" required placeholder="e.g. 45 Mofolo Street">
              </div>

              <div class="form-group">
                <label for="inputContactNo">Contact Number</label>
                <input type="tel" id="inputContactNo" class="form-control" runat="server" maxlength="10" required placeholder="e.g 011 876 7788">
              </div>

              <div class="form-group">
                <label for="inputEmail">Email Address</label>
                <input type="email" id="inputEmail" class="form-control" runat="server" required placeholder="e.g. email@domain.co.za">
              </div>

              <div class="form-group">
                <label for="inputPassword" >Password</label>
                <input type="password" id="inputPassword" class="form-control" runat="server" required>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        
      </div>
      <div class="row" >
        <div class="col-12">
            
          <div id="ActionButtons" runat="server">
          <a href="Manage_Schools.aspx" class="btn btn-secondary">Cancel</a>
          <asp:button OnClick="btnCreateUser" runat="server" type="submit" text="Create New User" class="btn btn-success float-right"></asp:button>
          </div> 

        </div>
      </div>
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
 </form>
              

   
</asp:Content>

