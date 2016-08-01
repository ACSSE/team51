(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        
       

    }

})(angular.module('BursifyApp'));