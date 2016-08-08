(function (app) {
    'use strict';

    app.controller('addSponsorshipCtrl', addSponsorshipCtrl);

    addSponsorshipCtrl.$inject = ['$scope','$timeout', 'apiService', 'notificationService', '$mdDialog', '$mdMedia'];

    function addSponsorshipCtrl($scope,$timeout, apiService, notificationService, $mdDialog, $mdMedia) {
        $scope.pageClass = 'page-view-sponsorship';
        $scope.ser = {
            title: 'Developer',
            email: 'ipsum@lorem.com',
            firstName: '',
            lastName: '',
            company: 'Google',
            address: '1600 Amphitheatre Pkwy',
            city: 'Mountain View',
            state: 'CA',
            biography: 'Loves kittens, snowboarding, and can type at 130 WPM.\n\nAnd rumor has it she bouldered up Castle Craig!',
            postalCode: '94043'
        };
        $scope.vegetables = ['Corn', 'Onions', 'Kale', 'Arugula', 'Peas', 'Zucchini'];
        $scope.searchTerm;
        $scope.clearSearchTerm = function () {
            $scope.searchTerm = '';
        };

        $(document).mousemove(function (e) {
            window.x = e.pageX;
            window.y = e.pageY;
        });

        $scope.data = {
            cb1: true
        };

        $scope.fixPosition = function () {
            
            $timeout(function () {
                $('body').removeAttr('style');
                if (document.getElementsByClassName('md-active')) {
                    for (var i = 0; i < document.getElementsByClassName('md-active').length; i++) {
                        var ele = document.getElementsByClassName('md-active')[i];
                        if (ele.localName == 'div') {
                            var position = y - ele.clientHeight;
                            ele.style.top = position + "px";
                        }
                    }
                }
            }, 0);
        };
        // The md-select directive eats keydown events for some quick select
        // logic. Since we have a search input here, we don't need that logic.
      
        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


    }

})(angular.module('BursifyApp'));

