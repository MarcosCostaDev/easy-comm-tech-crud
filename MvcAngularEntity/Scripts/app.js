var CandidadoApp = angular.module("CandidatoApp", ["ngRoute", "CandidatoControllers"]);


CandidadoApp.config([
    "$routeProvider", function($routeProvider) {


        $routeProvider.when("/listar"
                , {
                    templateUrl: "App/Candidato/Listar.html"
                    , controller: "ListarController"
                })
            .when("/Criar"
                , {
                    templateUrl: "App/Candidato/Editar.html"
                    , controller: "EditarController"
                })
            .when("/Editar/:Id"
                , {
                    templateUrl: "App/Candidato/Editar.html"
                    , controller: "EditarController"
                })
            .otherwise(
                {
                    redirectTo: "/listar"
                }
            );


    }
]);