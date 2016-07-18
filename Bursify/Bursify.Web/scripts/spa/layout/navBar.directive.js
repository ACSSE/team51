(function(app) {
    'use strict';

    app.directive('navBar', navBar);

    function navBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layout/navBar.html'
        }
    }

})(angular.module('common.ui'));