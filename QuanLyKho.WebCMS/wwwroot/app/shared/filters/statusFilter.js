/// <reference path="../wwwroot/libs/angular/angular.min.js" />
/// <reference path="../wwwroot/libs/angular/angular.js" />

(function (app) {    
    app.filter('statusFilter', function () {
        return function (input) {
            if (input === true) {
                return 'Active';
            } else
                return 'Lock';
        };
    });
})(angular.module('app.common'));