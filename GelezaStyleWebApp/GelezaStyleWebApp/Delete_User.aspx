<%@ Page Title="Delete User" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete_User.aspx.cs" Inherits="GelezaStyleWebApp.Delete_User" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
    <form runat="server">
     <section class="content">
         <div>
               <div id="SuccessRegistrationAlert" runat="server" visible="false" class="alert alert-success" role="alert">
                            User has been successfully deleted!
                         </div>
                    </div>

                     <div>
                        <div id="FailRegistrationAlert" runat="server" visible="false" class="alert alert-danger" role="alert">
                            Error! User could not be deleted.
                         </div>
                   </div>
        
        <div class="row">
          
        </div>

       
         <div class="card card-primary card-outline" id="cardBody" runat="server">
              <div class="card-body">
                 <h5 class="card-title"></h5>
                   <p class="card-text" id="cardText" runat="server">
                    
                    </p>
                    <a href="Manage_Users.aspx" class="card-link">Cancel</a>
		            <asp:button runat="server" OnClick="btn_DeleteClick" class="card-link" Text="Delete User"></asp:button>
			    </div>
          </div>
     </section>
    </form>
</asp:Content>
