(function (app) {
    'use strict';

    app.controller('leaderboardCtrl', leaderboardCtrl);

    leaderboardCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function leaderboardCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-sponsor-leaderboard';
  
       $scope.loadSponsors= function(){
           apiService.get('api/Sponsor/GetAllSponsors/', null, Done, Failed);

       }
       $scope.Sponsors = {};
       function Done(result) {
           $scope.Sponsors = result.data;
           $scope.Sponsors.sort(function (a, b) { return (a.Rating > b.Rating) ? 1 : ((b.Rating > a.Rating) ? -1 : 0); });
       }

       function Failed() {
           notificationService.displayError("Failed");
       }

    }

})(angular.module('BursifyApp'));