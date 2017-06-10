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
        }).otherwise({
            redirectTo: '/pagina/no_encontrado'
        });


    });
    app.run(function (Idle) {
        // start watching when the app runs. also starts the Keepalive service by default. 
        // Idle.watch();
    });
})();

