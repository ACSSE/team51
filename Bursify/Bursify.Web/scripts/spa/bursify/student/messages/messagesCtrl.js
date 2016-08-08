(function (app) {
    'use strict';

    app.controller('messagesCtrl', messagesCtrl);

    messagesCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    function messagesCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-messages';

        var imagePath = 'img/list/60.jpeg';
        $scope.messages = [
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands..."
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
        ];

    }

})(angular.module('BursifyApp'));

