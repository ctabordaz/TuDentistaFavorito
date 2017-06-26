(function () {
    'use strict';
    var app = angular.module('UtilitiesService', []);

    app.value('datosAuth', {
        value: { Usuario: "Admin", Contrasena: "Admin123" }
    });



})();