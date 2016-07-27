(function () {
    'use strict';

    angular.module('BursifyApp', ['common.core', 'common.ui', 'ngMaterial', 'ngHamburger', 'acute.select'])
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
            .when("/", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            }).when("/bursify/student/home", {
                templateUrl: "scripts/spa/bursify/student/home/index.html",
                controller: "studentCtrl"
            }).when("/bursify/sponsor/home", {
                templateUrl: "scripts/spa/bursify/sponsor/home/index.html",
                controller: "sponsorCtrl"
            }).when("/bursify/admin/home", {
                templateUrl: "scripts/spa/bursify/admin/home/index.html",
                controller: "adminCtrl"
            }).when("/sponsorship/view", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl"
            }).when("/student/profile", {
                templateUrl: "scripts/spa/bursify/student/profile/profile.html",
                controller: "studentProfileCtrl"
            }).when("/student/campaigns", {
                templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                controller: "campaignsCtrl"
            }).when("/sponsor/chart", {
                templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                controller: "leaderboardCtrl"
            }).otherwise({ redirectTo: "/" });



    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();