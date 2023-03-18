<%@ Page Title="Update Remove User" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateRemoveUser.aspx.cs" Inherits="GelezaStyleWebApp.UpdateRemoveUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">

     <section class="contact py-lg-4 py-md-3 py-sm-3 py-3">
         <form runat="server">
      
        <div>
         <div class="container py-lg-5 py-md-4 py-sm-4 py-3">
             <div class="typo-section py-4 border-top border-bottom">
            <a href="ManageUsers.aspx" class="btn btn-lg btn-primary" >Go back</a>
         </div>
        </div>
        

            <div class="contact-list-grid">
               
	  
                       
         <div class="row row-cols-1 row-cols-md-3 g-4" runat="server" id="UserCard"> 
         "<div class="col" >
             </div>
          </div>

	   
        
           </div>
        </div> 
        </form>
      </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MasterFooterPlaceHolder" runat="server">
</asp:Content>
