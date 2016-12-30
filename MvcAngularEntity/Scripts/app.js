var CandidadoApp = angular.module("CandidatoApp", ["ngRoute", "CandidatoControllers"]);




CandidadoApp.config([
    "$routeProvider", function ($routeProvider) {


        $routeProvider.when("/listar"
                , {
                    templateUrl: "Candidato/Listar.html"
                    , controller: "ListarController"
                })
            .when("/Criar"
                , {
                    templateUrl: "Candidato/Editar.html"
                    , controller: "EditarController"
                })
            .when("/Editar/:id"
                , {
                    templateUrl: "Candidato/Editar.html"
                    , controller: "EditarController"
                })
            .otherwise(
                {
                    redirectTo: "/listar"
                }
            );

      
    }
]);
