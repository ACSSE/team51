(function (app) {
    'use strict';

    app.controller('campaignsCtrl', campaignsCtrl);

    campaignsCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    
    function campaignsCtrl($scope, $http, apiService, notificationService) {
        $scope.pageClass = 'page-home-campaign';

        $scope.campaigns = []; // stores campaigns

/* METHODS RELATING TO A ALL BURSIFY USERS **/
        //Get all the campains from the DB 
        $scope.allCampaigns = function ()
        {
            //Get all Campaigns on bursify database


        }
        
        //Get all the campaigns from the Json file 
        $http.get('campaigns.json').success(function (data) {

            $scope.campaigns = data;
        });



/* METHODS RELATING TO A SINGLE USER **/

        //Get campaigns belonging to a single student
        $scope.myCampaigns = function ($scope)
        {
            //Get all the Campaigns for this student

        }

        //Push new Campaign to the DB 
        $scope.addCampaign = function ()
        {
            //Add campaign  i.e http post 


        }

        //Edit Camapign 
        $scope.editCampaign = function($scope)
        {
            //Get a campaign with an ID matching the parameter
        }

        //Delete Campaign 
        $scope.deleteCampaign = function()
        {
            //Delete a campaign with an ID matching the parameter
        }
    }

})(angular.module('BursifyApp'));