(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService) {
        $scope.pageClass = 'page-student-reportcard';

        $scope.graph = {};
        $scope.graph.visible = false;

        $scope.showGraph = function (yesOrNo) {
            $scope.graph.visible = yesOrNo;
        }

        $scope.graph.data = [[1, 2, 3, 4, 5, 6, 7, 8]];
        $scope.graph.labels = ['hoi', 'doei', 'hallo', 'hee', 'hoi', 'doei', 'hallo', 'hee'];
        $scope.graph.options = {
            animation: false
        };
        $scope.graph.series = ['Series']
        // $scope.graph.colours;
        $scope.graph.legend = true;
   
       // apiService.get('/api/student/GetMyReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);
        
        function reportLoadCompleted() {
            notificationService.displayInfo("Load complete");
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }

    }

})(angular.module('BursifyApp'));

