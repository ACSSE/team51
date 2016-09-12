(function (app) {
    'use strict';

    app.controller('studentApplicationCtrl', studentApplicationCtrl);

    studentApplicationCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', 'membershipService', '$timeout', 'fileUploadService', '$routeParams'];


    function studentApplicationCtrl($scope, $rootScope, apiService, notificationService, membershipService, $timeout, fileUploadService, $routeParams) {
        $scope.pageClass = 'page-view-sponsorship';
        $scope.max = 2;
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
        $scope.nextTab = function () {
            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;

        };
        $scope.Student = {};

        $scope.loadStudent = function () {
          
            apiService.get('/api/bursifyUser/getuser/?userId=' + $routeParams.StudentId, null, profileLoaded, profileLoadFailed);
        }

        function loadReports() {  
            apiService.get('/api/report/GetAllReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted, reportLoadFailed);

            apiService.get('/api/report/GetSortedReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted2, reportLoadFailed2);

            apiService.get('/api/campaign/GetAllCampaigns/?userId=' + $routeParams.StudentId, null, campLoadCompleted, campLoadFailed);

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
                    caption:"Most Recent Average's",
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
                    label: "" + $scope.recentReports[0].ReportYear + "/" + $scope.recentReports[0].ReportPeriod,
                    value: $scope.recentReports[0].Average
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


       
        function profileLoaded(result) {
           
            $scope.Student = result.data;
            loadReports();
        }


        function profileLoadFailed() {
            notificationService.displayError('Error');
        }

        $scope.Campaigns = {}
        function campLoadCompleted(result) {
            $scope.Campaigns = result.data;
        }

        function campLoadFailed()
        {
            notificationService.displayError("Error loading campaigns.");
        }
    

    }
})(angular.module('BursifyApp'));

