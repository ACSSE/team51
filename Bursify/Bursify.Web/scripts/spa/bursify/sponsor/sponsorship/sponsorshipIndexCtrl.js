(function (app) {
    'use strict';

    app.controller('sponsorshipIndexCtrl', sponsorshipIndexCtrl);

    sponsorshipIndexCtrl.$inject = ['$scope', '$timeout', 'apiService', '$location', 'notificationService', '$mdDialog', '$mdMedia'];


    function sponsorshipIndexCtrl($scope, $timeout, apiService, $location, notificationService, $mdDialog, $mdMedia) {
        $scope.pageClass = 'page-view-sponsorship';
        $scope.max = 2;
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
        $scope.nextTab = function () {
             var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;

        };

     
        $scope.addHigh = function () {
            $location.path('/sponsor/sponsorships/add');
        };

        $scope.addTer = function () {
            $location.path('/sponsor/sponsorships/add');
        };

        $scope.levels = $scope.levels || [
                  { id: 1, name: 'High School' },
                  { id: 2, name: 'Tertiary' }
        ];

        $scope.announceClick = function (index) {
            if (index == 0) {
                $location.path('/sponsor/sponsorships/add');
            }
        };

        $scope.field = null;
        $scope.fields = null;
        $scope.loadFields = function () {
           
            return $timeout(function () {
                $scope.fields = $scope.fields || [
                  { id: 1, name: 'Accounting' },
                  { id: 2, name: 'Aviation' },
                  { id: 3, name: 'Animation' },
                  { id: 4, name: 'Arts & Crafts' },
                  { id: 5, name: 'Automotive' },
                  { id: 6, name: 'Aerospace' },
                  { id: 7, name: 'Banking' }
                ];
            }, 10);
        };

        $scope.create = function () {
            $location.path('/bursify/sponsor/home');
        };


        $scope.showAdvanced = function (ev) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
            $mdDialog.show({
                controller: 'sponsorshipIndexCtrl',
                templateUrl: '/Scripts/spa/bursify/sponsor/sponsorship/addSponsorship/dialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true
            })
            .then(function (answer) {
                alert("hi");
                $mdDialog.hide();
            }, function () {
                $scope.status = 'You cancelled the dialog.';
            });

         
            $scope.$watch(function () {
                return $mdMedia('xs') || $mdMedia('sm');
            }, function (wantsFullScreen) {
                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };

    }


})(angular.module('BursifyApp'));

