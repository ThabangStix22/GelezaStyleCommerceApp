<%@ Page Title="Manage Schools" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_Schools.aspx.cs" Inherits="GelezaStyleWebApp.ManageSchools" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
   
             <div class="mb-2">
                    <a class="btn btn-secondary" href="javascript:void(0)" data-shuffle=""> Shuffle items </a>
                    <div class="float-right">
                      <select class="custom-select" style="width: auto;" data-sortorder="">
                        <option value="index"> Sort by Position </option>
                        <option value="sortData"> Sort by Custom Data </option>
                      </select>
                      <div class="btn-group">
                        <a class="btn btn-default" href="javascript:void(0)" data-sortasc=""> Ascending </a>
                        <a class="btn btn-default" href="javascript:void(0)" data-sortdesc=""> Descending </a>
                      </div>
                    </div>
                  </div>
         
		<form runat="server" id="SchoolCard">
               
        </form>
           
</asp:Content>
