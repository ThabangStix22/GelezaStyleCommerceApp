<%@ Page Title="Manager Update School" Async="True" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update_School.aspx.cs" Inherits="GelezaStyleWebApp.bootstrap.ManagerUpdateSchool" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
<form runat="server" >
   <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Add New School</h1>
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
                   School has been successfully updated!
                       </div>
                </div>

                     <div>
                        <div id="FailRegistrationAlert" runat="server" visible="false" class="alert alert-danger" role="alert">
                            Error! School email already exists.
                         </div>
                   </div>


        <div class="col-md-6">       
          <div class="card card-primary"  id="RegistrationBox" runat="server" Visible="true">
            <div class="card-header">
              <h3 class="card-title">School information</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName" >School Name</label>
                <input type="text" id="inputName" class="form-control" runat="server" required placeholder="e.g Phutaditjaba High School">
              </div>
              <div class="form-group">
                <label for="inputAddress" >School Address</label>
                <input type="text" id="inputAddress" class="form-control" runat="server" required placeholder="e.g 1 Thutlwa Street">
              </div>
             <!-- <div class="form-group">
                <label for="inputStatus">Status</label>
                <select id="inputStatus" class="form-control custom-select">
                  <option selected disabled>Select one</option>
                  <option>On Hold</option>
                  <option>Canceled</option>
                  <option>Success</option>
                </select>
              </div>-->
              <div class="form-group">
                <label for="inputContactNo">Contact Number</label>
                <input type="tel" id="inputContactNo" class="form-control" runat="server" maxlength="10" required placeholder="e.g 011 876 7788">
              </div>
              <div class="form-group">
                <label for="inputEmail">Email Address</label>
                <input type="email" id="inputEmail" class="form-control" runat="server" required placeholder="email@domain.co.za">
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
          <asp:button OnClick="btnUpdateSchool" runat="server" type="submit" text="Update School Info" class="btn btn-success float-right"></asp:button>
          </div> 

        </div>
      </div>
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
 </form>
</asp:Content>


