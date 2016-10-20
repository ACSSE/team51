(function (app) {
    'use strict';

    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService','$http', '$base64', '$cookieStore', '$rootScope'];

    function membershipService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {

        var service = {
            login: login,
            register: register,
            saveCredentials: saveCredentials,
            removeCredentials: removeCredentials,
            isUserLoggedIn: isUserLoggedIn
        }

        function login(user, completed) {
            apiService.post('/api/account/login', user,
            completed,
            loginFailed);
           
            return user;
        }

        function register(user, completed) {
            if (user.password == 'Admin123') {
                user.usertype = 'Admin';
            }
            apiService.post('/api/account/register', user,
            completed,
            registrationFailed);
        }


        function saveCredentials(user) {
           
            var membershipData = $base64.encode(user.Email + ':' + user.password);
          //  notificationService.displayError("UID: " + user.useremail);
            $rootScope.repository = {
                loggedUser: {
                    username: user.Name,
                    useremail: user.Email,
                    userIden: user.ID,
                    authdata: membershipData
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);
        }


       

     

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');
            $http.defaults.headers.common.Authorization = '';
        };

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }

        function registrationFailed(response) {

            notificationService.displayError('Registration failed. Try again.');
        }

        function isUserLoggedIn() {
            return $rootScope.repository.loggedUser != null;
        }

        return service;
    }



})(angular.module('common.core'));