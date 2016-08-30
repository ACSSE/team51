(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', '$location'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService, $location) {
        $scope.pageClass = 'page-student-reportcard';
        $scope.myDataSource = {
            chart: {
                caption: "Username's Report Analytics",
                subCaption: "Five most recent reports.",
                numberSuffix: "%",
            },
            data:[{
                label: "2016/SEM1",
                value: "72"
            },
            {
                label: "2015/SEM2",
                value: "67"
            },
            {
                label: "2015/SEM1",
                value: "75"
            },
            {
                label: "2014/SEM2",
                value: "87"
            },
            {
                label: "2014/SEM1",
                value: "90"
            }]
        };
  
        $scope.loadReports = function () {
            apiService.get('/api/report/GetAllReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);
        }
     

        $scope.myReports = {};
        
        function reportLoadCompleted(result) {
            notificationService.displayInfo("Load complete");
            $scope.myReports = result.data;
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }

        $scope.AddReport = function () {
            $location.path('/student/report/add');
        }

    }

})(angular.module('BursifyApp'));

