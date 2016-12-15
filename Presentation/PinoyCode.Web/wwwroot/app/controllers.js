/// <reference path="../lib/angular/angular.js" />
/// <reference path="../lib/angular/angular.min.js" />
/// <reference path="../lib/jquery/dist/jquery.min.js" />
/// <reference path="../lib/jquery/dist/jquery.js" />


(function () {
    'use strict';

    angular
        .module('app')
        .controller('categoryController', categoryController);

    categoryController.$inject = ['$scope', '$location'];

    function categoryController($scope, $location) {
        var path = $location.url() + "/classifieds/list";
        jQuery.getJSON(path, function (data) {

        });

        $scope.paged = paged;

        var paged = {
            pageIndex: 0,
            pagedSize: 11,
            searchByPropertyName: "Title",
            searchByText: "",
            orderByPropertyName: 'Title',
            orderByDescending: false
        }
    }



})();
