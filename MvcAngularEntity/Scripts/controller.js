var CandidatoControllers = angular.module("CandidatoControllers", []);

CandidatoControllers.controller("ListarController"
    , ["$scope", "$http"
    , function($scope, $http) {


            var candidatoshttp = $http({
                method: 'GET'
                , url: '/api/Candidato'
                });

        candidatoshttp.then(function(data){
            $scope.Candidatos = data;
        }, function(data){
            
        });

     
    }]);

CandidatoControllers.controller("EditarController"
    , ["$scope", "$filter", "$http", "$routeParams", "$location"
    , function ($scope, $filter, $http, $routeParams, $location) {


        $scope.salvar = function () {
            if ($scope.candidato.ID) {
                $http.post("/api/Candidato/", $scope.candidato).success(function (data) {
                    $location.path("/Listar");
                }).error(function (data) {
                    $scope.error = "Um erro ocorreu ao salvar. " + data.ExceptionMessage;
                });
            }
            else {
                $http.put("/api/Candidato/", $scope.candidato).success(function (data) {
                    $location.path("/Listar");
                }).error(function (data) {
                    $scope.error = "Um erro ocorreu ao salvar. " + data.ExceptionMessage;
                });
            }
        }

        if ($routeParams.Id) {
            $scope.id = $routeParams.Id;
            $scope.Titulo = "Editar Candidato";

          $http.get("/api/Candidato")
          .success(function (data) {
              $scope.candidato = data;
          });
        }
        else {
            $scope.Titulo = "Cadastrar um novo candidato";
        }
    }]);