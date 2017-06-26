/*
    Controlador TratamientoController
    encargado de mostrar todos los tratamientos
*/

(function () {
    'use strict';
    angular.module('DentistaApp').controller('TratamientoController', ['$scope', '$location', 'Tratamientos', 'Pacientes', 'datosAuth', 'Token', '$http', function ($scope, $location, Tratamientos, Pacientes, datosAuth, Token, $http) {

        $scope.titulo = "Tratamientos";
        $scope.listaTratamiento = [];
        $scope.listaTratamientoMostrar = [];
        $scope.mensaje = "";
        $scope.mensajeError = "";
        $scope.paciente = {};
        $scope.existeCliente = false;
        $scope.cargando = true;
        $scope.pagina = 1;
        $scope.elementosPagina = 20;
        $scope.paginar = true;
        $scope.textoPaginar = "Ver Todos";

        var urlArray = $location.absUrl().split('/');
        var parametro = urlArray[urlArray.length - 1];
        var token = "";


        /*
            Se obtiene el toke de autenticacion y de se llama la api de tratamientos
            para traer a todos lo tratamientos 
            se envia el token en el header del request
        */
        Token.get(datosAuth.value, function (data) {
            token = data.Token;
            $http.defaults.headers.common['Authorization'] = "Bearer " + token;
            if (parametro == "" || parametro == null || isNaN(parametro)) {
                $scope.listaTratamiento = Tratamientos.getAll({}, function (data) {
                    $scope.cargando = false;
                    paginar($scope.pagina);
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando los tratamientos";
                    $scope.cargando = false;
                });
            } else {
                $scope.paciente = Pacientes.getbyId({ id: parametro }, function (data) {
                    $scope.existeCliente = true;
                    $scope.listaTratamiento = data.Tratamientos;
                    $scope.cargando = false;
                    paginar($scope.pagina);
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido un error cargando datos del paciente";
                    $scope.cargando = false;
                });

            }
        }, function (error) {
            $scope.mensajeError = "Ha ocurrido un error con la autenticación";
            $scope.cargando = false;
        });


        /*
            Se elimina un tratamiento utilizando la api de tratamientos y enviandole
            el token en el header del request
        */
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
                paginar($scope.pagina);
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error elimando el tratamiento";
                $scope.cargando = false;
            })
        }


        /*
             Observa si ha cambiado la pagina 
             de ser asi carga la pagina nueva
         */
        $scope.$watch('pagina', function () {
            paginar($scope.pagina);
        });


        /*
            se encarga de cargar la nueva pagina filtrando la lista completa
        */
        function paginar(pagina) {
            $scope.pagina = pagina;
            var pagedData = $scope.listaTratamiento.slice((pagina - 1) * $scope.elementosPagina, pagina * $scope.elementosPagina);
            $scope.listaTratamientoMostrar = pagedData;
        }

        /*
            se encarga de mostrar todos los elementos en una sola pagina
        */
        $scope.VerTodos = function () {
            $scope.cargando = true;
            $scope.paginar = !$scope.paginar;
            if ($scope.paginar) {
                $scope.elementosPagina = 20;
                $scope.textoPaginar = "Ver Todos";
            } else {
                $scope.elementosPagina = $scope.listaTratamiento.length;
                $scope.textoPaginar = "Paginar";
            }
            paginar($scope.pagina);
            $scope.cargando = false;
        }
    }]);
})();
