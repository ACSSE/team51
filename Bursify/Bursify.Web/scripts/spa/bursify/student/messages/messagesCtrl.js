(function (app) {
    'use strict';

    app.controller('messagesCtrl', messagesCtrl);

    messagesCtrl.$inject = ['$scope', 'apiService', 'notificationService'];


    function messagesCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-view-messages';

        $scope.read = function (message) {
           
            notificationService.displaySuccess(message.ID);
        }

        var imagePath = 'img/list/60.jpeg';
        $scope.messages = [
          {
              ID: 0,
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands..."
          },
          {
              ID: 1,
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              ID: 3,
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          },
          {
              ID: 4,
              face: imagePath,
              what: 'Brunch this weekend?',
              who: 'Min Li Chan',
              when: '3:08PM',
              notes: " I'll be in your neighborhood doing errands"
          }
        ];

    }

})(angular.module('BursifyApp'));

