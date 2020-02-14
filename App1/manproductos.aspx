<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="manproductos.aspx.cs" Inherits="App1.manproductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		function Numeros(string) {//solo letras y numeros
			var out = '';
			//Se añaden solo numeros
			var filtro = '1234567890.';//Caracteres validos

			for (var i = 0; i < string.length; i++)
				if (filtro.indexOf(string.charAt(i)) != -1)
					out += string.charAt(i);
			return out;
			// return tx.toUpperCase();
		}
	</script>
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
	<asp:Button ID="btnagregar" runat="server" Text="Agregar Producto" CssClass="btn btn-default" OnClick="btnagregar_Click"/>    
	 <div class="row">
	<div class="col-xs-12 col-sm-6 col-md-6">
	<center>
		 <asp:Label ID="lblep" runat="server" Text=""></asp:Label>
		<div runat="server" id="divdetalle1">
		<h1></h1>
		 
		<table id="example" class="table table-striped table-bordered" style="font-size: 10px;">
		<thead>
			<tr>
				<th>CÓDIGO</th>
				<th>DECRIPCIÓN</th>
				<th>STOCK</th>
				<th>PESO KG</th>
				<th>PRECIO</th>
				<th>IMAGEN</th>
				<th>ESTADO</th>
				<th></th> 
				<th></th> 
			</tr>
		</thead>
		<tbody>
       
		<asp:Repeater ID="rptPedidos" runat="server">
              <ItemTemplate>
				   <tr>
					  <td><%# Eval("IDPRO") %></td>
					  <td><%# Eval("DESPRO") %></td>
					  <td><%# Eval("STOCKPRO") %></td>
					   <td><%# Eval("PESPRO") %></td>
					   <td><%# Eval("PREPRO") %></td>
					  <td><img src="<%# Eval("IMG") %>" style="width:45PX; height:40PX;"/></td>
					  <td><%# Eval("ESTPRO") %></td> 
					  <td>
                      <asp:ImageButton ID="btnver" runat="server" CommandArgument='<%#Eval("IDPRO")%>'  OnClick="btnver_Click" ImageUrl="~/imgs/ver.png" Width="20" Height="20"></asp:ImageButton>
					  </td>
					    <td>
                      <asp:ImageButton ID="btneli" runat="server" CommandArgument='<%#Eval("IDPRO")%>'  OnClick="btneli_Click" ImageUrl="~/imgs/eli.png" Width="20" Height="20" OnClientClick="return confirm('¿Esta seguro de querer eliminar el producto seleccionado?');"></asp:ImageButton>
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
		  <h1>Guardar Productos</h1>
		  <div class="form-group">
			  Código: <asp:Label ID="lblidp" runat="server" Text=""></asp:Label>
		 </div>
		  <div class="form-group">
			 Descripción:  <input type="text" runat="server" class="input" id="txtdes"/>
		 </div>
		   <div class="form-group">
			  Precio: <input type="text" runat="server" class="input" id="txtpre" onkeyup="this.value=Numeros(this.value)"/>
		 </div>
		   <div class="form-group">
			  Stock: <input type="text" runat="server" class="input" id="txtstock" onkeyup="this.value=Numeros(this.value)"/>
		 </div>
		  <div class="form-group">
			 Peso: <input type="text" runat="server" class="input" id="txtpeso" onkeyup="this.value=Numeros(this.value)"/>
		 </div>
		  <div class="form-group">
			  Estado: 
			  <asp:DropDownList ID="cbxestado" runat="server" CssClass="btn btn-default" >
				  <asp:ListItem Value="1">Activado</asp:ListItem>
				  <asp:ListItem Value="2">Desactivado</asp:ListItem>
			  </asp:DropDownList>
		 </div>
		  <div class="form-group">
			 Imagen: <img src="" style="width:45PX; height:40PX;" runat="server" id="imgpro"/> 
			  <asp:Label ID="lgen" runat="server" Text=""></asp:Label>
		 </div>
			  <asp:FileUpload ID="fileimg" runat="server" Height="30px" Width="259px" CssClass="btn btn-default" />
                     
		  <div class="form-group">
			 <asp:Button ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnguardar_Click" />
		 </div>
		   
      </div>
 </div>
</div>

</div>
<br>
<br> 
</asp:Content>
