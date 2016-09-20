angular.module('BursifyApp')




// Main application controller
.controller('formCtrl', ['$scope', '$http', 'notificationService', '$routeParams','apiService',
  function ($scope, $http,  notificationService , $routeParams,apiService) {

      // Set defaults
      $scope.currencySymbol = '$';
      $scope.logoRemoved = false;
      $scope.printMode = false;

      $scope.printInfo = function () {
          window.print();
      };


      $scope.LoadData = function () {
       
          apiService.get('/api/bursifyUser/getuser/?userId=' + $routeParams.StudentId, null, userLoaded, userLoadFailed);
      }

      $scope.User = {};
      function userLoaded(result) {
          $scope.User = result.data;
          loadStudent();
      }

      function userLoadFailed() {
          notificationService.displayError("Unable to load user.");
      }

      function loadStudent() {
          apiService.get('/api/student/getstudent/?studentId=' + $routeParams.StudentId, null, studentLoaded, studentLoadFailed);

      }

      $scope.Student = {};
      function studentLoaded(result) {
          $scope.Student = result.data;
          loadSponsorship();
      }

      function studentLoadFailed() {
          notificationService.displayError("Unable to load student.");
      }

      $scope.Sponsorship = {};
      function loadSponsorship() {
          apiService.get('/api/Sponsorship/GetSponsorship/?sponsorshipId=' + $routeParams.SponsorshipId, null, sponsorshipLoaded, sponsorshipLoadFailed);

      }


      function sponsorshipLoaded(result) {
          $scope.Sponsorship = result.data;
          apiService.get('/api/report/GetAllReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted, reportLoadFailed);


        //  window.print();
          
      }

  
      $scope.myDataSource = {};
      $scope.myDataSource2 = {};

      $scope.myReports = {};

      $scope.recentReports = {};

      function reportLoadCompleted(result) {

          $scope.myReports = result.data;
          apiService.get('/api/report/GetSortedReports/?studentId=' + $routeParams.StudentId, null, reportLoadCompleted2, reportLoadFailed2);
      }

      function reportLoadFailed() {
          notificationService.displayError("Load failed");
      }




      function dataItem(label, value) {
          this.label = label;
          this.value = value;
      }


      function reportLoadCompleted2(result) {

          $scope.recentReports = result.data;
          var label1 = $scope.recentReports
          $scope.myDataSource = {
              chart: {
                  caption: "Most Recent Average's",
                  subCaption: "",
                  numberSuffix: "%",
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
              data: [{
              }]
          };

          for (var i = 0; i < $scope.recentReports.length; i++) {
              $scope.myDataSource.data.push(new dataItem($scope.recentReports[i].ReportYear + "/" + $scope.recentReports[i].ReportPeriod, $scope.recentReports[i].Average))
          }

          $scope.myDataSource2 = {
              "chart": {
                  "caption": "",
                  "subCaption": "Most Recent Report Marks",
                  "yAxisName": "Subjects",
                  "numberSuffix": "%",
                  "paletteColors": "#3F51B5",
                  "bgColor": "#ffffff",
                  "showBorder": "0",
                  "showCanvasBorder": "0",
                  "usePlotGradientColor": "0",
                  "plotBorderAlpha": "5",
                  "placeValuesInside": "1",
                  "valueFontColor": "#ffffff",
                  "showAxisLines": "1",
                  "axisLineAlpha": "25",
                  "divLineAlpha": "10",
                  "alignCaptionWithCanvas": "0",
                  "showAlternateVGridColor": "0",
                  "captionFontSize": "14",
                  "subcaptionFontSize": "14",
                  "subcaptionFontBold": "0",
                  "toolTipColor": "#ffffff",
                  "toolTipBorderThickness": "0",
                  "toolTipBgColor": "#000000",
                  "toolTipBgAlpha": "80",
                  "toolTipBorderRadius": "2",
                  "toolTipPadding": "5"
              },

              "data": []
          };


          for (var i = 0; i < $scope.myReports[0].Subjects.length; i++) {
              $scope.myDataSource2.data.push(new dataItem($scope.myReports[0].Subjects[i].Name, $scope.myReports[0].Subjects[i].MarkAcquired))
          }


          apiService.get('/api/campaign/GetAllCampaigns/?userId=' + $routeParams.StudentId, null, campLoadCompleted, campLoadFailed);
      }



      function reportLoadFailed2() {
          notificationService.displayError("Load Sorted failed");
      }



      function sponsorshipLoadFailed() {
          notificationService.displayError("Unable to load sponsorship.");
      }

  }])
