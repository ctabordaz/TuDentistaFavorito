(function () {
    'use strict';

    var app = angular.module('ResourcesService', ['ngResource'])

    app.factory('baseUrl', ['$location', function ($location) {
        var url = $location.absUrl();

        return url;
    }]);

    app.factory('pathUrl', ['$location', function ($location) {
        var url = '';
        return url;
    }]);


    app.factory('Pacientes', ['$resource', 'baseUrl', function ($resource, baseUrl) {
        return $resource( '/api/pacientes', {}, {
            getAll: { method: 'GET', url: '/api/pacientes/getAll', params: {}, isArray: true },
            getbyId: { method: 'GET', url: '/api/pacientes/getbyId' },
            save: { method: 'Post', url: '/api/pacientes/save' },
            deletePacient: { method: 'GET', url: '/api/pacientes/delete' }
        });
    }]);

    app.factory('Tratamientos', ['$resource', 'baseUrl', function ($resource, baseUrl) {
        return $resource('/api/tratamiento', {}, {
            getAll: { method: 'GET', url: '/api/tratamiento/getAll', params: {}, isArray: true },
            getAllbyPaciente: { method: 'GET', url: '/api/tratamiento/getAllbyPaciente', isArray: true },
            save: { method: 'Post', url: '/api/tratamiento/save' },
            deleteTratamiento: { method: 'GET', url: '/api/tratamiento/delete' }
        });
    }]);

    app.factory('Token', ['$resource', 'baseUrl', function ($resource, baseUrl) {
        return $resource('/api/token', {}, {
            get: { method: 'Post', url: '/api/token'}
        });
    }]);


})();