(function () {
    'use strict';
    angular.module('DentistaApp').controller('CrearPacienteController', ['$scope', 'Pacientes', '$location', function ($scope, Pacientes, $location) {

        $scope.titulo = "Crear Paciente";
        $scope.nuevoPaciente = {};
        $scope.nuevoTratamiento = {};
        $scope.listaTratamientos = [];
        $scope.mensajeError = "";
        $scope.mensaje = "";
        
        $scope.tratamientoFechaIni = "";
        $scope.tratamientoFechaFin = "";
        $scope.tratamientoCosto = "";
        $scope.tratamientoDetalle = "";

        $scope.pacienteNombre = "";
        $scope.pacienteIdentificacion = "";
        $scope.pacienteEdad = "";
        $scope.pacienteContacto = "";
        $scope.pacienteUltimaFecha = "";
        $scope.pacienteProximaFecha = "";       
        $scope.toggleNuevoTratamiento = true;
        $scope.toggleListaTratamientos = true;
        $scope.EditandoTratamiento = false;
        $scope.Editando = false;

        var campoInvalido = "Campo Invalido";
        var indexTratamiento = 0;
        var urlArray = $location.absUrl().split('/');
        var parametro = urlArray[urlArray.length - 1];

        var inicializarPaciente = function () {
            $scope.nuevoPaciente = {
                Id: 0,
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

        inicializarPaciente();
        inicializarTratamiento();

        if (parametro !== "" && !isNaN(parametro)) {
            $scope.Editando = true;
            $scope.titulo = "Editar Paciente";
            Pacientes.getbyId({ id: parametro }, function (data) {
                $scope.nuevoPaciente = data;
                $scope.nuevoPaciente.ProximaConsulta = new Date(data.ProximaConsulta);
                $scope.nuevoPaciente.UltimaConsulta = new Date(data.UltimaConsulta);
                $scope.listaTratamientos = data.Tratamientos;
            }, function (error) {
                $scope.mensajeError = "Ha ocurrido un error cargando datos del paciente";
            });
        }

        $scope.GuardarTratamiento = function () {
            if (validarTratamiento()) {
                $scope.nuevoTratamiento.Paciente_Id = $scope.nuevoPaciente.Id;
                $scope.listaTratamientos.push(angular.copy($scope.nuevoTratamiento));
                inicializarTratamiento();
            }
        };

        $scope.GuardarPaciente = function () {
            $scope.mensajeError = "";
            $scope.mensaje = "";

            if (validarPaciente()) {
                $scope.nuevoPaciente.Tratamientos = angular.copy($scope.listaTratamientos);
                Pacientes.save($scope.nuevoPaciente, function (data) {
                    $scope.mensaje = "El paciente se ha guardado correctamente";
                    if (!$scope.Editando) {
                        inicializarPaciente();
                        inicializarTratamiento();
                        $scope.listaTratamientos = [];
                    }                    
                    
                }, function (error) {
                    $scope.mensajeError = "Ha ocurrido guardando el paciente";
                });
            }

        };


        $scope.EliminarTratamiento = function (index) {
            $scope.listaTratamientos = $scope.listaTratamientos.filter(function (element, i) {
                return i !== index;
            });
        }

        $scope.EditarTratamiento = function (index) {
            indexTratamiento = index;
            $scope.EditandoTratamiento = true;
            $scope.nuevoTratamiento = angular.copy($scope.listaTratamientos[index]);
            $scope.nuevoTratamiento.FechaInicio = new Date($scope.listaTratamientos[index].FechaInicio);
            $scope.nuevoTratamiento.FechaConclusion = new Date($scope.listaTratamientos[index].FechaConclusion);
        }

        $scope.ActualizarTratamiento = function () {
            if (validarTratamiento()) {
                $scope.listaTratamientos[indexTratamiento] = angular.copy($scope.nuevoTratamiento);
                inicializarTratamiento();
                indexTratamiento = 0;
                $scope.EditandoTratamiento = false;
            }
            
        }

        var validarTratamiento = function () {

            $scope.tratamientoFechaIni = "";
            $scope.tratamientoFechaFin = "";
            $scope.tratamientoCosto = "";
            $scope.tratamientoDetalle = "";
            var valido = true;
            if ($scope.nuevoTratamiento.FechaInicio == "" || $scope.nuevoTratamiento.FechaInicio == null) {
                $scope.tratamientoFechaIni = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoTratamiento.FechaConclusion == "" || $scope.nuevoTratamiento.FechaConclusion == null) {
                $scope.tratamientoFechaFin = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoTratamiento.Costo == "" || $scope.nuevoTratamiento.Costo == null) {
                $scope.tratamientoCosto = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoTratamiento.Detalle == "" || $scope.nuevoTratamiento.Detalle == null) {
                $scope.tratamientoDetalle = campoInvalido;
                valido = false;
            }

            return valido;
        };

        var validarPaciente = function () {
            var valido = true;
            $scope.pacienteNombre = "";
            $scope.pacienteIdentificacion = "";
            $scope.pacienteEdad = "";
            $scope.pacienteContacto = "";
            $scope.pacienteUltimaFecha = "";
            $scope.pacienteProximaFecha = "";
            if ($scope.nuevoPaciente.Nombre == "" || $scope.nuevoPaciente.Nombre == null) {
                $scope.pacienteNombre = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoPaciente.Identificacion == "" || $scope.nuevoPaciente.Identificacion == null) {
                $scope.pacienteIdentificacion = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoPaciente.Edad == "" || $scope.nuevoPaciente.Edad == null) {
                $scope.pacienteEdad = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoPaciente.DatosContacto == "" || $scope.nuevoPaciente.DatosContacto == null) {
                $scope.pacienteContacto = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoPaciente.UltimaConsulta == "" || $scope.nuevoPaciente.UltimaConsulta == null) {
                $scope.pacienteUltimaFecha = campoInvalido;
                valido = false;
            }

            if ($scope.nuevoPaciente.ProximaConsulta == "" || $scope.nuevoPaciente.ProximaConsulta == null) {
                $scope.pacienteProximaFecha = campoInvalido;
                valido = false;
            }

            return valido
        }

    }]);
})();
