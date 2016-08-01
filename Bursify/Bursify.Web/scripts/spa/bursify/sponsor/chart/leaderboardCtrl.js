(function (app) {
    'use strict';

    app.controller('leaderboardCtrl', leaderboardCtrl);

    leaderboardCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function leaderboardCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-sponsor-leaderboard';

    }

})(angular.module('BursifyApp'));