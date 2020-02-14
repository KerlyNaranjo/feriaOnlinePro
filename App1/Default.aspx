<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
	<div class="container">
    <div class="row">
		 <asp:Repeater ID="rptProductos" runat="server">
              <ItemTemplate>
				   <div class="col-md-4">
					    
					   <img src ="<%# Eval("IMG") %>" style="width:150px; height:150px;"/>

					   <br /> <label><%# Eval("DESPRO") %></label>  <label style="text-align:left; color:red;">$ <%# Eval("PREPRO") %></label><br />
					 
					   
					   <asp:LinkButton ID="btncarrito" runat="server"
                               CommandName="coti" CommandArgument='<%#Eval("IDPRO")%>'  OnClick="btncarrito_Click">Ver mas</asp:LinkButton>
			    	</div>
            </ItemTemplate>   
         </asp:Repeater> 
   </div>
      	
</div>
</asp:Content>
