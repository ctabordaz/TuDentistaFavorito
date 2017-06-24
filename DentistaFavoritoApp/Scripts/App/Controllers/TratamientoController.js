(function () {
    'use strict';
    angular.module('DentistaApp').controller('TratamientoController', ['$scope', '$location', 'Tratamientos', function ($scope, $location, Tratamientos) {

        $scope.titulo = "Tratamientos";
        $scope.listaTratamiento = [];
        var urlArray = $location.absUrl().split('/');
        var parametro = urlArray[urlArray.length - 1];
        $scope.listaTratamiento = Tratamientos.getAllbyPaciente({ id: parametro }, function (data) {

        });
    }]);
})();
