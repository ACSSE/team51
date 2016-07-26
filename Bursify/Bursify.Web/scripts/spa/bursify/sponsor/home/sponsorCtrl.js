(function (app) {
    'use strict';

    app.controller('sponsorCtrl', sponsorCtrl);

    sponsorCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function sponsorCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-sponsor';
        $scope.test = test;
        alert("ey");
        function test() {
            alert("ey");
        }

    }

 

})(angular.module('BursifyApp'));