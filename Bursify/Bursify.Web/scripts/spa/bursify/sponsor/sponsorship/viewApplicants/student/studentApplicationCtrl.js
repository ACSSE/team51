(function (app) {
    'use strict';

    app.controller('studentApplicationCtrl', studentApplicationCtrl);

    studentApplicationCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', 'membershipService', '$timeout', 'fileUploadService', '$routeParams', '$mdDialog', '$mdMedia'];


    function studentApplicationCtrl($scope, $rootScope, apiService, notificationService, membershipService, $timeout, fileUploadService, $routeParams, $mdDialog, $mdMedia) {
        $scope.pageClass = 'page-view-sponsorship';
        $scope.max = 2;
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
        $scope.userPassword = "";
        $scope.nextTab = function () {
            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;

        };
        $scope.showAdvanced = function (ev) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
            $mdDialog.show({
                controller: 'studentApplicationCtrl',
                templateUrl: '/Scripts/spa/bursify/sponsor/sponsorship/viewapplicants/student/dialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
               
                clickOutsideToClose: true
            })
            .then(function (answer) {
                $mdDialog.hide();
            }, function () {
                $scope.status = 'You cancelled the dialog.';
            });


            $scope.$watch(function () {
                return $mdMedia('xs') || $mdMedia('sm');
            }, function (wantsFullScreen) {
                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };

        $scope.Student = {};
      

        $scope.loadStudent = function () {
          
            apiService.get('/api/bursifyUser/getuser/?userId=' + $routeParams.StudentId, null, profileLoaded, profileLoadFailed);
            $scope.spID = $routeParams.SponsorshipId;
        }

        $scope.Fields = [];
        function loadReports() {  
            apiService.get('/api/report/GetAllReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted, reportLoadFailed);

            //apiService.get('/api/report/GetSortedReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted2, reportLoadFailed2);

            //apiService.get('/api/campaign/GetAllCampaigns/?userId=' + $routeParams.StudentId, null, campLoadCompleted, campLoadFailed);
            var f = $scope.Student.Student.StudyField;

            var myFields = f.split(",");
            

            for (var i = 0; i < myFields.length; i++) {
                $scope.Fields.push(myFields[i]);
            }
    
        }

        $scope.myDataSource = {};
        $scope.myDataSource2 = {};

        $scope.myReports = {};

        $scope.recentReports = {};

        function reportLoadCompleted(result) {

            $scope.myReports = result.data;
            apiService.get('/api/report/GetSortedReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted2, reportLoadFailed2);
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }

 


        function dataItem(label, value) {
            this.label = label;
            this.value = value;
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
                }]
            };

            for (var i = 0; i < $scope.recentReports.length; i++) {
                $scope.myDataSource.data.push(new dataItem($scope.recentReports[i].ReportYear + "/" + $scope.recentReports[i].ReportPeriod, $scope.recentReports[i].Average))
            }

            $scope.myDataSource2 = {
                "chart": {
                    "caption": "",
                    "subCaption": "Most Recent Report Marks",
                    "yAxisName": "Subjects",
                    "numberSuffix": "%",
                    "paletteColors": "#3F51B5",
                    "bgColor": "#ffffff",
                    "showBorder": "0",
                    "showCanvasBorder": "0",
                    "usePlotGradientColor": "0",
                    "plotBorderAlpha": "5",
                    "placeValuesInside": "1",
                    "valueFontColor": "#ffffff",
                    "showAxisLines": "1",
                    "axisLineAlpha": "25",
                    "divLineAlpha": "10",
                    "alignCaptionWithCanvas": "0",
                    "showAlternateVGridColor": "0",
                    "captionFontSize": "14",
                    "subcaptionFontSize": "14",
                    "subcaptionFontBold": "0",
                    "toolTipColor": "#ffffff",
                    "toolTipBorderThickness": "0",
                    "toolTipBgColor": "#000000",
                    "toolTipBgAlpha": "80",
                    "toolTipBorderRadius": "2",
                    "toolTipPadding": "5"
                },

                "data": []
            };


            for (var i = 0; i < $scope.myReports[0].Subjects.length; i++){
                $scope.myDataSource2.data.push(new dataItem($scope.myReports[0].Subjects[i].Name, $scope.myReports[0].Subjects[i].MarkAcquired))
            }


            apiService.get('/api/campaign/GetAllCampaigns/?userId=' + $routeParams.StudentId, null, campLoadCompleted, campLoadFailed);
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


        $scope.Approve = function() {
            apiService.post('/api/account/verifypassword/?userId='+ $rootScope.repository.loggedUser.userIden + '&password=' + $scope.userPassword , null,   verified,  verifiedFailed)
        }

        function verified(result) {
            if (result.data.success) {
               
                apiService.post('/api/sponsor/approvesponsorship/?studentId=' + $routeParams.StudentId + '&sponsorshipId=' + $routeParams.SponsorshipId, null, approveSuccessful, approveFailed)

            } else {
                notificationService.displayError("Incorrect password !");
                $mdDialog.hide();
            }
        }

        function verifiedFailed(result) {
            notificationService.displayError("Could not verify password");
        }

        function approveSuccessful() {
            notificationService.displaySuccess("Approved.");
            $mdDialog.hide();
        }

        function approveFailed() {
            notificationService.displayError("Could not approve sponsorship at this moment in time. Try again later.")
        }


    

    }
})(angular.module('BursifyApp'));

