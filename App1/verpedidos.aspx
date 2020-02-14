<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verpedidos.aspx.cs" Inherits="App1.verpedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container">
		<div class="row">
	     <div class="col-xs-12 col-sm-6 col-md-6"> 
			 <table>
				 <tr>
					 <td>
						 Fecha Inicial
					 </td>
					 <td>
						  <input type="date" runat="server" id="txtfi"/>
					 </td>
					 <td>
						 Fecha Final
					 </td>
					 <td>
						  <input type="date" runat="server" id="txtff"/>
					 </td>
					 <td>
						 <asp:ImageButton ID="btnbuscar" runat="server" ImageUrl="~/imgs/buscar.png" OnClick="btnbuscar_Click" Width="35" Height="35" />
					 </td>
				 </tr>
			 </table>
		<center>
		 <asp:Label ID="lblep" runat="server" Text=""></asp:Label>
		<div runat="server" id="divdetalle1">
		<h1>Pedidos</h1>
		 
		<table id="example" class="table table-striped table-bordered" style="font-size: 10px;">
		<thead>
			<tr>
				<th>CÓDIGO</th>
				<th>CLIENTE</th>
				<th>CANTIDAD</th>
				<th>SUBTOTAL</th>
				<th>TOTAL</th>
				<th>ESTADO</th>				 
				<th></th>
				<th></th>
			</tr>
		</thead>
		<tbody>       
		<asp:Repeater ID="rptPedidos" runat="server">
              <ItemTemplate>
				   <tr>
					  <td><%# Eval("IDPED") %></td>
					  <td><%# Eval("CLIENTE") %></td>
					  <td><%# Eval("CANTIDAD") %></td>
					  <td><%# Eval("SUBTOTAL") %></td>
					  <td><%# Eval("TOTAL") %></td>
					   <td><%# Eval("ESTADO") %></td>
					   <td>
                      <asp:ImageButton ID="btnver" runat="server" CommandArgument='<%#Eval("IDPED")%>' OnClick="btnver_Click" ImageUrl="~/imgs/ver.png" Width="20" Height="20"></asp:ImageButton>
					   </td>
					   <td>
						   <asp:ImageButton ID="btneli" runat="server" CommandArgument='<%#Eval("IDPED")%>' OnClick="btneli_Click" ImageUrl="~/imgs/eli.png" Width="20" Height="20"></asp:ImageButton>
					   </td>					    
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
		</tbody>
		</table>
    </div>
	</center>
		 </div>
	    </div>

	</div>
</asp:Content>
