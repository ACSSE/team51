﻿(function (app) {
    'use strict';

    app.controller('editCampaignCtrl', editCampaignCtrl);

    addCampaignCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    function editCampaignCtrl($scope, $http, apiService, notificationService) {
        $scope.pageClass = 'page-home-edit-campaign';

    }

})(angular.module('BursifyApp'));