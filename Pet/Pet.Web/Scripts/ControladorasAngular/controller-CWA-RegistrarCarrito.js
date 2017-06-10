(function () {
    angular.module('api')
    .controller('RegistrarCarritoController',
      ['$scope', '$http', '$routeParams', '$timeout', 'Enum', 'ParseHtml', '$rootScope', 'Helpers', 'ServiciosConector', '$compile',
      function ($scope, $http, $routeParams, $timeout, Enum, ParseHtml, $rootScope, Helpers, ServiciosConector, $compile) {
          $timeout(function () {

              if ($rootScope.DatosFormulario == undefined)
                  $rootScope.DatosFormulario = new Object();

              if ($rootScope.DatosFormulario.Carrito == undefined)
                  $rootScope.DatosFormulario.Carrito = new Object();

              if ($rootScope.DatosFormulario.Carrito.Filtro == undefined)
                  $rootScope.DatosFormulario.Carrito.Filtro = new Object();


              if ($rootScope.DatosFormulario.Carrito.DatosCarrito == undefined)
                  $rootScope.DatosFormulario.Carrito.DatosCarrito = new Object();


              $rootScope.DatosFormulario.Carrito.DatosCarrito.ListaCarritoBL = [];
              if ($rootScope.DatosFormulario.CalcularVB != undefined) {

                  $rootScope.DatosFormulario.Carrito.Filtro.CodigoCarroCompras = 0;
                  $rootScope.DatosFormulario.Carrito.Filtro.CodigoLinea = $rootScope.DatosFormulario.CalcularVB.Filtro.CodigoLinea;
                  $rootScope.DatosFormulario.Carrito.Filtro.CodigoCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente;

                  $scope.CargarDatosIniciales();
              }

          });

          $scope.CargarDatosIniciales = function () {
              $scope.gridapigrillaCarritoServicio.refresh([]);
              var objRequest = {
                  "request":
                    {
                        "Carrito": $rootScope.DatosFormulario.Carrito.Filtro
                    }
              };

              $.ajax({
                  url: "/Carrito/ConsultarCarritoBlLiquidacion",
                  type: "POST",
                  headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                  data: objRequest,
                  dataType: "json",
                  cache: true,
                  async: false,
                  success: function (data) {

                      if (data.Resultado.Estado == true) {
                          $rootScope.DatosFormulario.Carrito.Comision = "Monto Total en Soles de los BLS c/ conceptos en Soles + Comisión por Operación. (5 USD)     Monto Total en Dolares de los BLS c/ conceptos en Soles + Comisión por Operación. (5 USD)";
                          $rootScope.DatosFormulario.Carrito.DatosCarrito.ListaCarritoBL = data.ListaCarroComprasBL;
                          $scope.Grid_DataBind("ListarBL", $rootScope.DatosFormulario.Carrito.DatosCarrito.ListaCarritoBL);

                          // Cargar Seccion Liquidacion
                          $rootScope.DatosFormulario.Carrrito.Liquidacion.ListaCarroComprasLiquidacion = data.ListaCarroComprasLiquidacion;
                          $scope.Grid_DataBind("ListarLiquidacion", $rootScope.DatosFormulario.Carrrito.Liquidacion.ListaCarroComprasLiquidacion);
                          // Muestra Detalle
                          if (data.ListaCarroComprasBL.length > 0) {
                              //var ListaDetalleServicio =  data.ListaCarroComprasBL[0].ListaDetalleCarro;
                              //$scope.Grid_DataBind("ListaServicio",ListaDetalleServicio);
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

                              var groupDetalleServicio = data.ListaCarroComprasBL[0].GroupDetalleCarro;
                              var lstDetalleCarrito = groupDetalleServicio.LstGroupDetalleCarro;
                              $rootScope.DatosFormulario.Carrrito.Servicio.TotalSolesMoneda = groupDetalleServicio.TotalSoles;
                              $rootScope.DatosFormulario.Carrrito.Servicio.TotalDolaresMoneda = groupDetalleServicio.TotalDolares;
                              ObtenerSolesDolareLiquidacion(data.CodigoSoles, data.CodigoDolares);
                              $scope.Grid_DataBind("ListaServicio", lstDetalleCarrito);
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

          function ObtenerSolesDolareLiquidacion(CodigoSoles, CodigoDolares) {
              var montoSoles = 0;
              var montoDolares = 0;
              var datos = $rootScope.DatosFormulario.Carrrito.Liquidacion.ListaCarroComprasLiquidacion;
              for (i = 0; i < datos.length; i++) {
                  if (datos[i].CodigoMoneda == CodigoSoles) {
                      montoSoles += datos[i].Monto;
                  }
                  if (datos[i].CodigoMoneda == CodigoDolares) {
                      montoDolares += datos[i].Monto;
                  }
              }
              $rootScope.DatosFormulario.Carrrito.Liquidacion.TotalSolesMoneda = montoSoles;
              $rootScope.DatosFormulario.Carrrito.Liquidacion.TotalDolaresMoneda = montoDolares;
          }
          $scope.Salir_Click = function () {
              $rootScope.Redirect("/#!/sistema/calcular-vb/");
          }
          $scope.checkBoxGrilla = function (event, idgrilla) {
              var check = angular.element(event.target)[0].checked;
              setTimeout('$("#gbox_' + idgrilla + '").find("#' + event.target.id + '").prop("checked",' + check + ')', 50);
              if (idgrilla == "grillaListaSucursales") {
                  $.each($rootScope.DatosFormulario.DatosTarifaEscalonada.ListaSucursales, function (x) { this.idCheck = check; });
              }
          }


          $scope.MiBoton = function (idgrilla, tipoboton, cellvalue, options, rowObject) {
              var eventoclick = "";
              switch (idgrilla) {
                  case "grillaVbCarritoListarBL":
                      {
                          switch (tipoboton) {
                              case "Editar":
                                  eventoclick = "$parent.aFacturar('" + rowObject.CodigoCarroCompras + "' , '" + rowObject.CodigoCarroComprasBL + "');";
                                  break;
                              case "Quitar":
                                  eventoclick = "$parent.QuitarBL('" + rowObject.CodigoCarroCompras + "' , '" + rowObject.CodigoCarroComprasBL + "');";
                                  break;
                          }
                      }
                      break;
                  case "grillaVbCarritoLiquidacion":
                      {
                          switch (tipoboton) {
                              case "Editar":
                                  eventoclick = "$parent.aFacturarLiquidacion('" + rowObject.CodigoCarroComprasLiquidacion + "' , '" + rowObject.CodigoTipoLiquidacion + "' , '" + rowObject.TipoLiquidacion + "');";
                                  break;
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

          $scope.Pagar_Click = function () {
              var resultado = ValidarClienteFacturar();
              if (resultado == false) {
                  return false;
              }
          }
          function ValidarClienteFacturar() {
              var resultado = true;
              var listaBL = $from($rootScope.DatosFormulario.Carrito.ListaConsultaBL).where("$IdCheck==true").toArray();
              var listaLiquidacion = $rootScope.DatosFormulario.Carrrito.Liquidacion.ListaCarroComprasLiquidacion;
              var listaCodigoBL = [];
              var listaCodigoLiquidacion = [];
              if (listaLiquidacion.length > 0) {
                  $.each(listaLiquidacion, function (x) {
                      var obj = {};
                      obj.CodigoCarroComprasLiquidacion = this.CodigoCarroComprasLiquidacion;
                      listaCodigoLiquidacion.push(obj);
                  });
                  if (listaBL.length > 0) {
                      $.each(listaBL, function (x) {
                          var obj = {};
                          obj.CodigoCarroComprasBL = this.CodigoCarroComprasBL;
                          listaCodigoBL.push(obj);
                      });
                  }
                  var objRequest = {};
                  objRequest.ListaBLClienteFacturar = listaCodigoBL;
                  objRequest.ListaLiquidacionClienteFacturar = listaCodigoLiquidacion;
                  $.ajax({
                      url: "/Carrito/ValidarClienteFacturar",
                      type: "POST",
                      headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                      data: objRequest,
                      dataType: "json",
                      cache: true,
                      async: false,
                      success: function (data) {
                          if (data) {

                          }
                      }
                  });

              } else {
                  if (listaBL.length > 0) {

                  } else {
                      MiAlert("Debe Seleccionar por lo menos un BL para poder realizar el pago");
                      resultado = false;
                  }
              }

              return resultado;
          }
          $scope.aFacturar = function (CodigoCarroCompras, CodigoCarroComprasBL) {
              //   var objReg = $from($rootScope.DatosFormulario.DatosGenerales.DataBuscarDetalleClientes.ClienteMatchCodeList).where("$idMatchCode=='" + id + "'").firstOrDefault();
              //    $(".caja11.ListaMatchcode").html("");
              var ListaServicio = [];
              var Listado = $rootScope.DatosFormulario.Carrito.DatosCarrito.ListaCarritoBL;
              ListaServicio = $.grep(Listado, function (e) {
                  return e.CodigoCarroCompras == CodigoCarroCompras &&
                                      e.CodigoCarroComprasBL == CodigoCarroComprasBL;
              });

              var ListaDetalleServicio = ListaServicio[0].ListaDetalleCarro;
              var ListaconceptoLocal = ObtenerConceptoPorServicio(ListaDetalleServicio);

              AbrirPopup_aFacturar("Editar", ListaconceptoLocal, CodigoCarroComprasBL);

          }
          $scope.aFacturarLiquidacion = function (CodigoCarroComprasLiquidacion, CodigoTipoLiquidacion, TipoLiquidacion) {
              var unique = {};
              var distinct = [];
              var obj = new Object();
              obj.Accion = "I"
              obj.CodigoCarroComprasBL = CodigoCarroComprasLiquidacion;
              obj.CodigoGrupoConcepto = CodigoTipoLiquidacion;
              obj.NombreGrupoConcepto = TipoLiquidacion;
              obj.CodigoCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente;
              obj.DescripcionCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserNombreCliente;
              distinct.push(obj);

              AbrirPopup_aFacturarLiquidacion("Editar", distinct, CodigoCarroComprasLiquidacion);

          }


          AbrirPopup_aFacturar = function (tipo, rowObject, CodigoCarroComprasBL) {

              var altura = 800;
              getPopupResponsive({
                  formURL: "ClienteFacturar",
                  title: "A Facturar",
                  nombreDiv: "divPopupRegistroClienteFactrura",
                  nombreGrid: "",
                  width: "0px",
                  height: altura,
                  params: {},
                  HideSelection: true,
                  multiSelect: false,
                  select: function (row) {
                      //llena aqui o cuando completa el grabado:  $rootScope.DatosFormulario.DataParaLiberar
                      return true;
                  },
                  beforeShow: function (obj) {
                      $rootScope.hashPopup = $(obj).attr("mapurl");
                      $(obj).attr("ModoPagina", tipo);
                      $compile($("#divPopupRegistroClienteFactrura"))($scope);
                      var scopePopup = angular.element("#divPopupRegistroClienteFactrura").scope();
                      scopePopup.row = JSON.parse(JSON.stringify(rowObject));
                      scopePopup.CodigoCarroComprasBL = CodigoCarroComprasBL;
                      scopePopup.EsLiquidacion = false;
                      scopePopup.rowOk = rowObject;


                  },

              });

          }

          AbrirPopup_aFacturarLiquidacion = function (tipo, rowObject, CodigoCarroComprasLiquidacion) {

              var altura = 800;
              getPopupResponsive({
                  formURL: "ClienteFacturar",
                  title: "A Facturar",
                  nombreDiv: "divPopupRegistroClienteFactrura",
                  nombreGrid: "",
                  width: "0px",
                  height: altura,
                  params: {},
                  HideSelection: true,
                  multiSelect: false,
                  select: function (row) {
                      //llena aqui o cuando completa el grabado:  $rootScope.DatosFormulario.DataParaLiberar
                      return true;
                  },
                  beforeShow: function (obj) {
                      $rootScope.hashPopup = $(obj).attr("mapurl");
                      $(obj).attr("ModoPagina", tipo);
                      $compile($("#divPopupRegistroClienteFactrura"))($scope);
                      var scopePopup = angular.element("#divPopupRegistroClienteFactrura").scope();
                      scopePopup.row = JSON.parse(JSON.stringify(rowObject));
                      scopePopup.CodigoCarroComprasLiquidacion = CodigoCarroComprasLiquidacion;
                      scopePopup.EsLiquidacion = true;
                      scopePopup.rowOk = rowObject;


                  },

              });

          }



          $scope.QuitarBL = function (IdCarroCompras, IdCarroBL) {
              MiConfirm("Esta seguro de eliminar el BL?.", function () {
                  miBlock(true, "html");
                  $.ajax({
                      url: "/Carrito/EliminarCarritoBl",
                      type: "POST",
                      headers: { __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val() },
                      data: "CodigoCarroComprasBL=" + IdCarroBL,
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

                                  //MiAlertOk("BL : " +  objNewBl.NumeroBL  +"  fue agregado algo carrito con éxito.", MiAlertOk_success);
                                  $scope.CargarDatosIniciales();
                                  CalcularTotales();
                                  $rootScope.DatosFormulario.Carrrito.Servicio.TotalSolesMoneda = 0;
                                  $rootScope.DatosFormulario.Carrrito.Servicio.TotalDolaresMoneda = 0;

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

          }


          $scope.GrillaClick = function (obj, idgrilla, rowid, iRow, iCol, e) {
              //   MiAlert(rowid);
              var objDetalle = obtenerObjetoSeleccionarBL(rowid);
              // $rootScope.DatosFormulario.BLSeleccionado = objDetalle ;
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


              var ListaServicio = [];

              var Listado = $rootScope.DatosFormulario.Carrito.DatosCarrito.ListaCarritoBL;
              ListaServicio = $.grep(Listado, function (e) {
                  return e.CodigoCarroCompras == objDetalle.CodigoCarroCompras &&
                                      e.CodigoCarroComprasBL == objDetalle.CodigoCarroComprasBL;
              });

              // var ListaDetalleServicio =  ListaServicio[0].ListaDetalleCarro;

              // $scope.Grid_DataBind("ListaServicio",ListaDetalleServicio);

              var groupDetalleServicio = ListaServicio[0].GroupDetalleCarro;
              var lstDetalleCarrito = groupDetalleServicio.LstGroupDetalleCarro;
              $rootScope.DatosFormulario.Carrrito.Servicio.TotalSolesMoneda = groupDetalleServicio.TotalSoles;
              $rootScope.DatosFormulario.Carrrito.Servicio.TotalDolaresMoneda = groupDetalleServicio.TotalDolares;
              $scope.Grid_DataBind("ListaServicio", lstDetalleCarrito);

          }



          function ObtenerConceptoPorServicio(Lista) {
              var unique = {};
              var distinct = [];

              Lista.forEach(function (x) {

                  if (!unique[x.CodigoGrupoConcepto]) {


                      var obj = new Object();
                      obj.Accion = "I"
                      obj.CodigoCarroComprasBL = x.CodigoCarroComprasBL;
                      obj.CodigoGrupoConcepto = x.CodigoGrupoConcepto;
                      obj.NombreGrupoConcepto = x.NombreGrupoConcepto;
                      obj.CodigoCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserCodigoCliente;
                      obj.DescripcionCliente = $rootScope.DatosFormulario.CalcularVB.Datos.UserNombreCliente;



                      distinct.push(obj);

                      unique[x.CodigoGrupoConcepto] = true;

                  }


              });

              return distinct
          }


          $scope.Grid_DataBind = function (grid, data) {

              if (grid == "ListarBL") {
                  $scope.gridapigrillaVbCarritoListarBL.refresh(data);
              }
              if (grid == "ListaServicio") {
                  $scope.gridapigrillaCarritoServicio.refresh(data);
              }
              if (grid == "ListarLiquidacion") {
                  $scope.gridapigrillaVbCarritoLiquidacion.refresh(data);
              }

              $rootScope.$apply();
          }


          function obtenerObjetoAngular2(valor) {
              var objTemp = valor.replace("root", "rootScope");
              var indexFin = objTemp.lastIndexOf(".");
              var obj = eval(objTemp.slice(0, indexFin));
              return obj;
          }


          function obtenerObjetoSeleccionarBL(rowid) {

              var id = rowid - 1;
              var objGrilaItem = $("#gview_" + 'grillaVbCarritoListarBL').find('td[aria-describedby="' + 'grillaVbCarritoListarBL' + '_CodigoCarroCompras"]');
              var objDetalle = new Object();
              if (objGrilaItem.length > 0) {

                  var ngModel = objGrilaItem[id].attributes[5].value;
                  objDetalle = obtenerObjetoAngular2(ngModel);

              } else {
                  objDetalle = null;
              }


              return objDetalle;
          }


          $scope.CheckItem_BL = function (row) {
              CalcularTotales();
          }
          function CalcularTotales() {
              var totalSoles = 0
              var totalDolares = 0;
              var listaBL = $rootScope.DatosFormulario.Carrito.ListaConsultaBL;
              for (var i = 0; i < listaBL.length; i++) {
                  var objBL = listaBL[i];
                  if (objBL.IdCheck) {
                      totalDolares += objBL.GroupDetalleCarro.TotalDolares;
                      totalSoles += objBL.GroupDetalleCarro.TotalSoles;
                  }
              }
              $rootScope.DatosFormulario.Carrito.TotalSolesMoneda = totalSoles;
              $rootScope.DatosFormulario.Carrito.TotalDolaresMoneda = totalDolares;
          }


      }]);
})();