(function (app) {
    'use strict';

    app.controller('adminCtrl', adminCtrl);

    adminCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function adminCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));