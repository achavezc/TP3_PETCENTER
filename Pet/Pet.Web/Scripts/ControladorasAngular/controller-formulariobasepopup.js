(function () {
    angular.module('api')
		.controller('FormularioBasePopupController',
			['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$attrs',
			function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $attrs) {

			    $timeout(function () {
			        //aqui también puede activar plugins, se ejecuta al final de carga de página.
			        ponerFechas($attrs.id);
			        PonerFocoInicio($attrs.id);

			        $("input[type=text]").on("keyup", function (e) {
			            var keyespecial = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
			            if (keyespecial == 13) {
			                $("img[alt=Buscar]").parent().parent().click();
			            }
			        });


			    });
			    $scope.SalirPopup_Click = function () {
			        //$("#"+$attrs.id).dialog("close");
			        $("#" + $attrs.id).modal("hide");
			    }
			 
			  



			}]);


})();