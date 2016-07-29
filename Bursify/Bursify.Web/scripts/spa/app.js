(function () {
    'use strict';

    angular.module('BursifyApp', ['common.core', 'common.ui', 'ngMaterial', 'ngHamburger', 'md.data.table'])
        .config(config)
        .controller('MainCtrl', function($scope) {
            $scope.tgState = false;
        }).run(run);


    config.$inject = ['$routeProvider', '$mdThemingProvider', '$mdIconProvider'];
    function config($routeProvider, $mdThemingProvider, $mdIconProvider) {

        $mdIconProvider
        .iconSet('social', 'Content/img/icons/sets/social-icons.svg', 24)
        .defaultIconSet('Content/img/icons/sets/core-icons.svg', 24);

        $routeProvider
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            }).when("/bursify/student/home", {
                templateUrl: "scripts/spa/bursify/student/home/index.html",
                controller: "studentCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/bursify/sponsor/home", {
                templateUrl: "scripts/spa/bursify/sponsor/home/index.html",
                controller: "sponsorCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/bursify/admin/home", {
                templateUrl: "scripts/spa/bursify/admin/home/index.html",
                controller: "adminCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/sponsorship/view", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/student/profile", {
                templateUrl: "scripts/spa/bursify/student/profile/profile.html",
                controller: "studentProfileCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/student/campaigns", {
                templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                controller: "campaignsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/student/applications", {
                templateUrl: "scripts/spa/bursify/student/applications/myApplications.html",
                controller: "myApplicationsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).when("/sponsor/chart", {
                templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                controller: "leaderboardCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }).otherwise({ redirectTo: "/" });



    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();