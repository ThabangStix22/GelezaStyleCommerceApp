<%@ Page Title="View Assigned Schools" ASync="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Assigned_Schools.aspx.cs" Inherits="GelezaStyleWebApp.View_Assigned_Schools" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
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
         
		<form runat="server" id="ViewAssignedSchools">
               
        </form>
           
</asp:Content>
