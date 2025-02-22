﻿(function () {
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
             .when("/fmp", {
                 templateUrl: "scripts/spa/account/fmp.html",
                 controller: "fmpCtrl"
             })
              .when("/reset", {
                  templateUrl: "scripts/spa/account/reset.html",
                  controller: "resetCtrl"
              })
            .when("/student/home", {
                templateUrl: "scripts/spa/bursify/student/home/index.html",
                controller: "studentCtrl",
              resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/home", {
                templateUrl: "scripts/spa/bursify/sponsor/home/index.html",
                controller: "sponsorCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/admin/home", {
                templateUrl: "scripts/spa/bursify/admin/home/index.html",
                controller: "adminCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
             .when("/admin/student", {
                 templateUrl: "scripts/spa/bursify/admin/home/student/index.html",
                 controller: "adminStudentCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
             .when("/admin/sponsor", {
                 templateUrl: "scripts/spa/bursify/admin/home/sponsor/index.html",
                 controller: "adminSponsorCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
             .when("/admin/campaign", {
                 templateUrl: "scripts/spa/bursify/admin/home/campaign/index.html",
                 controller: "adminCampaignCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
             .when("/admin/insight", {
                 templateUrl: "scripts/spa/bursify/admin/home/sponsor/index.html",
                 controller: "adminSponsorCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
            .when("/sponsorship/view", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })

            .when("/student/profile", {
                templateUrl: "scripts/spa/bursify/student/profile/profile.html",
                controller: "studentProfileCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/messages", {
                templateUrl: "scripts/spa/bursify/student/messages/messages.html",
                controller: "messagesCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/report", {
                templateUrl: "scripts/spa/bursify/student/reportcard/reportcard.html",
                controller: "reportcardCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/report/add", {
                templateUrl: "scripts/spa/bursify/student/reportcard/addreport/addreport.html",
                controller: "addReportCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
              .when("/student/report/view/:reportID", {
                  templateUrl: "scripts/spa/bursify/student/reportcard/viewreport/viewreportcard.html",
                  controller: "viewreportcardCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
              })
            .when("/sponsor/profile", {
                templateUrl: "scripts/spa/bursify/sponsor/profile/profile.html",
                controller: "sponsorProfileCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })

              .when("/sponsor/tracker", {
                  templateUrl: "scripts/spa/bursify/sponsor/tracker/tracker.html",
                  controller: "trackCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
              })
             .when("/sponsor/leaderboard", {
                 templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                 controller: "leaderboardCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
            .when("/sponsor/registration", {
                templateUrl: "scripts/spa/bursify/sponsor/registration/registration.html",
                controller: "registrationCtrl",
              resolve: { isAuthenticated: isAuthenticated }
            })
             .when("/student/registration", {
                 templateUrl: "scripts/spa/bursify/student/registration/registration.html",
                 controller: "registrationStudentCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })
            .when("/sponsor/sponsorships", {
                templateUrl: "scripts/spa/bursify/sponsor/sponsorship/sponsorshipIndex.html",
                controller: "sponsorshipIndexCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/sponsorships/add", {
                templateUrl: "scripts/spa/bursify/sponsor/sponsorship/addSponsorship/add.html",
                controller: "addSponsorshipCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })

             .when("/sponsor/sponsorships/view/:sponsorshipId", {
                 templateUrl: "scripts/spa/bursify/sponsor/sponsorship/ViewApplicants/applicants.html",
                 controller: "applicantsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })

              .when("/sponsor/sponsorships/sponsored/:sponsorshipId", {
                  templateUrl: "scripts/spa/bursify/sponsor/sponsorship/sponsored/sponsored.html",
                  controller: "sponsoredCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
              })

             .when("/sponsor/sponsorships/edit/:sponsorshipId", {
                 templateUrl: "scripts/spa/bursify/sponsor/sponsorship/editSponsorship/edit.html",
                 controller: "editSponsorshipCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })

             .when("/sponsor/sponsorships/metric/:sponsorshipId", {
                 templateUrl: "scripts/spa/bursify/sponsor/sponsorship/metrics/metric.html",
                 controller: "metricCtrl",
                resolve: { isAuthenticated: isAuthenticated }
             })

              .when("/sponsor/sponsorships/view/student/:StudentId/:SponsorshipId", {
                  templateUrl: "scripts/spa/bursify/sponsor/sponsorship/ViewApplicants/student/studentapplication.html",
                  controller: "studentApplicationCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
              })

               .when("/sponsor/sponsorship/sponsored/student/:StudentId/:SponsorshipId", {
                   templateUrl: "scripts/spa/bursify/sponsor/sponsorship/sponsored/student/studentSponsored.html",
                   controller: "studentSponsoredCtrl",
                  resolve: { isAuthenticated: isAuthenticated }
               })

              .when("/sponsor/sponsorships/view/student/form/:StudentId/:SponsorshipId", {
                  templateUrl: "scripts/spa/bursify/sponsor/sponsorship/ViewApplicants/student/form/form.html",
                  controller: "formCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
              })
            
            .when("/student/campaigns", {
                templateUrl: "scripts/spa/bursify/student/campaigns/viewCampaigns.html",
                controller: "campaignsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/applications", {
                templateUrl: "scripts/spa/bursify/student/applications/myApplications.html",
                controller: "myApplicationsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/chart", {
                templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                controller: "leaderboardCtrl",
                 // resolve: { isAuthenticated: isAuthenticated}
            })
              .when("/student/chart", {
                  templateUrl: "scripts/spa/bursify/student/chart/leaderboard.html",
                  controller: "leaderboardCtrl",
                  // resolve: { isAuthenticated: isAuthenticated}
              })
            .when("/student/sponsorship/:sponsorshipId", {
                templateUrl: "scripts/spa/bursify/student/sponsorship/index.html",
                controller: "sponsorshipCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/sponsor/viewStudent/:StudentId", {
                templateUrl: "scripts/spa/bursify/sponsor/student/viewStudent.html",
                controller: "viewStudentCtrl",
               resolve: { isAuthenticated: isAuthenticated }
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
                controller: "campaignDetailsCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/fund-campaign", {
                templateUrl: "scripts/spa/bursify/student/campaigns/fundCampaign.html",
                controller: "fundCampaignCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/student/test", {
                templateUrl: "scripts/spa/bursify/student/campaigns/test.html",
                controller: "testCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })

            .when("/student/campaign-progress/:campaignId", {
                templateUrl: "scripts/spa/bursify/student/campaigns/campaignProgress.html",
                controller: "campaignProgressCtrl",
               resolve: { isAuthenticated: isAuthenticated }
            })

            .when("/student/addAccount", {
                templateUrl: "scripts/spa/bursify/student/campaigns/addAccount.html",
                controller: "addAccountCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })


            //Sponsor
                        .when("/sponsor/campaign-details/:campaignId", {
                            templateUrl: "scripts/spa/bursify/sponsor/campaigns/campaignDetails.html",
                            controller: "viewCampaignCtrl",
                           resolve: { isAuthenticated: isAuthenticated }
                        })
                            .when("/sponsor/campaigns", {
                                templateUrl: "scripts/spa/bursify/sponsor/campaigns/viewCampaigns.html",
                                controller: "campaignsCtrl",
                                resolve: { isAuthenticated: isAuthenticated }
                            })

                        .when("/sponsor/chart", {
                            templateUrl: "scripts/spa/bursify/sponsor/chart/leaderboard.html",
                            controller: "leaderboardCtrl",
                             resolve: { isAuthenticated: isAuthenticated}
                        })

                        .when("/sponsor/fund", {
                            templateUrl: "scripts/spa/bursify/sponsor/campaigns/fundCampaign.html",
                            controller: "fundCampaignCtrl",
                           resolve: { isAuthenticated: isAuthenticated }
                        })

            /* Campaigns end**/
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