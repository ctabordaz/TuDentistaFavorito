(function () {
    'use strict';
    angular.module('DentistaApp').controller('TratamientoController', ['$scope', '$location', 'Tratamientos', 'Pacientes', 'datosAuth', 'Token', '$http', function ($scope, $location, Tratamientos, Pacientes, datosAuth, Token, $http) {

        $scope.titulo = "Tratamientos";
        $scope.listaTratamiento = [];
        $scope.mensaje = "";
        $scope.mensajeError = "";
        $scope.paciente = {};
        $scope.existeCliente = false;

        var urlArray = $location.absUrl().split('/');
        var parametro = urlArray[urlArray.length - 1];
        var token = "";

        Token.get(datosAuth.value, function (data) {
            token = data.Token;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            if (parametro == "" || parametro == null || isNaN(parametro)) {
                $scope.listaTratamiento = Tratamientos.getAll({}, function (data) { }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando los tratamientos";
                });
            } else {
                $scope.paciente = Pacientes.getbyId({ id: parametro }, function (data) {
                    $scope.existeCliente = true;
                    $scope.listaTratamiento = data.Tratamientos;
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando datos del paciente";
                });

            }
        }, function (error) {
            $scope.mensajeError = "Ha ocurrido un error con la autenticación";
        });


        

        


        $scope.Eliminar = function (id, index) {
            $scope.mensaje = "";
            $scope.mensajeError = "";
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            Tratamientos.deleteTratamiento({ Id: id }, function (data) {
                $scope.listaTratamiento = $scope.listaTratamiento.filter(function (element, i) {
                    return i !== index;
                });
                $scope.mensaje = "El tratamiento ha sido eliminado correctamente;"
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error elimando el tratamiento";
            })
        }
    }]);
})();
