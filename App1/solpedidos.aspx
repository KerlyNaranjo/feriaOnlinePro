<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="solpedidos.aspx.cs" Inherits="App1.solpedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container">	
	<nav class="">
    <div class="">   
    <ul class="nav navbar-nav">
      <li class="active"><a href="admin.aspx"><i class="glyphicon glyphicon-cog"></i>Inicio</a></li>
       <li class="active"><a href="solpedidos.aspx"><i class="glyphicon glyphicon-user"></i>Pedidos Solicitados</a></li>
       <li class="active"><a href="manproductos.aspx"><i class="glyphicon glyphicon-pencil"></i>Mantenimiento Productos</a></li>
       <li class="active"><a href="mantenimiento.aspx"><i class="glyphicon glyphicon-th-list"></i>Ingreso Perfil</a></li>
       <li class="active"><a href="mantenimiento.aspx"><i class="glyphicon glyphicon-pencil"></i>Editar Perfil</a></li>
       <li class="active"><a href="mantenimiento.aspx"><i class="glyphicon glyphicon-indent-left"></i>Permisos</a></li>
       <li class="active"><a href="mantenimiento.aspx"><i class="glyphicon glyphicon-pencil"></i>Registro Usuarios</a></li>
      
    </ul>
  </div>
</nav>
 <br>
 <br>
       <!-- EDSION -->
          <center> 
         <table style="width :80%;">
			 <tr>
				 <td>
					 Fecha Inicial 
				 </td>
				  <td>
					  <input type="date" runat="server" id="txtfi" />
				 </td>
				  <td>
					 Fecha Inicial 
				 </td>
				  <td>
					  <input type="date" runat="server" id="txtff" />
				 </td>
				 <td>
					  <asp:ImageButton ID="ImageButton1" runat="server" 
						  ImageUrl="~/imgs/buscar.png" Width="20" Height="20" OnClick="ImageButton1_Click"></asp:ImageButton>
				 </td>
			 </tr>
         </table>

       	 
       	  </center>
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
				<th>REPARTIDOR</th>
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
					    <td><%# Eval("REPARTIDOR") %></td>
					   <td>
                      <asp:ImageButton ID="btnver" runat="server" CommandArgument='<%#Eval("IDPED")%>'  OnClick="btnver_Click" ImageUrl="~/imgs/ver.png" Width="20" Height="20"></asp:ImageButton>
					   </td>
					     <td>
                           <a href="javascript:abrir(<%#Eval("IDPED")%>);"><img src="/imgs/impresion.png" Width="20" Height="20" /> </a>
                        </td>

					   
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
		</tbody>
		</table>
       <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
	</center>
  </div>
  <div class="col-xs-6 col-md-4">
	  <div runat="server" id="divdetalle">
		  <h1>Asignar Repartidor</h1>
		  <div class="form-group">
			  Código: <asp:Label ID="lblidped" runat="server" Text="Label"></asp:Label>
		 </div>
		  <div class="form-group">
			 Cliente: <asp:Label ID="lblcli" runat="server" Text="Label"></asp:Label>
		 </div>
		   <div class="form-group">
			  Cantidad Productos: <asp:Label ID="lblcant" runat="server" Text="Label"></asp:Label>
		 </div>
		  <div class="form-group">
			  Total a pagar: <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label>
		 </div>
		  <div class="form-group">
			  Repartidor Actual: <asp:Label ID="lblra" runat="server" Text="Label"></asp:Label>
		 </div>
		    <div class="form-group">
			Nuevo Repartidor: 
				<asp:DropDownList ID="cbxrepartidor" runat="server"  ></asp:DropDownList>
		 </div>
		  <div class="form-group">
			 <asp:Button ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnguardar_Click" />
		 </div>
		   
      </div>
 </div>
</div>



</div>
<br>
<br> 
<script> 
	function abrir(id){ 
	   window.open("imprimir.aspx?id="+id+"","ventana1","width=800,height=600,scrollbars=NO") 
	} 
</script>
</asp:Content>
