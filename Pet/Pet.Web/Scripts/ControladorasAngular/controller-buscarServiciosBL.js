(function () {
    angular.module('api')
        .controller('BuscarServiciosBLController',
        ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$compile',
            function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $compile) {
                $timeout(function () {
                    $scope.CargarDatosIniciales();
                });

                $scope.CargarDatosIniciales = function () {
                    if ($rootScope.DatosFormulario == undefined)
                        $rootScope.DatosFormulario = new Object();
                    if ($rootScope.DatosFormulario.DataFiltroBusquedaServicioBL == undefined)
                        $rootScope.DatosFormulario.DataFiltroBusquedaServicioBL = new Object();
                    $rootScope.FlagMostrarBotonSeleccionar = true;
                    $scope.Limpiar_Click();
                }

                $scope.GrillaDblClick = function (obj, idgrilla, rowid, iRow, iCol, e) {
                    var data = jQuery("#" + obj.id).jqGrid('getRowData', rowid);
                    var estado = ProcesarSeleccionado(data);
                    if (estado) {
                        $rootScope.$apply();
                        $scope.$parent.SalirPopup_Click();
                    }
                }

                function validateDuplicate(data, lista) {
                    var listDuplicateKey = $.grep(lista, function (e) { return e.CodigoConceptoBoxer == data.CodigoConceptoBoxer; });
                    if (listDuplicateKey.length > 0) {
                        $(".caja11.msgerror.Objeto").html("El servicio seleccionado ya existe, elija otro.");
                        return true;
                    } else {
                        $(".caja11.msgerror.Objeto").html("");
                        return false;
                    }
                }

                function ProcesarSeleccionado(data) {
                    var nuevoId;

                    if (validateDuplicate(data, $rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales)) {
                        return false;
                    }
                    //nuevoId = Helpers.GenerarId($rootScope.DatosFormulario.CalcularVB.ListaServiciosOpcionales, "IdServicioOpcional");
                    nuevoId = Helpers.GenerarId($rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional, "IdServicioOpcional");
                    
                    var newObjAcLocalALaNave = {
                        IdBL: $rootScope.IdBL,  // nuevo
                        IdServicioOpcional: nuevoId,
                        CodigoConceptoBoxer: data.CodigoConceptoBoxer,
                        NombreConcepto: data.NombreConcepto,
                        Cantidad: 1,
                        Moneda: data.Moneda,
                        CodigoMoneda: data.CodigoMoneda,
                        PrecioUnitario: data.Monto,
                        MontoIGV: data.MontoIGV,
                        MontoTotal: parseFloat(data.Monto) + parseFloat(data.MontoIGV),
                        Accion: "I"
                    }
                    $scope.gridapigrillaVistoBuenoServiciosOpcionales.insertRange([newObjAcLocalALaNave]);
 
                    // ListaMemoriaServOpcional...
                    $rootScope.DatosFormulario.CalcularVB.ServicioOpiconal.ListaMemoriaServOpcional.push(newObjAcLocalALaNave);

                    
                    $scope.CalculcularMontosServOpcionales($rootScope.IdBL);
                    cargarItemParaCalcularVB(data ,nuevoId);
                    return true;
                }


                function cargarItemParaCalcularVB(data , idServicioOpcional) {
                    var objCalcular = new Object();
                    
                    //objCalcular.IdBL = $rootScope.IdBL;  // nuevo
                    objCalcular.IdServicioOpcional = idServicioOpcional;
                    objCalcular.Cantidad = 1;
                    objCalcular.CodigoClienteDestinatario = "";
                    objCalcular.CodigoConcepto = data.CodigoConceptoBoxer;
                    objCalcular.CodigoConceptoFalcon = data.CodigoConceptoFalcon;
                    objCalcular.CodigoMoneda = data.CodigoMoneda;
                    objCalcular.CodigoTarifaFalcon = data.CodigoTarifaFalcon;
                    objCalcular.Contenedor = "";
                    objCalcular.Moneda = data.Moneda;
                    objCalcular.MontoIGV = data.MontoIGV;
                    objCalcular.MontoTotal = parseFloat(data.Monto) + parseFloat(data.MontoIGV);
                    objCalcular.NombreConcepto = data.NombreConcepto;
                    objCalcular.NroExoneracion = 0;
                    objCalcular.Observaciones = "";
                    objCalcular.PrecioUnitario = data.Monto;
                    objCalcular.TipoConcepto = data.CodigoGrupoConcepto;
                    objCalcular.ListaPeriodosSob = [];
                    $rootScope.DatosFormulario.CalcularVB.ListaCalculoAll.push(objCalcular);
                }

                $scope.Seleccionar_Click = function () {
                    var rowKey = jQuery("#grillaBusquedaListaServiciosBL").jqGrid('getGridParam', 'selrow');
                    if (rowKey != undefined) {
                        if (rowKey.length > 0) {
                            var rowObject = jQuery('#grillaBusquedaListaServiciosBL').getRowData(rowKey);
                            var estado = ProcesarSeleccionado(rowObject);
                            if (estado) {
                                $(".caja11.msgerror.Objeto").html("");
                                $scope.$parent.SalirPopup_Click();
                            }

                        } else {
                            $(".caja11.msgerror.Objeto").html("Seleccione un registro.");
                        }
                    } else {
                        $(".caja11.msgerror.Objeto").html("Seleccione un registro.");
                    }
                }

                $scope.Grid_DataBind = function (grid, data) {
                    $scope.gridapiListaNaveDesde.refresh(data);

                }

                $scope.Buscar_Click = function () {
                    $(".caja11.msgerror.Objeto").html("");
                    if ($rootScope.EsEnter) {
                        return false;
                    }
                    miBlock(true, "#divPopupBuscarServiciosBL");
                    $rootScope.DatosFormulario.DataFiltroBusquedaServicioBL.CodigoLinea = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea;
                    $rootScope.DatosFormulario.DataFiltroBusquedaServicioBL.CodigoSucursal = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoSucursal;
                    var objRequest = { "filtro": JSON.parse(JSON.stringify($rootScope.DatosFormulario.DataFiltroBusquedaServicioBL)) };
                    $scope.gridapigrillaBusquedaListaServiciosBL.find(objRequest);
                    miBlock(false, "#divPopupBuscarServiciosBL");
                }

                $scope.Salir_Click = function () {
                    $scope.$parent.SalirPopup_Click();
                }

                $scope.Limpiar_Click = function () {
                    $(".caja11.msgerror.Objeto").html("");
                    $rootScope.DatosFormulario.DataFiltroBusquedaServicioBL.CodigoServicio = "";
                    $rootScope.DatosFormulario.DataFiltroBusquedaServicioBL.NombreServicio = "";
                }

                $scope.Enter = function () {
                    $rootScope.EsEnter = true;
                    return false;
                }

                $("input").focusout(function () {
                    $rootScope.EsEnter = false;
                });

            }]);
})();