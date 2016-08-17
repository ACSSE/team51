(function (app) {
    'use strict';
    app.controller('fundCampaignCtrl', fundCampaignCtrl);

    fundCampaignCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$mdDialog', '$mdMedia'];

    function fundCampaignCtrl($scope, apiService, notificationService, $mdDialog, $mdMedia) {
        $scope.pageClass = 'page-home-Fund-campaign';


        $scope.fundCampaign = function (ev) {

            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
            $scope.campaignName = "TXTXTX";

            

            $scope.cancelFunding = function () {
                $mdDialog.cancel();
            }

            $mdDialog.show({

                controller: 'fundCampaignCtrl', // this must be the name of your controller

                templateUrl: '/Scripts/spa/bursify/student/campaigns/fund.html', //this is the url of the template you make

                parent: angular.element(document.body),

                targetEvent: ev,
                scope :$scope,
                clickOutsideToClose: true,
                fullscreen: useFullScreen,

            })
            $scope.$watch(function () {

                return $mdMedia('xs') || $mdMedia('sm');

            }, function (wantsFullScreen) {

                $scope.customFullscreen = (wantsFullScreen === true);

            });

        };

    }


})(angular.module('BursifyApp'));