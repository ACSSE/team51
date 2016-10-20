(function (app) {
    'use strict';

    app.controller('adminSponsorCtrl', adminSponsorCtrl);

    adminSponsorCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function adminSponsorCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));