
/// <reference path="../wwwroot/libs/angular/angular.min.js" />
/// <reference path="../wwwroot/libs/angular/angular.js" />

//function nac danh

(function () {

    //'use strict';
    // ten module chinh: app dependence [] ,  truyen vao config mot func config
    // goi dc ui.router da truyen tu app.common
    angular.module('app',
       ['app.common',
        'app.products',        
        'app.product_categories']).config(config);

    //$stateProvider, $urlRouterProvider thuoc $urlRouterr
    config.$inject = ['$urlRouterProvider', '$stateProvider'];

    //trien khai func config
    function config($urlRouterProvider, $stateProvider) {
        $stateProvider.state("home", {
            url:'/admin',
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();