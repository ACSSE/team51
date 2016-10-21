(function (app) {
    'use strict';

    app.controller('leaderboardCtrl', leaderboardCtrl);

    leaderboardCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function leaderboardCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-sponsor-leaderboard';
  
       $scope.loadSponsors= function(){
           apiService.get('api/Sponsor/GetTopTenSponsors/', null, Done, Failed);

       }
       $scope.Sponsors = {};
       function Done(result) {
           $scope.Sponsors = result.data;
       }

       function Failed() {
           notificationService.displayError("Failed");
       }

    }

})(angular.module('BursifyApp'));