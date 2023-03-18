<%@ Page Title="View_Order_Contents" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Order_Contents.aspx.cs" Inherits="GelezaStyleWebApp.View_Order_Contents" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">

    <section class="content" data-select2-id="32">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-info">
            <div class="card-header">
              <h3 class="card-title">
                Order Contents
              </h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body p-0">
              <div class="row row-cols-1 row-cols-md-3 g-4" id="ViewOrderItems" runat="server">

 
             </div>
          </div>
        </div>
      </div>
        <!-- /.col-->
      </div>
      <!-- /.container-fluid -->
    </section>
</asp:Content>
