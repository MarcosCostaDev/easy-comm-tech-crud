var CandidatoControllers = angular.module("CandidatoControllers", []);

CandidatoControllers.controller("ListarController"
    , ["$scope", "$http", function ($scope, $http) {


        $http({
            method: 'GET'
            , url: '/api/Candidato'
        }).then(function (resultado) {
            $scope.Candidatos = resultado.data;
        }, function (data) {
            $scope.Error = data.error;
        });


        $scope.Excluir = function (candidato) {

               $http({
                   method: 'DELETE'
                 , url: '/api/Candidato/Delete?Id=' + candidato.Id
               }).then(function (resultado) {
                   $scope.Candidatos = resultado.data;
               }, function (data) {
                   $scope.Error = data.error;
               });
        }


    }]);

CandidatoControllers.controller("EditarController"
    , ["$scope", "$filter", "$http", "$routeParams", "$location"
    , function ($scope, $filter, $http, $routeParams, $location) {

            $scope.opcoes = [1, 2, 3, 4, 5];

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

        $scope.voltar = function() {
            $location.path("/Listar");
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