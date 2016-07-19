(function () {
    'use strict';

    angular.module('BursifyApp', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
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
            })
            .when("/bursify/student/campaigns-view", {
                templateUrl: "scripts/spa/bursify/campaigns/viewCampaigns.html",
                controller: "campaignsCtrl"
            })
            .when("/bursify/student/campaign-add", {
                templateUrl: "scripts/spa/bursify/campaigns/addCampaign.html",
                controller: "addCampaignCtrl"
            })
            .when("/bursify/student/campaign-edit", {
                templateUrl: "scripts/spa/bursify/campaigns/editCampaign.html",
                controller: "editCampaignCtrl"
            }).otherwise({ redirectTo: "http://localhost:50000/index.html" });
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