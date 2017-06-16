<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusMascota.aspx.cs" Inherits="PetCenter.Presentacion.Adopcion.BusMascota" %>

<%@ Import Namespace="PetCenter"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%=FuncionesUrlString.LibreriasCSS()%>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div class="row" style="padding-left:15px;padding-right:40px;padding-top:10px">		
                           
		        <div class="panel panel-default">
			        <div class="panel-body">
																														        	
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-2 control-label">Nombre</label>										
										        <div class="col-xs-4">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_nombre" placeholder="Codigo de Consulta" autocomplete="off">
										        </div>

                                                <label for="inputPaterno" class="col-xs-2 control-label">Raza</label>										
										        <div class="col-xs-4">
											        
                                                    <asp:DropDownList class="form-control" ID="ddl_raza" runat="server"></asp:DropDownList>
                
										        </div>

									        </div>	
                                            <div class="form-group" style="padding-top:5px">
										    
										        <div class="col-xs-12" style="text-align:center">
											        <asp:Button ID="btn_buscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btn_grabar_Click"/>										        
										        </div>
									        </div>                                        																																												
																																
			        </div>
		        </div>
       
		    <div class="panel panel-default">
			    <div class="panel-body">
																					
									    <div class="form-group">
										    
                                            <asp:GridView ID="grid_Mascotas" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" EmptyDataText="Realizar Busqueda" OnRowDataBound="grid_Clientes_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="codigo_mascota" HeaderText="Codigo" />
                                                    <asp:BoundField DataField="nombreMascota" HeaderText="Nom.Mascota" />
                                                    <asp:BoundField DataField="genero" HeaderText="Genero" />
                                                    <asp:BoundField DataField="nombreRaza" HeaderText="Raza" />
                                                    <asp:BoundField DataField="EdadDias" HeaderText="Edad(Dias)" />
                                                </Columns>
                                                <HeaderStyle BackColor="#990000" Font-Names="Arial" Font-Size="13px" ForeColor="White" />
                                                <RowStyle Font-Names="Arial" Font-Size="12px" />
                                            </asp:GridView>

									    </div>	                                                       																																														
																																
			    </div>
		    </div>
	        
	        </div>
    </form>
    <%=FuncionesUrlString.LibreriasJS()%>
</body>
</html>
