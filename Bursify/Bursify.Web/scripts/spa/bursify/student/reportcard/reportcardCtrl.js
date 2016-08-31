(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', '$location'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService, $location) {
        $scope.pageClass = 'page-student-reportcard';
        $scope.loadReports = function () {
            apiService.get('/api/report/GetAllReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);

            apiService.get('/api/report/GetSortedReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted2, reportLoadFailed2);
        }
        $scope.myDataSource = {};


        $scope.myReports = {};

        $scope.recentReports = {};
        
        function reportLoadCompleted(result) {
   
            $scope.myReports = result.data;
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }


        function reportLoadCompleted2(result) {
           
            $scope.recentReports = result.data;
            var label1 = $scope.recentReports
            $scope.myDataSource = {
                chart: {
                    caption: $rootScope.repository.loggedUser.username + " Report Analytics",
                    subCaption: "Five most recent reports.",
                    numberSuffix: "%",
                    paletteColors: "00897b"
                },
                data: [{
                    label: "" + $scope.recentReports[0].ReportYear + "/" + $scope.recentReports[0].ReportPeriod,
                    value:  $scope.recentReports[0].Average
                },
                {
                    label: "" + $scope.recentReports[1].ReportYear + "/" + $scope.recentReports[1].ReportPeriod,
                    value: $scope.recentReports[1].Average
                },
                {
                    label: "" + $scope.recentReports[2].ReportYear + "/" + $scope.recentReports[2].ReportPeriod,
                    value: $scope.recentReports[2].Average
                },
                {
                    label: "" + $scope.recentReports[3].ReportYear + "/" + $scope.recentReports[3].ReportPeriod,
                    value: $scope.recentReports[3].Average
                },
                {
                    label: "" + $scope.recentReports[4].ReportYear + "/" + $scope.recentReports[4].ReportPeriod,
                    value: $scope.recentReports[4].Average
                }]
            };

        }



        function reportLoadFailed2() {
            notificationService.displayError("Load Sorted failed");
        }

        $scope.AddReport = function () {
            $location.path('/student/report/add');
        }

    }

})(angular.module('BursifyApp'));

