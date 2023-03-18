<%@ Page Title="Manage Stock" async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_Stock.aspx.cs" Inherits="GelezaStyleWebApp.ManageStock" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">


    
     <section class="contact py-lg-4 py-md-3 py-sm-3 py-3">
         
         <div class="container py-lg-5 py-md-4 py-sm-4 py-3">
            
             <div class="typo-section py-4 border-top border-bottom">
                 <div class="text-center">
                      <button class="btn btn-primary" type="submit">Boys Clothing</button>
                      <button class="btn btn-primary" type="submit">Girls Clothing</button>
                      <button class="btn btn-primary" type="submit">Unisex Clothing</button>

                 </div>
            

         </div>
            <div class="contact-list-grid">
            <div class="row row-cols-1 row-cols-md-3 g-4" id="ProductCard" runat="server">
            </div>
           </div>
        </div> 
      </section>

</asp:Content>
