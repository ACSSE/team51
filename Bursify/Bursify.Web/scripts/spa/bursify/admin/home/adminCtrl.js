(function (app) {
    'use strict';

    app.controller('adminCtrl', adminCtrl);

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function studentCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));