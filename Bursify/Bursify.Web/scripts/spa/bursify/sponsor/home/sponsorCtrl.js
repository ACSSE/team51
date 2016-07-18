(function (app) {
    'use strict';

    app.controller('sponsorCtrl', sponsorCtrl);

    sponsorCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function sponsorCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-sponsor';

    }

})(angular.module('BursifyApp'));