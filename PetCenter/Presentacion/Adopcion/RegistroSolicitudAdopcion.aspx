<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroSolicitudAdopcion.aspx.cs" Inherits="PetCenter.Presentacion.Adopcion.RegistroSolicitudAdopcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="resources/css/jquery-ui-1.12.1.custom.min.css" rel="stylesheet">
	<link href="resources/css/bootstrap.min.css" rel="stylesheet">
	<link href="resources/css/style.css" rel="stylesheet">
	<link href="resources/css/datepicker.min.css" rel="stylesheet">
	
	<link href="resources/css/angular-csp.css" rel="stylesheet">
	<link href="resources/css/angular-ui-notification.min.css" rel="stylesheet">

     <!-- ESTE ORDEN DEBE DE RESPETARSE -->
	<!-- verifique internet explore version 8 -->
	<script	src="resources/js/jquery/jquery.min.js"></script>		
	<script	src="resources/js/jquery/jquery-ui-1.9.1.custom.min.js"></script>	
	<script	src="resources/js/jquery/jquery.blockUI.js"></script>
	<script	src="resources/js/bootstrap/bootstrap.min.js"></script>
    
	<script src="resources/js/angularjs/angular.min.js"></script>
	<script	src="resources/js/angularjs/angular-route.min.js"></script>
	<script	src="resources/js/angularjs/angular-resource.min.js"></script>
	<script	src="resources/js/angularjs/angular-animate.js"></script>
	<script	src="resources/js/angularjs/angular-locale_es-pe.js"></script>
	<script	src="resources/js/angularjs/ui-bootstrap-tpls.min.js"></script>
	<script	src="resources/js/angularjs/ng-table.min.js"></script>		
	
	<!-- PARA EL MANEJO DE FECHAS -->
	<script src="resources/js/angularjs/moment.min.js"></script>
	<script src="resources/js/angularjs/bootstrap-datepicker.min.js"></script>
	<script src="resources/js/angularjs/bootstrap-datetimepicker.min.js"></script>	

	<!-- NOTIFICACIONES -->
	<script src="resources/js/angularjs/angular-ui-notification.min.js"></script>
	
	<!-- PROPIOS -->			
	<script src="resources/js/FuncionesComunes.js"></script>

    <script type="text/ecmascript">

        function abrirBusCliente() {

            var url = 'BusCliente.aspx';
            top.Fc_Popup_jquery_3(url, 680, 550, 'Buscar Cliente', '#divConsulta3');

        }

        function abrirBusMascota() {

            var url = 'BusMascota.aspx';
            top.Fc_Popup_jquery_3(url, 680, 550, 'Buscar Mascota', '#divConsulta3');

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    
            <div class="row" style="padding-left:40px;padding-right:20px">		
            
                <div class="form-group" style="padding-bottom:15px">
										        <label for="inputPaterno" class="col-xs-12 control-label">CLIENTE</label>										
                </div>	
		        <div class="panel panel-default">
			        <div class="panel-body">
																					
									        <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Numero de DNI.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" id="txt_dni" runat="server" autocomplete="off">
										        </div>
									        </div>	
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Nombres.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" id="txt_nombre" runat="server"  autocomplete="off">
										        </div>
									        </div>
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Apellidos.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" runat="server" id="txt_apellidos"  autocomplete="off">
										        </div>
									        </div>

                                            <div class="form-group" style="padding-bottom:23px">
										    
										        <div class="col-xs-12">
											        <input type="button" value="Busqueda Avanzada" class="btn btn-default" onclick="abrirBusCliente()"/>
										        </div>
									        </div>                                        																																												
																																
			        </div>
		        </div>

                <div class="form-group" style="padding-bottom:15px">
										        <label for="inputPaterno" class="col-xs-12 control-label">MASCOTA</label>										
                </div>	

		        <div class="panel panel-default">
			        <div class="panel-body">
																					
									        <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Raza.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" id="txt_raza" autocomplete="off">
										        </div>
									        </div>	
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Nombres.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" id="txt_nombre_mascota" autocomplete="off">
										        </div>
									        </div>
                                            <div class="form-group" style="padding-bottom:23px">
										        <label for="inputPaterno" class="col-xs-3 control-label">Edad.</label>										
										        <div class="col-xs-9">
											        <input type="text" maxlength="9" class="form-control" id="txt_edad" autocomplete="off">
										        </div>
									        </div>

                                            <div class="form-group" style="padding-bottom:23px">
										    
										        <div class="col-xs-12">
											        <input type="button" value="Busqueda Avanzada" class="btn btn-default" onclick="abrirBusMascota()"/>
										        </div>
									        </div>                                        																																												
																																
			        </div>
		        </div>

                <div class="form-group" style="padding-bottom:15px;text-align:center">
										        
                    <asp:Button ID="btn_grabar" runat="server" Text="Button" class="btn btn-default" OnClick="btn_grabar_Click"/>
										        
                </div>

	        </div>
            <div style="display:none">
            <asp:TextBox ID="id_codigo_cliente" runat="server"></asp:TextBox>
            <asp:TextBox ID="id_codigo_mascota" runat="server"></asp:TextBox>
            </div>
    </form>
</body>
</html>
