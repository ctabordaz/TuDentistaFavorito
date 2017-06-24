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
        return $resource( 'api/pacientes', {}, {
            getAll: { method: 'GET', url: 'api/pacientes/getAll', params: {}, isArray: true },
            save: { method: 'Post', url: '/api/pacientes/save' },
            deletePacient: { method: 'GET', url: '/api/pacientes/deletePaciente' }
        });
    }]);


})();