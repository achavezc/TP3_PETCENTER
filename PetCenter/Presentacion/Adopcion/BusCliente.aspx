<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusCliente.aspx.cs" Inherits="PetCenter.Presentacion.Adopcion.BusCliente" %>
<%@ Import Namespace="PetCenter"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
										        <label for="inputPaterno" class="col-xs-2 control-label">N DNI.</label>										
										        <div class="col-xs-4">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_dni" placeholder="Codigo de Consulta" autocomplete="off">
										        </div>

                                                <label for="inputPaterno" class="col-xs-2 control-label">Ape.Paterno</label>										
										        <div class="col-xs-4">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_pat" placeholder="Codigo de Consulta" autocomplete="off">
										        </div>

									        </div>	
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-2 control-label">Ape.Materno</label>										
										        <div class="col-xs-4">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_mat" placeholder="Codigo de Consulta" autocomplete="off">
										        </div>

                                                <label for="inputPaterno" class="col-xs-2 control-label">Nombres</label>										
										        <div class="col-xs-4">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_nom" placeholder="Codigo de Consulta" autocomplete="off">
										        </div>

									        </div>	
                                            <div class="form-group" style="padding-top:5px">
										    
										        <div class="col-xs-12" style="text-align:center">
											        <asp:Button ID="btn_grabar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btn_grabar_Click"/>										        
										        </div>
									        </div>                                        																																												
																																
			        </div>
		        </div>
       
		    <div class="panel panel-default">
			    <div class="panel-body">
																					
									    <div class="form-group">
										    
                                            <asp:GridView ID="grid_Clientes" runat="server" CssClass= "table table-striped table-bordered table-condensed" UseAccessibleHeader="true" AutoGenerateColumns="False" EmptyDataText="Realizar Busqueda" OnRowDataBound="grid_Clientes_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="codigo_cliente" HeaderText="Codigo" />
                                                    <asp:BoundField DataField="apellidoPaterno" HeaderText="Ape.Paterno" />
                                                    <asp:BoundField DataField="apellidoMaterno" HeaderText="Ape.Materno" />
                                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                                    <asp:BoundField DataField="numeroDocumento" HeaderText="Dni." />
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
