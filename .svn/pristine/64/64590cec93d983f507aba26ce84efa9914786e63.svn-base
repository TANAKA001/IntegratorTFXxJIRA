
var App = angular.module("App", ['angularGrid', 'ngDialog']);

App.globalConfig = {};


App.autocomplete = {};

App.autocomplete.keyPress = function ($event, objSearch, funcSelectedItem) {
    if ($event.keyCode == 38) {
        objSearch.index = objSearch.index - 1;
        if (objSearch.index < 0)
            objSearch.index = 0;
    }
    else if ($event.keyCode == 40) {
        if (!objSearch.itens || objSearch.itens.length == 0) {
            if (objSearch.value == undefined | objSearch.value == '' | !objSearch.pesquisar)
                objSearch.itens = objSearch.options;
            else if (objSearch.pesquisar)
                objSearch.pesquisar(objSearch.value, null);
        }
        else {
            objSearch.index = objSearch.index + 1;
            if (objSearch.index > objSearch.itens.length - 1)
                objSearch.index = objSearch.itens.length - 1;
        }
    } else if ($event.keyCode == 13) {
        objSearch.carregando = true;
        if (objSearch.itens.length > objSearch.index && objSearch.index > -1)
            funcSelectedItem(objSearch.itens[objSearch.index]);
        this.index = 0;
        this.carregando = false;
    }

}

