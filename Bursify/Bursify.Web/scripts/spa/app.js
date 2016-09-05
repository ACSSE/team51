(function () {
    'use strict';

    angular.module('BursifyApp', ['common.core', 'common.ui', 'ngMaterial', 'ngSanitize', 'ngHamburger', 'md.data.table', 'ng-fusioncharts'])
        .config(config)
        .controller('MainCtrl', function($scope) {
            $scope.tgState = false;
        }).run(run);


    config.$inject = ['$routeProvider', '$mdThemingProvider', '$mdIconProvider'];
    function config($routeProvider, $mdThemingProvider, $mdIconProvider) {

        $mdIconProvider
        .iconSet('social', 'Content/img/icons/sets/social-icons.svg', 24)
        .iconSet('communication', 'Content/img/icons/sets/communication-icons.svg', 24)
        .defaultIconSet('Content/img/icons/sets/core-icons.svg', 24);

        $routeProvider
          
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/student/home", {
                templateUrl: "scripts/spa/bursify/student/home/index.html",
                controller: "studentCtrl",
               // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/home", {
                templateUrl: "scripts/spa/bursify/sponsor/home/index.html",
                controller: "sponsorCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/admin/home", {
                templateUrl: "scripts/spa/bursify/admin/home/index.html",
                controller: "adminCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsorship/view", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/profile", {
                templateUrl: "scripts/spa/bursify/student/profile/profile.html",
                controller: "studentProfileCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/messages", {
                templateUrl: "scripts/spa/bursify/student/messages/messages.html",
                controller: "messagesCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/report", {
                templateUrl: "scripts/spa/bursify/student/reportcard/reportcard.html",
                controller: "reportcardCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/report/add", {
                templateUrl: "scripts/spa/bursify/student/reportcard/addreport/addreport.html",
                controller: "addReportCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/profile", {
                templateUrl: "scripts/spa/bursify/sponsor/profile/profile.html",
                controller: "sponsorProfileCtrl",
                 // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/registration", {
                templateUrl: "scripts/spa/bursify/sponsor/registration/registration.html",
                controller: "registrationCtrl",
               // resolve: { isAuthenticated: isAuthenticated }
            })
             .when("/student/registration", {
                 templateUrl: "scripts/spa/bursify/student/registration/registration.html",
                 controller: "registrationStudentCtrl",
                 // resolve: { isAuthenticated: isAuthenticated }
             })
            .when("/sponsor/sponsorships", {
                templateUrl: "scripts/spa/bursify/sponsor/sponsorship/sponsorshipIndex.html",
                controller: "sponsorshipIndexCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/sponsorships/add", {
                templateUrl: "scripts/spa/bursify/sponsor/sponsorship/addSponsorship/add.html",
                controller: "addSponsorshipCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/sponsorships/addT", {
                templateUrl: "scripts/spa/bursify/sponsor/sponsorship/addSponsorship/addT.html",
                controller: "addTSponsorshipCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/campaigns", {
                templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                controller: "campaignsCtrl",
                 // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/applications", {
                templateUrl: "scripts/spa/bursify/student/applications/myApplications.html",
                controller: "myApplicationsCtrl",
                 // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/chart", {
                templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                controller: "leaderboardCtrl",
                 // resolve: { isAuthenticated: isAuthenticated}
            }).when("/student/sponsorship/:sponsorshipId", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl",
                 // resolve: { isAuthenticated: isAuthenticated }
            })
            /* Campaigns start **/
                //STUDENT 
                .when("/student/campaigns", {
                    templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                    controller: "campaignsCtrl",
                    resolve: { isAuthenticated: isAuthenticated }
                })
                .when("/student/myCampaigns/", {
                    templateUrl: "scripts/spa/bursify/student/campaigns/myCampaigns.html",
                    controller: "myCampaignsCtrl",
                    resolve: { isAuthenticated: isAuthenticated }
                })
            .when("/student/add-campaign", {
                templateUrl: "scripts/spa/bursify/student/campaigns/addCampaign.html",
                controller: "addCampaignCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/edit-campaign/:campaignId", {
                templateUrl: "scripts/spa/bursify/student/campaigns/editCampaign.html",
                controller: "editCampaignCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/campaign-details/:campaignId", {
                templateUrl: "scripts/spa/bursify/student/campaigns/campaignDetails.html",
                controller: "campaignDetailsCtrl"
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/fund-campaign", {
                templateUrl: "scripts/spa/bursify/student/campaigns/fundCampaign.html",
                controller: "fundCampaignCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/test", {
                templateUrl: "scripts/spa/bursify/student/campaigns/test.html",
                controller: "testCtrl",
                // resolve: { isAuthenticated: isAuthenticated }
            })

            .when("/student/addAccount", {
                templateUrl: "scripts/spa/bursify/student/campaigns/addAccount.html",
                controller: "addAccountCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            //Sponsor
                        .when("/student/campaign-details/:campaignId", {
                            templateUrl: "scripts/spa/bursify/student/campaigns/campaignDetails.html",
                            controller: "campaignDetailsCtrl"
                            // resolve: { isAuthenticated: isAuthenticated }
                        })
                            .when("/student/campaigns", {
                                templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                                controller: "campaignsCtrl",
                                resolve: { isAuthenticated: isAuthenticated }
                            })

                        .when("/sponsor/chart", {
                            templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                            controller: "leaderboardCtrl",
                            // resolve: { isAuthenticated: isAuthenticated}
                        })



            /* Campaigns start **/
            .otherwise({
                redirectTo: function () {
                    window.location = "/index.html";
                }
            });
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