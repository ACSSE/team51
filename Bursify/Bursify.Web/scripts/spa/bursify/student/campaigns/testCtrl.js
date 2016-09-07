(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/testCtrl
    app.controller('testCtrl', testCtrl);

    testCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function testCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-test-campaign';

        
    }

})(angular.module('BursifyApp'));


