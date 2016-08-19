(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService) {
        $scope.pageClass = 'page-student-reportcard';

       

       // apiService.get('/api/student/GetMyReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);
        
        function reportLoadCompleted() {
            notificationService.displayInfo("Load complete");
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }

    }

})(angular.module('BursifyApp'));

