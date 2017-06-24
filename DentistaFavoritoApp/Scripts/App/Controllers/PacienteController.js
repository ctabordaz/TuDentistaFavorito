(function () {
    'use strict';
    angular.module('DentistaApp').controller('PacienteController', ['$scope', 'Pacientes',  function ($scope, Pacientes) {

        $scope.titulo = "Pacientes";
        $scope.pacientesLista = [];
        $scope.mensajeError = "";
        $scope.mensaje = "";

        $scope.pacientesLista = Pacientes.getAll({}, function (pacientes) { }, function (error) {
            $scope.mensajeError = "Ha ocurrido un error cargado los pacientes";
        });

        $scope.Eliminar = function (id,index) {
            Pacientes.deletePacient({ Id  : id}, function (data) {
                $scope.mensaje = "Se ha eliminado correctamente el paciente";
                $scope.pacientesLista = $scope.pacientesLista.filter(function (element, i) {
                    return i !== index;
                });
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error eliminando el paciente";
            });
        }

    }]);
})();
