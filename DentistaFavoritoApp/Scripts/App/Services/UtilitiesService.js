(function () {
    'use strict';
    var app = angular.module('UtilitiesService', []);


    //Datos autenticacion
    app.value('datosAuth', {
        value: { Usuario: "Admin", Contrasena: "Admin123" }
    });


})();