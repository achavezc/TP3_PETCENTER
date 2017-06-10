(function () {
    angular.module('api')
        .controller('GenerarCalcularVBController',
        ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$compile',
            function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $compile) {
                var idActual = "";
                $timeout(function () {

                    if ($rootScope.DatosFormulario == undefined)
                        $rootScope.DatosFormulario = new Object();

                    if ($rootScope.DatosFormulario.CalcularVB == undefined)
                        $rootScope.DatosFormulario.CalcularVB = new Object();

                    if ($rootScope.DatosFormulario.CalcularVB.Datos == undefined)
                        $rootScope.DatosFormulario.CalcularVB.Datos = new Object();

                    if ($rootScope.DatosFormulario.CalcularVB.Filtro == undefined)
                        $rootScope.DatosFormulario.CalcularVB.Filtro = new Object();

                    if ($rootScope.DatosFormulario.RegistraCarrito == undefined)
                        $rootScope.DatosFormulario.RegistraCarrito = new Object();

                    if ($rootScope.DatosFormulario.RegistraCarrito.Carrito == undefined)
                        $rootScope.DatosFormulario.RegistraCarrito.Carrito = new Object();

                    if ($rootScope.DatosFormulario.RegistraCarrito.ListaBL == undefined)
                        $rootScope.DatosFormulario.RegistraCarrito.ListaBL = [];

                    if ($rootScope.DatosFormulario.CalcularVB.ServicioOpiconal == undefined)
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal = new Object();

                    if ($rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional == undefined)
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional = [];

                    if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoVB == undefined) {
                        $rootScope.DatosFormulario.CalcularVB.ListaCalculoVB = [];
                    }
                    if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll == undefined) {
                        $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = [];
                    }

                    if ($rootScope.DatosFormulario.BLSeleccionado != undefined)
                        $rootScope.DatosFormulario.BLSeleccionado = null;

                    if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll != undefined)
                        $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = [];

                    //$rootScope.DatosFormulario.CalcularVB.TotalSolesMoneda =
                    //$rootScope.DatosFormulario.CalcularVB.TotalDolaresMoneda

                    //$("#pg_grillaVistoBuenoListarBL_pager").find(".ui-pg-button").attr("style","")
                    //$("#grillaVistoBuenoListarBL_pager_left").attr("style", "display:none");
                    $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional = [];

                    $scope.Limpiar_Click();


                    $rootScope.EsMenuLiberacion = true;
                    $rootScope.EsMenuLiberacionCodicion = true;
                    $rootScope.EsMenuCalcularVB = false;

                    $scope.CargarDatosIniciales();

                    //  $rootScope.DatosFormulario.ExisteVigencia = false;

                });

                $scope.MiBoton = function (idgrilla, tipoboton, cellvalue, options, rowObject) {
                    var eventoclick = "";
                    switch (idgrilla) {
                        case "grillaVistoBuenoServiciosOpcionales":
                            {
                                switch (tipoboton) {
                                    case "Quitar":
                                        eventoclick = "$parent.QuitarServicioOpcional(" + rowObject.IdServicioOpcional + ");";
                                        break;
                                }
                            }
                            break;

                    }
                    if (tipoboton == "Editar") {
                        html = HtmlCrearBoton("Modificar", eventoclick, "");
                    }
                    if (tipoboton == "Quitar") {
                        html = HtmlCrearBoton("Eliminar", eventoclick, "ng-disabled='FlagEditing==false'");
                    }
                    return html;
                }

                $scope.CargarDatosIniciales = function () {

                    $.ajax({
                        url: "/CalculadorVB/CalculadorVbIndex",
                        type: "POST",
                        headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                        data: "",
                        dataType: "json",
                        cache: true,
                        async: false,
                        success: function (data) {

                            $rootScope.DatosFormulario.CalcularVB.Datos.Lineas = data.Linea;
                            $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente = data.UserCodigoCliente;
                            $rootScope.DatosFormulario.CalcularVB.Datos.UserNombreCliente = data.UserNombreCliente;

                            // MiAlert($rootScope.DatosFormulario.CalcularVB.Datos.UserNombreCliente );

                            if (data.Linea.length > 0) {
                                $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea = data.Linea[0].Codigo;
                                $scope.SeleccionarCarrier();
                                if (data.Linea.length == 1) {
                                    $rootScope.DatosFormulario.CalcularVB.Datos.Habilitado = 'False';
                                }
                            }
                            $rootScope.DatosFormulario.CalcularVB.Datos.Sucursal = ObtenerSucursalesByLinea($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea);
                            var LstSucrsal = $rootScope.DatosFormulario.CalcularVB.Datos.Sucursal;
                            if (LstSucrsal.length > 0) {

                                $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal = LstSucrsal[0].Codigo;

                                if (LstSucrsal.length == 1) {
                                    $rootScope.DatosFormulario.CalcularVB.Datos.HabilitadoSucursal = 'False';
                                }

                            }

                        }
                    });
                }

                $scope.Buscar_Click = function () {
                    if ($rootScope.EsEnter) {
                        return false;
                    }

                    if ($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea == undefined) {
                        $(".caja11.msgerror.CodigoLinea").html("Línea es requerido.");
                        return false;
                    } else {
                        if ($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea.length <= 0) {
                            $(".caja11.msgerror.CodigoLinea").html("Línea es requerido.");
                            return false;
                        } else {
                            $(".caja11.msgerror.CodigoLinea").html("");
                        }
                    }

                    if ($rootScope.DatosFormulario.CalcularVB.Filtro.NumeroBL == undefined) {
                        $(".caja11.msgerror.NumeroBL").html("Nro BL es requerido.");
                        return false;
                    }
                    else if ($rootScope.DatosFormulario.CalcularVB.Filtro.NumeroBL.length <= 0) {
                        $(".caja11.msgerror.NumeroBL").html("Nro BL es requerido.");
                        return false;
                    }
                    else if ($rootScope.DatosFormulario.CalcularVB.Filtro.NumeroBL.length > 16) {
                        $(".caja11.msgerror.NumeroBL").html("Por favor, introduzca un valor inferior o igual a 20.");
                        return false;
                    } else {
                        $(".caja11.msgerror.NumeroBL").html("");
                    }

                    if ($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal == undefined) {
                        $(".caja11.msgerror.CodigoSucursal").html("Sucursal es requerido.");
                        return false;
                    } else {
                        if ($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal.length <= 0) {
                            $(".caja11.msgerror.CodigoSucursal").html("Sucursal es requerido.");
                            return false;
                        } else {
                            $(".caja11.msgerror.CodigoSucursal").html("");
                        }
                    }

                    var objRequest = { "filtros": $rootScope.DatosFormulario.CalcularVB.Filtro };

                    if (ValidarDeudaPendientePago($rootScope.DatosFormulario.CalcularVB.Filtro)) {
                        MiAlertOk("Tiene Deudas Pendiente de Pago", PendienteDePago_Page);
                    } else {

                        miBlock(true, "html");
                        $scope.LimpiarGrilla('Todos');
                        $.ajax({
                            url: "/CalculadorVB/ConsultarBL",
                            type: "POST",
                            headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                            data: objRequest,
                            dataType: "json",
                            cache: true,
                            async: false,
                            success: function (data) {

                                miBlock(false, "html");
                                if (data.Resultado.Estado == true) {
                                    $rootScope.DatosFormulario.CalcularVB.ListaConsultaBL = data.ListaConsultaBL;
                                    $scope.Grid_DataBind("ListarBL", $rootScope.DatosFormulario.CalcularVB.ListaConsultaBL);

                                    if (data.ListaConsultaBL.length == 1) {

                                        $(jQuery("#" + "grillaVistoBuenoListarBL").find("[id='" + 1 + "']")[0]).find("td").each(function () {
                                            this.style.setProperty('background', '#58AADC', 'important');
                                        });

                                        jQuery("#" + "grillaVistoBuenoListarBL").find("tr").each(function () {
                                            var objTd = $(this);
                                            if (objTd.attr("id") != 1) {
                                                objTd.find("td").each(function () {
                                                    //this.style.setProperty('background', 'transparent', 'important');
                                                    this.style.setProperty('background', '', 'important');
                                                });
                                            }
                                        });

                                        var objGrilaItem = $("#gview_" + 'grillaVistoBuenoListarBL').find('td[aria-describedby="' + 'grillaVistoBuenoListarBL' + '_Id"]');
                                        var objDetalle = new Object();

                                        if (objGrilaItem.length > 0) {

                                            var ngModel = objGrilaItem[0].attributes[5].value;
                                            objDetalle = obtenerObjetoAngular2(ngModel);

                                            $rootScope.DatosFormulario.ExisteVigencia = true;
                                            $rootScope.DatosFormulario.BLSeleccionado = objDetalle;
                                            $scope.CalcularServicio_Click();

                                        } else {

                                            objDetalle = null;
                                        }
                                    }

                                } else {

                                    if (data.Resultado.Mensajes.length > 0) {
                                        MiError(data.Result.Mensajes[0].Mensaje);
                                    }
                                    else {
                                        MiError(data.Resultado.Mensaje);
                                    }
                                }

                            }
                        });


                    }
                }

                function ValidarDeudaPendientePago(filtro) {

                    var respuesta = false;
                    var objRequest = {
                        "filtros": {
                            CodigoCliente: $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente,
                            CodigoSucursal: $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal
                        }
                    };
                    $.ajax({
                        url: "/CalculadorVB/ValidarDeudaPendientePago",
                        type: "POST",
                        headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                        data: objRequest,
                        dataType: "json",
                        cache: true,
                        async: false,
                        success: function (data) {
                            respuesta = data;
                        }
                    });

                    return respuesta;
                }





                $scope.Grid_DataBind = function (grid, data) {
                    if (grid == "ListarBL") {
                        $scope.gridapigrillaVistoBuenoListarBL.refresh(data);
                    }
                    if (grid == "ListarCalcularVb") {
                        $scope.gridapigrillaVistoBuenoServicios.refresh(data);
                    }
                    if (grid == "ListarServicioOpcional") {
                        $scope.gridapigrillaVistoBuenoServiciosOpcionales.refresh(data);
                    }
                    $rootScope.$apply();
                }

                $scope.Limpiar_Click = function () {

                    if ($rootScope.DatosFormulario.CalcularVB.Filtro.NumeroBL != undefined)
                        $rootScope.DatosFormulario.CalcularVB.Filtro.NumeroBL = null;
                    $(".caja11.msgerror.NumeroBL").html("");

                    if ($rootScope.DatosFormulario.CalcularVB.Datos.Lineas != undefined)
                        if ($rootScope.DatosFormulario.CalcularVB.Datos.Lineas.length > 1) {
                            $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea = null;
                            $(".caja11.msgerror.CodigoLinea").html("");
                        }
                    if ($rootScope.DatosFormulario.CalcularVB.Filtro.CodigoCourier != undefined)
                        $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoCourier = null;

                    if ($rootScope.DatosFormulario.CalcularVB.Datos.Sucursal != undefined)
                        if ($rootScope.DatosFormulario.CalcularVB.Datos.Sucursal.length > 1) {
                            $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal = null;
                            $(".caja11.msgerror.CodigoSucursal").html("");
                        }

                    $rootScope.DatosFormulario.RegistraCarrito.Carrito = {};
                    $rootScope.DatosFormulario.CalcularVB.Filtro = {};
                    // $rootScope.DatosFormulario.CalcularVB.Datos ={};
                    $rootScope.DatosFormulario.RegistraCarrito.ListaBL = {};

                    $scope.LimpiarGrilla('Todos');

                }

                $scope.CargarSucursal = function () {

                    $scope.SeleccionarCarrier();

                    var codLinea = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea;
                    $rootScope.DatosFormulario.CalcularVB.Datos.Sucursal = ObtenerSucursalesByLinea(codLinea);
                    $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal = null;
                }

                $scope.SeleccionarCarrier = function () {
                    var codigoLinea = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea;
                    if (codigoLinea != undefined) {
                        if (codigoLinea.length > 0) {
                            var codigoCarrier = $from($rootScope.DatosFormulario.CalcularVB.Datos.Lineas).where("$Codigo=='" + codigoLinea + "'").firstOrDefault().Carrier;
                            $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoCourier = codigoCarrier;
                        } else {
                            $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoCourier = "";
                        }
                    }
                    else {
                        $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoCourier = "";
                    }
                }

                $scope.GrillaClick = function (obj, idgrilla, rowid, iRow, iCol, e) {
                   // if (rowid != idActual) {
                        idActual = rowid;
                        $scope.LimpiarObjetos();
                        $scope.LimpiarGrilla('ListarCalcularVb');
                        $rootScope.DatosFormulario.ExisteVigencia = true;
                        var objDetalle = obtenerObjetoSeleccionarBL(rowid);

                        $rootScope.DatosFormulario.BLSeleccionado = objDetalle;

                        $(jQuery("#" + obj.id).find("[id='" + rowid + "']")[0]).find("td").each(function () {
                            this.style.setProperty('background', '#58AADC', 'important');
                        });

                        jQuery("#" + obj.id).find("tr").each(function () {
                            var objTd = $(this);
                            if (objTd.attr("id") != rowid) {
                                objTd.find("td").each(function () {
                                    //this.style.setProperty('background', 'transparent', 'important');
                                    this.style.setProperty('background', '', 'important');
                                });
                            }
                        });
                   // }
                    // ------------------------
                    var ListaServicioOpcional = [];
                    var Listado = $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional;
                    if (Listado.length > 0) {
                        ListaServicioOpcional = $.grep(Listado, function (e) { return e.IdBL == objDetalle.Id; });
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda = null;
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda = null;
                        if (ListaServicioOpcional.length > 0) { $scope.CalculcularMontosServOpcionales(objDetalle.Id); }
                        $scope.Grid_DataBind("ListarServicioOpcional", ListaServicioOpcional);
                    }
                    //-------------------------
                }

                function obtenerObjetoAngular(valor) {
                    var objTemp = valor.replace("root", "rootScope");
                    var indexFin = objTemp.lastIndexOf(".");
                    var obj = eval(objTemp.slice(2, indexFin));
                    return obj;
                }

                function obtenerObjetoAngular2(valor) {
                    var objTemp = valor.replace("root", "rootScope");
                    var indexFin = objTemp.lastIndexOf(".");
                    var obj = eval(objTemp.slice(0, indexFin));
                    return obj;
                }
                function obtenerObjetoSeleccionarBL(rowid) {
                    /*
                    var rowKey = jQuery("#grillaVistoBuenoListarBL").jqGrid('getGridParam', 'selrow');
                    if (rowKey == undefined) {
                        return "";
                    } else {
                        var rowObject = jQuery('#grillaVistoBuenoListarBL').getRowData(rowKey);
                        return rowObject.Id;
                    }
                    */
                    if (!rowid) {
                        rowid = jQuery("#grillaVistoBuenoListarBL").jqGrid('getGridParam', 'selrow');
                    }
                    var id = rowid - 1;
                    var objGrilaItem = $("#gview_" + 'grillaVistoBuenoListarBL').find('td[aria-describedby="' + 'grillaVistoBuenoListarBL' + '_Id"]');
                    var objDetalle = new Object();
                    if (objGrilaItem.length > 0 && rowid != undefined && rowid != null) {

                        var ngModel = objGrilaItem[id].attributes[5].value;
                        objDetalle = obtenerObjetoAngular2(ngModel);

                    } else {
                        objDetalle = null;
                    }


                    return objDetalle;
                }


                $scope.CalcularServicio_Click = function () {

                    var objBL = $rootScope.DatosFormulario.BLSeleccionado;

                    if (objBL == null) {
                        $(".caja11.msgerror.ListaConsultaBL").html("Debe seleccionar por lo menos una BL.");
                        return;
                    }

                    var objRequest = { "filtros": objBL };

                    if ($rootScope.DatosFormulario.ExisteVigencia) {
                        $(".caja11.msgerror.ListaCalculoVB").html("");
                        miBlock(true, "html");

                        $.ajax({
                            url: "/CalculadorVB/CalcularServicioVB",
                            type: "POST",
                            headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                            data: objRequest,
                            dataType: "json",
                            cache: true,
                            async: true,
                            success: function (data) {

                                miBlock(false, "html");
                                if (data.Resultado.Estado == true) {

                                    $rootScope.DatosFormulario.CalcularVB.ListaCalculoVB = data.ListaCalculoVB;
                                    if (data.ListaCalculoAll.length > 0) {
                                        if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.length > 0) {
                                            // $scope.LimpiarObjetos();
                                            $scope.LimpiarListaCalculo();
                                            $.each(data.ListaCalculoAll, function (x) {
                                                $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.push(this);
                                            });
                                        } else {
                                            $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = data.ListaCalculoAll;
                                        }
                                    }
                                    $rootScope.DatosFormulario.CalcularVB.TotalSolesMoneda = data.TotalSoles;
                                    $rootScope.DatosFormulario.CalcularVB.TotalDolaresMoneda = data.TotalDolares;
                                    $scope.Grid_DataBind("ListarCalcularVb", $rootScope.DatosFormulario.CalcularVB.ListaCalculoVB);

                                } else {

                                    if (data.Resultado.Mensajes.length > 0) {
                                        MiError(data.Result.Mensajes[0].Mensaje);
                                    }
                                    else {
                                        MiError(data.Resultado.Mensaje);
                                    }
                                }

                            }
                        });


                    } else {
                        $(".caja11.msgerror.ListaConsultaBL").html("Debe seleccionar por lo menos una BL.");
                    }
                }

                $scope.Carrito_Click = function () {
                    $(".caja11.msgerror.ListaConsultaBL").html("");
                    if ($rootScope.DatosFormulario.BLSeleccionado == null) {
                        $(".caja11.msgerror.ListaConsultaBL").html("Debe seleccionar una BL.");
                        return;
                    }
                    var objBL = obtenerObjetoSeleccionarBL();
                    if (objBL == null) {
                        //$(".caja11.msgerror.ListaConsultaBL").html("Debe seleccionar por lo menos una BL.");
                        MiAlert("Ocurrio un error");
                        return;
                    }

                    if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.length == 0) {
                        MiAlert("Se debe calcular los servicios");
                        return;
                    }

                    if ($rootScope.DatosFormulario.ExisteVigencia) {

                        $rootScope.DatosFormulario.RegistraCarrito.Carrito.CodigoCarroCompras = 0;
                        $rootScope.DatosFormulario.RegistraCarrito.Carrito.CodigoLinea = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea;//objBL.CodigoLinea;
                        $rootScope.DatosFormulario.RegistraCarrito.Carrito.CodigoCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente;//objBL.CodigoCliente;

                        var ListCalcularVb = $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll;

                        var ListaBl = [];
                        var objNewBl = new Object();

                        var ListDetalleCarrito = [];


                        objNewBl.CodigoSucursal = objBL.CodigoSucursal;
                        objNewBl.NumeroBL = objBL.NumeroBL;
                        objNewBl.CodigoLinea = objBL.CodigoLinea;
                        objNewBl.CodigoNave = objBL.CodigoNave;
                        objNewBl.NumeroViaje = objBL.NumeroViaje;
                        objNewBl.CodigoPuertoOrigen = objBL.CodigoPuertoOrigen;
                        objNewBl.CodigoPuertoEmbarque = objBL.CodigoPuertoEmbarque;
                        objNewBl.CodigoPuertoDescarga = objBL.CodigoPuertoDescarga;
                        objNewBl.CodigoDestinoFinal = objBL.CodigoDestinoFinal;
                        objNewBl.CodigoTipoBL = objBL.TipoBL;
                        objNewBl.CodigoRegimen = objBL.CodigoRegimen;
                        objNewBl.CodigoSede = objBL.CodigoSucursal;
                        objNewBl.ListaDetalleCarro = [];

                        if (ListCalcularVb.length > 0) {
                            $.each(ListCalcularVb, function (x) {

                                var objCarrito = new Object();
                                objCarrito.CodigoCarroComprasDetalle = "";
                                objCarrito.CodigoCarroComprasBL = 0;
                                objCarrito.CodigoConceptoBoxer = this.CodigoConcepto;
                                objCarrito.CodigoGrupoConcepto = this.TipoConcepto;
                                objCarrito.MontoPagar = this.PrecioUnitario;
                                objCarrito.CodigoMoneda = this.CodigoMoneda;
                                objCarrito.Cantidad = this.Cantidad;
                                objCarrito.MontoIGV = this.MontoIGV;
                                objCarrito.MontoTotal = this.MontoTotal;
                                objCarrito.Observacion = this.Observaciones;
                                objCarrito.CodigoConceptoFalcon = this.CodigoConceptoFalcon;
                                objCarrito.CodigoTarifaFalcon = this.CodigoTarifaFalcon;
                                objCarrito.Contenedor = this.Contenedor;
                                objCarrito.NumeroExoneracion = this.NroExoneracion;
                                objCarrito.CodigoDestFactura = this.CodigoClienteDestinatario;
                                objCarrito.Accion = "I";

                                objCarrito.ListaSobrestadia = [];

                                if (this.ListaPeriodosSob.length > 0) {

                                    $.each(this.ListaPeriodosSob, function (y) {

                                        var objSob = new Object();
                                        objSob.CodigoCarroComprasSobrestadia = 0;
                                        objSob.CodigoCarroComprasDetalle = "";
                                        objSob.Contenedor = this.Contenedor;
                                        objSob.CodigoPeriodo = this.Periodo;
                                        objSob.FechaInicio = this.FechaInicio;
                                        objSob.FechaFin = this.FechaFin;
                                        objSob.DiasLibres = this.DiasLibres;
                                        objSob.DiasSobrestadia = this.DiasSobrestadia;
                                        objSob.CodigoMoneda = this.Moneda;
                                        objSob.MontoTarifa = this.Tarifa;
                                        objSob.TotalSobrestadia = this.TotalSobrestadia;

                                        objCarrito.ListaSobrestadia.push(objSob);
                                    });
                                }

                                objNewBl.ListaDetalleCarro.push(objCarrito);
                            });
                        }

                        ListaBl.push(objNewBl);
                        $rootScope.DatosFormulario.RegistraCarrito.ListaBL = ListaBl;
                        $(".caja11.msgerror.ListaCalculoVB").html("");


                        MiConfirm("Esta seguro de agregar al carrito?.", function () {
                            miBlock(true, "html");
                            $.ajax({
                                url: "/Carrito/RegistrarCarrito",
                                type: "POST",
                                headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                                data: $rootScope.DatosFormulario.RegistraCarrito,
                                dataType: "json",
                                cache: true,
                                async: true,
                                success: function (data) {
                                    miBlock(false, "html");
                                    if (data.Resultado.Estado == true) {

                                        if (data.Resultado.CodigoError == "1") {

                                            if (data.Resultado.Mensajes.length > 0) {
                                                MiAlert(data.Result.Mensajes[0].Mensaje);
                                            }
                                            else {
                                                MiAlert(data.Resultado.Mensaje);
                                            }
                                        } else {

                                            removerBL($rootScope.DatosFormulario.CalcularVB.ListaConsultaBL, objBL);

                                            // Limipo Objetos ------------------------------------------------------
                                            if ($rootScope.DatosFormulario.BLSeleccionado != undefined)
                                                $rootScope.DatosFormulario.BLSeleccionado = null;

                                            if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll != undefined)
                                                $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = [];

                                            if ($rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional != undefined)
                                                $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional = [];

                                            /*if ($rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales != undefined)
                                                $rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales = [];*/

                                            //------------------------------------------------------------------------
                                            $scope.LimpiarGrilla('ListarCalcularVb');
                                            $scope.LimpiarGrilla('ListarServiciosOpcionales');
                                            $scope.Grid_DataBind("ListarBL", $rootScope.DatosFormulario.CalcularVB.ListaConsultaBL);
                                            MiAlertOk("BL : " + objNewBl.NumeroBL + "  fue agregado algo carrito con éxito.", MiAlertOk_success);

                                        }

                                    } else {

                                        if (data.Resultado.Mensajes.length > 0) {
                                            MiError(data.Result.Mensajes[0].Mensaje);
                                        }
                                        else {
                                            MiError(data.Resultado.Mensaje);
                                        }
                                    }

                                }
                            });
                        });


                    } else {
                        $(".caja11.msgerror.ListaConsultaBL").html("Debe seleccionar por lo menos una BL.");
                    }

                }


                $scope.LimpiarObjetos = function () {

                    if ($rootScope.DatosFormulario.BLSeleccionado != undefined)
                        $rootScope.DatosFormulario.BLSeleccionado = null;

                    $scope.LimpiarListaCalculo();
                    /*if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll != undefined)
                        if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.length > 0) {
                            var ListListaCalculoAll = $.extend(true, [], $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll);
                            var LstSrvOpcional = $.grep(ListListaCalculoAll, function (e) { return e.TipoConcepto == "004"; });
                            $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = LstSrvOpcional;
                        }
                    */
                }


                $scope.LimpiarListaCalculo = function () {

                    if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll != undefined)
                        if ($rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.length > 0) {
                            var ListListaCalculoAll = $.extend(true, [], $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll);
                            var LstSrvOpcional = $.grep(ListListaCalculoAll, function (e) { return e.TipoConcepto == "004"; });
                            $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = LstSrvOpcional;
                        }
                       // $scope.$apply();
                }

                $scope.Salir_Click = function () {
                    $rootScope.Redirect("/#!/sistema/bienvenido/");
                }

                $scope.CarritoGo_Click = function () {
                    $rootScope.Redirect("/#!/sistema/carrito/");
                }

                function MiAlertOk_success() {

                }

                function PendienteDePago_Page() {
                    $rootScope.Redirect("/#!/sistema/pendiente-pago");
                }


                $scope.LimpiarGrilla = function (grid) {
                    if (grid == 'Todos') {
                        $scope.gridapigrillaVistoBuenoListarBL.refresh([]);
                        $scope.gridapigrillaVistoBuenoServicios.refresh([]);
                        $scope.gridapigrillaVistoBuenoServiciosOpcionales.refresh([]);

                        $rootScope.DatosFormulario.CalcularVB.TotalSolesMoneda = null;
                        $rootScope.DatosFormulario.CalcularVB.TotalDolaresMoneda = null;

                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda = null;
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda = null;
                    }
                    if (grid == "ListarBL") {
                        $scope.gridapigrillaVistoBuenoListarBL.refresh([]);
                    }
                    if (grid == "ListarCalcularVb") {
                        $scope.gridapigrillaVistoBuenoServicios.refresh([]);
                        $rootScope.DatosFormulario.CalcularVB.TotalSolesMoneda = null;
                        $rootScope.DatosFormulario.CalcularVB.TotalDolaresMoneda = null;
                    }
                    if (grid == "ListarServiciosOpcionales") {
                        $scope.gridapigrillaVistoBuenoServiciosOpcionales.refresh([]);
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda = null;
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda = null;
                    }
                    $scope.$apply();
                }

                $scope.AgregarServicioOpcional = function (grid) {
                    $(".caja11.msgerror.ListaServiciosOpcionales").html("");
                    var objBL = $rootScope.DatosFormulario.BLSeleccionado;
                    if (objBL == null) {
                        $(".caja11.msgerror.ListaServiciosOpcionales").html("Debe seleccionar una BL.");
                        return;
                    }
                    $rootScope.IdBL = objBL.Id;
                    getPopupResponsive({
                        formURL: "ServicioBl",
                        title: "Agregar Servicio Opcional",
                        nombreDiv: "divAgregarServicioOpcional",
                        nombreGrid: "",
                        width: "0px",
                        height: 800,
                        params: {},
                        HideSelection: true,
                        multiSelect: false,
                        select: function (row) {
                            return true;
                        },
                        beforeShow: function (obj) {
                            $rootScope.hashPopup = $(obj).attr("mapurl");
                            // $(obj).attr("ModoPagina", tipo);
                            $compile($("#divAgregarServicioOpcional"))($scope);
                            //var scopePopup = angular.element("#divAgregarServicioOpcional").scope();
                            //scopePopup.row = JSON.parse(JSON.stringify(rowObject));
                            //scopePopup.rowOk = rowObject;
                        }
                    });
                    $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda = 0;
                    $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda = 0;
                }

                $scope.QuitarServicioOpcional = function (idServicioOpcional) {
                    //$rootScope.DatosFormulario.CalcularVB.ListaCalculoAll
                    var listaGrillaMemoriaServicioOpcional = $rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales;
                    var listaGrillaServicioOpcional = [];
                    var listaBaseMemoriaServicioOpcional = $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional;
                    var listaBaseServicioOpcional = [];

                    var ListadoMemoriaServiciosOpcionalesAll = $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll;
                    var listaBaseServicioOpcionalAll = [];

                    // Elimina de la Lista Servicio Opcional
                    for (var x = 0; x < listaGrillaMemoriaServicioOpcional.length; x++) {
                        if (listaGrillaMemoriaServicioOpcional[x].IdServicioOpcional != idServicioOpcional) {
                            listaGrillaServicioOpcional.push(listaGrillaMemoriaServicioOpcional[x]);
                        }
                    }
                    // Elimina de la Lista Servicio Opcional Temporal
                    for (var x = 0; x < listaBaseMemoriaServicioOpcional.length; x++) {
                        if (listaBaseMemoriaServicioOpcional[x].IdServicioOpcional != idServicioOpcional) {
                            listaBaseServicioOpcional.push(listaBaseMemoriaServicioOpcional[x]);
                        }
                    }
                    // elimina de la Lista ListaCalculoAll
                    for (var x = 0; x < ListadoMemoriaServiciosOpcionalesAll.length; x++) {
                        if (ListadoMemoriaServiciosOpcionalesAll[x].TipoConcepto == "004") {
                            if (ListadoMemoriaServiciosOpcionalesAll[x].IdServicioOpcional != idServicioOpcional) {
                                listaBaseServicioOpcionalAll.push(ListadoMemoriaServiciosOpcionalesAll[x]);
                            }
                        } else {
                            listaBaseServicioOpcionalAll.push(ListadoMemoriaServiciosOpcionalesAll[x]);
                        }
                    }

                    $rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales = listaGrillaServicioOpcional;
                    $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional = listaBaseServicioOpcional;
                    $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll = listaBaseServicioOpcionalAll;

                    $scope.gridapigrillaVistoBuenoServiciosOpcionales.refresh(listaGrillaServicioOpcional);
                    $scope.CalculcularMontosServOpcionales();
                    $rootScope.$apply();
                }


                $scope.CalculcularMontosServOpcionales = function (idBL) {

                    var MontoSoles = 0;//$rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda ;
                    var MontoDolares = 0; // $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda;
                    
                    if ($rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional.length > 0) {
                        var Listado = $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional;
                        var LstServOpcionxBL = $.grep(Listado, function (e) { return e.IdBL == idBL; });
                        $.each(LstServOpcionxBL, function (y) {
                            if (this.CodigoMoneda == "105") // DOLARES
                            {
                                MontoDolares = parseFloat(MontoDolares) + parseFloat(this.MontoTotal);
                            } else {
                                MontoSoles = parseFloat(MontoSoles) + parseFloat(this.MontoTotal);
                            }
                        });
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalSolesMoneda = MontoSoles;
                        $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.TotalDolaresMoneda = MontoDolares;
                    }
                }

                function removerBL(arr, item) {
                    var i = arr.indexOf(item);
                    arr.splice(i, 1);
                }



            }]);
})();