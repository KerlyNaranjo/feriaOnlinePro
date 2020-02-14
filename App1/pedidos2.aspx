<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"   EnableEventValidation="false" AutoEventWireup="true" CodeBehind="pedidos2.aspx.cs" Inherits="App1.pedidos2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container">
   <div class="row">
	 <div class="col-xs-12 col-sm-6 col-md-6">
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
					   
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
		</tbody>
		</table>
    </div>
	</center>
  </div>
  <div class="col-xs-6 col-md-4">
	  <div runat="server" id="divdetalle">
		  <h1>Detalle  Pedido</h1>
		  <asp:Label ID="lblcp" runat="server" Text="Label"></asp:Label>
		  <table id="example" class="table table-striped table-bordered" style="font-size: 10px;">
		<thead>
			<tr>
				<th>CÓDIGO</th>
				<th>PRODUCTO</th>
				<th>DESCRIPCIÓN</th>
				<th>P. UNITARIO</th>
				<th>CANTIDAD</th>
				<th>SUBTOTAL</th>
				<th>TOTAL</th>
				 
			</tr>
		</thead>
		<tbody>
		  <asp:Repeater ID="rptPedidosDetalle" runat="server">
              <ItemTemplate>
				   <tr>
					  <td><%# Eval("IDPRO") %></td>
					  <td> 
						  <asp:Image ID="Imagen" runat="server" ImageUrl='<%# Eval("IMG") %>'
                                                Width="35px" Height="35px" /> 
					  </td>
					   <td><%# Eval("DESPRO") %></td>
					  <td><%# Eval("PUDET") %></td>
					  <td><%# Eval("CANDET") %></td>
					  <td><%# Eval("SUBTOTAL") %></td>
					   <td><%# Eval("TOTAL") %></td>					  
					 
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
       </tbody>
		</table>
		  		  	 Dirección de entrega:  <asp:Label ID="txtdire" runat="server" Text="Label"></asp:Label>
		            	<div class="form-group" id="calificacion" runat="server">

							    Desea Calificar el pedido realizado?
						    <br />
							<table style="text-align:center;">
								<tr>
									<td><img src="imgs/cb.jpg" Height="37px" Width="40px" /> </td>
								    <td> <img src="imgs/cr.jpg" Height="37px" Width="40px" /></td>
								    <td><img src="imgs/cm.jpg" Height="37px" Width="40px" /> </td>
								</tr>
								<tr>
									<td><asp:RadioButton ID="rbb" runat="server" GroupName="select" /></td>
								    <td> <asp:RadioButton ID="rbr" runat="server" GroupName="select"/></td>
								    <td> <asp:RadioButton ID="rbm" runat="server" GroupName="select"/></td>
								</tr>
							</table>
						 	<br />
							Comenrtario
							<br />
							<textarea id="txtcp" runat="server" style="width: 291px; height: 82px"></textarea>
							
								<br />
							<asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="Button1_Click" />
						</div>
		         
		  
		  
		  
		 
		  
	  </div>
	  

  </div>
 </div>
			 <asp:Label ID="lblerror" runat="server" Text="" BackColor="Red"></asp:Label>
</div>

</asp:Content>
