(function () {
    angular.module('api')
    .controller('CarritoClienteFacturaController',
      ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$compile',
      function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $compile) {
          $timeout(function () {

        			if ($rootScope.DatosFormulario == undefined)
        				  $rootScope.DatosFormulario = new Object();
	  
              if ($rootScope.DatosFormulario.Carrito  == undefined)
                  $rootScope.DatosFormulario.Carrito  = new Object();

              if ($rootScope.DatosFormulario.Carrito.ClienteFaturar == undefined)
                  $rootScope.DatosFormulario.Carrito.ClienteFaturar = new Object();
              

              $rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto = [];
      			  $scope.CargarDatosIniciales();

          });

           $scope.CargarDatosIniciales = function () {
            
            var listaTempConcepto= new Object();
            listaTempConcepto=[];
            listaTempConcepto = $scope.row ;
           // listaTempConcepto=$.grep($rootScope.DatosFormulario.DatosGenerales.DataBuscarDetalleClientes.ClienteLineaMatchCodeList, function (e) { 
           //   return  e.CodigoLinea == $scope.row.CodigoLinea && e.CodigoMatchCode ==$scope.row.idMatchCode  && e.Accion != "U" ; });
            if (!$scope.EsLiquidacion) {
                $.ajax({
                    url: "/Carrito/ConsultarClienteFacturar",
                    type: "POST",
                    headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                    data: "CodigoCarroComprasBL=" + $scope.CodigoCarroComprasBL,
                    dataType: "json",
                    cache: true,
                    async: false,
                    success: function (data) {

                        if (data.Resultado.Estado == true) {
                            if (data.ListaBLClienteFacturar.length > 0) {
                                $rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto = data.ListaBLClienteFacturar;
                            } else {
                                $rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto = listaTempConcepto;

                            }
                        }
                    }
                });
            } else {
                $.ajax({
                    url: "/Carrito/ConsultarLiquidacionClienteFacturar",
                    type: "POST",
                    headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                    data: "CodigoCarroComprasLiquidacion=" + $scope.CodigoCarroComprasLiquidacion,
                    dataType: "json",
                    cache: true,
                    async: false,
                    success: function (data) {

                        if (data.Resultado.Estado == true) {
                            if (data.ListaBLClienteFacturar.length > 0) {
                                $rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto = data.ListaBLClienteFacturar;
                            } else {
                                $rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto = listaTempConcepto;

                            }
                        }
                    }
                });
            }
            $scope.gridapigrillaCarritoClienteFactura.refresh($rootScope.DatosFormulario.Carrito.ClienteFaturar.ListaConcepto);
            $rootScope.$apply();
        }
		  
          $scope.MiBoton = function (idgrilla, tipoboton, cellvalue, options, rowObject) {
              var eventoclick = "";
              switch (idgrilla) {
                  case "grillaCarritoClienteFactura":
                    {
                        switch (tipoboton) {
                            case "Editar":
                                eventoclick = "$parent.BuscarCliente('" + rowObject.CodigoGrupoConcepto + "' , '" + rowObject.CodigoCarroComprasLiquidacion + "');";
                                break;
                           /* case "Quitar":
                                eventoclick = "$parent.QuitarBL('" + rowObject.col + "');";
                                break;*/
                        }
                    }
                    break;
   

              }

              if (tipoboton == "Editar") {
                  html = HtmlCrearBoton("Modificar", eventoclick, "");
              }
              if (tipoboton == "Quitar") {
                  html = HtmlCrearBoton("Eliminar", eventoclick, "");
              }
              return html;
          }


          $scope.BuscarCliente = function (CodigoGrupoConcepto, CodigoCarroComprasLiquidacion) {

              var rowObject;
              if (CodigoGrupoConcepto != "null" && CodigoGrupoConcepto != "0") {
                  rowObject = CodigoGrupoConcepto;
              }
              if (CodigoCarroComprasLiquidacion != "null" && CodigoCarroComprasLiquidacion != "0") {
                  rowObject = CodigoCarroComprasLiquidacion;
              }
                $rootScope.FlagCallClientes = "busquedaCarritoAfacturar";
                $rootScope.FlagTipoCliente = "busqueda";
                var altura = 800;
                getPopupResponsive({
                    formURL: "Cliente/BuscarCliente",
                    title: "Buscar Cliente",
                    nombreDiv: "divPopupBuscarCliente",
                    nombreGrid: "",
                    width: "1200px",
                    height: altura,
                    params: {},
                    HideSelection: true,
                    multiSelect: false,
                    select: function (row) {
                        return true;
                    },
                    beforeShow: function (obj) {
                        $rootScope.hashPopup = $(obj).attr("mapurl");
                        $compile($("#divPopupBuscarCliente"))($scope);

                      var scopePopup = angular.element("#divPopupRegistroClienteFactrura").scope();
                      scopePopup.row = JSON.parse(JSON.stringify(rowObject));
                      scopePopup.rowOk = rowObject;

                    }
                });

            }
            
            
            $scope.Salir_Click=function(){
              $scope.$parent.SalirPopup_Click(); 
            } 


            $scope.Grabar_Click = function () {
                if (!$scope.EsLiquidacion) {
                    $.ajax({
                        url: "/Carrito/RegistrarClienteFacturar",
                        type: "POST",
                        headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                        data: $rootScope.DatosFormulario.Carrito.ClienteFaturar,
                        dataType: "json",
                        cache: true,
                        async: false,
                        success: function (data) {

                            if (data.Resultado.Estado == true) {
                                MiAlertOk("Se ha actulizado los conceptos con éxito.", MiAlertOk_success);
                            }
                        }
                    });
                } else {
                    $.ajax({
                        url: "/Carrito/RegistrarLiquidacionClienteFacturar",
                        type: "POST",
                        headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                        data: $rootScope.DatosFormulario.Carrito.ClienteFaturar,
                        dataType: "json",
                        cache: true,
                        async: false,
                        success: function (data) {

                            if (data.Resultado.Estado == true) {
                                MiAlertOk("Se ha actulizado los conceptos con éxito.", MiAlertOk_success);
                            }
                        }
                    });
                }
            }

            
            function MiAlertOk_success() {
                $scope.$parent.SalirPopup_Click();
            }

      }]);
})();