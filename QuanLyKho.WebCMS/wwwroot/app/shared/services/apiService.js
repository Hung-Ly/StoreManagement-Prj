/// <reference path="../../../libs/angular/angular.min.js" />
/// <reference path="../../../libs/angular/angular.js" />

(function (app) {
    'use strict';

    app.factory('apiService', apiService);


    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            //dinh nghia get = func get
            get: get
        };
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('app.common'));