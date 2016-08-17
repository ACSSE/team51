(function (app) {
    'use strict';

    app.controller('sponsorProfileCtrl', sponsorProfileCtrl);

    sponsorProfileCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function sponsorProfileCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};

    }

})(angular.module('BursifyApp'));

