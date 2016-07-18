(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function studentCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-student';

    }

})(angular.module('BursifyApp'));