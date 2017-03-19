/// <reference path="../../../libs/angular/angular.min.js" />
/// <reference path="../../../libs/angular/angular.js" />

(function (app) {
    'use strict';

    app.factory('apiService', apiService);


    apiService.$inject = ['$http','notificationService'];

    function apiService($http, notificationService) {
        return {
            //dinh nghia get = func get
            get: get,
            post: post
        };
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {               
                notificationService.displayError(error.ErrorMessage);
            });
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error);
                failure(error);
            });
        }
    }
})(angular.module('app.common'));