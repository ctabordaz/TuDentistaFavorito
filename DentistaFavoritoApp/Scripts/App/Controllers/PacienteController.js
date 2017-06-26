(function () {
    'use strict';
    angular.module('DentistaApp').controller('PacienteController', ['$scope', 'Pacientes', 'datosAuth', 'Token', '$http', function ($scope, Pacientes, datosAuth, Token, $http) {

        $scope.titulo = "Pacientes";
        $scope.pacientesLista = [];
        $scope.mensajeError = "";
        $scope.mensaje = "";
        $scope.cargando = true;
        var token = "";
        
        Token.get(datosAuth.value, function (data) {
            token = data.Token;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token ;
            $scope.pacientesLista = Pacientes.getAll({}, function (pacientes) { $scope.cargando = false }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error cargado los pacientes";
                $scope.cargando = false;
            });
        }, function (error) {
            $scope.mensajeError = "Ha ocurrido un error con la autenticación";
            $scope.cargando = false;
        });

        $scope.Eliminar = function (id, index) {
            $scope.cargando = true;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            Pacientes.deletePacient({ Id: id }, function (data) {
                $scope.mensaje = "Se ha eliminado correctamente el paciente";
                $scope.pacientesLista = $scope.pacientesLista.filter(function (element, i) {
                    return i !== index;
                });
                $scope.cargando = false; 
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error eliminando el paciente";
                $scope.cargando = false;
            });
        };

    }]);
})();
