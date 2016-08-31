(function (app) {
    'use strict';

    app.controller('addAccountCtrl', addAccountCtrl);

    addAccountCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$rootScope'];

    function addAccountCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $rootScope) {
        $scope.pageClass = 'page-campaign-addAccount';

        $scope.Account = {};

        /** Account info    **/
        $scope.Account.ID = 4;//
        $scope.Account.AccountName = $rootScope.repository.loggedUser.username;
        $scope.AccountType = "Select Account Type";
        $scope.Account.AccountNumber = 0;
        $scope.Account.BankName = "Select Your Bank";
        $scope.Account.BranchName;
        $scope.Account.BranchCode = 0;
        /* End of Form input */
        $scope.addAccount = addAccount;

        //Methods 


        function addAccount() {
            apiService.post('api/Campaign/SaveCampaignAccount', $scope.Account,
            addAccountSucceded,
            addAccountFailed);
        }

        function addAccountSucceded(response) {
            notificationService.displaySuccess('Account has been added successfully');
            $scope.campaign = response.data;

            redirectToCampaigns();
        }

        function addAccountFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToCampaigns() {
            $location.path('/student/campaigns');
        }
    }
})(angular.module('BursifyApp'));