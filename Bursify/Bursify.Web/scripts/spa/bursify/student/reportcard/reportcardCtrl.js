(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService) {
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
  
       
     
       // apiService.get('/api/student/GetMyReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);
        
        function reportLoadCompleted() {
            notificationService.displayInfo("Load complete");
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }

    }

})(angular.module('BursifyApp'));

