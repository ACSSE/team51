(function (app) {
    'use strict';

    app.controller('metricCtrl', metricCtrl);

    metricCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$routeParams'];

    function metricCtrl($scope, apiService, notificationService, $routeParams) {
        $scope.pageClass = 'page-view-sponsorship';


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };

        function dataItem(label, value) {
            this.label = label;
            this.value = value
        }

        $scope.loadAll = function () {
            apiService.get('api/Sponsorship/GetMaleFemaleRatio/?sponsorshipId=' + $routeParams.sponsorshipId, null, MaleVSFemaleDone, MaleVSFemaleFailed);
        }

        $scope.MVFData = {};
        $scope.MVFDataSource = {};
        function MaleVSFemaleDone(result) {
            $scope.MVFData = result.data;
            loadProvince();
            $scope.MVFDataSource = {
                chart: {
                    "caption": "Male vs. Female",
                  
                    "paletteColors": "#0075c2,#1aaf5d,#f2c500,#f45b00,#8e0000",
                    "bgColor": "#ffffff",
                    "showBorder": "0",
                    "use3DLighting": "0",
                    "showShadow": "0",
                    "enableSmartLabels": "0",
                    "startingAngle": "0",
                    "showPercentValues": "1",
                    "showPercentInTooltip": "0",
                    "decimals": "1",
                    "captionFontSize": "14",
                    "subcaptionFontSize": "14",
                    "subcaptionFontBold": "0",
                    "toolTipColor": "#ffffff",
                    "toolTipBorderThickness": "0",
                    "toolTipBgColor": "#000000",
                    "toolTipBgAlpha": "80",
                    "toolTipBorderRadius": "2",
                    "toolTipPadding": "5",
                    "showHoverEffect": "1",
                    "showLegend": "1",
                    "legendBgColor": "#ffffff",
                    "legendBorderAlpha": "0",
                    "legendShadow": "0",
                    "legendItemFontSize": "10",
                    "legendItemFontColor": "#666666",
                    "useDataPlotColorForLabels": "1"
                },
                "data": [
                    {
                        "label": "Male",
                        "value": $scope.MVFData.Male
                    },
                    {
                        "label": "Female",
                        "value": $scope.MVFData.Female
                    }
                ]
            };

        }

        function MaleVSFemaleFailed() {
            notificationService.displayError("Male vs Female failed.");
        }


        function loadProvince() {
            apiService.get('api/Sponsorship/GetApplicantsPerProvince/?sponsorshipId=' + $routeParams.sponsorshipId, null, ProvinceDone, ProvinceFailed);

        }

        $scope.ProvinceData = {}
        $scope.ProvinceDataSource = {};
        function ProvinceDone(result) {
            $scope.ProvinceData = result.data;
            $scope.ProvinceDataSource = {
                "chart": {
                    "caption": "Applicants Per Province",
                  
                    "xAxisName": "Province",
                    "yAxisName": "Count",
                   
                    "paletteColors": "#0075c2,#1aaf5d,#f2c500,#f45b00,#8e0000",
                    "bgColor": "#ffffff",
                    "borderAlpha": "20",
                    "canvasBorderAlpha": "0",
                    "usePlotGradientColor": "0",
                    "plotBorderAlpha": "10",
                    "placevaluesInside": "1",
                    "rotatevalues": "1",
                    "valueFontColor": "#ffffff",
                    "showXAxisLine": "1",
                    "xAxisLineColor": "#999999",
                    "divlineColor": "#999999",
                    "divLineDashed": "1",
                    "showAlternateHGridColor": "0",
                    "subcaptionFontBold": "0",
                    "subcaptionFontSize": "14"
                },
                "data": [
                   
                ]
              
            }

            for (var i = 0; i < $scope.ProvinceData.count; i++) {
                $scope.ProvinceDataSource.data.push(new dataItem($scope.ProvinceData.data[i].Province, $scope.ProvinceData.data[i].ApplicantCount))
            }

            loadWeekly();
        }

        function ProvinceFailed() {
            notificationService.displayError("Province Failed");
        }

        function loadWeekly() {
            apiService.get('api/Sponsorship/GetApplicantsPerWeek/?sponsorshipId=' + $routeParams.sponsorshipId, null, WeeklyDone, WeeklyFailed);

        }

        $scope.WeeklyData = {};
        $scope.WeeklyDataSource = {};
        function WeeklyDone(result) {
            $scope.WeeklyData = result.data;
            $scope.WeeklyDataSource = {

                "chart": {
                    "caption": "Applicants Per Week",
                 
                    "xAxisName": "Week",
                    "yAxisName": "Count",
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
                    "divLineDashed": "1",
                    "divLineDashLen": "1",
                    "showXAxisLine": "1",
                    "xAxisLineThickness": "1",
                    "xAxisLineColor": "#999999",
                    "showAlternateHGridColor": "0"
                },
                "data": [
                 
                ]
            };
            for (var i = 0; i < $scope.WeeklyData.count; i++) {
                $scope.WeeklyDataSource.data.push(new dataItem("Week " + $scope.WeeklyData.data[i].Week, $scope.WeeklyData.data[i].ApplicantCount))
            }
            loadAverage()
        }

        function WeeklyFailed() {
            notificationService.displayError("Weekly Failed");
        }

        function loadAverage() {
            apiService.get('api/Sponsorship/GetApplicantOverallAverage/?sponsorshipId=' + $routeParams.sponsorshipId, null, AverageDone, AverageFailed);

        }

        $scope.Average = {}
        function AverageDone(result) {
            $scope.Average = result.data
        }

        function AverageFailed() {
            notificationService.displayError("Average Failed");
        }


    }

})(angular.module('BursifyApp'));

