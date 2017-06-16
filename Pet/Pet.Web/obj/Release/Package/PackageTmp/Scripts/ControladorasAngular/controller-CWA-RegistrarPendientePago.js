(function () {
    angular.module('api')
        .controller('RegistrarPendientePagoController',
        ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$compile',
            function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $compile) {
                $timeout(function () {

                    if ($rootScope.DatosFormulario == undefined)
                        $rootScope.DatosFormulario = new Object();

                    //$scope.CargarDatosIniciales();
                    //$scope.FlagCargaMasivaEliminar = true;


                });

                $scope.CargarDatosIniciales = function () {
                    $.ajax({
                        url: "/CargaMasiva/CargaMasivaIndex",
                        type: "POST",
                        headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                        data: "",
                        dataType: "json",
                        cache: true,
                        async: false,
                        success: function (data) {
                            $rootScope.DatosFormulario.DatosCargaMasivaAC.Lineas = data.Linea;
                            if (data.Linea.length > 0) {
                                $rootScope.DatosFormulario.CargaMasivaAC.CodigoLinea = data.Linea[0].Codigo;
                                if (data.Linea.length == 1) {
                                    $rootScope.DatosFormulario.DatosCargaMasivaAC.Habilitado = 'False';
                                }
                            }
                        }
                    });
                }



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

                $scope.CalcularServicio_Click = function () {

                    MiAlert("Calcular");
                }

                $scope.Carrito_Click = function () {
                    MiAlert("carrito");
                }

                $scope.CarritoGo_Click = function () {
                    $rootScope.Redirect("/#!/sistema/carrito/");
                }

                function MiAlertOk_success() {

                }

            }]);
})();