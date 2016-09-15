using System.Web.Optimization;

namespace Bursify.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/j").Include(
                "~/Content/assets/js/jquery-1.11.1.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(

                //  "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/Vendors/respond.src.js",

                "~/Scripts/Vendors/fusionchart.js",
                 "~/Scripts/Vendors/fusioncharts.charts.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-fusionchart.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",

                 "~/Scripts/Vendors/angular-animate.min.js",
                 "~/Scripts/Vendors/angular-aria.js",
                 "~/Scripts/Vendors/angular-messages.min.js",
                 "~/Scripts/Vendors/angular-material.min.js",
                "~/Scripts/Vendors/angular-hamburger-toggle.js",
                 "~/Scripts/Vendors/angular-sanitize.js",

                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",

                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/raphael.js",
                "~/Scripts/Vendors/md-table.min.js",
                "~/Scripts/Vendors/loading-bar.js",


                 "~/ Content/assets/js/main.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(

            #region Services
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/services/fileUploadService.js",
                "~/Scripts/spa/account/loginCtrl.js",
            #endregion

            #region Campaign
                  "~/Scripts/spa/bursify/sponsor/campaigns/campaignsCtrl.js",
                  "~/Scripts/spa/bursify/sponsor/campaigns/viewCampaignCtrl.js",

                  "~/Scripts/spa/bursify/student/campaigns/campaignsCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/campaignDetailsCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/addCampaignCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/editCampaignCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/myCampaignsCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/addAccountCtrl.js",
                  "~/Scripts/spa/bursify/student/campaigns/confirmDeleteCtrl.js",
                  
            #endregion

                "~/Scripts/spa/account/registerCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                "~/Scripts/spa/bursify/student/home/studentCtrl.js",
                 "~/Scripts/spa/bursify/student/profile/studentProfileCtrl.js",
                 "~/Scripts/spa/bursify/student/messages/messagesCtrl.js",
                   "~/Scripts/spa/bursify/sponsor/profile/sponsorProfileCtrl.js",
                    "~/Scripts/spa/bursify/sponsor/registration/registrationCtrl.js",
                     "~/Scripts/spa/bursify/student/registration/registrationStudentCtrl.js",
                    "~/Scripts/spa/bursify/sponsor/sponsorship/sponsorshipIndexCtrl.js",
                    "~/Scripts/spa/bursify/sponsor/sponsorship/addSponsorship/addSponsorshipCtrl.js",
                      "~/Scripts/spa/bursify/sponsor/sponsorship/viewapplicants/applicantsCtrl.js",
                       "~/Scripts/spa/bursify/sponsor/sponsorship/viewapplicants/student/studentApplicationCtrl.js",
                         "~/Scripts/spa/bursify/sponsor/sponsorship/viewapplicants/student/form/formctrl.js",

                "~/Scripts/spa/bursify/admin/home/adminCtrl.js",
                "~/Scripts/spa/bursify/sponsor/home/sponsorCtrl.js",
                "~/Scripts/spa/bursify/sponsor/chart/leaderboardCtrl.js",
                "~/Scripts/spa/bursify/student/sponsorship/sponsorshipCtrl.js",
                 "~/Scripts/spa/bursify/student/applications/myApplicationsCtrl.js",
                    "~/Scripts/spa/bursify/student/reportcard/reportcardCtrl.js",
                    "~/Scripts/spa/bursify/student/reportcard/addReport/addreportCtrl.js",
                     "~/Scripts/spa/bursify/sponsor/student/viewStudentCtrl.js",
                 "~/Scripts/spa/layout/navBar.directive.js",
                   "~/Scripts/spa/layout/spnavBar.directive.js"



                ));




            bundles.Add(new StyleBundle("~/Content/css").Include(


                "~/content/css/bootstrap.css",

                 "~/content/css/font-awesome.css",
                "~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css",
                  "~/Scripts/Vendors/angular-hamburger-toggle.css",
                   "~/Scripts/Vendors/angular-aside.css",
                    "~/Scripts/Vendors/md-table.min.css",

         "~/content/assets/css/style.css",
          "~/content/dist/css/AdminLTE.min.css",
          "~/Scripts/Vendors/angular-material.min.css"


                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}