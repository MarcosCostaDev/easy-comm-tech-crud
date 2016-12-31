var CandidatoControllers = angular.module("CandidatoControllers", []);

CandidatoControllers.controller("ListarController"
    , ["$scope", "$http", "$location", function ($scope, $http, $location) {


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

        $scope.Editar = function (candidato) {
            $location.path("/Editar/" + candidato.Id);

        }


    }]);

CandidatoControllers.controller("EditarController"
    , ["$scope", "$filter", "$http", "$routeParams", "$location"
    , function ($scope, $filter, $http, $routeParams, $location) {

        $scope.opcoes = [1, 2, 3, 4, 5];

        $http({
            method: 'GET'
                   , url: '/api/BuscaVagas'
        }).then(function (resultado) {
            $scope.BuscaVagasList = resultado.data;
        }, function (data) {
            $scope.Error = data.error;
        });


        $scope.salvar = function () {

            $scope.Candidato.CandidatoBuscaVagas = $scope.Candidato.CandidatoBuscaVagas || [];
            var temTipoVaga =  $scope.Candidato.CandidatoBuscaVagas.length > 0;
            angular.forEach($scope.BuscaVagasList
                , function (item) {
                    if (temTipoVaga) {
                        angular.forEach($scope.Candidato.CandidatoBuscaVagas
                      , function (item2) {
                          if (item.Id == item2.BuscaVagaId) {
                              item2.Selecionado = item.Selecionado;
                          }
                      });
                    }
                    else {
                      
                        $scope.Candidato.CandidatoBuscaVagas.push({
                            BuscaVagaId: item.Id
                                , CandidatoId: $scope.Candidato.Id || null
                                , Selecionado: item.Selecionado || false
                        });
                    }


                });

            if ($scope.Candidato.Id) {
                $http.put("/api/Candidato/", $scope.Candidato).success(function (data) {
                    $location.path("/Listar");
                }).error(function (data) {
                    $scope.error = "Um erro ocorreu ao salvar. " + data.ExceptionMessage;
                });
            }
            else {
                $http.post("/api/Candidato/", $scope.Candidato).success(function (data) {
                    $location.path("/Listar");
                }).error(function (data) {
                    $scope.error = "Um erro ocorreu ao salvar. " + data.ExceptionMessage;
                });
            }
        }

        $scope.voltar = function () {
            $location.path("/Listar");
        }


        if ($routeParams.Id) {
            $scope.Id = $routeParams.Id;
            $scope.Titulo = "Editar Candidato";

            $http.get("/api/Candidato?id=" + $scope.Id)
            .success(function (data) {
                $scope.Candidato = data;

                angular.forEach($scope.Candidato.CandidatoBuscaVagas
                    , function (value, key) {

                        angular.forEach($scope.BuscaVagasList
                            , function (value2, key2) {
                                if (value.BuscaVagaId == value2.Id) {
                                    value2.Selecionado = value.Selecionado;
                                }
                            });
                    });
            });
        }
        else {
            $scope.Titulo = "Cadastrar um novo candidato";
        }
    }]);