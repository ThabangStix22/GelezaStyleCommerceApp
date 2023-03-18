<%@ Page Title="Monthly Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Monthly_Report.aspx.cs" Inherits="GelezaStyleWebApp.Monthly_Report" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
       
     <div>
		<section id="complaints" style="text-align:center" class="container">
			<header>
				<h2>Monthly Visual Order's Chart of purchased clothing categories</h2>
				
			</header>
		</section>
					
<hr />

		<div>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/fusioncharts.js"></script>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/themes/fusioncharts.theme.fusion.js"></script>

			<div>
				 <asp:Literal ID="CompID" runat="server"></asp:Literal>     
			</div>
		</div>

<hr />

		<div>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/fusioncharts.js"></script>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/themes/fusioncharts.theme.fusion.js"></script>

			<div>
				 <asp:Literal ID="chartContainer" runat="server"></asp:Literal>     
			</div>
		</div>

<hr />

		<div>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/fusioncharts.js"></script>
			<script type="text/javascript" src="//cdn.fusioncharts.com/fusioncharts/latest/themes/fusioncharts.theme.fusion.js"></script>

			<div>
				 <asp:Literal ID="chartContainer2" runat="server"></asp:Literal>     
			</div>
		</div>
	</div>
</asp:Content>
