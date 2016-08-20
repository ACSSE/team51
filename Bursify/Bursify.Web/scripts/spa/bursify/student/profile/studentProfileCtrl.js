(function (app) {
    'use strict';

    app.controller('studentProfileCtrl', studentProfileCtrl);

    studentProfileCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    function studentProfileCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};
    }

})(angular.module('BursifyApp'));

