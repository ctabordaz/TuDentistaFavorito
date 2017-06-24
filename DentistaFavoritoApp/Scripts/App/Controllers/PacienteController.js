(function () {
    'use strict';
    angular.module('DentistaApp').controller('PacienteController', ['$scope', 'Pacientes', function ($scope, Pacientes) {

        $scope.titulo = "Pacientes";
        $scope.pacientesLista = [];


        $scope.pacientesLista = Pacientes.getAll({}, function (pacientes) {
        });

        $scope.Eliminar = function (id) {
            Pacientes.deletePacient({ Id  : id}, function (data) {

            });
        }

    }]);
})();
