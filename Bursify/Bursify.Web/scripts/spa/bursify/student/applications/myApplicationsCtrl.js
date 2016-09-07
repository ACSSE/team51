(function (app) {
    'use strict';

    app.controller('myApplicationsCtrl', myApplicationsCtrl);

    myApplicationsCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService'];

    function myApplicationsCtrl($scope,$rootScope, apiService, notificationService) {
        $scope.pageClass = 'page-student-myApplications';

       

        apiService.get('/api/student/GetMyApplications/?studentId=' + $rootScope.repository.loggedUser.userIden, null, applicationLoadCompleted, applicationLoadFailed);
        
        function applicationLoadCompleted(result) {
            $scope.applications = result.data;
        }


        function applicationLoadFailed(result) {
            notificationService.displayError("Failed");
        }


        $scope.selected = [];

        $scope.query = {
            order: 'name',
            limit: 4,
            page: 1
        };

        function success() {

            //<td md-cell>{{application.name}}</td>
            //      <td md-cell>{{application.sponsor}}</td>
            //      <td md-cell>{{application.closing}}</td>
            //      <td md-cell>{{aplication.date}}</td>
            //      <td md-cell>{{application.status}}</td>
       
        }

        $scope.getApplications = function () {
            notificationService.displayError('Here');
        };


    }

})(angular.module('BursifyApp'));

