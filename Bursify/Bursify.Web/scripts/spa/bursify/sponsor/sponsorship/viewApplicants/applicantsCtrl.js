(function (app) {
    'use strict';

    app.controller('applicantsCtrl', applicantsCtrl);

    applicantsCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams'];

    function applicantsCtrl($scope, $rootScope, apiService, notificationService, $routeParams) {
        $scope.pageClass = 'page-view-applicants';

        apiService.get('/api/sponsorship/GetApplicants/?sponsorshipId=' + $routeParams.sponsorshipId, null, applicantsLoadCompleted, applicantsLoadFailed);

        $scope.Applicants = [{ Name: "Nice Name", School: "UJ", PicturePath: "Content/images/student/student3.jpg", Age: 18, Province: "Gauteng", Level: "Grade 12", Average: 80, Gender: "Female" },
            { Name: "Abe Name", School: "UCT", PicturePath: "Content/images/student/student8.jpg", Age: 18, Province: "Gauteng", Level: "Grade 12", Average: 80 , Gender: "Male"}];
        $scope.selected = [];
        $scope.query = {
            order: 'name',
            limit: 5,
            page: 1
        };



        function applicantsLoadCompleted() {

        }

        function applicantsLoadFailed() {
            notificationService.displayError("Failed");
        }
    }

})(angular.module('BursifyApp'));