var Util = function (ngDialog, $http) {
    serviceUtil = {};

    serviceUtil.Clone = function (obj) {
        if (null == obj || "object" != typeof obj) return obj;
        var copy = obj.constructor();
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) copy[attr] = obj[attr];
        }
        return copy;
    }

    serviceUtil.OpenConfirm = function (msg, confirmar, cancelar) {
        ngDialog.openConfirm({
            template: "<style>" +
            ".ngdialog-content{" +
            "position:relative;" +
            "margin-top: 200px!important;" +
            "border: 5px solid #99CC00;" +
            "width: 500px !important;" +
            "color: #99CC00;" +
            "font: bold;" +
            "text-align:center;" +
            "border-radius: 2px;" +
            "}" +
            "</style>" +
            "<p>" +
            msg +
            "</p>" +
            "<div class='ngdialog-buttons'>" +
            "<button type='button' class='ngdialog-button' ng-click='confirm()'>Confirmar</button>" +
            "<button type='button' class='ngdialog-button' ng-click='closeThisDialog()'>Cancelar</button>" +
            "</div>",
            plain: true,
            closeByDocument: true,
            closeByEscape: true
        }).then(confirmar, cancelar)
    }

    serviceUtil.Alerta = function (msg) {
        ngDialog.open({
            template: "<style>" +
            ".alert-on-modal .ngdialog-content{" +
            "position:relative;" +
            "margin-top: 200px !important;" +
            "border: 5px solid #99CC00;" +
            "width: 500px !important;" +
            "color: #99CC00;" +
            "font: bold;" +
            "text-align:center;" +
            "border-radius: 2px;" +
            "}" +
            "</style>" +
            "<div class=alert-content>" +
            msg +
            "</div>",
            className: 'ngdialog-theme-default alert-on-modal',
            plain: true
        })
    }

    serviceUtil.delegateErro = function (erro) {

        if (erro.Message)
            serviceUtil.Alerta(erro.Message);
        else
            serviceUtil.Alerta(erro);
    }

    serviceUtil.localeGrid = function () {
        var parametersGrid = new Array();
        parametersGrid['more'] = 'Mais';
        parametersGrid['page'] = 'Pagina';
        parametersGrid['to'] = 'a';
        parametersGrid['of'] = 'de';
        parametersGrid['first'] = '<<';
        parametersGrid['previous'] = '&nbsp;<&nbsp;';
        parametersGrid['next'] = '&nbsp;>&nbsp;';
        parametersGrid['last'] = '>>';

        return parametersGrid;
    }

    serviceUtil.getDefaultGridOptions = function () {
        return {
            enableSorting: true,
            enableFilter: true,
            enableColResize: true,
            rowSelection: 'multiple',
            localeText: serviceUtil.localeGrid(),
            pageSize: 20,
            pageSizeList: [10, 20, 50, 100, 150, 300, 500]
        };
    }

    serviceUtil.getItem = function (filtros, successo) {
        $http.get("GetItem" + filtros).success(successo).error(function (erro) {
            $.loading.hide();
            serviceUtil.delegateErro(erro);
        });
    }

    serviceUtil.getItens = function (skip, top, filtro, successo, erroDelegate) {
        $http.post("Get?skip=" + skip + "&top=" + top, filtro).success(successo).error(erroDelegate);
    }

    serviceUtil.Atualizar = function (filtros, itemAtualizar, successo) {
        $http.patch("Patch" + filtros, itemAtualizar).success(successo).error(function (erro) {
            $.loading.hide();
            serviceUtil.delegateErro(erro);
        });
    }

    serviceUtil.Inserir = function (itemInserir, successo) {
        $http.post("Post", itemInserir).success(successo).error(function (erro) {
            $.loading.hide();
            serviceUtil.delegateErro(erro);
        });
    }

    serviceUtil.Excluir = function (itensLista, successo) {
        $http.post("Excluir", itensLista).success(successo).error(function (erro) {
            $.loading.hide();
            serviceUtil.delegateErro(erro);
        });
    }

    serviceUtil.bindGrid = function (entidade) {
        $http.post("GetCount", entidade.filtro).error(function (erro) { serviceUtil.delegateErro(erro); })
            .then(function (result) {
                
                var dataSource = {
                    rowCount: result.data,// - not setting the row count, infinite paging will be used
                    pageSize: entidade.gridOptions.pageSize,
                    overflowSize: entidade.gridOptions.pageSize,
                    getRows: function (start, finish, callbackSuccess, callbackFail) {
                        //Este código deve chamar o servidor para buscar os dados, e um temporizador pode ser utilizado para dar a experiência de uma chamada assíncrona.
                        
                        serviceUtil.getItens(start, entidade.gridOptions.pageSize, entidade.filtro, callbackSuccess, function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); })

                    }
                };

                entidade.gridOptions.api.setDatasource(dataSource);
            });
    }

    serviceUtil.bindGridFromPath = function (entidade, path) {
        $http.post("../" + path + "/GetCount" + entidade.filtro).error(function (erro) { serviceUtil.delegateErro(erro); })
            .then(function (result) {
                
                var dataSource = {
                    rowCount: result.data,// - not setting the row count, infinite paging will be used
                    pageSize: entidade.gridOptions.pageSize,
                    overflowSize: entidade.gridOptions.pageSize,
                    getRows: function (start, finish, callbackSuccess, callbackFail) {
                        //Este código deve chamar o servidor para buscar os dados, e um temporizador pode ser utilizado para dar a experiência de uma chamada assíncrona.
                
                        $http.post("../" + path + "/Get" + entidade.filtro + "&skip=" + start + "&top=" + entidade.gridOptions.pageSize).success(callbackSuccess).error(function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); });

                    }
                };

                entidade.gridOptions.api.setDatasource(dataSource);

            });
    }

    serviceUtil.bindGridCustomPath = function (entidade, path, getCountMethod, getMethod) {
        $http.post("../" + path + "/" + getCountMethod, entidade.filtro).error(function (erro) { serviceUtil.delegateErro(erro); })
            .then(function (result) {
               
                var dataSource = {
                    rowCount: result.data,// - not setting the row count, infinite paging will be used
                    pageSize: entidade.gridOptions.pageSize,
                    overflowSize: entidade.gridOptions.pageSize,
                    getRows: function (start, finish, callbackSuccess, callbackFail) {
                        //Este código deve chamar o servidor para buscar os dados, e um temporizador pode ser utilizado para dar a experiência de uma chamada assíncrona.
                        
                        //serviceUtil.getItens(start, entidade.gridOptions.pageSize, entidade.filtro, callbackSuccess, function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); })
                        $http.post("../" + path + "/" + getMethod + "?skip=" + start + "&top=" + entidade.gridOptions.pageSize, entidade.filtro).success(callbackSuccess).error(function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); });
                        //setTimeout(function () {
                        ////Caso queira usar um temporizador para dar a experi?ncia de uma chamada ass?ncrona.
                        //}, 500);
                    }
                };

                entidade.gridOptions.api.setDatasource(dataSource);

            });
    }

    serviceUtil.bindGridCustomPathWithCallbacks = function (entidade, path, getCountMethod, getMethod, sucesso, falha) {
        $http.post("../" + path + "/" + getCountMethod, entidade.filtro).error(function (erro) { serviceUtil.delegateErro(erro); })
            .then(function (result) {
                
                var dataSource = {
                    rowCount: result.data,// - not setting the row count, infinite paging will be used
                    pageSize: entidade.gridOptions.pageSize,
                    overflowSize: entidade.gridOptions.pageSize,
                    getRows: function (start, finish, callbackSuccess, callbackFail) {
                        //Este código deve chamar o servidor para buscar os dados, e um temporizador pode ser utilizado para dar a experiência de uma chamada assíncrona.
                      
                        //serviceUtil.getItens(start, entidade.gridOptions.pageSize, entidade.filtro, callbackSuccess, function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); })
                        $http.post("../" + path + "/" + getMethod + "?skip=" + start + "&top=" + entidade.gridOptions.pageSize, entidade.filtro).success(callbackSuccess).success(sucesso).error(function (erro) { serviceUtil.delegateErro(erro); callbackFail(erro); }).error(falha);
                        //setTimeout(function () {
                        ////Caso queira usar um temporizador para dar a experi?ncia de uma chamada ass?ncrona.
                        //}, 500);
                    }
                };

                entidade.gridOptions.api.setDatasource(dataSource);

            });
    }

    //Carregar dados na grid
    serviceUtil.setRowsGrid = function (entidade, dados) {
        entidade.gridOptions.api.setRows(dados);
    }

    serviceUtil.ExportarExcel = function (data, nome, colunas) {

        var opts = {
            headers: true,
        };

        var query = 'SELECT ';

        if (colunas)
            query = query + colunas;
        else
            query = query + '*';

        query = query + ' INTO XLSX("' + nome + '.xlsx" , ? ) FROM ?';

        alasql(query, [opts, data]);

    };

    return serviceUtil;
}

