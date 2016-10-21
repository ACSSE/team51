(function (app) {
    'use strict';

    app.controller('adminStudentCtrl', adminStudentCtrl);

    adminStudentCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function adminStudentCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));