(function (app) {
    'use strict';

    app.controller('sponsorCtrl', sponsorCtrl);

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function studentCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-sponsor';

    }

})(angular.module('BursifyApp'));