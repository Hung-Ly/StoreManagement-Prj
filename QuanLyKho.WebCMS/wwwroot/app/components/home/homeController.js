/// <reference path="../wwwroot/libs/angular/angular.min.js" />
/// <reference path="../wwwroot/libs/angular/angular.js" />

(function () {
    'use strict';
    angular.module('app')
        .controller('homeController', homeController)

    homeController.$inject = ['$location']; 

    function homeController() {
 
    }
})();
