(function () {
    'use strict';
    angular.module('DentistaApp').controller('CrearPacienteController', ['$scope', 'Pacientes', function ($scope, Pacientes) {

        $scope.titulo = "Crear Paciente";
        $scope.nuevoPaciente = {};
        $scope.nuevoPaciente = {
            Nombre: "",
            Identificacion: "",
            Edad: "",
            DatosContacto: "",
            UltimaConsulta: "",
            ProximaConsulta: ""
        };


        $scope.GuardarPaciente = function () {
            Pacientes.save($scope.nuevoPaciente, function (data) { });
        }



    }]);
})();
