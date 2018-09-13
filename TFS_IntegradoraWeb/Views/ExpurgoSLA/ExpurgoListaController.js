

App.controller("ExpurgoListaController", function ($scope, $rootScope, $http) {

    $rootScope.expurgoEscope = $scope;
    $scope.expurgo = {};

    $scope.expurgo.filtro = {};

    $scope.grid = {};
    $scope.grid.gridOptions = {

        angularCompileRows: true,
        rowData: [],
        cellValueChanged: function (event) {
            var data = event.data;
        },
        enableColResize: true,
    }


    $scope.columnDefinitions = function () {

        var columnDefs = [
            {
                displayName: "Work Item",
                field: "",
                width: 1,
            },
            {
                displayName: "Data Expurgo",
                field: "",
                width: 1,
            },
        ];

        return columnDefs;
    }
    
    $scope.grid.gridOptions.columnDefs = $scope.columnDefinitions();

    $scope.grid.gridOptions.angularCompileRows = true;

    

    $scope.Pesquisar = function () {
        alert("EXPURGO");
    }


});