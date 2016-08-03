(function (app) {
    'use strict';

    app.controller('campaignDetailsCtrl', campaignDetailsCtrl);

    campaignDetailsCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    function campaignDetailsCtrl($scope, $http, apiService, notificationService) {
        $scope.pageClass = 'page-home-campaign-details';

    }
})(angular.module('BursifyApp'));