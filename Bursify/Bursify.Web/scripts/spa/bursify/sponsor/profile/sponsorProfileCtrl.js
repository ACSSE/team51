(function (app) {
    'use strict';

    app.controller('sponsorProfileCtrl', sponsorProfileCtrl);

    sponsorProfileCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    app.directive("addbuttonsbutton", function () {
        return {
            restrict: "E",
            template: "<div class=\"row\"><div class=\"col-md-9\"></div><div class=\"col-md-3\"><label style=\"padding-left: 20px;\" addbuttons>Add More Subjects</label><span addbuttons class=\"fa fa-plus-circle fa-2x\" style=\"padding-left:5px;\"></span></div></div>"
           
        }
    });

    app.directive("addbuttons", function ($compile) {
        return function (scope, element, attrs) {
            element.bind("click", function () {
                scope.count++;
                angular.element(document.getElementById('space-for-buttons')).append($compile("<div class=\"row\" id=\"markInput\"><div class=\"col-md-9\"><div class=\"form-group\"><select class=\"form-control\" style=\"width: 100%;\" tabindex=\"-1\" aria-hidden=\"true\" ng-model=\"markselect.subject\" ng-options=\"s.subject for s in markselect.level.subjects\"><option value=\"\" style=\"text-align: center;\">-- Subject --</option></select></div></div><div class=\"col-md-3\"><div class=\"form-group\"><input type=\"number\" class=\"form-control\" id=\"exampleInputEmail1\" placeholder=\"%\"></div></div></div>")(scope));
            });
        };
    });

    //Directive for showing an alert on click
    app.directive("alert", function () {
        return function (scope, element, attrs) {
            element.bind("click", function () {
                console.log(attrs);
                alert("This is alert #" + attrs.alert);
            });
        };
    });

    function sponsorProfileCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};

    }

})(angular.module('BursifyApp'));

