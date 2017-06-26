(function () {
    'use strict';
    angular.module('DentistaApp').controller('TratamientoController', ['$scope', '$location', 'Tratamientos', 'Pacientes', 'datosAuth', 'Token', '$http', function ($scope, $location, Tratamientos, Pacientes, datosAuth, Token, $http) {

        $scope.titulo = "Tratamientos";
        $scope.listaTratamiento = [];
        $scope.mensaje = "";
        $scope.mensajeError = "";
        $scope.paciente = {};
        $scope.existeCliente = false;
        $scope.cargando = true;
        var urlArray = $location.absUrl().split('/');
        var parametro = urlArray[urlArray.length - 1];
        var token = "";

        Token.get(datosAuth.value, function (data) {
            token = data.Token;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            if (parametro == "" || parametro == null || isNaN(parametro)) {
                $scope.listaTratamiento = Tratamientos.getAll({}, function (data) {
                    $scope.cargando = false;
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando los tratamientos";
                    $scope.cargando = false;
                });
            } else {
                $scope.paciente = Pacientes.getbyId({ id: parametro }, function (data) {
                    $scope.existeCliente = true;
                    $scope.listaTratamiento = data.Tratamientos;
                    $scope.cargando = false;
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando datos del paciente";
                    $scope.cargando = false;
                });

            }
        }, function (error) {
            $scope.mensajeError = "Ha ocurrido un error con la autenticación";
            $scope.cargando = false;
        });


        

        


        $scope.Eliminar = function (id, index) {
            $scope.mensaje = "";
            $scope.mensajeError = "";
            $scope.cargando = true;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            Tratamientos.deleteTratamiento({ Id: id }, function (data) {
                $scope.listaTratamiento = $scope.listaTratamiento.filter(function (element, i) {
                    return i !== index;
                });
                $scope.mensaje = "El tratamiento ha sido eliminado correctamente;"
                $scope.cargando = false;
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error elimando el tratamiento";
                $scope.cargando = false;
            })
        }
    }]);
})();
