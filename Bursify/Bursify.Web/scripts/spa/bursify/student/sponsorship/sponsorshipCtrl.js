(function (app) {
    'use strict';

    app.controller('sponsorshipCtrl', sponsorshipCtrl);

    sponsorshipCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function sponsorshipCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-sponsorship';


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


    }

})(angular.module('BursifyApp'));

