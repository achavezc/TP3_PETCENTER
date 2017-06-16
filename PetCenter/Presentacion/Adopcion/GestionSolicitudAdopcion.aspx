<%@ Page Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="GestionSolicitudAdopcion.aspx.cs" Inherits="PetCenter.Presentacion.NewFolder1.RegistroSolicitudAdopcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .grid {
            width:100%;

        }
    </style>           

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/ecmascript">

        function abrirSolicitud() {

            var url = 'RegistroSolicitudAdopcion.aspx';
            Fc_Popup_jquery(url, 720, 570, 'Registrar Solicitud Adopciòn', '#divConsulta');

        }
    </script>

    <table style="width:100%">        
        <tr>
            <td>&nbsp;</td>
            <td colspan="2" style="padding-top: 10px;padding-left:5px;padding-right:5px">
             <br />
             <div class="row">	
										    <label for="inputPaterno" class="col-sm-3 control-label" style="margin-top:12px">SOLICITUD DE ADOPCIÓN</label>										
										    <div class="col-sm-9" style="text-align:right">											    
                                                <input type="button" value="Nueva Solicitud" class="btn btn-default" onclick="abrirSolicitud()"/>
										    </div>
			</div>	

            <div class="row" style="padding-left:15px;padding-right:15px">		
		    <div class="panel panel-default">
			    <div class="panel-body">
																					
									    <div class="form-group" style="padding-bottom:23px">
										    <label for="inputPaterno" class="col-sm-2 control-label">Fecha de Inicio</label>										
										    <div class="col-sm-4">
											    <input type="text" readonly="readonly" class="form-control" id="txt_fec_ini" runat="server" placeholder="Fecha de Inicio" autocomplete="off" ng-model="buscar.buscodigo">
										    </div>
                                            <label for="inputPaterno" class="col-sm-2 control-label">Fecha de Fin</label>										
										    <div class="col-sm-4">
											    <input type="text" runat="server" class="form-control" id="txt_fechafin" readonly="readonly" placeholder="Fecha de Fin" autocomplete="off" ng-model="buscar.buscodigo">
										    </div>

                                            <script type="text/javascript">
                                                $(function () {
                                                    $('#ContentPlaceHolder1_txt_fec_ini').datetimepicker({
                                                        format: 'DD/MM/YYYY'
                                                    }).on('change', function () {
                                                        $('.bootstrap-datetimepicker-widget').css("display", "none");                                                        
                                                    });
                                                });

                                                $(function () {
                                                    $('#ContentPlaceHolder1_txt_fechafin').datetimepicker({
                                                        format: 'DD/MM/YYYY'
                                                    }).on('change', function () {
                                                        $('.bootstrap-datetimepicker-widget').css("display", "none");
                                                    });
                                                });
                                            </script>

									    </div>

                                       <div class="form-group" style="padding-bottom:23px">
										    <label for="inputPaterno" class="col-sm-2 control-label">DNI del Cliente</label>										
										    <div class="col-sm-4">
											    <input type="text" maxlength="9" class="form-control" runat="server" id="txt_dni" placeholder="Numero de DNI." autocomplete="off" ng-model="buscar.buscodigo">
										    </div>
                                            <label for="inputPaterno" class="col-sm-2 control-label">Apellidos del Cliente</label>										
										    <div class="col-sm-4">
											    <input type="text" maxlength="9" class="form-control" runat="server" id="txt_nombre_cliente" placeholder="Apellidos" autocomplete="off" ng-model="buscar.buscodigo">
										    </div>
									    </div>		
                    
                                        <div class="form-group" style="padding-bottom:23px">
										    <label for="inputPaterno" class="col-sm-2 control-label">Nombre de Mascota</label>										
										    <div class="col-sm-4">
											    <input type="text" maxlength="9" class="form-control" id="txt_nombre_mascota" runat="server" placeholder="Descripcion de la raza" autocomplete="off" ng-model="buscar.buscodigo">
										    </div>
                                            <label for="inputPaterno" class="col-sm-2 control-label">Raza</label>										
										    <div class="col-sm-4">
											        
                                                    <asp:DropDownList class="form-control" ID="ddl_raza" runat="server"></asp:DropDownList>
                
										        &nbsp;</div>
									    </div>	
                                        <div class="form-group" style="padding-bottom:23px">
                                            <label for="inputPaterno" class="col-sm-2 control-label">Nº Solicitud</label>										
										    <div class="col-sm-4">
											    <input type="text" maxlength="9" class="form-control" id="txt_numero" runat="server" placeholder="Descripcion de la raza" autocomplete="off" ng-model="buscar.buscodigo">
										    </div>										    
										    <div class="col-sm-6" style="text-align:left">
											    <asp:Button ID="btn_buscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btn_buscar_Click" />
										    </div>
									    </div>																																															
																																
			    </div>
		    </div>
	        </div>
            
            <div class="row">	
										    <label for="inputPaterno" class="col-sm-12 control-label" style="margin-top:12px">RESULTADO</label>																				    
			</div>	

            <div class="row" style="padding-left:15px;padding-right:15px">		
		    <div class="panel panel-default">
			    <div class="panel-body">
																					
									    <div class="form-group">
										    
                                            <asp:GridView ID="grid_Solicitudes" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" EmptyDataText="Realizar Busqueda" OnRowDataBound="grid_Clientes_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="numero_solicitud" HeaderText="N Solicitud" />
                                                    <asp:BoundField DataField="apellidoPaterno" HeaderText="Ape.Paterno" />
                                                    <asp:BoundField DataField="apellidoMaterno" HeaderText="Ape.Materno" />
                                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                                    <asp:BoundField DataField="nombreMascota" HeaderText="Mascota" />
                                                    <asp:BoundField DataField="fechaSolicitud" DataFormatString="{0:d}" HeaderText="Fecha_Solicitud" />
                                                </Columns>
                                                <HeaderStyle BackColor="#990000" Font-Names="Arial" Font-Size="13px" ForeColor="White" />
                                                <RowStyle Font-Names="Arial" Font-Size="12px" />
                                            </asp:GridView>

									    </div>	                                                       																																														
																																
			    </div>
		    </div>
	        </div>       

            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        

</asp:Content>