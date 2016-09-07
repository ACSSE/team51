(function (app) {
    'use strict';

    app.controller('sponsorCtrl', sponsorCtrl);

    sponsorCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function sponsorCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-sponsor';
        
        apiService.get('/api/student/GetAllStudents/', null, CompletedStudent, FailedStudent);

        function CompletedStudent(result) {
            $scope.Students = result.data;
        }

        function FailedStudent() {
            notificationService.displayInfo('Unable to load students.');
        }

    }

 

})(angular.module('BursifyApp'));