(function (app) {
    'use strict';

    app.controller('adminCtrl', adminCtrl);

    adminCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location'];

    function adminCtrl($scope, apiService, notificationService, $location) {
        $scope.pageClass = 'page-home-admin';
       

        $scope.goToStudent = function () {
            $location.path("/admin/student");
        }

        $scope.goToSponsor = function () {
            $location.path("/admin/sponsor");
        }

        $scope.goToInsight = function () {
            $location.path("/admin/insight");
        }

        $scope.goToCampaign = function () {
            $location.path("/admin/campaign");
        }

    }

})(angular.module('BursifyApp'));