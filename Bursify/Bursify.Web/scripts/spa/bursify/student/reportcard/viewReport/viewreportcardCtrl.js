(function (app) {
    'use strict';

    app.controller('viewreportcardCtrl', viewreportcardCtrl);

    viewreportcardCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', '$location', '$routeParams'];

    function viewreportcardCtrl($scope, $rootScope, apiService, notificationService, $location, $routeParams) {
        $scope.pageClass = 'page-student-viewreportcard';
        $scope.loadReports = function () {
            apiService.get('/api/report/GetAllReports/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reportLoadCompleted, reportLoadFailed);

            
        }
        $scope.myDataSource = {};

        $scope.init = function(){
            apiService.get('/api/report/GetReport/?studentId=' + $rootScope.repository.loggedUser.userIden + "&reportId=" + $routeParams.reportID, null, reportLoadCompleted, reportLoadFailed);
        }


        function dataItem(label, value) {
            this.label = label;
            this.value = value
        }

        $scope.Report = {};
        function reportLoadCompleted(result) {
            $scope.Report = result.data;
            addData();
        }

        function addData() {


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
                    "trendlines": [
           {
               "line": [
                   {
                       "startvalue": "50",
                       "color": "#0075c2",
                       "displayvalue": "Current{br}Average",
                       "valueOnRight": "1",
                       "thickness": "1",
                       "showBelow": "1",
                       "tooltext": "Previous year quarterly target  : $13.5K"
                   }]}]

                },
                data: [{

                }]
            };

       

            for (var i = 0; i < $scope.Report.Subjects.length; i++) {
                $scope.myDataSource.data.push(new dataItem($scope.Report.Subjects[i].Name, $scope.Report.Subjects[i].MarkAcquired))
            }
 
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }


    }

})(angular.module('BursifyApp'));

