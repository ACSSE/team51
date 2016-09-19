(function (app) {
    'use strict';

    app.controller('viewreportcardCtrl', viewreportcardCtrl);

    viewreportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', '$location'];

    function viewreportcardCtrl($scope, $rootScope, apiService, notificationService, $location) {
        $scope.pageClass = 'page-student-viewreportcard';
        $scope.loadReports = function () {
            apiService.get('/api/report/GetAllReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);

            
        }
        $scope.myDataSource = {};


        function dataItem(label, value) {
            this.label = label;
            this.value = value
        }


        function reportLoadFailed2() {
            notificationService.displayError("Load Sorted failed");
        }



    }

})(angular.module('BursifyApp'));

