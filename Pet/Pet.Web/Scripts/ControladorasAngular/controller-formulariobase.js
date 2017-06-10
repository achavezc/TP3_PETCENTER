(function () {
    angular.module('api')
		.controller('FormularioBaseController',
			['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector',
			function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector) {

			    $timeout(function () {
			        //aqui también puede activar plugins, se ejecuta al final de carga de página.
			        ponerFechas();
			        PonerFocoInicio();
			        $("input[type=text]").on("keyup", function (e) {
			            var keyespecial = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
			            if (keyespecial == 13) {
			                $("img[alt=Buscar]").parent().parent().click();
			            }
			        });
			    });
			 
			
		



			}]);


})();