<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detproducto.aspx.cs" Inherits="App1.detproducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
	<br /><br />
	<div class="container">
		<div class="row">
	       <div class="col-xs-12 col-sm-6 col-md-4">
			   <asp:Image ID="img1" runat="server" Width="350" Height="360"/>
	       </div>
			<div class="col-xs-12 col-sm-6 col-md-4">
				<asp:Label ID="lbldes" runat="server" Text="Label"></asp:Label>
				 <br /> <br />
				 PRECIO: $<asp:Label ID="lblprecio" runat="server" Text="Label"></asp:Label>
				 
				 <br /><br />
				CANTIDAD <input type="number"  id="txtnum" runat="server" style="width:80px;" value="0"/>
				<br /><br />
				<asp:ImageButton ID="btncarrito" runat="server" ImageUrl="imgs/cesta.png" Width="50px" Height="40px" OnClick="btncarrito_Click" />
	             <asp:ImageButton ID="btnatras" runat="server" ImageUrl="imgs/atras.png" Width="50" Height="40" OnClick="btnatras_Click" />
	             
			</div>
		</div>
	</div>
	<br /><br />
</asp:Content>
