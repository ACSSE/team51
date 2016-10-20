(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/
    app.controller('campaignProgressCtrl', campaignProgressCtrl);

    campaignProgressCtrl.$inject = ['$scope', 'apiService', '$routeParams', 'notificationService', '$rootScope', '$mdDialog', '$mdMedia', '$location'];

    function campaignProgressCtrl($scope, apiService, $routeParams, notificationService, $rootScope, $mdDialog, $mdMedia, $location) {
        $scope.pageClass = 'page-home-CampaignReport';

        $scope.campaign = {};
        $scope.campaignId = 77;
        /** Headers **/
        $scope.loadReports = loadReports();

        /*** Load Campaign Finance Report ***/
        $scope.financeDataSource = {};
        $scope.financeReports = {};
        
        /** Load Campaign Province Report **/

        $scope.provinceDataSource = {};
        $scope.provinceReport = {};

        
        function provinceLoadCompleted(result) {

            $scope.provinceDataSource = {
                chart: {
                    caption: "This Campaign's money coming in lol :)",
                    subCaption: "",
                    numberPrefix: "R",
                    //numberSuffix: ".00",
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
                data: [{}]
            };

            var funds = result.data;
            var i = 1;


            var currentDate = new Date();//Get todays date

            alert((currentDate + "\n" + $scope.campaign.StartDate));

            funds.forEach(function (entry) {
                $scope.financeDataSource.data.push(new dataItem("Day " + (i), entry.AmountContributed));
                i++
            });
        }

        function financeLoadFailed(result) {
            notificationService.displayError("Finance reports: " + result.data);
        }

        /**End of Province Report**/
        function financeLoadCompleted(result) {

            //var financeDataSource = result.data;
            
            $scope.financeDataSource = {
                chart: {
                    caption: "This Campaign's money coming in lol :)",
                    subCaption: "",
                    numberPrefix: "R",
                    //numberSuffix: ".00",
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
                data: [{}]
            };

        //public int CampaignId { get; set; }
        //public int SponsorId { get; set; }
        //public double AmountContributed { get; set; }
        //public DateTime DateOfContribution { get; set; }


            var funds = result.data;
            var i = 1;

            
            var currentDate = new Date();//Get todays date

            alert((currentDate + "\n" + $scope.campaign.StartDate));

            funds.forEach(function (entry)
            {
                $scope.financeDataSource.data.push(new dataItem("Day " + (i), entry.AmountContributed));
                i++
            });
        }

        function financeLoadFailed(result) {
            notificationService.displayError("Finance reports: " + result.data);
        }

        function campaignLoadFailed(result) {
            notificationService.displayError("Campaign Load Fail: " + result.data);
        }

        function campaignLoadCompleted(result)
        {
            $scope.campaign = result.data;
        }

        /*** End of finace campaign **/


        /** Start of funders report **/
        $scope.fundersDataSource = {};
        $scope.fundersReports = {};

        function fundersLoadCompleted(result) {

            $scope.fundersDataSource = {
                chart: {
                    caption: "This Campaign's money coming in lol :)",
                    subCaption: "",
                    numberPrefix: "R",
                    //numberSuffix: ".00",
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
                data: [{}]
            };
            var funds = result.data;
            var i = 1;

            //Call Api to get a campaign so that this function can get the date the campaign was created 


            funds.forEach(function (entry) {
                $scope.fundersDataSource.data.push(new dataItem(entry.Name, entry.AmountContributed));
                i++
            });
            
        }

        function fundersLoadFailed() {
            notificationService.displayError("Failed to load funders reports");
        }
        /** End of funders report **/


        /** Start of upvotes report **/
        $scope.upvotesDataSource = {};
        $scope.upvotesReports = {};

        function upvotesLoadCompleted(result) {

            $scope.upvotesDataSource = {
                chart: {
                    caption: "This Campaign's money coming in lol :)",
                    subCaption: "",
                    numberPrefix: "R",
                    //numberSuffix: ".00",
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
                data: [{}]
            };

            var campaigns = result.data;
            var i = 0;

            campaigns.forEach(function (entry) {
                i++
                $scope.upvotesDataSource.data.push(new dataItem("Day " + (i + 1), entry.AmountContributed));
            });
        }

        function upvotesLoadFailed() {
            notificationService.displayError("Failed to load funders reports");
        }
        /** End of upvotes report **/


        /** Load all Reports **/
        function loadReports() {
            //Call Api to get a campaign so that this function can get the date the campaign was created 
            apiService.get('/api/Campaign/GetCampaign/?campaignId=' + $scope.campaignId, null,
            campaignLoadCompleted,
            campaignLoadFailed);

            /** Get The campaign Details **/
            apiService.get('/api/Campaign/GetCampaignSponsors/?campaignId= ' + $scope.campaignId, null,
            financeLoadCompleted,
            financeLoadFailed);
            

            //Funders Report
            apiService.get('/api/Campaign/GetCampaignSponsors/?campaignId= ' + $scope.campaignId, null,
                fundersLoadCompleted,
                fundersLoadFailed);
            
            //upvotes report
            apiService.get('/api/Campaign/', null,
                upvotesLoadCompleted,
                upvotesLoadFailed);

        }

        //Adding data to the chart dynamically 
        function dataItem(label, value)
        {
            this.label = label;
            this.value = value;
        }
        /** End Load Reports **/


        //Next button 
        $scope.nextTab = function () {

            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;
        };

        //Previous button 
        $scope.prevTab = function () {

            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex - 1;
            $scope.selectedIndex = index;
        };
    }

})(angular.module('BursifyApp'));