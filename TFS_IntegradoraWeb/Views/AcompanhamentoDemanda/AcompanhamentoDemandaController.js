
App.controller("AcompanhamentoDemandaController", function ($scope, $rootScope, ngDialog, $http, Util) {

    $rootScope.gerAcompanhamento = $scope;
    $scope.gerAcompanhamento = {}
    $scope.gerAcompanhamento.title = $scope.ngDialogData.origem;
    $scope.gerAcompanhamento.filtro = {};

    $scope.gerAcompanhamento.listaEsteiras = {};
    $scope.gerAcompanhamento.listaEsteiras = $rootScope.acompanhamento.acompanhamento.listaAcompanhamento.listaEsteiras

    $scope.gerAcompanhamento.camposLimpos = function () {
        $scope.gerAcompanhamento.msg = ""
        $scope.gerAcompanhamento.msgDtsk = ""
        $scope.gerAcompanhamento.filtro.NumJira = "";
        $scope.gerAcompanhamento.filtro.DtTrabalhada = "";
        $scope.gerAcompanhamento.filtro.DtFaturada = "";
        $scope.gerAcompanhamento.filtro.Esteira = "";
        $scope.gerAcompanhamento.filtro.HrsTrabalhadas = "";
        $scope.gerAcompanhamento.filtro.HrsFaturadas = "";
        $scope.gerAcompanhamento.filtro.WorkItem = "";
        $scope.gerAcompanhamento.filtro.Descricao = "";
        $scope.gerAcompanhamento.filtro.Observacao = "";

        $scope.gerAcompanhamento.filtro.MaxHrs = "";
        $scope.gerAcompanhamento.filtro.podeSalvar = 'S'
    }
    $scope.gerAcompanhamento.camposLimpos();

    $scope.AjustaVizualisacao = function () {
        var _origem = $scope.ngDialogData.origem

        $scope.gerAcompanhamento.disabled = {};
        $scope.gerAcompanhamento.disabled.WorkItem = (_origem == "Incluir") ? false : true;
        $scope.gerAcompanhamento.disabled.DtTrabalhada = (_origem == "Incluir") ? false : (_origem == "Editar") ? true : false;
        $scope.gerAcompanhamento.disabled.DtFaturada = (_origem == "Incluir") ? false : (_origem == "Editar") ? true : false;
        $scope.gerAcompanhamento.disabled.Esteira = (_origem == "Incluir") ? false : true;
        $scope.gerAcompanhamento.disabled.HrsTrabalhadas = false;
        $scope.gerAcompanhamento.disabled.HrsFaturadas = false;
        $scope.gerAcompanhamento.disabled.Descricao = (_origem == "Incluir") ? false : (_origem == "Editar") ? true : false;
        $scope.gerAcompanhamento.disabled.Observacao = (_origem == "Incluir") ? false : (_origem == "Editar") ? true : false;

    }
    $scope.AjustaVizualisacao();

    $scope.gerAcompanhamento.Limpar = function () {

        $scope.AjustaVizualisacao();
        $scope.gerAcompanhamento.camposLimpos()
    }

    $scope.gerAcompanhamento.Pesquisar = function () {

        $http.post("../AcompanhamentoDemandaLista/PesquisarNumJira", $scope.gerAcompanhamento.filtro).success(function (resultado) {
            
            if (resultado.jiraIssue != undefined || resultado.jiraIssue != null) {

                if (resultado.jiraIssue.length > 0) {

                    $scope.gerAcompanhamento.filtro.DtTrabalhada = resultado.jiraIssue[0].DataTrabalho;
                    $scope.gerAcompanhamento.filtro.DtFaturada = resultado.jiraIssue[0].DataFaturamento;
                    $scope.gerAcompanhamento.filtro.Esteira = resultado.jiraIssue[0].Esteira;
                    $scope.gerAcompanhamento.filtro.HrsTrabalhadas = resultado.jiraIssue[0].QtdHorasTrabalhadas;

                    $scope.gerAcompanhamento.filtro.WorkItem = resultado.jiraIssue[0].WorkItem;
                    $scope.gerAcompanhamento.filtro.Descricao = resultado.jiraIssue[0].Descricao;
                    $scope.gerAcompanhamento.filtro.Observacao = resultado.jiraIssue[0].Observacao;

                    if ($scope.ngDialogData.origem == "Incluir") {

                        $scope.gerAcompanhamento.filtro.HrsFaturadas = resultado.totFatAcompJira;
                    } else {

                        $scope.gerAcompanhamento.filtro.HrsFaturadas = resultado.jiraIssue[0].QtdHorasFaturadas;
                    }

                    if ($scope.gerAcompanhamento.filtro.HrsFaturadas == 0) {
                        $scope.gerAcompanhamento.filtro.podeSalvar = 'N'
                    } else {
                        $scope.gerAcompanhamento.filtro.podeSalvar = 'S'
                    }

                    $scope.gerAcompanhamento.filtro.MaxHrs = $scope.gerAcompanhamento.filtro.HrsFaturadas;

                }
                $scope.gerAcompanhamento.msg = resultado.msg;
                if ($scope.gerAcompanhamento.filtro.NumJira == undefined) {
                    $scope.gerAcompanhamento.camposLimpos();
                }
            } 
        }).error(function (erro) {
            serviceUtil.delegateErro(erro);

        });
    }

    $scope.gerAcompanhamento.Salvar = function () {
        $http.post("../AcompanhamentoDemandaLista/CriarAcompanhamento", $scope.gerAcompanhamento.filtro).success(function (resultado) {

            $scope.gerAcompanhamento.msg = resultado;

        }).error(function (erro) {
            serviceUtil.delegateErro(erro);

        });
    }

    $scope.gerAcompanhamento.validaWorkItem = function () {
        $http.post("../AcompanhamentoDemandaLista/ValidaWorkItem", $scope.gerAcompanhamento.filtro).success(function (resultado) {

           

            if (resultado.msg == "" && (resultado.workItem != undefined || resultado.workItem != "" ) ) {
                $scope.gerAcompanhamento.filtro.HrsFaturadas = resultado.workItem[0].QtdHorasFaturadas;
                $scope.gerAcompanhamento.msg = "";
            } else {
                $scope.gerAcompanhamento.msg = resultado.msg;
            }


        }).error(function (erro) {
            serviceUtil.delegateErro(erro);

        });
    }

    $('.datepicker').datepicker();
});

