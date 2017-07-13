(function () {
    var app = angular.module('api', ['ngIdle', 'ngRoute']);
    //app.config(['$routeProvider', '$locationProvider', function (IdleProvider, KeepaliveProvider,$routeProvider, $locationProvider) { 

    app.config(function (IdleProvider, KeepaliveProvider, $routeProvider, $locationProvider) {
        // IdleProvider.idle(59 * 60); // in seconds 
        // IdleProvider.timeout(5); // in seconds 
        // KeepaliveProvider.interval(2); // in seconds


        $locationProvider.hashPrefix('!');

        $routeProvider.when("/", {
            templateUrl: "SeguridadAgma/Seguridad",
            controller: 'PageHomeController'
        }).when("/sistema/bienvenido/", {
            templateUrl: "bienvenido",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/ProgramacionTurno", {
            templateUrl: "ProgramacionTurno",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/ProgramacionTurno/Adicionar", {
            templateUrl: "ProgramacionTurno/Adicionar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/ProgramacionTurno/Lectura", {
            templateUrl: "ProgramacionTurno/Lectura",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/Epicrisis", {
            templateUrl: "Epicrisis",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/Epicrisis/Adicionar", {
            templateUrl: "Epicrisis/Adicionar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/Epicrisis/Lectura", {
            templateUrl: "Epicrisis/Lectura",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/sistema/busqueda/BuscarOrdenIntervencion", {
            templateUrl: "OrdenIntervencion/BuscarOrdenIntervencion",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/FichaHospitalizacion", {
            templateUrl: "FichaHospitalizacion",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/FichaHospitalizacion/Adicionar", {
            templateUrl: "FichaHospitalizacion/Adicionar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/FichaHospitalizacion/Lectura", {
            templateUrl: "FichaHospitalizacion/Lectura",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/FichaHospitalizacion/Editar", {
            templateUrl: "FichaHospitalizacion/Editar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/sistema/busqueda/BuscarInsumos", {
            templateUrl: "FichaHospitalizacion/BuscarInsumos",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/RiesgoQuirurgico", {
            templateUrl: "RiesgoQuirurgico",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/RiesgoQuirurgico/Adicionar", {
            templateUrl: "RiesgoQuirurgico/Adicionar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/RiesgoQuirurgico/Lectura", {
            templateUrl: "RiesgoQuirurgico/Lectura",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/sistema/busqueda/BuscarFicha", {
            templateUrl: "RiesgoQuirurgico/BuscarFicha",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/OrdenIntervencion", {
            templateUrl: "OrdenIntervencion",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/OrdenIntervencion/Adicionar", {
            templateUrl: "OrdenIntervencion/Adicionar",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).when("/OrdenIntervencion/Lectura", {
            templateUrl: "OrdenIntervencion/Lectura",
            controller: 'FormularioBaseController',
            controllerAs: 'currentController'
        }).otherwise({
            redirectTo: '/pagina/no_encontrado'
        });


    });
    app.run(function (Idle) {
        // start watching when the app runs. also starts the Keepalive service by default. 
        // Idle.watch();
    });
})();

