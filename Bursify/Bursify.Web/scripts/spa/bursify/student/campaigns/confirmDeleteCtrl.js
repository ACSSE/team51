(function (app) {
    'use strict';
    app.controller('confirmDeleteCtrl', confirmDeleteCtrl);

    //Single Campaign view
    confirmDeleteCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$mdDialog', '$mdMedia', '$rootScope'];

    function confirmDeleteCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $mdDialog, $mdMedia, $rootScope) {
        $scope.pageClass = "page-campaign-ConfirmDelete";

        $scope.cancelDelete = function () {
            $mdDialog.cancel();
        }

        $mdDialog.show({
            controller: 'confirmDeleteCtrl', // this must be the name of your controller
            templateUrl: '/Scripts/spa/bursify/student/campaigns/confirmDelete.html', //this is the url of the template u call
            parent: angular.element(document.body),
            targetEvent: ev,
            scope: $scope, //pass the scope to dialog
            clickOutsideToClose: true,
        });

        $scope.$watch(function () {

            return $mdMedia('xs') || $mdMedia('sm');

        }, function (wantsFullScreen) {

            $scope.customFullscreen = (wantsFullScreen === true);
        });
    };
})(angular.module('BursifyApp'));