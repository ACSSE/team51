(function (app) {
    'use strict';

    app.controller('registrationCtrl', registrationCtrl);

    registrationCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    function registrationCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-registration';
       

    }

})(angular.module('BursifyApp'));

