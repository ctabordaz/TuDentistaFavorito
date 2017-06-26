/*
    Servicio de recursos para los llamados a las apis

*/

(function () {
    'use strict';

    var app = angular.module('ResourcesService', ['ngResource'])

    //Recursos de la api de pacientes
    app.factory('Pacientes', ['$resource',  function ($resource) {
        return $resource( '/api/pacientes', {}, {
            getAll: { method: 'GET', url: '/api/pacientes/getAll', params: {}, isArray: true },
            getbyId: { method: 'GET', url: '/api/pacientes/getbyId' },
            save: { method: 'Post', url: '/api/pacientes/save' },
            deletePacient: { method: 'GET', url: '/api/pacientes/delete' }
        });
    }]);

    //Recurso de la api de tratamientos
    app.factory('Tratamientos', ['$resource',  function ($resource) {
        return $resource('/api/tratamientos', {}, {
            getAll: { method: 'GET', url: '/api/tratamientos/getAll', params: {}, isArray: true },
            getAllbyPaciente: { method: 'GET', url: '/api/tratamientos/getAllbyPaciente', isArray: true },
            save: { method: 'Post', url: '/api/tratamientos/save' },
            deleteTratamiento: { method: 'GET', url: '/api/tratamientos/delete' }
        });
    }]);

    //Recurso de la api de token
    app.factory('Token', ['$resource',  function ($resource) {
        return $resource('/api/token', {}, {
            get: { method: 'Post', url: '/api/token'}
        });
    }]);


})();