(function (app) {
    'use strict';

    app.controller('reportcardCtrl', reportcardCtrl);

    reportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', '$location'];

    function reportcardCtrl($scope, $rootScope, apiService, notificationService, $location) {
        $scope.pageClass = 'page-student-reportcard';
        $scope.loadReports = function () {
            apiService.get('/api/report/GetAllReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);

            
        }
        $scope.myDataSource = {};


        $scope.myReports = {};

        $scope.recentReports = {};
        
        function reportLoadCompleted(result) {
   
            $scope.myReports = result.data;
            apiService.get('/api/report/GetSortedReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted2, reportLoadFailed2);
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }


        function reportLoadCompleted2(result) {
           
            $scope.recentReports = result.data;
            var label1 = $scope.recentReports
            $scope.myDataSource = {
                chart: {
                    caption: "Most Recent Average's",
                    subCaption: "",
                    numberSuffix: "%",
                    //Cosmetics
                    "lineThickness": "2",
                    "paletteColors": "#0075c2",
                    "baseFontColor": "#333333",
                    "baseFont": "Helvetica Neue,Arial",
                    "captionFontSize": "14",
                    "subcaptionFontSize": "14",
                    "subcaptionFontBold": "0",
                    "showBorder": "0",
                    "bgColor": "#ffffff",
                    "showShadow": "0",
                    "canvasBgColor": "#ffffff",
                    "canvasBorderAlpha": "0",
                    "divlineAlpha": "100",
                    "divlineColor": "#999999",
                    "divlineThickness": "1",
                    "divLineIsDashed": "1",
                    "divLineDashLen": "1",
                    "divLineGapLen": "1",
                    "showXAxisLine": "1",
                    "xAxisLineThickness": "1",
                    "xAxisLineColor": "#999999",
                    "showAlternateHGridColor": "0",

                },
                data: [{
                    
                 }]
            };

            for (var i = 0; i < $scope.recentReports.length; i++) {
                $scope.myDataSource.data.push(new dataItem($scope.recentReports[i].ReportYear + "/" + $scope.recentReports[i].ReportPeriod, $scope.recentReports[i].Average))
            }

        }


        function dataItem(label, value) {
            this.label = label;
            this.value = value
        }


        function reportLoadFailed2() {
            notificationService.displayError("Load Sorted failed");
        }

        $scope.AddReport = function () {
            $location.path('/student/report/add');
        }

    }

})(angular.module('BursifyApp'));

