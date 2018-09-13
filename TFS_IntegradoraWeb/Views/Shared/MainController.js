
angular.module("App").requires.push('angularGrid');

App.controller("MainController", function ($scope, $rootScope, ngDialog, $http, Util) {

    $rootScope.main = $scope;
    $scope.main = {};
    $scope.main.filtro = {};
    $scope.main.acoes = "";

    App.main = {};

    $scope.default = function () {

        $scope.main.filtro.ExibirPagina = 'HOME';
    }

    $scope.Exibe = function (param) {

        $scope.main.filtro.ExibirPagina = param;
    }
    $scope.Acesso = function () {

        // Util.bindGrid($scope.acompanhamento);
        $http.post("../Main/validaUsuario").success(function (resultado) {

            $scope.Incluir = resultado.acesso[0].Incluir;
            $scope.Editar = resultado.acesso[0].Editar;
            $scope.Dividir = resultado.acesso[0].Dividir;
            $scope.Apagar = resultado.acesso[0].Apagar;

            $scope.acoes = resultado

        }).error(function (erro) {
            serviceUtil.delegateErro(erro);
        });
    };

    $scope.Acesso();


    $scope.main.GetAcompanhamentos = function () {
        $rootScope.acompanhamento.GetAcompanhamentos();
    }
});