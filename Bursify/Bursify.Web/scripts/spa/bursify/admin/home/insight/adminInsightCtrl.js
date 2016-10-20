(function (app) {
    'use strict';

    app.controller('adminInsightCtrl', adminInsightCtrl);

    adminInsightCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function adminInsightCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));