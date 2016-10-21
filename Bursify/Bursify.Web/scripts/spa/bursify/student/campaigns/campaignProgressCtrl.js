(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/
    app.controller('campaignProgressCtrl', campaignProgressCtrl);

    campaignProgressCtrl.$inject = ['$scope', 'apiService', '$routeParams', 'notificationService', '$rootScope', '$mdDialog', '$mdMedia', '$location'];

    function campaignProgressCtrl($scope, apiService, $routeParams, notificationService, $rootScope, $mdDialog, $mdMedia, $location) {
        $scope.pageClass = 'page-home-CampaignReport';

        $scope.campaign = {};
        $scope.campaignId = $routeParams.campaignId;
        /** Headers **/
        $scope.loadReports = loadReports();

        /*** Load Campaign Finance Report ***/
        $scope.financeDataSource = {};
        $scope.financeReports = {};
        
        /** Load Campaign Province Report **/

        $scope.provinceDataSource = {};
        $scope.provinceReport = {};

        
        function provinceLoadCompleted(result) {
            alert(result.data);

            $scope.provinceDataSource = {
                chart: {
                    "animation": "0",
                    "showbevel": "0",
                    "usehovercolor": "1",
                    "canvasbordercolor": "FFFFFF",
                    "bordercolor": "FFFFFF",
                    "showlegend": "1",
                    "showshadow": "0",
                    "legendposition": "BOTTOM",
                    "legendborderalpha": "0",
                    "legendbordercolor": "ffffff",
                    "legendallowdrag": "0",
                    "legendshadow": "0",
                    "caption": "Campaign Contributions Per Province",
                    "connectorcolor": "000000",
                    "fillalpha": "80",
                    "hovercolor": "CCCCCC",
                    "showborder": 0
                },
                "colorrange": {
                    "minvalue": "0",
                    "startlabel": "Low",
                    "endlabel": "High",
                    "code": "e44a00",
                    "gradient": "1",
                    "color": [
                        {
                            "maxvalue": 30000,
                            "displayvalue": "Average",
                            "code": "f8bd19"
                        },
                        {
                            "maxvalue": 100000,
                            "code": "6baa01"
                        }
                    ],
                    "maxvalue": 0
                },
                data: [
                    {
                        "data": [
                            {
                                label: "Gauteng",
                                value: "2515"
                            },
                            {
                                "id": "11",
                                "value": "64406"
                            },
                            {
                                "id": "09",
                                "value": "60725"
                            },
                            {
                                "id": "07",
                                "value": "36101"
                            },
                            {
                                "id": "06",
                                "value": "69620"
                            },
                            {
                                "id": "02",
                                "value": "60419"
                            },
                            {
                                "id": "03",
                                "value": "63140"
                            },
                            {
                                "id": "08",
                                "value": "94861"
                            },
                            {
                                "id": "05",
                                "value": "94861"
                            }
                        ]
                    }
                ]
            };

         
        }

        function dataItem(label, value) {
            this.label = label;
            this.value = value
        }

        function provinceLoadFailed(result) {
            notificationService.displayError("Province reports: " + result.data);
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

           // alert((currentDate + "\n" + $scope.campaign.StartDate));

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
            notificationService.displayError("Failed to load Upvotes reports");
        }
        /** End of upvotes report **/


        /** Load all Reports **/
        function loadReports() {
            //Call Api to get a campaign so that this function can get the date the campaign was created 
            apiService.get('/api/Campaign/GetReportCampaign/?campaignId=' + $scope.campaignId, null,
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
            
            apiService.get('/api/Campaign/GetFundersPerProvince/?campaignId= ' + $scope.campaignId, null,
            provinceLoadCompleted,
            provinceLoadFailed);

            //upvotes report
            apiService.get('/api/Campaign/GetUpVotes/?campaignId=' + $scope.campaignId, null,
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
    }

})(angular.module('BursifyApp'));