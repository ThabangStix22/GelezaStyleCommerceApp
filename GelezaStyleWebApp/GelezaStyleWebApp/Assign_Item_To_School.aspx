<%@ Page Title="Assign Item To School" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assign_Item_To_School.aspx.cs" Inherits="GelezaStyleWebApp.Assign_Item_To_School" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
<section class="content" data-select2-id="32">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-info">
            <div class="card-header">

                  <div class="typo-section py-4 border-top border-bottom">
                 <div class="text-center">
                     <form runat="server">
                       
                     </form>
                      
                 </div>
            

         </div>
              <h3 class="card-title">
                Assigned School Items
              </h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body p-0">
              <div class="row row-cols-1 row-cols-md-3 g-4" id="AssignedItems" runat="server">

 
             </div>
          </div>
        </div>
      </div>
        <!-- /.col-->
      </div>
      <!-- /.container-fluid -->
    </section>

</asp:Content>
