(function () {
    'use strict';
    angular.module('DentistaApp').controller('CrearPacienteController', ['$scope', 'Pacientes', function ($scope, Pacientes) {

        $scope.titulo = "Crear Paciente";
        $scope.nuevoPaciente = {};
        $scope.nuevoTratamiento = {};
        $scope.listaTratamientos = [];
        $scope.mensajeError = "";
        $scope.mensaje = "";
        
        var inicializarPaciente = function () {
            $scope.nuevoPaciente = {
                Nombre: "",
                Identificacion: "",
                Edad: "",
                DatosContacto: "",
                UltimaConsulta: "",
                ProximaConsulta: "",
                Tratamientos: []
            };
        };

        var inicializarTratamiento = function () {
            $scope.nuevoTratamiento = {
                FechaInicio: "",
                FechaConclusion: "",
                Costo: "",
                Detalle: ""

            };

        };
        


        $scope.GuardarTratamiento = function () {
            $scope.listaTratamientos.push(angular.copy($scope.nuevoTratamiento));
            inicializarTratamiento();
        };

        $scope.GuardarPaciente = function () {
            $scope.mensajeError = "";
            $scope.mensaje = "";
            $scope.nuevoPaciente.Tratamientos = angular.copy($scope.listaTratamientos);
            Pacientes.save($scope.nuevoPaciente, function (data) {
                $scope.mensaje = "El paciente se ha guardado correctamente";
                inicializarPaciente();
                inicializarTratamiento();
                $scope.listaTratamientos = [];
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido guardando el paciente";
            });

            
        };

        
        $scope.EliminarTratamiento = function (index) {
            $scope.listaTratamientos = $scope.listaTratamientos.splice(index+1, 1);
        }

        inicializarPaciente();
        inicializarTratamiento();


    }]);
})();
