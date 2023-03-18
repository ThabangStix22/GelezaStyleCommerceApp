<%@ Page Title="Compelete Order" async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complete_Order.aspx.cs" Inherits="GelezaStyleWebApp.CompleteOrder" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
     <form runat="server">
     <section class="content">
         <div>
               <div id="SuccessRegistrationAlert" runat="server" visible="false" class="alert alert-success" role="alert">
                            Order has been successfully prepared!
                         </div>
                    </div>

                     <div>
                        <div id="FailRegistrationAlert" runat="server" visible="false" class="alert alert-danger" role="alert">
                            Error! Order could not be prepared.
                         </div>
                   </div>
        
        <div class="row">
          
        </div>

       
         <div class="card card-primary card-outline" id="cardBody" runat="server">
              <div class="card-body">
                 <h5 class="card-title"></h5>
                   <p class="card-text" id="cardText" runat="server">
                    
                    </p>
                    <a href="View_Orders.aspx" class="card-link">Cancel</a>
		            <asp:button runat="server" OnClick="completeOrder_Click" class="card-link" Text="Complete Order"></asp:button>
			    </div>
          </div>
     </section>
    </form>
</asp:Content>
