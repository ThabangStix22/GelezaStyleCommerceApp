<%@ Page Title="Assign New School" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_New_School.aspx.cs" Inherits="GelezaStyleWebApp.Assign_New_School" %>

   <asp:Content ID="Content4" ContentPlaceHolderID="MasterHeadPlaceHolder" runat="server"> 
      
   </asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
    <script src="plugins/jquery/jquery.js"></script>
     <script src="Scripts/jquery-3.6.0.js"></script>
       <script type="text/javascript"> 
           $(document).ready(function () {
               var availableSchools = $('#AvailableSchools').val();
               $('#SelectSchool').click(function () {
                   $.ajax({
                       type: 'GET',
                       url: 'http://localhost:5000/api/School/GetActiveSchools/1',
                       datatype: 'json',
                       contentType:'application/json',
                       success: function (data) {
                           activeSchools.empty();
                           $.each(data, function (index, val) {
                               var schoolNames = activeSchools.SchName;
                               var schoolID = activeSchools.SchID;
                               availableSchools.append('<option data-id="'+schoolID+'">' + schoolNames + '</option>');
                           });
                       }

                   });
               });

           });
       </script>
   <form runat="server" method="post" id="schoolFormData">

   <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Assign School To Item</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Assign Item to School</a></li>
              <li class="breadcrumb-item active">Assign item</li>
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
                            Item has been successfully assigned to school!
                         </div>
                    </div>

                     <div>
                        <div id="FailRegistrationAlert" runat="server" visible="false" class="alert alert-danger" role="alert">
                            Error! Item already assigned.
                         </div>
                   </div>
        <div class="col-md-6">
                 
          <div class="card card-primary"  id="RegistrationBox" runat="server" Visible="true">
            <div class="card-header">
              <h3 class="card-title">Available Registered Schools</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
            <div class="form-group" data-select2-id="29">
                  <label>Which schools would you like to assign your item to?</label>
                  <asp:ListBox ID="SelectedSchools" runat="server" class="select2 select2-hidden-accessible"
                      selectionMode="Multiple" multiple="true" data-placeholder="Select a School" style="width: 100%;" 
                      tabindex="-1" aria-hidden="true">
                  </asp:ListBox>
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
          <a href="Assign_Item_To_School.aspx" class="btn btn-secondary">Cancel</a>
         
           
             <asp:button OnClick="btnAssignItem" runat="server" type="submit" text="Assign Item" class="btn btn-success float-right"></asp:button>
          </div> 

        </div>
      </div>
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
 </form>
   
</asp:Content>
