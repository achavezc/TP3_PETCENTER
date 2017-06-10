(function () {
    angular.module('api')
    .controller('PageHomeController',
      ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$location', '$window',
      function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $location, $window) {

          $timeout(function () {
              //aqui también puede activar plugins, se ejecuta al final de carga de página.
              $("#frmLogin").appendTo("#HomeSeccionDerecha")
              PORTAL.init();
              $scope.CargarFormularioLogin();

          });


          $scope.CargarFormularioLogin = function () {
              //if($scope.datosFormularioLogin==undefined)
              //{
              //return null;
              //}
              //var datosFormularioLogin= $scope.datosFormularioLogin;
              //var datosLogin={
              //      "submit":datosFormularioLogin.Parts.es_pe__NombreBoton,
              //      "mensajeError":datosFormularioLogin.Parts.es_pe__MensajeError,
              //      "urlLogin":"/SeguridadAgma/Login/",
              //      "urlHome": datosFormularioLogin.Parts.PaginaInicio,
              //      "modoAutenticacion": datosFormularioLogin.Parts.ModoAutenticacion.Value,
              //    };
              var datosLogin = {
                  "submit": "Ingresar",
                  "mensajeError": "Usuario y/o Contraseña Incorrectos",
                  "urlLogin": "/SeguridadAgma/Login/",
                  "urlHome": "sistema/bienvenido/",
                  "modoAutenticacion": "AW",
              };
              if (datosLogin.modoAutenticacion == "AW") {
                  $("#frmLogin>.fila").hide()
              }
              var mifrmLogin = $("#frmLogin form");
              mifrmLogin.find(":submit").val(datosLogin.submit);

              mifrmLogin.find("input[name=Usuario], input[name=Contrasena]").attr("maxlength", 50);
              mifrmLogin.find("input[name=Usuario]").addClass("soloalfanumerico inc_arroba inc_backslash inc_punto inc_menos");
              $(mifrmLogin).submit(function () {
                  var valorUsuario = mifrmLogin.find("input[name=Usuario]").val();
                  var valorClave = mifrmLogin.find("input[name=Contrasena]").val();
                  var resultado = true;
                  if (valorUsuario == "") {
                      mifrmLogin.find("input[name=Usuario]").parent().find(".field-validation-valid").html("Campo obligatorio");
                      //resultado = false;
                  }
                  if (valorClave == "") {
                      mifrmLogin.find("input[name=Contrasena]").parent().find(".field-validation-valid").html("Campo obligatorio");
                      //resultado = false;
                  }
                  if (!resultado) {
                      //return false;
                  }
                 

                  //if (!$(this).data("validator").valid())
                  //    return false;

                  if (mifrmLogin.find("input[name=Contrasena]").val() === "")
                      return false;

                  miBlock(true, "#ContenedorBody");
                  mifrmLogin.find(":submit").attr("disabled", "disabled");
                  $.ajax({
                      url: datosLogin.urlLogin,
                      type: "POST",
                      headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                      data: "usuario=" + encodeURIComponent(mifrmLogin.find("input[name=Usuario]").val())
                          + "&Password=" + encodeURIComponent(mifrmLogin.find("input[name=Contrasena]").val()),
                      dataType: "json",
                      success: function (data) {
                          if (data != undefined) {
                              if (data.Success === true) {
                                  //$rootScope.CargaInicialAplicacion();

                                  //$location.url(datosLogin.urlHome)
                                  $window.location.href = "#!/" + datosLogin.urlHome;
                              }
                              else {
                                  MiError(datosLogin.mensajeError);
                              }
                          }
                          mifrmLogin.find(":submit").removeAttr("disabled");
                          miBlock(false, "#ContenedorBody");
                          $scope.CargarMenu();
                      }
                  });


                  return false;
              });

          };


      }]);


})();