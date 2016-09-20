(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);


    app.filter('itemFilter', function () {
        return function (items, searchItem) {
            if (!searchItem) {
                return items;
            }

            return items.filter(function (element, index, array) {
                var x = element.ExpensesCovered + " ";
              
                var z = searchItem + "";
                var y = z.split(',');
                var ret = true;
                

                for (var i = 0; i < y.length; i++) {
                    if(x.includes(y[i])){

                    } else {
                        ret = false;
                    }
                }

                if (ret) {
                    return element;
                }
                    
               
            });

        };
    });

    app.filter('fieldFilter', function () {
        return function (items, searchField) {
            if (!searchField || searchField == '*All Fields') {
                return items;
            }

            return items.filter(function (element, index, array) {
               
                var ret = false;
                if (element.StudyFields.includes(searchField)) {
                    ret = true
                }

                if (ret) {
                    return element;
                }


            });

        };
    });

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope'];

    function studentCtrl($scope, apiService, notificationService, $rootScope) {
        $scope.pageClass = 'page-home-student';
        $scope.sortType     = 'name'; // set the default sort type
        $scope.sortReverse  = false; 

        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };
        $scope.sortB = "";

        $scope.fields = [
            '*All Fields',
          'Art',
          'Design',
          'Architecture',
          'Accounting',
          'Economics',
          'Finance',
          'Civil Engineering',
          'Education',
          'Electrical Engineering',
           'Mechanical Engineering',
           'Extraction Metallurgy',
           'Industrial Engineering',
           'Mining Engineering',
           'Mineral Surveying',
           'Town Planning',
           'Engineering',
           'Health Sciences',
           'Biokinetics',
           'Sport Development',
           'Sport Management',
           'Somatology',
           'Social Work',
           'Communication & Language',
           'Geography & Anthropology',
           'Philosophy & Religion',
           'Polotics',
           'Psychology',
           'Public Relations',
           'Law',
           'Human Resource Management',
           'Information Management',
           'Public Management & Governance',
           'Tourism Development',
           'Logistics Management',
           'Marketing Management',
           'Transport Economics',
           'Hospitality Management',
           'Logistics',
           'Management',
           'Business Information Technology',
           'Food & Beverage Operations',
           'Information Technology',
           'Informatics',
           'Zoology',
           'Environmental Management',
           'Geography',
           'Human Physiologo',
           'Biochemistry',
           'Sport Sciences',
           'Computational Science',
           'Mathematical Statistics',
           'Mathematics',
           'Chemistry',
           'Physics',
           'Food Technology',
           'Applied Mathematics',
           'Computer Science'];

        $scope.sortSPA = function () {
            $scope.sortDate = true;
            $scope.sortRating = false;
            $scope.sortAZ = false;
        }

        $scope.sortSPB = function () {
            $scope.sortDate = false;
            $scope.sortRating = true;
            $scope.sortAZ = false;
          
        }

        $scope.sortSPC = function () {
            $scope.sortRating = false;
            $scope.sortDate = false;
            $scope.sortAZ = true;
        }

        $scope.items = ['Registration', 'Examination Fees', 'Tuition Fees', 'Textbooks', 'Accommodation', 'Living Allowance', 'Laptop Allowance', 'Transport'];

        $scope.sorts = [
            { name: 'Closing Date', value: 'ClosingDate' },
            { name: 'A - Z', value: 'Name' },
            { name: 'Rating', value: '-Rating' },
            

        ];


        $scope.items = [
          { name: 'Registration', value: 'Registration' },
          { name: 'Eaxmination Fees', value: 'Examination Fees' },
          { name: 'Tuition Fees', value: 'Tuition Fees' },
          { name: 'Textbooks', value: 'Textbooks' },
          { name: 'Accommodation', value: 'Accommodation' },
          { name: 'Living Allowance', value: 'Living Allowance' },
          { name: 'Laptop Allowance', value: 'Laptop Allowance' },
          { name: 'Transport', value: 'Transport' },
          { name: '*All', value: 'Registration,Examination Fees,Tuition Fees,Textbooks,Accommodation,Living Allowance,Laptop Allowance,Transport' },


        ];



        $scope.loadSponsorships = function () {
            $scope.sortA = '-Rating';
            apiService.get('/api/sponsorship/GetAllSponsorships', null, CompletedSponsorship, FailedSponsorship);
        }
       
        function CompletedSponsorship(result) {
            $scope.Sponsorships = result.data;
            //for (var i = 0; i < $scope.Sponsorships.length; i++) {
            //    var s = $scope.Sponsorships[i].ExpensesCovered;
            //    s = s.split(',');
            //    s.pop();
            //    s.sort();
            //    $scope.Sponsorships[i].ExpensesCovered = s;
            //}
            loadReccommended();
        }

        function loadReccommended() {
            apiService.get('/api/student/getsponsorshipsuggestions/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reccoCompleted, reccoFailed);
        }

        $scope.Recco = {};
        function reccoCompleted(result) {
            $scope.Recco = result.data;
        }




        $scope.getNumber = function (max) {
            return new Array(max);
        }

        function reccoFailed() {
            notificationService.displayInfo('Unable to load reccommended sponsorships.');
        }

        function FailedSponsorship() {
            notificationService.displayInfo('Unable to load sponsorships.');
        }


    }


})(angular.module('BursifyApp')


);

