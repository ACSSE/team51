(function (app) {
    'use strict';

    app.controller('applicantsCtrl', applicantsCtrl);

    applicantsCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams'];

    function applicantsCtrl($scope, $rootScope, apiService, notificationService, $routeParams) {
        $scope.pageClass = 'page-view-applicants';

        apiService.get('/api/sponsorship/GetApplicants/?sponsorshipId=' + $routeParams.sponsorshipId, null, applicantsLoadCompleted, applicantsLoadFailed);



    }

})(angular.module('BursifyApp'));