Util.$inject = ['ngDialog', '$http'];

App.factory("Util", Util);


App.directive('formAutocomplete', ['filterFilter', function (filterFilter) {
    return {
        require: "ngModel",
        scope: {
            options: "=",
            value: '@',
            placeHolder: '@',
            modelvalue: '@',
            onChange: "&"
        },
        template: '<div class="col-sm-push-12"><div class="col-sm-push-12"><input class="inputValueAutoComplete col-sm-12 form-control" type="text" ng-model="field.value" ng-blur="field.fechar()" ng-keyup="keyPress($event)" ng-click="click()"  focus-me="field.focus" placeholder="{{field.placeHolder}}"/><span class="autocomplete-seta" ng-click="field.setaClick()">&nbsp;&nbsp;&nbsp;</span></div><div class="col-sm-12 autocomplete-div"><ul class="col-sm-12 autocomplete-container ng-hide" ng-style="hgt" ng-show="itens.length > 0"><li id="item_{{$index}}" class="autocomplete-item" ng-class="{Selected:index == $index}" ng-repeat="item in itens" ng-click="field.selecionar(item)">{{item.Texto}}</li></ul></div></div>',
        restrict: 'E',
        replace: true,
        controller: ['$scope', '$timeout', 'filterFilter', function ($scope, $timeout, filterFilter, ngModel) {
            $scope.field = $scope;
            $scope.field.index = 0;
            $scope.field.carregando = true;

            $scope.field.selecionar = function (itemSelecionado) {
                $scope.field.carregando = true;

                //var itemSelecionado = $scope.field.itens[$scope.field.index];
                $scope.field.value = itemSelecionado.Texto ? itemSelecionado.Texto : itemSelecionado;
                $scope.field.itens = [];
                $scope.ngModel.$setViewValue(itemSelecionado.Valor != undefined ? itemSelecionado.Valor : itemSelecionado);
                this.index = 0;
                this.carregando = false;
                if ($scope.onChange)
                    $scope.onChange();
            }

            $scope.field.click = function () {
                $scope.field.value = "";
            }

            $scope.field.fechar = function () {
                $timeout(function () {
                    if (!$scope.field.carregando) {
                        
                        $scope.field.itens = [];
                    }
                    $scope.field.carregando = false;
                }, 300);
            }
            $scope.field.pesquisar = function (newValue, oldValue) {
                if (newValue != undefined && newValue != '' && newValue != oldValue && !$scope.field.carregando && $scope.field.options)

                    $scope.field.itens = $scope.field.options.filter(function (item) {

                        var retorno = false;
                        if (item.Texto != null) {
                            retorno = item.Texto.toLowerCase().indexOf(newValue.toLowerCase()) > -1

                        } else if (item.Valor != null) {
                            retorno = item.Valor.toLowerCase().indexOf(newValue.toLowerCase()) > -1

                        }

                        return retorno;
                    });
                else {
                    $scope.field.itens = [];
                    if ((newValue == undefined || newValue == '') && newValue != oldValue && oldValue != undefined && oldValue != '' && $scope.ngModel.$modelValue != undefined) {
                        $scope.ngModel.$setViewValue(null);
                        $scope.onChange();
                    }
                }
                $scope.field.carregando = false;
            }

            $scope.field.keyPress = function ($event) {
                App.autocomplete.keyPress($event, $scope.field, $scope.field.selecionar);
            }
            $scope.field.setaClick = function () {
                
                $scope.field.carregando = true;
                if ($scope.field.itens && $scope.field.itens.length > 0) {
                    $scope.field.itens = [];
                } else {
                    $scope.field.itens = $scope.field.options;
                }

                var altura = 0;

                if ($scope.field.itens != null) {

                    altura = $scope.field.itens.length * 32;

                }

                if (altura > 250) {
                    altura = 250;
                }

                $scope.hgt = { height: (altura) + 'px' };

                $scope.field.focus = true;
                $timeout(function () { $scope.field.focus = true; }, 300);
            }

            $scope.field.bindItem = function (newValue, oldValue) {
                
                if ($scope.field.options && $scope.field.options.length > 0 && $scope.ngModel) {
                    var valorAtual = $scope.ngModel.$modelValue;
                    if (valorAtual != undefined) {
                        for (var i = 0; i < $scope.field.options.length; i++) {
                            if (($scope.field.options[i] != undefined && $scope.field.options[i] == valorAtual) || ($scope.field.options[i].Valor != undefined && $scope.field.options[i].Valor == valorAtual)) {
                                $scope.field.carregando = true;

                                var itemSelecionado = $scope.field.options[i];
                                $scope.field.value = itemSelecionado.Texto ? itemSelecionado.Texto : itemSelecionado;
                                //$scope.ngModel.$setViewValue(itemSelecionado.Valor != undefined ? itemSelecionado.Valor : itemSelecionado);
                                $scope.field.itens = [];

                                $scope.field.index = 0;
                                //$scope.field.carregando = false;

                            }
                        }
                    } else {
                        $scope.field.carregando = true;
                        $scope.field.value = '';
                        //$scope.field.carregando = false;
                    }
                }
            }

            $scope.$watch('field.value', $scope.field.pesquisar, true);
            $scope.$watch('ngModel.$modelValue', $scope.field.bindItem, true);
            $scope.field.carregando = false;
        }],
        link: function ($scope, el, $attrs, ngModel, ctrl) {
            $scope.ngModel = ngModel;
        }
    };
}]);

App.directive("limitToMax", function () {
    return {
        link: function (scope, element, attributes) {
            element.on("keydown keyup", function (e) {
                if (Number(element.val()) > Number(attributes.max) &&
                    e.keyCode != 46 // delete
                    &&
                    e.keyCode != 8 // backspace
                ) {
                    e.preventDefault();
                    element.val(attributes.max);
                }
            });
        }
    };
});