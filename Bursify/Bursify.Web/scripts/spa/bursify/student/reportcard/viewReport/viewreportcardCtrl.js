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

        $scope.myDataSource = {
            "chart": {
                "caption": "",
                "xAxisname": "Mark",
                "yAxisName": "Percentage%",
                "numberSuffix": "%",
                "plotFillAlpha": "80",
                "paletteColors": "#0075c2,#1aaf5d",
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
                "usePlotGradientColor": "0",
                "showplotborder": "0",
                "valueFontColor": "#ffffff",
                "placeValuesInside": "1",
                "showHoverEffect": "1",
                "rotateValues": "1",
                "showXAxisLine": "1",
                "xAxisLineThickness": "1",
                "xAxisLineColor": "#999999",
                "showAlternateHGridColor": "0",
                "legendBgAlpha": "0",
                "legendBorderAlpha": "0",
                "legendShadow": "0",
                "legendItemFontSize": "10",
                "legendItemFontColor": "#666666"
            },
            "categories": [
                {
                    "category": [
                        {
                            "label": "Q1"
                        },
                        {
                            "label": "Q2"
                        },
                        {
                            "label": "Q3"
                        },
                        {
                            "label": "Q4"
                        }
                    ]
                }
            ],
            "dataset": [
                {
                    "seriesname": "Previous Year",
                    "data": [
                        {
                            "value": "10000"
                        },
                        {
                            "value": "11500"
                        },
                        {
                            "value": "12500"
                        },
                        {
                            "value": "15000"
                        }
                    ]
                }
            ],
            "trendlines": [
                {
                    "line": [
                        {
                            "startvalue": "12250",
                            "color": "#0075c2",
                            "displayvalue": "Current{br}Average",
                            "valueOnRight": "1",
                            "thickness": "1",
                            "showBelow": "1",
                            "tooltext": "Previous year quarterly target  : $13.5K"
                        },
                        {
                            "startvalue": "25950",
                            "color": "#1aaf5d",
                            "displayvalue": "Other{br}Average",
                            "valueOnRight": "1",
                            "thickness": "1",
                            "showBelow": "1",
                            "tooltext": "Current year quarterly target  : $23K"
                        }
                    ]
                }
            ]
        };

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

            for (var i = 0; i < $scope.Report.Subjects.length; i++) {
                $scope.myDataSource.data.push(new dataItem($scope.Report.Subjects[i].Name, $scope.Report.Subjects[i].MarkAcquired))
            }

            $scope.myDataSource.chart.caption = "hey";
        }

        function reportLoadFailed() {
            notificationService.displayError("Load failed");
        }


    }

})(angular.module('BursifyApp'));

