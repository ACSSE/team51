(function (app) {
    'use strict';

    app.controller('sponsorCtrl', sponsorCtrl);

    app.filter('myFilter', function () {
        return function (items, FilterType) {
           
            return items;
        };
    });

    sponsorCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$timeout'];

    function sponsorCtrl($scope, apiService, notificationService, $timeout) {
        $scope.pageClass = 'page-home-sponsor';
        
        apiService.get('/api/student/GetAllStudents/', null, CompletedStudent, FailedStudent);

        function CompletedStudent(result) {
            $scope.Students = result.data;
        }

        function FailedStudent() {
            notificationService.displayInfo('Unable to load students.');
        }
        $scope.fields = null;
        $scope.loadFields = function () {
           
            return $timeout(function () {
                $scope.fields = $scope.fields || [
                  { id: 1, name: 'Art' },
                  { id: 2, name: 'Design' },
                  { id: 3, name: 'Architecture' },
                  { id: 4, name: 'Accounting' },
                  { id: 5, name: 'Economics' },
                 { id: 6, name: 'Finance' },
                 { id: 7, name: 'Civil Engineering' },
                 { id: 8, name: 'Education' },
                 { id: 9, name: 'Electrical Engineering' },
                 { id: 10, name: 'Mechanical Engineering' },
                 { id: 11, name: 'Extraction Metallurgy' },
                 { id: 12, name: 'Industrial Engineering' },
                 { id: 13, name: 'Mining Engineering' },
                 { id: 14, name: 'Mineral Surveying' },
                 { id: 15, name: 'Town Planning' },
                  { id: 16, name: 'Engineering' },
                 { id: 17, name: 'Health Sciences' },
                 { id: 18, name: 'Biokinetics' },
                 { id: 19, name: 'Sport Development' },
                 { id: 20, name: 'Sport Management' },
                  { id: 21, name: 'Somatology' },
                  { id: 22, name: 'Social Work' },
                { id: 23, name: 'Communication & Language' },
                { id: 24, name: 'Geography & Anthropology' },
                { id: 25, name: 'Philosophy & Religion' },
                { id: 26, name: 'Polotics' },
                 { id: 27, name: 'Psychology' },
                  { id: 28, name: 'Public Relations' },
                 { id: 29, name: 'Law' },
                 { id: 30, name: 'Human Resource Management' },
                 { id: 31, name: 'Information Management' },
                 { id: 32, name: 'Public Management & Governance' },
                 { id: 33, name: 'Tourism Development' },
                 { id: 34, name: 'Logistics Management' },
                 { id: 35, name: 'Marketing Management' },
                 { id: 36, name: 'Transport Economics' },
                 { id: 37, name: 'Hospitality Management' },
                 { id: 38, name: 'Logistics' },
                 { id: 39, name: 'Management' },
                 { id: 40, name: 'Business Information Technology' },
                 { id: 41, name: 'Food & Beverage Operations' },
                 { id: 42, name: 'Information Technology' },
                 { id: 43, name: 'Informatics' },
                 { id: 44, name: 'Zoology' },
                 { id: 45, name: 'Environmental Management' },
                 { id: 46, name: 'Geography' },
                 { id: 47, name: 'Human Physiologo' },
                 { id: 48, name: 'Biochemistry' },
                 { id: 49, name: 'Sport Sciences' },
                 { id: 50, name: 'Computational Science' },
                 { id: 51, name: 'Mathematical Statistics' },
                 { id: 52, name: 'Mathematics' },
                 { id: 53, name: 'Chemistry' },
                 { id: 54, name: 'Physics' },
                 { id: 55, name: 'Food Technology' },
                 { id: 56, name: 'Applied Mathematics' },
                 { id: 57, name: 'Computer Science' },
                ];
            }, 5);
        };


    }

 

})(angular.module('BursifyApp'));