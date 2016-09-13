(function (app) {
    'use strict';

    app.controller('applicantsCtrl', applicantsCtrl);

    applicantsCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams', '$timeout'];

    function applicantsCtrl($scope, $rootScope, apiService, notificationService, $routeParams, $timeout) {
        $scope.pageClass = 'page-view-applicants';

        apiService.get('/api/sponsorship/GetApplicants/?sponsorshipId=' + $routeParams.sponsorshipId, null, applicantsLoadCompleted, applicantsLoadFailed);
        $scope.Applicants = {};

         $scope.selected = [];
        $scope.query = {
            order: '-Average',
            limit: 5,
            page: 1
        };


        $scope.options = {
            rowSelection: true,
            multiSelect: true,
            autoSelect: true,
            decapitate: false,
            largeEditDialog: false,
            boundaryLinks: false,
            limitSelect: true,
            pageSelect: true
        };

        $scope.selected = [];
        $scope.limitOptions = [5, 10, 15, {
            label: 'All',
            value: function () {
                return $scope.Applicants ? $scope.Applicants.count : 0;
            }
        }];

        $scope.toggleLimitOptions = function () {
            $scope.limitOptions = $scope.limitOptions ? undefined : [5, 10, 15];
        };

     

        $scope.onPaginate = function (page, limit) {
            console.log('Scope Page: ' + $scope.query.page + ' Scope Limit: ' + $scope.query.limit);
            console.log('Page: ' + page + ' Limit: ' + limit);

            $scope.promise = $timeout(function () {

            }, 2000);
        };


        $scope.log = function (item) {
            console.log(item.name, 'was selected');
        };

        $scope.loadStuff = function () {
            $scope.promise = $timeout(function () {

            }, 2000);
        };

        $scope.onReorder = function (order) {

            console.log('Scope Order: ' + $scope.query.order);
            console.log('Order: ' + order);

            $scope.promise = $timeout(function () {

            }, 2000);
        };



        function applicantsLoadCompleted(result) {
     
            $scope.Applicants = result.data;
        }

        function applicantsLoadFailed() {
            notificationService.displayError("Failed");
        }
    }

})(angular.module('BursifyApp'));

