(function (app) {
    'use strict';

    app.controller('addSponsorshipCtrl', addSponsorshipCtrl);

    addSponsorshipCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function addSponsorshipCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-sponsorship';


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


    }

})(angular.module('BursifyApp'));

