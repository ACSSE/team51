(function (app) {
    'use strict';

    app.controller('registrationStudentCtrl', registrationStudentCtrl);

    registrationStudentCtrl.$inject = ['$scope', '$rootScope', '$timeout', 'apiService', '$location', 'notificationService', '$compile', 'fileUploadService', 'membershipService', '$interval'];

    function registrationStudentCtrl($scope, $rootScope, $timeout, apiService, $location, notificationService, $compile, fileUploadService, membershipService, $interval) {
        $scope.pageClass = 'page-registration-student';


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };

        $scope.selectedIndex = 0;
        $scope.secondLocked = false;


        $scope.nextTab = function () {

            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;
        };

        $scope.myDate = new Date();
        $scope.minDate = new Date(
            $scope.myDate.getFullYear()-40,
            $scope.myDate.getMonth(),
            $scope.myDate.getDate());
        $scope.maxDate = new Date(
            $scope.myDate.getFullYear()-15,
            $scope.myDate.getMonth(),
            $scope.myDate.getDate());

        $scope.prepareID = prepareID;

        $scope.Student = {
            "ID": "",
            "FirstName": "Mike",
            "Surname": "Ross",
            "PhoneNumber": "084 913 4302",
            "IdNumber": "9009165873089",
            "StudentNumber": "2157865",
            "DateOfBirth": "",
            "Age": "",
            "Race": "",
            "Gender": "",
            "HasDisability": "",
            "DisabilityDescription": "",
            "ResProvince": "Gauteng",
            "ResCity": "Johannesburg",
            "ResStreetAddress": "7 Jeff Street",
            "ResPostCode": "1718",
            "PostProvince": "",
            "PostPOBox": "",
            "PostCity": "",
            "PostStreetAddress": "",
            "PostPostalCode": "",
            "GuardianRelationship": "Mother",
            "GuardianPhone": "085 789 1456",
            "GuardianEmail": "mother@nicemother.com",
            "CurrentOccupation": "",
            "StudyFields": "",
            "MarksYear": "",
            "InstituitionName": "",
            "InstituitionWebsite": "",
            "StudentLevel": "",
            "Marks": [{ "SubjectName": "", "SubjectMark": "" , "StudentId": "", "Period": ""}],
            "Essay": "",
            "IDDocumentPath": "",
            "MarticCertificatePath": "",
            "CVPath": "",
            "AgreeTandCs": true
        };
        $scope.count = 0;
        
   
        $scope.appendText = function () {
          
            $scope.count = $scope.count + 1;

            if ($scope.Student.InstituitionType.level == 'University' || $scope.Student.InstituitionType.level == 'Private University/College') {
                angular.element(document.getElementById('MarksInputAdd')).append($compile("<div class=\'box-body\' id=\'markInput" + $scope.count + "\'><div class=\'col-md-9\'><div class=\'form-group\'> <input type='text' ng-model='Student.Marks[" + $scope.count  + "].SubjectName' class='form-control' id='exampleInputEmail1' placeholder='Module Name'></div></div><div class=\'col-md-3\'><div class=\'form-group\'><input type=\'number\' ng-model=\'Student.Marks[" + $scope.count + "].SubjectMark\' class=\'form-control\' id=\'exampleInputEmail1\' placeholder=\'%\'></div></div></div>")($scope));
            } else {  
                angular.element(document.getElementById('MarksInputAdd')).append($compile("<div class=\'box-body\' id=\'markInput" + $scope.count + "\'><div class=\'col-md-9\'><div class=\'form-group\'><select class=\'form-control\' style=\'width: 100%;\' tabindex=\'-1\' aria-hidden=\'true\' ng-model=\"Student.Marks[" + $scope.count + "]\" ng-options=\'s.subject for s in Student.InstituitionType.subjects\'><option value=\'\' ng-model=\'Student.Marks[" + $scope.count + "].SubjectMark\' style=\'text-align: center;\'>-- Subject --</option></select></div></div><div class=\'col-md-3\'><div class=\'form-group\'><input type=\'number\' ng-model=\'Student.Marks[" + $scope.count + "].SubjectMark\' class=\'form-control\' id=\'exampleInputEmail1\' placeholder=\'%\'></div></div></div>")($scope));
            }
           
        }

        $scope.typeChange = false;

        $scope.removeMarks = function () {
            if ($scope.typeChange == false){
                $scope.typeChange = true;
            } else {
               
                for (var i = 0; i <= $scope.count; i++) {
                 
                    angular.element(document.getElementById('markInput' + i)).remove();
                }
              
            }

        }

        $scope.uploading = false;

        document.getElementById("uploadIDBtn").onchange = function () {
            document.getElementById("uploadIDFile").value = this.value;
            $scope.Student.IDDocumentPath = this.value;
            UploadID();
        };

        document.getElementById("uploadMCBtn").onchange = function () {
            document.getElementById("uploadMCFile").value = this.value;
            $scope.Student.MatricCertificatePath = this.value;
        };

        document.getElementById("uploadCVBtn").onchange = function () {
            document.getElementById("uploadCVFile").value = this.value;
            $scope.Student.CVPath = this.value;

        };

        var IDFile = null;
        function UploadID() {
            $scope.uploading = true;
            fileUploadService.uploadFile(IDFile, $rootScope.repository.loggedUser.userIden, IDUploadDone);
        }  

        function IDUploadDone() {
            //notificationService.displayInfo("I.D document has been uploaded.");
            $scope.uploading = false;
        }

        function prepareID($files) {
            IDFile = $files;
            UploadID();
            
        }

        $scope.provin = null;
        $scope.Industry = null;

        $scope.fields = null;
        $scope.loadFields = function () {

            return $timeout(function () {
                $scope.fields = $scope.fields || [
                  { id: 1, name: 'Accounting' },
                  { id: 2, name: 'Aviation' },
                  { id: 3, name: 'Animation' },
                  { id: 4, name: 'Arts & Crafts' },
                  { id: 5, name: 'Automotive' },
                  { id: 6, name: 'Aerospace' },
                  { id: 7, name: 'Banking' }
                ];
            }, 10);
        };


        $scope.data = [
          {
              "id": "0",
              "level": "High School",
              "grades": [
                  { "grade": "Grade 10" },
                  { "grade": "Grade 11" },
                  { "grade": "Grade 12" }
              ],
              "places": [
{ "place": "AB PHOKOMPE SECONDARY SCHOOL" },
{ "place": "ABBOTTS COLLEGE-CENTURION" },
{ "place": "ABBOTTS COLLEGE-JOHANNESBURG SOUTH" },
{ "place": "ABBOTTS COLLEGE-NORTHCLIFF" },
  { "place": "ABBOTTS COLLEGE-PRETORIA EAST" },
  { "place": "ABDULLAH BIN SALAAM ISLAMIC CENTRE" },
  { "place": "ABEL MOTSHOANE SECONDARY SCHOOL" },
  { "place": "ABUNDANT LIFE CHRISTIAN ACADEMY" },
  { "place": "ACADEMIC QUALITY EDUCATION COLLEGE" },
  { "place": "ACADEMY BUSINESS SCHOOL" },
  { "place": "ACADEMY CHARITY TRUST-JHB" },
  { "place": "ADAM MASEBE SECONDARY SCHOOL" },
  { "place": "AFRICA HOUSE COLLEGE" },
  { "place": "AFRICA INTERNATIONAL PRIVATE SCHOOL" },
  { "place": "AFRICAN LEARDERSHIP ACADEMY" },
  { "place": "AFRICAN SCHOOL FOR EXCELLENCE" },
  { "place": "AFRIKAANSE HOËR MEISIESKOOL" },
  { "place": "AFRIKAANSE HOËR SEUNSKOOL" },
  { "place": "AFRIKAANSE HOËRSKOOL GERMISTON" },
  { "place": "AFRO-KOMBS COLLEGE" },
  { "place": "AHA-THUTO SECONDARY SCHOOL" },
  { "place": "AHMED TIMOL SECONDARY SCHOOL" },
  { "place": "AL GHAZALI INDEPENDENT SCHOOL" },
  { "place": "ALAFANG SECONDARY SCHOOL" },
  { "place": "AL-AQSA EXTENSION 10 SCHOOL" },
  { "place": "AL-ASR EDUCATIONAL INSTITUTE SECONDARY SCHOOL" },
  { "place": "AL-AZHAR INSTITUTE, JOHANNESBURG" },
  { "place": "ALBERTON CHRISTIAN ACADEMY" },
  { "place": "ALBERTON HIGH SCHOOL" },
  { "place": "ALEXANDRA SECONDARY SCHOOL" },
  { "place": "ALHUDA ACADEMY" },
  { "place": "ALLANRIDGE SECONDARY SCHOOL" },
  { "place": "ALLEN GLEN HIGH SCHOOL" },
  { "place": "ALMA MATER AKADEMIE" },
  { "place": "ALPHA AND OMEGA CHRISTIAN ACADEMY" },
  { "place": "ALPHA TUTORIAL COLLEGE" },
  { "place": "ALRAPARK SECONDARY SCHOOL" },
  { "place": "ALTMONT TECHNICAL HIGH SCHOOL" },
  { "place": "AMANDASIG SECONDARY  SCHOOL" },
  { "place": "AMAZING GRACE PRIVATE SCHOOL" },
  { "place": "AMITY INTERNATIONAL" },
  { "place": "AMOGELANG SECONDARY SCHOOL" },
  { "place": "AMOS MAPHANGA SECONDARY" },
  { "place": "ANCHOR CHRISTIAN ACADEMY" },
  { "place": "ANCHOR COMPREHENSIVE" },
  { "place": "ANCHORAGE SECONDARY SCHOOL" },
  { "place": "ANDREWS ACADEMY" },
  { "place": "ARMOUR FOUNDATION LEARNING INSTITUTE" },
  { "place": "ARROWS OF DESTINY CHRISTIAN ACADEMY" },
  { "place": "ARVANITES COLLEGE OF EDUCATION" },
  { "place": "ASHBURY PREPARATORY SCHOOL" },
  { "place": "ASHTON INTERNATIONAL COLLEGE" },
  { "place": "ASSEMBLIES OF GOD COLLEGE" },
  { "place": "ASSER MALOKA SECONDARY SCHOOL" },
  { "place": "ASSUMPTION CONVENT" },
  { "place": "ATHLONE BOYS' HIGH SCHOOL" },
  { "place": "ATHLONE GIRLS' HIGH SCHOOL" },
      { "place": "ATLAS COMBINED SCHOOL" },
  { "place": "ATM SCHOOLS" },
  { "place": "AUCKLAND PARK ACADEMY OF EXCELLENCE" },
  { "place": "AURORA GIRLS HIGH SCHOOL" },
  { "place": "AURUM INTERNATIONAL COLLEGE" },
  { "place": "AZAADVILLE MUSLIM SCHOOL" },
  { "place": "AZARA SECONDARY SCHOOL" },
  { "place": "B.B. MYATAZA SECONDARY SCHOOL" },
  { "place": "BADIRILE SECONDARY SCHOOL" },
  { "place": "BALMORAL COLLEGE" },
  { "place": "BARACHEL CHRISTIAN ACADEMY" },
  { "place": "BARNATO PARK HIGH SCHOOL" },
  { "place": "BASA TUTORIAL INSTITUTE" },
  { "place": "BEAULIEU COLLEGE" },
  { "place": "BEDFORDVIEW HIGH SCHOOL" },
  { "place": "BEMSSEL COLLEGE" },
  { "place": "BENONI CHRISTIAN SCHOOL" },
  { "place": "BENONI EDUCATIONAL COLLEGE" },
  { "place": "BENONI HIGH SCHOOL" },
  { "place": "BENONI MUSLIM SCHOOL" },
  { "place": "BEREA PARK INDEPENDENT HIGH SCHOOL" },
  { "place": "BESEK COLLEGE" },
  { "place": "BETHARRY ENGLISH PRIVATE SCHOOL" },
  { "place": "BET'OR CHRISTIAN SCHOOL" },
  { "place": "BEVERLY HILLS SECONDARY SCHOOL" },
  { "place": "BEYHAN COLLEGE" },
  { "place": "BHUKULANI SECONDARY SCHOOL" },
  { "place": "BISHOP BAVIN SCHOOL-ST GEORGE'S" },
  { "place": "BLUE EAGLE HIGH SCHOOL" },
  { "place": "BLUE HILLS COLLEGE" },
  { "place": "BOITSHEPO SECONDARY SCHOOL" },
  { "place": "BOITUMELO SECONDARY SCHOOL" },
  { "place": "BOITUMELONG SECONDARY SCHOOL" },
  { "place": "BOKAMOSO HIGH SCHOOL" },
  { "place": "BOKGONI TECHNICAL SECONDARY SCHOOL" },
  { "place": "BOKOMOSO SECONDARY SCHOOL" },
  { "place": "BOKSBURG CHRISTIAN ACADEMY" },
  { "place": "BOKSBURG HIGH SCHOOL" },
  { "place": "BONA COMPREHENSIVE SCHOOL" },
  { "place": "BONA LESEDI SECONDARY SCHOOL" },
  { "place": "BOPASENATLA SECONDARY SCHOOL" },
  { "place": "BOPHELO-IMPILO PRIVATE" },
  { "place": "BOPHELONG COMMUNITY INDEPENDENT SCHOOL" },
  { "place": "BOPHELONG SECONDARY SCHOOL" },
  { "place": "BOSASA MOGALE LESEDING YOUTH DEVELOPMENT CENTRE" },
  { "place": "BOSMONT MUSLIM SCHOOL" },
  { "place": "BOSTON NSC OPEN DISTANCE EDUCATION" },
  { "place": "BOTEBO-TSEBO SECONDARY SCHOOL" },
  { "place": "BOTSE-BOTSE SECONDARY SCHOOL" },
  { "place": "BRACKEN HIGH SCHOOL" },
  { "place": "BRAINTRUST COLLEGE" },
  { "place": "BRAKPAN HIGH SCHOOL" },
  { "place": "BRAKPAN OPVOEDKUNDIGE SENTRUM" },
  { "place": "BRANDCLIFF HOUSE" },
  { "place": "BRESCIA HOUSE URSULINE CONVENT" },
  { "place": "BREYTENBACH EDUCENTRE/ONDERRIGSENTRUM" },
  { "place": "BRIDGEWAY CHRISTIAN SCHOOL" },
  { "place": "BRIGHT SPARK LEARNING ACADEMY" },
  { "place": "BRITISH INTERNATIONAL COLLEGE INDEPENDENT SCHOOL" },
  { "place": "BRITISH INTERNATIONAL COLLEGE-PRETORIA" },
  { "place": "BRONBERG AKADEMIE" },
  { "place": "BRYANSTON HIGH SCHOOL" },
  { "place": "BUHLEBEMFUNDO SECONDARY SCHOOL" },
  { "place": "BUHLEBUZILE SECONDARY SCHOOL" },
  { "place": "CAIPHUS NYOKA SECONDARY SCHOOL" },
  { "place": "CALVARY CHRISTIAN COLLEGE" },
  { "place": "CARLETON JONES HIGH SCHOOL" },
  { "place": "CARPE DIEM ACADEMY" },
  { "place": "CENTAURI LEARNING CENTRE" },
  { "place": "CENTRAL COLLEGE" },
  { "place": "CENTRAL ISLAMIC SCHOOL" },
  { "place": "CENTRAL SECONDARY SCHOOL" },
  { "place": "CENTURION CHRISTIAN SCHOOL" },
  { "place": "CENTURION COLLEGE" },
  { "place": "CHARIS CHRISTIAN SCHOOL" },
  { "place": "CHARLTON VOS COLLEGE OF EDUCATION" },
  { "place": "CHARTER INDEPENDENT COLLEGE" },
  { "place": "CHARTWELL COUNTRY COLLEGE" },
  { "place": "CHIPA-TABANE SECONDARY SCHOOL" },
  { "place": "CHRIS J BOTHA SECONDARY SCHOOL" },
  { "place": "CHRIST CHURCH SCHOOL" },
  { "place": "CHRISTIAN BROTHERS' COLLEGE" },
  { "place": "CHRISTIAN BROTHERS' COLLEGE MOUNT EDMUND" },
      { "place": "CHRISTIAN PROGRESSIVE SCHOOL" },
  { "place": "CHRYSTAL SPRINGS PRIVATE SCHOOL" },
  { "place": "CHURCHIL HIGH SCHOOL" },
  { "place": "CLAPHAM HIGH SCHOOL" },
  { "place": "CONVENT OF THE HOLY FAMILY" },
  { "place": "CORNERSTONE COLLEGE SEC. SCHOOL" },
  { "place": "CORNWALL HILL COLLEGE" },
  { "place": "CORONATIONVILLE SECONDARY SCHOOL" },
  { "place": "COSMO CITY SECONDARY SCHOOL" },
  { "place": "COURTNEY HOUSE" },
  { "place": "COVENANT COLLEGE" },
  { "place": "CRAIGHALL COLLEGE" },
  { "place": "CRAWFORD COLLEGE - SANDTON" },
  { "place": "CRAWFORD PREPARATORY ITALIA" },
  { "place": "CRAWFORD PREPARATORY LONEHILL" },
  { "place": "CRAWFORD PREPARATORY PRETORIA" },
  { "place": "CRESTA COLLEGE" },
  { "place": "CROWN CHRISTIAN SCHOOL" },
  { "place": "CRYSTAL PARK HIGH" },
  { "place": "CULTURA HIGH SCHOOL" },
  { "place": "CURRO AURORA" },
  { "place": "CURRO HAZELDEAN HIGH SCHOOL" },
  { "place": "CURRO HELDERWYK" },
  { "place": "CURRO PRIVATE SCHOOL-KRUGERSDORP" },
  { "place": "CURRO SERENGETI ACADEMY" },
  { "place": "CURRO THATCHFIELD" },
  { "place": "CVO SKOOL PRETORIA" },
  { "place": "D.A. MOKOMA SECONDARY SCHOOL" },
  { "place": "DAINFERN COLLEGE" },
  { "place": "DALEVIEW SECONDARY SCHOOL" },
  { "place": "DALIWONGA SECONDARY SCHOOL" },
  { "place": "DALPARK LEARNING ACADEMY" },
  { "place": "DALPARK SECONDARY SCHOOL" },
  { "place": "DAMELIN COLLEGE HIGH SCHOOL - RANDBURG" },
  { "place": "DAN KUTUMELA SECONDARY SCHOOL" },
  { "place": "DANSA INTERNATIONAL COLLEGE" },
  { "place": "DASPOORT SECONDARY SCHOOL" },
  { "place": "DAVEY SECONDARY SCHOOL" },
  { "place": "DAVID HELLEN PETA SECONDARY SCHOOL" },
  { "place": "DAVID MAKHUBO SECONDARY SCHOOL" },
  { "place": "DAWNVIEW HIGH SCHOOL" },
  { "place": "DE LA SALLE HOLY CROSS COLLEGE" },
  { "place": "DELCOM TRAINING INSTITUTION" },
  { "place": "DENVER SECONDARY SCHOOL" },
  { "place": "DESTINY HIGH SCHOOL" },
  { "place": "DEUTSCHE SCHULE JOHANNESBURG" },
  { "place": "DEUTSCHE SCHULE PRETORIA" },
  { "place": "DIE HEUWEL CHRISTIAN SKOOL" },
  { "place": "DIEPDALE SECONDARY SCHOOL" },
  { "place": "DIEPSLOOT COMBINED SCHOOL" },
  { "place": "DIEPSLOOT SECONDARY SCHOOL" },
  { "place": "DIEPSLOOT SECONDARY SCHOOL" },
  { "place": "DIEPSLOOT SECONDARY SCHOOL NO. 2" },
  { "place": "DIEPSLOOT WEST SECONDARY SCHOOL" },
  { "place": "DILOPYE PRIMARY SCHOOL" },
  { "place": "DINOKANENG SECONDARY SCHOOL" },
  { "place": "DINOTO TECHNICAL SECONDARY SCHOOL" },
  { "place": "DINWIDDIE HIGH SCHOOL" },
  { "place": "DIVERSITY HIGH SCHOOL" },
  { "place": "DOMINICAN CONVENT SCHOOL (BELGRAVIA)" },
  { "place": "DOXA DEO CHRISTIAN SCHOOL" },
  { "place": "DR BW VILAKAZI SECONDARY SCHOOL" },
  { "place": "DR HARRY GWALA SECONDARY SCHOOL" },
  { "place": "DR WF NKOMO SECONDARY SCHOOL" },
  { "place": "DR. A.T. MOREOSELE SECONDARY SCHOOL" },
  { "place": "DR. MOTSUENYANE SECONDARY SCHOOL" },
  { "place": "DSDC HIGH SCHOOL" },
  { "place": "DUNCTONWOOD PROGRESSIVE SCHOOL" },
  { "place": "DUO EDU SENIORONAFHANKLIKE SKOOL" },
  { "place": "DUZEK CHRISTIAN SCHOOL" },
  { "place": "EAST BANK HIGH SCHOOL" },
  { "place": "EAST RAND CHRISTIAN SCHOOL" },
  { "place": "EBENEZER MARANATHA INSTITUTE" },
  { "place": "EDEN COLLEGE" },
  { "place": "EDENDALE PEPPS SCHOOL" },
  { "place": "EDENGLEN HIGH SCHOOL" },
  { "place": "EDENICA PRIVATE SCHOOL" },
  { "place": "EDENPARK SECONDARY SCHOOL" },
  { "place": "EDEN-RIDGE HIGH SCHOOL" },
  { "place": "EDENVALE HIGH SCHOOL" },
  { "place": "EDUCATION ALIVE SCHOOL" },
  { "place": "EDUCATION INCORPORATED FOURWAYS" },
  { "place": "EDUCATIONAL PROGRAMMES CENTRE" },
  { "place": "ED-U-COLLEGE SECONDARY SCHOOL" },
  { "place": "EDUMORE CHRISTRIAN ACADEMY" },
  { "place": "EDUSON LEARNING CENTRE" },
  { "place": "EDWARD PHATUDI SECONDARY SCHOOL" },
  { "place": "EERSTERUST SECONDARY SCHOOL" },
  { "place": "EKANGALA SECONDARY SCHOOL" },
  { "place": "EKETSANG SECONDARY SCHOOL" },
  { "place": "EKUKHANYISELWENI CHRISTIAN SCHOOL" },
  { "place": "EL SHADDAI SCHOOL" },
  { "place": "EL TABERNACLE CHRISTIAN COLLEGE" },
  { "place": "EL ZERA PRIVATE SCHOOL" },
  { "place": "ELDOMAINE SECONDARY SCHOOL" },
  { "place": "ELDORADO PARK SECONDARY SCHOOL" },
  { "place": "ELETHU THEMBA PUBLIC SCHOOL" },
  { "place": "ELITE COLLEGE" },
  { "place": "ELIZABETH MATSEMELA SECONDARY SCHOOL" },
  { "place": "ELMAR INDEPENDENT SCHOOL" },
  { "place": "EMADWALENI SECONDARY SCHOOL" },
  { "place": "EMDENI SECONDARY SCHOOL" },
  { "place": "EMMANUEL PRIVATE SCHOOL" },
  { "place": "EMPIRICAL TRAINING ACADEMY" },
  { "place": "EMPRO ACADEMY" },
  { "place": "EMSHUKANTAMBO SECONDARY SCHOOL" },
  { "place": "ENNERDALE SECONDARY SCHOOL" },
  { "place": "ENTHEOS CHRISTIAN SCHOOL" },
  { "place": "EPHES MAMKELI SECONDARY SCHOOL" },
  { "place": "EQINISWENI SECONDARY SCHOOL" },
  { "place": "ERASMUS MONARENG SECONDARY SCHOOL" },
  { "place": "ESIBONELWESIHLE SECONDARY SCHOOL" },
  { "place": "ESOKWAZI SECONDARY SCHOOL" },
  { "place": "ESSELEN PARK SPORT SCHOOL OF EXCELLENCE" },
  { "place": "ETWATWA SECONDARY SCHOOL" },
  { "place": "EUREKA HIGH SCHOOL" },
  { "place": "EVEREST SCHOOL-NEWTOWN" },
  { "place": "EXCELSIOR ROOIHUISKRAAL AKADEMIE" },
  { "place": "FALCON EDUCATIONAL SCHOOL" },
  { "place": "FAR NORTH SECONDARY SCHOOL" },
  { "place": "FERNDALE HIGH SCHOOL" },
  { "place": "FESTICOL HIGH SCHOOL" },
  { "place": "FIDELITAS COMPREHENSIVE S." },
  { "place": "FINE TOWN SECONDARY SCHOOL" },
  { "place": "FLAVIUS MAREKA SECONDARY SCHOOL" },
  { "place": "FLORIDA PARK HIGH SCHOOL" },
  { "place": "FOCHVILLE  SECONDARY SCHOOL" },
  { "place": "FOCHVILLE SECONDARY SCHOOL NO 2" },
  { "place": "FONS LUMINIS SECONDARY SCHOOL" },
  { "place": "FONTANUS COMPREHENSIVE SECONDARY SCHOOL" },
  { "place": "FOREST HIGH SCHOOL" },
  { "place": "FORTE SECONDARY SCHOOL" },
  { "place": "FOUNDERS COMMUNITY SCHOOL" },
  { "place": "FOURWAYS HIGH SCHOOL" },
  { "place": "FR. SMANGALISO MKHATSHWA SECONDARY SCHOOL" },
  { "place": "FRANCISCAN MATRIC PROJECT" },
  { "place": "FRED NORMAN SECONDARY SCHOOL" },
  { "place": "FREEDOM COMMUNITY COLLEGE" },
  { "place": "FREEDOM PARK SECONDARY SCHOOL NO 1" },
  { "place": "FUMANA SECONDARY SCHOOL" },
  { "place": "FUNDA COMMUNITY TRAINING CENTRE" },
  { "place": "FUNDULWAZI SECONDARY SCHOOL" },
  { "place": "FUSION SECONDARY SCHOOL" },
  { "place": "GALEBOE MIDDLE SCHOOL" },
  { "place": "GALLAGHER COMBINED SCHOOL" },
  { "place": "GATANG SECONDARY SCHOOL" },
  { "place": "GAUTENG CAMPUS" },
  { "place": "GEKOMBINEERDE SKOOL CULLINAN" },
  { "place": "GEKOMBINEERDE SKOOL NOORDERLIG" },
  { "place": "GELUKSDAL SECONDARY SCHOOL" },
  { "place": "GENERAL SMUTS HIGH SCHOOL" },
  { "place": "GEORGE KHOSA SECONDARY SCHOOL" },
  { "place": "GEREFORMEERDE GEKOMBINEERDE SKOOL DIRK POSTMA" },
  { "place": "GERMISTON HIGH SCHOOL" },
  { "place": "GIBSON PILLAY LEARNING ACADEMY" },
  { "place": "GLEN AUSTIN HIGH SCHOOL" },
  { "place": "GLENBRACK HIGH SCHOOL" },
  { "place": "GLENVISTA HIGH SCHOOL" },
  { "place": "GLOBAL COMBINED COLLEGE" },
  { "place": "GRACE CHRISTIAN SCHOOL" },
  { "place": "GRACELAND EDUCATION CENTRE" },
  { "place": "GRANTLEY COLLEGE" },
  { "place": "GREENACRES PRIVATE COLLEGE" },
  { "place": "GREENFIELDS SECONDARY SCHOOL" },
  { "place": "GREENLANE COLLEGE" },
  { "place": "GREENSIDE HIGH SCHOOL" },
  { "place": "GREENWHICH COLLEGE" },
  { "place": "GREENWOOD COLLEGE" },
  { "place": "HAMBANI COLLEGE" },
  { "place": "HAMBANI COLLEGE" },
  { "place": "HAMMANSKRAAL SECONDARY SCHOOL" },
  { "place": "HANS KEKANA SECONDARY SCHOOL" },
  { "place": "HATFIED TUITION AND SKILLS DEVELOPMENT CENTRE" },
  { "place": "HATFIELD CHRISTIAN SCHOOL" },
  { "place": "HAYWOOD COLLEGE" },
  { "place": "HB NYATHI SECONDARY SCHOOL" },
  { "place": "HEARTWOOD INDEPENDENT SCHOOL" },
  { "place": "HELPMEKAAR PRIVAATSKOOL" },
  { "place": "HENLEY HIGH AND PREPARATORY SCHOOL" },
  { "place": "HENPRO SOLUTIONS COLLEGE" },
  { "place": "HERITAGE CHRISTIAN COLLEGE" },
  { "place": "HERON BRIDGE COLLEGE" },
  { "place": "HIGHLANDS NORTH BOYS HIGH SCHOOL" },
  { "place": "HILLVIEW HIGH SCHOOL" },
  { "place": "HIMALAYA SECONDARY SCHOOL" },
  { "place": "HIRCH LYONS SCHOOL" },
  { "place": "HL SETLALENTOA SECONDARY SCHOOL" },
  { "place": "HLANGANANI SECONDARY SCHOOL" },
  { "place": "HLOMPHANANG SECONDARY SCHOOL" },
  { "place": "HOËR TEGNIESE SKOOL CAREL DE WET" },
  { "place": "HOËR TEGNIESE SKOOL LANGLAAGTE" },
  { "place": "HOËR TEGNIESE SKOOL N DIEDERICHS" },
  { "place": "HOËR TEGNIESE SKOOL PRETORIA-TUINE" },
  { "place": "HOËR TEGNIESE SKOOL SPRINGS" },
  { "place": "HOËR TEGNOLOGIESE SKOOL JOHN VORSTER" },
  { "place": "HOËR VOLKSKOOL HEIDELBERG" },
  { "place": "HOËRSKOOL AKASIA" },
  { "place": "HOËRSKOOL ALBERTON" },
  { "place": "HOËRSKOOL BASTION" },
  { "place": "HOËRSKOOL BEKKER" },
  { "place": "HOËRSKOOL BIRCHLEIGH" },
  { "place": "HOËRSKOOL BRANDWAG" },
  { "place": "HOËRSKOOL CARLETONVILLE" },
  { "place": "HOËRSKOOL CENTURION" },
  { "place": "HOËRSKOOL DIE ADELAAR" },
  { "place": "HOËRSKOOL DIE ANKER" },
  { "place": "HOËRSKOOL DIE BURGER" },
  { "place": "HOËRSKOOL DIE FAKKEL" },
  { "place": "HOËRSKOOL DIE WILGERS" },
  { "place": "HOËRSKOOL DINAMIKA" },
  { "place": "HOËRSKOOL DR E G JANSEN" },
  { "place": "HOËRSKOOL DR MALAN" },
  { "place": "HOËRSKOOL DRIE RIVIERE" },
  { "place": "HOËRSKOOL DRIEHOEK" },
  { "place": "HOËRSKOOL EDENVALE" },
  { "place": "HOËRSKOOL ELANDSPOORT" },
  { "place": "HOËRSKOOL ELDORAIGNE" },
  { "place": "HOËRSKOOL ELSBURG" },
  { "place": "HOËRSKOOL ELSPARK" },
  { "place": "HOËRSKOOL ERASMUS" },
  { "place": "HOËRSKOOL F H ODENDAAL" },
  { "place": "HOËRSKOOL FLORIDA" },
  { "place": "HOËRSKOOL GARSFONTEIN" },
  { "place": "HOËRSKOOL GERRIT MARITZ" },
  { "place": "HOËRSKOOL GOUDRIF" },
  { "place": "HOËRSKOOL HANS MOORE" },
  { "place": "HOËRSKOOL HENDRIK VERWOERD" },
  { "place": "HOËRSKOOL HERCULES" },
  { "place": "HOËRSKOOL HUGENOTE" },
  { "place": "HOËRSKOOL JAN DE KLERK" },
  { "place": "HOËRSKOOL JAN VILJOEN" },
  { "place": "HOËRSKOOL JEUGLAND" },
  { "place": "HOËRSKOOL JOHAN JURGENS" },
  { "place": "HOËRSKOOL JOHN VORSTER" },
  { "place": "HOËRSKOOL KEMPTON PARK" },
  { "place": "HOËRSKOOL LANGENHOVEN" },
  { "place": "HOËRSKOOL LINDEN" },
  { "place": "HOËRSKOOL MARAIS VILJOEN" },
  { "place": "HOËRSKOOL MENLOPARK" },
  { "place": "HOËRSKOOL MONTANA" },
  { "place": "HOËRSKOOL MONUMENT" },
  { "place": "HOËRSKOOL NOORDHEUWEL" },
  { "place": "HOËRSKOOL OOS-MOOT" },
  { "place": "HOËRSKOOL OOSTERLIG" },
  { "place": "HOËRSKOOL OVERKRUIN" },
  { "place": "HOËRSKOOL OVERVAAL" },
  { "place": "HOËRSKOOL PRESIDENT" },
  { "place": "HOËRSKOOL PRETORIA-NOORD" },
  { "place": "HOËRSKOOL PRETORIA-WES" },
  { "place": "HOËRSKOOL PRIMROSE" },
  { "place": "HOËRSKOOL RANDBURG" },
  { "place": "HOËRSKOOL RIEBEECKRAND" },
  { "place": "HOËRSKOOL ROODEPOORT" },
  { "place": "HOËRSKOOL SILVERTON" },
  { "place": "HOËRSKOOL STAATSPRESIDENT C R SWART" },
  { "place": "HOËRSKOOL STOFFBERG" },
  { "place": "HOËRSKOOL SUIDERLIG" },
  { "place": "HOËRSKOOL TRANSVALIA" },
  { "place": "HOËRSKOOL TUINE" },
  { "place": "HOËRSKOOL UITSIG" },
  { "place": "HOËRSKOOL VANDERBIJLPARK" },
  { "place": "HOËRSKOOL VOORTREKKER" },
  { "place": "HOËRSKOOL VOORTREKKERHOOGTE" },
  { "place": "HOËRSKOOL VORENTOE" },
  { "place": "HOËRSKOOL VRYBURGER HIGH SCHOOL" },
  { "place": "HOËRSKOOL WATERKLOOF" },
  { "place": "HOËRSKOOL WESTONARIA" },
  { "place": "HOËRSKOOL WONDERBOOM" },
  { "place": "HOËRSKOOL WONDERFONTEIN" },
  { "place": "HOËRSKOOL ZWARTKOP" },
  { "place": "HOFMEYR SECONDARY SCHOOL" },
  { "place": "HOLY ROSARY CONVENT SCHOOL" },
  { "place": "HOLY TRINITY HIGH SCHOOL (CATHOLIC SEC.)" },
  { "place": "HOLY TRINITY SECONDARY SCHOOL" },
  { "place": "HOPE FOUNTAIN COMBINED COLLEGE" },
  { "place": "HOPE FOUNTAIN COMBINED SCHOOL-ERAND GARDENS" },
  { "place": "HOPE RESTORATION COLLEGE" },
  { "place": "HORIZON INTERNATIONAL HIGH SCHOOL" },
  { "place": "HOSEA KEKANA SECONDARY SCHOOL" },
  { "place": "HULWAZI SECONDARY SCHOOL" },
  { "place": "HYDE PARK HIGH SCHOOL" },
  { "place": "I. R. LESOLANG SECONDARY SCHOOL" },
  { "place": "IBHONGO SECONDARY SCHOOL" },
  { "place": "IKUSASA COMPREHENSIVE SCHOOL" },
  { "place": "IKUSASALETHU SECONDARY SCHOOL" },
  { "place": "ILLINGE SECONDARY SCHOOL" },
  { "place": "IMFUNDO SECONDARY SCHOOL" },
  { "place": "IMMACULATA SECONDARY SCHOOL" },
  { "place": "IMPACT TUTORIAL CENTRE" },
  { "place": "IMRA TECHNOLOGY ACADEMY" },
  { "place": "INQAYIZIVELE SECONDARY SCHOOL" },
  { "place": "INSTITUTE FOR QUALITY COLLEGIATE" },
  { "place": "INSTITUTE STATUS ACRES SECONDARY SCHOOL" },
  { "place": "INTERNATIONAL PRE-UNIVERSITY COLLEGE" },
  { "place": "IONA CONVENT" },
  { "place": "ISIKHUMBUZO SECONDARY SCHOOL" },
  { "place": "ISIZWE-SETJHABA SECONDARY SCHOOL" },
  { "place": "ISLAMIYA GIRLS INSTITUTE" },
  { "place": "ITHEMBA INSTITUTION OF TECHNOLOGY" },
  { "place": "ITHEMBA STUDY CENTRE" },
  { "place": "ITHUBA COMUNITY COLLEGE" },
  { "place": "ITHUBA-LETHU SECONDARY SCHOOL" },
  { "place": "ITHUTENG SECONDARY SCHOOL" },
  { "place": "ITIRELE-ZENZELE COMPREHENSIVE SCHOOL" },
  { "place": "IVORY PARK  SECONDARY SCHOOL" },
  { "place": "IVY ACADEMY" },
  { "place": "IZENZO KUNGEMAZWI COMMUNITY COLLEGE" },
  { "place": "J KEKANA SECONDARY SCHOOL" },
  { "place": "J.B. MATABANE SECONDARY SCHOOL" },
  { "place": "JABULANI TECHNICAL SECONDARY SCHOOL" },
  { "place": "JABULILE SECONDARY SCHOOL" },
  { "place": "JACARANDA ACADEMY" },
  { "place": "JAFTA MAHLANGU SECONDARY SCHOOL" },
  { "place": "JAHARI CHRISTIAN ACADEMY" },
  { "place": "JAMESON HIGH SCHOOL" },
  { "place": "JE MALEPE SECONDARY SCHOOL" },
  { "place": "JEPPE EDUCATION CENTRE" },
  { "place": "JEPPE EDUCATION CENTRE - VEREENIGING" },
  { "place": "JEPPE HIGH SCHOOL FOR BOYS" },
  { "place": "JEPPE HIGH SCHOOL FOR GIRLS" },
  { "place": "JET NTEO SECONDARY SCHOOL" },
  { "place": "JINTEK VARSITY COLLEGE" },
  { "place": "JIYANA SECONDARY SCHOOL" },
  { "place": "JOHANNESBURG MUSLIM SCHOOL" },
  { "place": "JOHANNESBURG POLYTECH INSTITUTE" },
  { "place": "JOHANNESBURG SECONDARY SCHOOL" },
  { "place": "JOHWETO PRIVATE PRIMARY SCHOOL" },
  { "place": "JORDAN SECONDARY SCHOOL" },
  { "place": "JORDAO COLLEGE" },
  { "place": "JUBILEE CHRISTIAN SCHOOL" },
  { "place": "JULES HIGH SCHOOL" },
  { "place": "JW SAINTS TECHNICAL COLLEGE" },
  { "place": "KAALFONTEIN SECONDARY SCHOOL" },
  { "place": "KAGISO SECONDARY SCHOOL" },
  { "place": "KATHSTAN COLLEGE" },
  { "place": "KATLEHO-IMPUMELELO SECONDARY SCHOOL" },
  { "place": "KATLEHONG SECONDARY SCHOOL" },
  { "place": "KATLEHONG TECHNICAL SECONDARY SCHOOL" },
  { "place": "KELOKITSO COMPREHENSIVE SCHOOL" },
  { "place": "KENILWORTH SECONDARY SCHOOL" },
  { "place": "KENNEDY G. BUNGANE MATHS AND SCIENCE ACADEMY" },
  { "place": "KENNETH MASEKELA SECONDARY SCHOOL" },
  { "place": "KENSINGTON SECONDARY SCHOOL" },
  { "place": "KGADIME MATSEPE SECONDARY SCHOOL" },
  { "place": "KGATELOPELE SECONDARY SCHOOL" },
  { "place": "KGETSE-YA-TSIE PRIMARY SCHOOL" },
  { "place": "KGOKARE SECONDARY SCHOOL" },
  { "place": "KGOMOTSO SECONDARY SCHOOL" },
  { "place": "KGORO YA THUTO SECONDARY SCHOOL" },
  { "place": "KHANYA-LESEDI SECONDARY SCHOOL" },
  { "place": "KHOMANANI BUSINESS COLLEGE" },
  { "place": "KHUTLO-THARO SECONDARY SCHOOL" },
  { "place": "KIBLER PARK SECONDARY SCHOOL" },
  { "place": "KING DAVID HIGH SCHOOL (VICTORY PARK)" },
  { "place": "KING DAVID SCHOOL-LINKSFIELD" },
  { "place": "KING EDWARD VII SCHOOL" },
  { "place": "KINGS HIGHWAY ACADEMY" },
  { "place": "KINGSMEAD COLLEGE" },
  { "place": "KINGSWAY SECONDARY SCHOOL" },
  { "place": "KLIPSPRUIT-WES SECONDARY SCHOOL" },
  { "place": "KLIPTOWN SECONDARY SCHOOL" },
  { "place": "KRUGERSDORP HIGH SCHOOL" },
  { "place": "KUBE SCHOOLS" },
  { "place": "KUDUNG MIDDLE SCHOOL" },
  { "place": "KWABHEKILANGA SECONDARY SCHOOL" },
  { "place": "KWADEDANGENDLALE SECONDARY SCHOOL" },
  { "place": "KWADUKATHOLE COMPREHENSIVE SCHOOL" },
  { "place": "KWA-MAHLOBO SECONDARY SCHOOL" },
  { "place": "KWENA MOLAPO COMPREHENSIVE FARM SCHOOL" },
  { "place": "L.G. HOLELE SECONDARY SCHOOL" },
  { "place": "LA SALLE COLLEGE" },
  { "place": "LABAN MOTLHABI COMPREHENSIVE SCHOOL" },
  { "place": "LAERSKOOL GLENHARVIE" },
  { "place": "LAKESIDE SECONDARY SCHOOL" },
  { "place": "LAMULA JUBILEE SECONDARY SCHOOL" },
  { "place": "LANCEA VALE SECONDARY SCHOOL" },
  { "place": "LANDULWAZI COMPREHENSIVE SCHOOL" },
  { "place": "LANGAVILLE SECONDARY SCHOOL" },
  { "place": "LAUDIUM SECONDARY SCHOOL" },
  { "place": "LAVELA SECONDARY SCHOOL" },
  { "place": "LAWLEY SECONDARY SCHOOL" },
  { "place": "LEADERS CHRISTIAN ACADEMY" },
  { "place": "LE-AMEN" },
  { "place": "LEAP SCIENCE AND MATHS SCHOOL" },
  { "place": "LEAP SCIENCE AND MATHS SCHOOL" },
  { "place": "LEAP SCIENCE AND MATHS SCHOOL (INDEPENDENT)" },
  { "place": "LEARNING STRATEGIES INTERNATIONAL (LSI) COLLEGE" },
  { "place": "LEBOHANG SECONDARY SCHOOL" },
  { "place": "LEBONE SECONDARY SCHOOL" },
  { "place": "LEE RAND HIGH SCHOOL" },
  { "place": "LEEDS BUSINESS SCHOOL" },
  { "place": "LEEUHOF AKADEMIE" },
  { "place": "LEFA-IFA SECONDARY SCHOOL" },
  { "place": "LEHLABILE SECONDARY SCHOOL" },
  { "place": "LEHWELERENG SECONDARY SCHOOL" },
  { "place": "LEKAMOSO SECONDARY SCHOOL" },
  { "place": "LEKOA SHANDU SECONDARY SCHOOL" },
  { "place": "LENASIA MUSLIM SCHOOL" },
  { "place": "LENASIA SECONDARY SCHOOL" },
  { "place": "LENASIA SOUTH SECONDARY SCHOOL" },
  { "place": "LENZ PUBLIC SCHOOL" },
  { "place": "LEONDALE SECONDARY SCHOOL" },
  { "place": "LESEDI SECONDARY SCHOOL" },
  { "place": "LESHATA SECONDARY SCHOOL" },
  { "place": "LESIBA SECONDARY SCHOOL" },
  { "place": "LETARE SECONDARY SCHOOL" },
  { "place": "LETHABONG SECONDARY SCHOOL" },
  { "place": "LETHAMAGA SECONDARY SCHOOL" },
  { "place": "LETHUKUTHULA SECONDARY SCHOOL" },
  { "place": "LETHULWAZI COMPREHENSIVE SCHOOL" },
  { "place": "LETLOTLO PRIMARY SCHOOL" },
  { "place": "LETSATSING PRIMARY MINE SCHOOL" },
  { "place": "LETSIBOGO SECONDARY SCHOOL" },
  { "place": "LIBERTY COMMUNITY SCHOOL" },
  { "place": "LIFE MINISTRIES CHRISTIAN SCHOOL" },
  { "place": "LIGNO VITAE ACADEMY" },
  { "place": "LI-HILLS TRAINING COLLEGE" },
  { "place": "LINGITJHUDU SECONDARY SCHOOL" },
  { "place": "LIVERPOOL SECONDARY SCHOOL" },
  { "place": "LODIRILE SECONDARY SCHOOL" },
  { "place": "LOERIE LAND INDEPENDENT SCHOOL" },
  { "place": "LOFENTSE GIRLS HIGH SCHOOL" },
  { "place": "LOMPEC INDEPENDENT PRIMARY AND SECONDARY SCHOOL" },
  { "place": "LONEHILL ACADEMY" },
  { "place": "LORETO CONVENT SCHOOL" },
  { "place": "LOTUS GARDENS SECONDARY SCHOOL" },
  { "place": "LUKHANYO HIGH SCHOOL" },
  { "place": "LUNEM LEARNING CENTRE" },
  { "place": "LYCEE FRANCAIS JULES VERNE" },
  { "place": "LYTTELTON MANOR HIGH SCHOOL" },
  { "place": "M. H. BALOYI SECONDARY SCHOOL" },
  { "place": "MABOPANE SECONDARY SCHOOL" },
  { "place": "MABUYA SECONDARY SCHOOL" },
  { "place": "MADIBA SECONDARY SCHOOL" },
  { "place": "MADIBANE COMPREHENSIVE SCHOOL" },
  { "place": "MADISONG SECONDARY SCHOOL" },
  { "place": "MADRESSAH AYESHA" },
  { "place": "MAFORI MPHAHLELE COMPREHENSIVE SCHOOL" },
  { "place": "MAGALIESBURG STATE SCHOOL" },
  { "place": "MAHARENG SECONDARY SCHOOL" },
  { "place": "MAHLASEDI HIGH SCHOOL" },
  { "place": "MAHLENGA SECONDARY SCHOOL" },
  { "place": "MAHUBE VALLEY SECONDARY SCHOOL" },
  { "place": "MAKGETSE SECONDARY SCHOOL" },
  { "place": "MAKHOSINI COMBINED SECONDARY SCHOOL" },
  { "place": "MALVERN HIGH SCHOOL" },
  { "place": "MAMELLONG COMPREHENSIVE" },
  { "place": "MAMELODI SECONDARY SCHOOL" },
  { "place": "MANDISA SHICEKA SECONDARY SCHOOL" },
  { "place": "MAPENANE SECONDARY SCHOOL" },
  { "place": "MAPETLA HIGH SCHOOL" },
  { "place": "MAPHUTHA SECONDARY SCHOOL" },
  { "place": "MARAGON SCHOOL" },
  { "place": "MARANATHA CHRISTIAN SCHOOL" },
  { "place": "MARIST BROTHERS COLLEGE" },
  { "place": "MARLBORO GARDENS SECONDARY SCHOOL" },
  { "place": "MARTHIE DE BRUIN SENTRUM" },
  { "place": "MARYVALE COLLEGE" },
  { "place": "MASIBAMBANE PRIVATE SCHOOL" },
  { "place": "MASIQHAKAZE SECONDARY SCHOOL" },
  { "place": "MASISEBENZE COMPREHENSIVE SCHOOL" },
  { "place": "MASITHWALISANE SECONDARY SCHOOL" },
  { "place": "MATLA COMBINED SCHOOL" },
  { "place": "MATSELISO SECONDARY SCHOOL" },
  { "place": "MAXEKE SECONDARY SCHOOL" },
  { "place": "MBOWA ACADEMY" },
  { "place": "MCAULEY HOUSE SCHOOL" },
  { "place": "MEADOWLANDS SECONDARY SCHOOL" },
  { "place": "MEMEZELO SECONDARY SCHOOL" },
  { "place": "MERIDIAN COLLEGE" },
  { "place": "METROPOLITAN  COLLEGE" },
  { "place": "MEYERTON SECONDARY SCHOOL" },
  { "place": "MH JOOSUB TECHNICAL SECONDARY SCHOOL" },
  { "place": "MICHAEL MOUNT WALDORF SCHOOL" },
  { "place": "MIDRAND EDU CENTRE" },
  { "place": "MIDRAND HIGH SCHOOL" },
  { "place": "MIDRAND PRIMARY AND HIGH SCHOOL" },
  { "place": "MIDRAND PRIMARY AND HIGH SCHOOL" },
  { "place": "MIDSTREAM COLLEGE" },
  { "place": "MINERVA SECONDARY SCHOOL" },
  { "place": "MISSOURILAAN SECONDARY SCHOOL" },
  { "place": "MNCUBE SECONDARY SCHOOL" },
  { "place": "MODILATI SECONDARY SCHOOL" },
  { "place": "MODIRI SECONDARY SCHOOL" },
  { "place": "MODIRI TECHNICAL SCHOOL" },
  { "place": "MOHALADITOE SECONDARY SCHOOL" },
  { "place": "MOHLOLI SECONDARY SCHOOL" },
  { "place": "MOKGOME SECONDARY SCHOOL" },
  { "place": "MOLETSANE SECONDARY SCHOOL" },
  { "place": "MOM SEBONE SECONDARY SCHOOL" },
  { "place": "MONDEOR HIGH SCHOOL" },
  { "place": "MONTESSORI ACADEMY AND COLLEGE" },
  { "place": "MOOT CHRISTIAN ACADEMY" },
  { "place": "MOPHOLOSI SECONDARY SCHOOL" },
  { "place": "MOQHAKA SECONDARY SCHOOL" },
  { "place": "MORRIS ISAACSON SECONDARY SCHOOL" },
  { "place": "MOSES MAREN MISSION TECHNICAL SECONDARY SCHOOL" },
  { "place": "MOSHATE SECONDARY SCHOOL" },
  { "place": "MOSUPATSELA SECONDARY SCHOOL" },
  { "place": "MOUNTAIN VIEW HIGH SCHOOL" },
  { "place": "MPHETHI MAHLATSI SECONDARY SCHOOL" },
  { "place": "MPILISWENI SECONDARY SCHOOL" },
  { "place": "MPONTSHENG SECONDARY SCHOOL" },
  { "place": "MPUMELELO SECONDARY SCHOOL" },
  { "place": "MUSI COMPREHENSIVE" },
  { "place": "NALEDI SECONDARY SCHOOL" },
  { "place": "NAMEDI SECONDARY SCHOOL" },
  { "place": "NASHVILLE CHRISTIAN COLLEGE" },
  { "place": "NATIONWIDE SCHOOL FOR ACADEMIC EXCELLENCE" },
  { "place": "NELLMAPIUS SECONDARY SCHOOL" },
  { "place": "NEW EERSTERUST SECONDARY SCHOOL" },
  { "place": "NEW GENERATION ACADEMY" },
  { "place": "NEW HOPE SECONDARY SCHOOL" },
  { "place": "NEW MILLENIUM COLLEGE" },
  { "place": "NEW MODEL PRIVATE COLLEGE" },
  { "place": "NEWGATE COLLEGE" },
  { "place": "NGAKA MASEKO SECONDARY SCHOOL" },
  { "place": "NGHUNGHUNYANI COMPREHENSIVE" },
  { "place": "NICK MPSHE SECONDARY SCHOOL" },
  { "place": "NIGEL HIGH SCHOOL" },
  { "place": "NIGEL SECONDARY SCHOOL" },
  { "place": "NIMROD NDEBELE SECONDARY SCHOOL" },
  { "place": "NIRVANA SECONDARY SCHOOL" },
  { "place": "NKUMBULO SECONDARY SCHOOL" },
  { "place": "NM TSUENE HIGH SCHOOL" },
  { "place": "NOORDWYK SECONDARY SCHOOL" },
  { "place": "NORKEM PARK HIGH SCHOOL" },
  { "place": "NORTH RIDING SECONDARY SCHOOL" },
  { "place": "NORTHCLIFF HIGH SCHOOL" },
  { "place": "NORTHVIEW HIGH SCHOOL" },
  { "place": "NORTHWOOD INDEPENDENT HIGH SCHOOL" },
  { "place": "NTIRISANO COMPREHENSIVE" },
  { "place": "NTSWANE SECONDARY SCHOOL" },
  { "place": "NUR-UL-ISLAM SCHOOL" },
  { "place": "O.R TAMBO SECONDARY SCHOOL" },
  { "place": "OAKDALE SECONDARY SCHOOL" },
  { "place": "OCEANS PRIVATE SCHOOL" },
  { "place": "OLIEVENHOUTBOSCH SECONDARY SCHOOL" },
  { "place": "OLYMPUS EDUCATIONAL INSTITUTE" },
  { "place": "OOS-RAND AKADEMIE" },
  { "place": "OOSRAND SECONDARY SCHOOL" },
  { "place": "OPRAH WINFREY LEADERSHIP ACADEMY FOR GIRLS - SOUTH AFRICA" },
  { "place": "ORANGE FARM SECONDARY SCHOOL" },
  { "place": "ORLANDO SECONDARY SCHOOL" },
  { "place": "ORLANDO WEST SECONDARY SCHOOL" },
  { "place": "OUR LADY OF WISDOM" },
  { "place": "OXFORD COMBINED COLLEGE" },
  { "place": "OXFORD TRAINING CENTRE" },
  { "place": "P.H.L MORAKA SECONDARY SCHOOL" },
  { "place": "PALMRIDGE EXT. 6 SECONDARY SCHOOL" },
  { "place": "PALMRIDGE SECONDARY SCHOOL" },
  { "place": "PARKLANDS HIGH SCHOOL" },
  { "place": "PARKTOWN BOYS' HIGH SCHOOL" },
  { "place": "PARKTOWN GIRLS' HIGH SCHOOL" },
      { "place": "PC TRAINING AND BUSINESS COLLEGE" },
  { "place": "PC TRAINING AND BUSINESS COLLEGE" },
  { "place": "PC TRAINING AND BUSINESS COLLEGE" },
  { "place": "PC TRAINING AND BUSINESS COLLEGE" },
  { "place": "PC TRAINING AND BUSINESS COLLEGE" },
  { "place": "PELOTONA PRIMARY SCHOOL" },
  { "place": "PETIT HIGH SCHOOL" },
  { "place": "PHAFOGANG SECONDARY SCHOOL" },
  { "place": "PHAHAMA SECONDARY SCHOOL" },
  { "place": "PHAKAMANI SECONDARY SCHOOL" },
  { "place": "PHANDIMFUNDO SECONDARY SCHOOL" },
  { "place": "PHATENG SECONDARY SCHOOL" },
  { "place": "PHEFENI SECONDARY SCHOOL" },
  { "place": "PHELINDABA SECONDARY SCHOOL" },
  { "place": "PHINEAS XULU SECONDARY SCHOOL" },
  { "place": "PHOENIX COLLEGE OF JOHANNESBURG" },
  { "place": "PHOENIX SECONDARY SCHOOL" },
  { "place": "PHOMOLONG SECONDARY SCHOOL" },
  { "place": "PHOMOLONG SECONDARY SCHOOL NO. 2" },
  { "place": "PHULONG SECONDARY SCHOOL" },
  { "place": "PHUMELELA PRIVATE COLLEGE" },
  { "place": "PHUMLANI SECONDARY SCHOOL" },
  { "place": "PHUMULA GARDENS SECONDARY SCHOOL" },
  { "place": "PHUTI JUNIOR SECONDARY SCHOOL" },
  { "place": "PIONEER ACADEMY ORMONDE" },
  { "place": "PJ SIMELANE SECONDARY SCHOOL" },
  { "place": "POELANO SECONDARY SCHOOL" },
  { "place": "PONEGO SECONDARY SCHOOL" },
  { "place": "PONELOPELE ORACLE SECONDARY SCHOOL" },
  { "place": "PRESTIGE COLLEGE" },
  { "place": "PRESTIGIOUS AURETE SECONDARY SCHOOL" },
  { "place": "PRETORIA BOYS' HIGH SCHOOL" },
  { "place": "PRETORIA CENTRAL HIGH SCHOOL" },
  { "place": "PRETORIA CHINESE SCHOOL" },
  { "place": "PRETORIA HIGH SCHOOL FOR GIRLS" },
  { "place": "PRETORIA INSTITUTE OF LEARNING" },
  { "place": "PRETORIA MUSLIM SCHOOL" },
  { "place": "PRETORIA MUSLIM TRUST SUNNI SCHOOL" },
  { "place": "PRETORIA SECONDARY SCHOOL" },
  { "place": "PRETORIA TECHNICAL HIGH SCHOOL" },
  { "place": "PRIDE LEARNING ACADEMY" },
  { "place": "PRIME UNIQUE ACADEMY" },
  { "place": "PRINCEFIELD TRUST SCHOOL" },
  { "place": "PRINCESS HIGH SCHOOL" },
  { "place": "PRINCESS PARK SECONDARY INDEPENDENT COLLEGE SCHOOL" },
  { "place": "PRINCESS PARK SECONDARY SCHOOL AND COLLEGE" },
  { "place": "PRO ARTE ALPHEN PARK" },
  { "place": "PROGRESS COMPREHENSIVE SCHOOL" },
  { "place": "PROSPERITUS SECONDARY SCHOOL" },
  { "place": "PROTEA GLEN SECONDARY SCHOOL" },
  { "place": "PROVIDENCE ACADEMY" },
  { "place": "PRUDENS SECONDARY SCHOOL" },
  { "place": "QALABOTJHA SECONDARY SCHOOL" },
  { "place": "QEDILIZWE SECONDARY SCHOOL" },
  { "place": "QOQA SECONDARY SCHOOL" },
  { "place": "QUANTUM SECONDARY SCHOOL" },
  { "place": "QUEENS HIGH SCHOOL" },
  { "place": "QUEENS PRIVATE SCHOOL" },
  { "place": "QUEENSWOOD CHRISTIAN COLLEGE" },
  { "place": "R W FICK SECONDARY SCHOOL" },
  { "place": "RABASOTHO COMBINED SCHOOL" },
  { "place": "RADLEY COLLEGE" },
  { "place": "RAKGOTSO SECONDARY SCHOOL" },
  { "place": "RAMOLELLE COMBINED" },
  { "place": "RAMOSUKULA PRIMARY SCHOOL" },
  { "place": "RAND HILLS ACADEMY" },
  { "place": "RAND HILLS COLLEGE" },
  { "place": "RAND MEISIESKOOL-GIRLS' SCHOOL" },
  { "place": "RAND PARK HIGH SCHOOL" },
  { "place": "RAND PREPARATORY AND COLLEGE" },
  { "place": "RAND TUTORIAL COLLEGE" },
  { "place": "RAND VIEW COLLEGE" },
  { "place": "RANDFONTEIN HIGH SCHOOL" },
  { "place": "RANDFONTEIN SECONDARY SCHOOL" },
  { "place": "RANTAILANE SECONDARY SCHOOL" },
  { "place": "RAPHELA SECONDARY SCHOOL" },
  { "place": "RATANDA SECONDARY SCHOOL" },
  { "place": "RATSHEPO SECONDARY SCHOOL" },
  { "place": "RAUCALL SECONDARY SCHOOL" },
  { "place": "RAYMOND MHLABA SECONDARY SCHOOL" },
  { "place": "REALO  SECONDARY SCHOOL" },
  { "place": "REASOMA SECONDARY SCHOOL" },
  { "place": "REDDAM HOUSE PRIVATE SCHOOL" },
  { "place": "REDHILL SCHOOL" },
  { "place": "REIGER PARK NO. 2 SECONDARY SCHOOL" },
  { "place": "REITUMETSE SECONDARY SCHOOL" },
  { "place": "RELEBOGILE SECONDARY SCHOOL" },
  { "place": "REPHAFOGILE SECONDARY SCHOOL" },
  { "place": "RESHOGOFADITSWE SECONDARY SCHOOL" },
  { "place": "RESIDENSIA SECONDARY SCHOOL" },
  { "place": "REUTLWILE JUNIOR SECONDARY SCHOOL" },
  { "place": "REVIVAL CHRISTIAN SCHOOL" },
  { "place": "RHEMA CHRISTIAN SCHOOL" },
  { "place": "RHODES TECHNICAL COLLEGE" },
  { "place": "RHODESFIELD TECHNICAL HIGH SCHOOL" },
  { "place": "RIBANE-LAKA SECONDARY SCHOOL" },
  { "place": "RIETVALLEI EXTENSION 1 SECONDARY SCHOOL" },
  { "place": "RIVERLEA SECONDARY SCHOOL" },
  { "place": "RIVERNORTH COMMERCIAL SCHOOL" },
  { "place": "RIVERSIDE HIGH SCHOOL" },
  { "place": "RIVONI SECONDARY SCHOOL" },
  { "place": "ROBIN HOOD PRIVATE SECONDARY SCHOOL" },
  { "place": "ROEDEAN SCHOOL (SA)" },
  { "place": "RONDEBULT SECONDARY SCHOOL" },
  { "place": "RONDEBULT SECONDARY SCHOOL NO. 2" },
  { "place": "ROOSEVELT HIGH SCHOOL" },
  { "place": "ROSHNEE ISLAMIC SCHOOL" },
  { "place": "ROSHNEE SECONDARY SCHOOL" },
  { "place": "ROSTEC TECHNICAL COLLEGE" },
  { "place": "ROSTEC TECHNICAL COLLEGE- PTA" },
  { "place": "ROSTEC TECHNICAL COLLEGE-JHB" },
  { "place": "ROYAL COLLEGE" },
  { "place": "RUABOHLALE JUNIOR SECONDARY SCHOOL" },
  { "place": "RUSOORD INTERMEDIATE SCHOOL" },
  { "place": "RUST-TER-VAAL SECONDARY SCHOOL" },
  { "place": "RUTASETJHABA SECONDARY SCHOOL" },
  { "place": "S B S M PRIVATE SCHOOL" },
  { "place": "SA COLLEGE SCHOOL" },
  { "place": "SA INTERNATIONAL COLLEGE OF EDUCATION" },
  { "place": "SACRED HEART COLLEGE" },
  { "place": "SAGEWOOD SCHOOL" },
  { "place": "SAHETI SCHOOL" },
  { "place": "SAKHISIZWE SECONDARY SCHOOL" },
  { "place": "SAMA INDEPENDENT PRIMARY AND SECONDARY SCHOOL" },
  { "place": "SAMELSON COLLEGE" },
  { "place": "SANDOWN HIGH SCHOOL" },
  { "place": "SANDRINGHAM HIGH SCHOOL" },
  { "place": "SANDTON TECHNICAL COLLEGE" },
  { "place": "SANDTONVIEW COMBINED SCHOOL" },
  { "place": "SAPPHIRE SECONDARY SCHOOL" },
  { "place": "SAULRIDGE SECONDARY SCHOOL" },
  { "place": "SCHAUMBURG COMBINED SCHOOL" },
  { "place": "SCHOOL OF MERIT PRIVATE SCHOOL" },
  { "place": "SCIENCES TUTORIALS" },
  { "place": "SEAGENG SECONDARY SCHOOL" },
  { "place": "SEANA MARENA SECONDARY SCHOOL" },
  { "place": "SEBETSA-O-THOLEMOPUTSO" },
  { "place": "SEDAVEN HIGH SCHOOL" },
  { "place": "SEDCO COLLEGE" },
  { "place": "SEDCO COLLEGE CARLETONVILLE" },
  { "place": "SEDCO COLLEGE-PRETORIA" },
  { "place": "SEEKERS PRIVATE HIGH SCHOOL" },
  { "place": "SEHOPOTSO SECONDARY SCHOOL" },
  { "place": "SEKANONTOANE SECONDARY SCHOOL" },
  { "place": "SEKOLO SA BOROKGO SCHOOL" },
  { "place": "SELELEKELA SECONDARY SCHOOL" },
  { "place": "SENAOANE SECONDARY SCHOOL" },
  { "place": "SENTHIBELE SENIOR SECONDARY SCHOOL" },
  { "place": "SESHEGONG SECONDARY SCHOOL" },
  { "place": "SETJHABA-SOHLE SECONDARY SCHOOL" },
  { "place": "SETUMO - KHIBA SECONDARY SCHOOL" },
  { "place": "SG MAFAESA SECONDARY SCHOOL" },
  { "place": "SGODIPHOLA SECONDARY SCHOOL" },
  { "place": "SHA-AREI TORAH PRIMARY SCHOOL" },
  { "place": "SHANAN CHRISTIAN SCHOOL" },
  { "place": "SHANGRI-LA ACADEMY SCHOOL" },
  { "place": "SHEIKH ANTA DIOP COLLEGE" },
  { "place": "SHEPPERD HIGH SCHOOL" },
  { "place": "SIJABULILE SECONDARY SCHOOL" },
  { "place": "SIKHULULEKILE SECONDARY SCHOOL" },
  { "place": "SILVER OAKS SECONDARY SCHOOL" },
  { "place": "SIMUNYE SECONDARY SCHOOL" },
  { "place": "SIR ISAAC NEWTON HIGH SCHOOL" },
  { "place": "SIR JOHN ADAMSON HIGH SCHOOL" },
  { "place": "SIR PIERRE VAN RYNEVELD HIGH SCHOOL" },
  { "place": "SITJHEJIWE SECONDARY SCHOOL" },
  { "place": "SIYABONGA SECONDARY SCHOOL" },
  { "place": "SIYABUSA SECONDARY SCHOOL" },
  { "place": "SIYAPHAMBILI SECONDARY SCHOOL" },
  { "place": "SIZANANI THUSANANG COMPREHENSIVE SCHOOL" },
  { "place": "SIZWE SECONDARY SCHOOL" },
  { "place": "SKYLINE HIGH SCHOOL" },
  { "place": "SOLOMON MAHLANGU FREEDOM SCHOOL" },
  { "place": "SONRISE CHRISTIAN SCHOOL" },
  { "place": "SOSHANGUVE EAST SECONDARY SCHOOL" },
  { "place": "SOSHANGUVE SECONDARY SCHOOL" },
  { "place": "SOSHANGUVE SOUTH SECONDARY SCHOOL" },
  { "place": "SOSHANGUVE TECHNICAL SECONDARY SCHOOL" },
  { "place": "SOUTHDOWNS COLLEGE" },
  { "place": "SOUTHVIEW HIGH SCHOOL" },
  { "place": "SPACE AGE INDEPENDENT SCHOOL" },
  { "place": "SPARROWS PRIVATE SCHOOL" },
  { "place": "SPARTAN HIGH SCHOOL" },
  { "place": "SPRINGS BOYS' HIGH SCHOOL" },
  { "place": "SPRINGS GIRLS' HIGH SCHOOL" },
      { "place": "SPRINGS MUSLIM SCHOOL" },
  { "place": "SPRINGS SECONDARY SCHOOL" },
  { "place": "ST ALBAN'S COLLEGE" },
  { "place": "ST ANDREWS SCHOOL FOR GIRLS" },
  { "place": "ST ANSGAR'S COMBINED SCHOOL" },
  { "place": "ST ATHANASIUS ORTHODOX CHRISTIAN SCHOOL" },
  { "place": "ST BENEDICT'S COLLEGE" },
  { "place": "ST CATHERINE'S CONVENT SCHOOL" },
      { "place": "ST CATHERINE'S DOMINICAN CONVENT" },
          { "place": "ST CHRISTOPHER'S ACADEMY" },
              { "place": "ST DAVID'S MARIST COLLEGE" },
                  { "place": "ST DOMINIC'S SCHOOL" },
                      { "place": "ST DUNSTAN'S MEMORIAL DIOCESAN SCHOOL" },
                          { "place": "ST ENDA'S SECONDARY SCHOOL" },
                              { "place": "ST FRANCIS COLLEGE" },
                          { "place": "ST JOHN'S COLLEGE" },
                              { "place": "ST MARTIN DE PORRES HIGH SCHOOL" },
                          { "place": "ST MARTIN'S SCHOOL" },
                              { "place": "ST MARY'S DIOCESAN SCHOOL FOR GIRLS" },
                                  { "place": "ST MARY'S SCHOOL FOR GIRLS" },
                                      { "place": "ST MATTHEWS PRIVATE SECONDARY SCHOOL (KLIPTOWN)" },
                                  { "place": "ST PETER'S COLLEGE" },
                                      { "place": "ST STITHIANS COLLEGE" },
                                  { "place": "ST TERESA'S MERCY SENIOR PRIMARY AND HIGH SCHOOL" },
                                      { "place": "ST URSULA'S SCHOOL" },
                                          { "place": "STANZA BOPAPE SECONDARY SCHOOL" },
                                      { "place": "STAR OF HOPE SCHOOL" },
                                  { "place": "STAR SCHOOLS" },
                              { "place": "STEMRIDGE DISHON SCHOOL" },
                          { "place": "STEVE BIKOVILLE SECONDARY SCHOOL" },
                      { "place": "STEVE TSWETE SECONDARY SCHOOL" },
                  { "place": "STRAUSS SECONDARY SCHOOL" },
              { "place": "SUCCESS KATLEGO ACADEMY" },
          { "place": "SUMMAT INSTITUTE- ALEXANDRA CAMPUS" },
      { "place": "SUMMAT INSTITUTE- MARKADE CAMPUS" },
  { "place": "SUMMAT INSTITUTE- MARKET STREET CAMPUS" },
  { "place": "SUMMAT INSTITUTE-PRETORIA CAMPUS" },
  { "place": "SUMMERHILL COMBINED SCHOOL" },
  { "place": "SUMMIT COLLEGE" },
  { "place": "SUNCREST HIGH SCHOOL" },
  { "place": "SUNRISE COMBINED COLLEGE" },
  { "place": "SUNRISE SECONDARY SCHOOL" },
  { "place": "SUNWARD CHRISTIAN ACADEMY" },
  { "place": "SUNWARD PARK HIGH SCHOOL" },
  { "place": "SUPERO PRIVATE COMBINED SCHOOL" },
  { "place": "SUPREME EDUCATIONAL COLLEGE" },
  { "place": "SUTHERLAND HIGH SCHOOL" },
  { "place": "T M LETLHAKE SECONDARY SCHOOL" },
  { "place": "TAAL-NET INTERNATIONAL SCHOOL" },
  { "place": "TANDI ELEANOR SIBEKO SECONDARY SCHOOL" },
  { "place": "TANDUKWAZI SECONDARY SCHOOL" },
  { "place": "TASK ACADEMY SCHOOL" },
  { "place": "TEACH THEM CHRISTIAN COLLEGE" },
  { "place": "TEBOGWANA SECONDARY SCHOOL" },
  { "place": "TEMBISA SECONDARY SCHOOL" },
  { "place": "TEMBISA WEST SECONDARY SCHOOL" },
  { "place": "TERSIA KING LEARING ACADEMY" },
  { "place": "TETELO SECONDARY SCHOOL" },
  { "place": "THABA-JABULA SECONDARY SCHOOL" },
  { "place": "THABO NTSAKO SECONDARY SCHOOL" },
  { "place": "THABO SECONDARY SCHOOL" },
  { "place": "THAMSANQA SECONDARY SCHOOL" },
  { "place": "THARABOLLO SECONDARY SCHOOL" },
  { "place": "THATHULWAZI W.R. HIGH SCHOOL" },
  { "place": "THE AMERICAN INTERNATIONAL SCHOOL OF JOHANNESBURG" },
  { "place": "THE BRITISH ACADEMY" },
  { "place": "THE GLEN HIGH SCHOOL" },
  { "place": "THE HILL HIGH SCHOOL" },
  { "place": "THE KEEP LEARNING CENTRE" },
  { "place": "THE KING'S COLLEGE WEST RAND" },
  { "place": "THE KING'S SCHOOL (ROBIN HILLS)" },
      { "place": "THE KING'S SCHOOL BRYANSTON" },
          { "place": "THE KING'S SCHOOL LINBRO" },
              { "place": "THE SAMIT CHRISTIAN ACADEMY" },
          { "place": "THE TORAH ACADEMY PRIMARY AND HIGH SCHOOL" },
      { "place": "THE TRAINING ACADEMY" },
  { "place": "THE VAAL HIGH SCHOOL" },
  { "place": "THE WAY CHRISTIAN SCHOOL" },
  { "place": "THETHA SECONDARY SCHOOL" },
  { "place": "THOKO THABA SECONDARY SCHOOL" },
  { "place": "THOLULWAZI SECONDARY SCHOOL" },
  { "place": "THOMAS MOFOLO SECONDARY SCHOOL" },
  { "place": "THREE RIVERS CHRISTIAN ACDEMY" },
  { "place": "THULA-MNTWANA INDEPENDENT SCHOOL" },
  { "place": "THULANI SECONDARY SCHOOL" },
  { "place": "THUSA-SETJHABA SECONDARY SCHOOL" },
  { "place": "THUTO BOHLALE SECONDARY SCHOOL" },
  { "place": "THUTO KITSO SECONDARY SCHOOL" },
  { "place": "THUTO LEFA SECONDARY SCHOOL" },
  { "place": "THUTO LEHAKWE SECONDARY SCHOOL" },
  { "place": "THUTO LORE SECONDARY SCHOOL" },
  { "place": "THUTO PELE SECONDARY SCHOOL" },
  { "place": "THUTO-KE-MAATLA COMPREHENSIVE SCHOOL" },
  { "place": "THUTO-LESEDI SECONDARY SCHOOL" },
  { "place": "THUTOLORE SECONDARY SCHOOL" },
  { "place": "THUTOPELE SECONDARY SCHOOL" },
  { "place": "THUTO-TIRO COMPREHENSIVE" },
  { "place": "TIISETSONG SECONDARY SCHOOL" },
  { "place": "TIPFUXENI SECONDARY SCHOOL" },
  { "place": "TIYELELANI SECONDARY SCHOOL" },
  { "place": "TLAKULA SECONDARY SCHOOL" },
  { "place": "TOKELO SECONDARY SCHOOL" },
  { "place": "TOMORROW'S PEOPLE COLLEGE" },
  { "place": "TOPAZ SECONDARY SCHOOL" },
  { "place": "TOTUS TUUS INDEPENDENT SCHOOL" },
  { "place": "TOWNVIEW HIGH SCHOOL" },
  { "place": "TRINITY HOUSE HIGH SCHOOL" },
  { "place": "TRINITY HOUSE SCHOOL" },
  { "place": "TRINITY SECONDARY SCHOOL" },
  { "place": "TSAKANE EXT.8 SECONDARY SCHOOL" },
  { "place": "TSAKANE SECONDARY SCHOOL" },
  { "place": "TSAKO THABO SECONDARY SCHOOL" },
  { "place": "TSHEPO-THEMBA SECONDARY SCHOOL" },
  { "place": "TSHWANE CHRISTIAN SCHOOL" },
  { "place": "TSHWANE COLLEGE" },
  { "place": "TSHWANE COLLEGE" },
  { "place": "TSHWANE INSTITUTE OF TECHNOLOGY FOUNDATION INDEPENDENT SCHOOL" },
  { "place": "TSHWANE SECONDARY SCHOOL" },
  { "place": "TSIBOGO PRIMARY SCHOOL" },
  { "place": "TSOLO SECONDARY SCHOOL" },
  { "place": "TSOSOLOSO YA AFRICA SECONDARY SCHOOL" },
  { "place": "TSWAING SECONDARY SCHOOL" },
  { "place": "TSWASONGU SECONDARY SCHOOL" },
  { "place": "TSWELOPELE SECONDARY SCHOOL" },
  { "place": "TUKSSPORT HIGH SCHOOL" },
  { "place": "TULIP COMBINED SCHOOL" },
  { "place": "TYGER VALLEY COLLEGE" },
  { "place": "UMQHELE SECONDARY SCHOOL" },
  { "place": "UNIHIGH INDEPENDENT SCHOOL" },
  { "place": "UNITED CHURCH PREPARATORY SCHOOL" },
  { "place": "UNITED CITY COLLEGE" },
  { "place": "UNITED SISTERHOOD MITZVAH" },
  { "place": "UNITY SECONDARY SCHOOL" },
  { "place": "VAAL ED U COLLEGE PRIVATE" },
  { "place": "VECTOR HIGH SCHOOL" },
  { "place": "VEREENIGING GIMNASIUM" },
  { "place": "VERITAS COLLEGE" },
  { "place": "VERITAS SECONDARY SCHOOL" },
  { "place": "VERNEY COLLEGE" },
  { "place": "VEZUKHONO SECONDARY SCHOOL" },
  { "place": "VICTORY HOUSE PRIVATE SCHOOL" },
  { "place": "VICTORY TRAINING COLLEGE" },
  { "place": "VILLA LISA SECONDARY SCHOOL" },
  { "place": "VINE CHRISTIAN SCHOOL" },
  { "place": "VINE COLLEGE" },
  { "place": "VLAKFONTEIN EXTENSION 3 PRIMARY SCHOOL" },
  { "place": "VLAKFONTEIN SECONDARY SCHOOL" },
  { "place": "VOLKSKOOL BRAKPAN" },
  { "place": "VOSLOORUS COMPREHENSIVE SECONDARY SCHOOL" },
  { "place": "VUKANI MAWETHU SECONDARY SCHOOL" },
  { "place": "VULANINDLELA SECONDARY SCHOOL" },
  { "place": "VUTOMI HIGH SCHOOL" },
  { "place": "VUWANI SECONDARY SCHOOL" },
  { "place": "WALLMANSTHAL SECONDARY SCHOOL" },
  { "place": "WATERSHED PRIVATE SCHOOL" },
  { "place": "WATERSRAND COMBINED SCHOOL" },
  { "place": "WATERSRAND SECONDARY SCHOOL" },
  { "place": "WATERSTONE COLLEGE" },
  { "place": "WAVELENGTH HIGH SCHOOL" },
  { "place": "WAVERLEY GIRLS' HIGH SCHOOL" },
  { "place": "WEDELA TECHNICAL SECONDARY SCHOOL" },
  { "place": "WENDYWOOD HIGH SCHOOL" },
  { "place": "WEST RIDGE HIGH SCHOOL" },
  { "place": "WESTBURY SECONDARY SCHOOL" },
  { "place": "WESTWOOD INDEPENDENT SCHOOL" },
  { "place": "WHITE HOUSE COLLEGE" },
  { "place": "WHITESTONE COLLEGE" },
  { "place": "WIGGLES AND SQUIGGLES SCHOOL" },
  { "place": "WILLIAM HILLS SECONDARY SCHOOL" },
  { "place": "WILLOW CRESCENT SECONDARY SCHOOL" },
  { "place": "WILLOWMEAD SECONDARY SCHOOL" },
  { "place": "WILLOWMOORE HIGH SCHOOL" },
  { "place": "WILLOWRIDGE HIGH SCHOOL" },
  { "place": "WINDMILL PARK SECONDARY SCHOOL" },
  { "place": "WINDSOR HOUSE ACADEMY" },
  { "place": "WINILE SECONDARY SCHOOL" },
  { "place": "WINNIE MANDELA SECONDARY SCHOOL" },
  { "place": "WINTERVELDT HIGH SCHOOL" },
  { "place": "WISDOM AND KNOWLEDGE COLLEGE" },
  { "place": "WISEMAN CELE SECONDARY SCHOOL" },
  { "place": "WISE-UP EDUCATION CENTRE" },
  { "place": "WOODHILL COLLEGE" },
  { "place": "WOODLANDS INTERNATIONAL COLLEGE" },
  { "place": "WORD IN TRUTH C TRAINING" },
  { "place": "WORD OF LIFE CHRISTIAN SCHOOL" },
  { "place": "WORDSWORTH HIGH SCHOOL" },
  { "place": "WOZANIBONE INTERM FARM SCHOOL" },
  { "place": "WTS TUTORIAL COLLEGE" },
  { "place": "WUFA COMPREHENSIVE SCHOOL" },
  { "place": "YESHIVA MAHARSH BESH AHARON  COMMUNITY SCHOOL" },
  { "place": "ZAKARIYYA PARK SECONDARY SCHOOL" },
  { "place": "ZEE'S ACADEMY" },
  { "place": "ZIKHETHELE SECONDARY SCHOOL" },
  { "place": "ZIMISELE SECONDARY SCHOOL" },
  { "place": "ZITHOBENI SECONDARY SCHOOL" },
  { "place": "ZITIKENI SECONDARY SCHOOL" },
  { "place": "ZONKIZIZWE SECONDARY SCHOOL" },
   { "place": "Other" },
              ],
              "subjects": [
                    { "subject": "Afrikaans FAL" },
                  { "subject": "Afrikaans HL" },
                  { "subject": "Afrikaans SL" },
                    { "subject": "English FAL" },
                  { "subject": "English HL" },
                   { "subject": "IsiNdebele HL" },
                     { "subject": "IsiXhosa FAL" },
                    { "subject": "IsiXhosa HL" },
                       { "subject": "IsiZulu FAL" },
                    { "subject": "IsiZulu HL" },


              ]

          }, {
              "id": "1",
              "level": "University",
              "grades": [
                  { "grade": "1st Year" },
                   { "grade": "2nd Year" },
                   { "grade": "3rd Year" },
                   { "grade": "4th Year" },
                   { "grade": "5th Year" },
                    { "grade": "6th Year" },
                   { "grade": "7th Year" },
                    { "grade": "Postgrad" },
                   { "grade": "Honours" },
                   { "grade": "Masters" },
              ],
              "places": [
                  { "place": "University of Cape Town" },
                  { "place": "University of Fort Hare" },
                  { "place": "University of the Free State" },
                  { "place": "University of KwaZulu-Natal" },
                  { "place": "University of Limpopo" },
                  { "place": "North-West University" },
                  { "place": "University of Pretoria" },
                  { "place": "Rhodes University" },
                  { "place": "University of Stellenbosch" },
                  { "place": "University of the Western Cape" },
                  { "place": "University of Johannesburg" },
                  { "place": "Nelson Mandela Metropolitan University" },
                  { "place": "University of South Africa" },
                  { "place": "University of Venda" },
                  { "place": "University of Zululand" },
                  { "place": "Cape Peninsula University of Technology" },
                  { "place": "Walter Sisulu University" },
                  { "place": "Central University of Technology" },
                  { "place": "Durban University of Technology" },
                  { "place": "Mangosuthu University of Technology" },
                  { "place": "University of Mpumalanga" },
                  { "place": "Sol Plaatje University" },
                  { "place": "Tshwane University of Technology" },
                  { "place": "Vaal University of Technology" },
                   { "place": "Other" }




              ]
          },
           {
               "id": "1",
               "level": "Private University/College",
               "grades": [
                   { "grade": "1st Year" },
                   { "grade": "2nd Year" },
                   { "grade": "3rd Year" },
                   { "grade": "4th Year" },
                   { "grade": "5th Year" },
                    { "grade": "6th Year" },
                   { "grade": "7th Year" },
                    { "grade": "Postgrad" },
                   { "grade": "Honours" },
                   { "grade": "Masters" },
               ],
               "places": [
                   { "place": "AFDA" },
                   { "place": "Akademia" },
                   { "place": "Aros" },
                   { "place": "Boston City Campus & Business College" },
                   { "place": "Cornerstone Institute" },
                   { "place": "Centurion Academy" },
                   { "place": "CTI Education Group" },
                   { "place": "Damelin" },
                   { "place": "Helderberg College" },
                   { "place": "IMM Graduate School of Marketing" },
                   { "place": "Inscape Design College" },
                   { "place": "Management College of Southern Africa" },
                   { "place": "Midrand Graduate Institute" },
                   { "place": "Milpark Business School" },
                   { "place": "Monash South Africa" },
                   { "place": "Oval Campus" },
                   { "place": "Rosebank College" },
                   { "place": "Varsity College" },
                   { "place": "Vega" },
                   { "place": "Other" }
               ],
               
           }
        ];

        $scope.loadProvinces = function () {

            return $timeout(function () {
                $scope.provinces = $scope.provinces || [
                  { id: 1, name: 'Eastern Cape' },
                  { id: 2, name: 'Free State' },
                  { id: 3, name: 'Gauteng' },
                  { id: 4, name: 'Kwa-Zulu Natal' },
                  { id: 5, name: 'Limpopo' },
                  { id: 6, name: 'Mpumalanga' },
                  { id: 7, name: 'Northern Cape' },
                  { id: 8, name: 'North West' },
                  { id: 9, name: 'Western Cape' }
                ];
            }, 5);
        };


        $scope.loadRaces = function () {

            return $timeout(function () {
                $scope.races = $scope.races || [
                  { id: 1, name: 'African' },
                  { id: 2, name: 'Asain' },
                  { id: 3, name: 'Coloured' },
                  { id: 4, name: 'Indian' },
                  { id: 5, name: 'White' }
                ];
            }, 5);
        };

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
                 { id: 43, name: 'Computer Science & Informatics' },
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
                ];
            }, 5);
        };


        $scope.loadRelates = function () {

            return $timeout(function () {
                $scope.relates = $scope.relates || [
                  { id: 1, name: 'Mother' },
                  { id: 2, name: 'Father' },
                  { id: 3, name: 'Uncle' },
                  { id: 4, name: 'Aunt' },
                  { id: 5, name: 'Gaurdian' }
                ];
            }, 5);
        };

        $scope.registerStudent = function () {
          
            $scope.user = {};
            $scope.user.ID = $rootScope.repository.loggedUser.userIden;
            $scope.user.Email = $rootScope.repository.loggedUser.useremail;
            $scope.user.Name = $scope.Student.FirstName + " " + $scope.Student.Surname;
            membershipService.saveCredentials($scope.user);
            $scope.userData.displayUserInfo();


            //post student data 

            $scope.Student.ID = $scope.user.ID;
           
            $scope.StudentP = {};
            $scope.StudentP.ID = $scope.Student.ID;
            $scope.StudentP.FirstName = $scope.Student.FirstName;
            $scope.StudentP.Surname = $scope.Student.Surname;
            $scope.StudentP.EducationLevel = $scope.Student.InstituitionType.level;
            $scope.StudentP.AverageMark = null;
            $scope.StudentP.StudentNumber = $scope.Student.StudentNumber;
            $scope.StudentP.IDNumber = $scope.Student.IdNumber;
            $scope.StudentP.Age = null;
            if ($scope.SelectedDisabilityY) {
                $scope.Student.HasDisability = true;
                $scope.StudentP.DisabilityDescription = $scope.Student.DisabilityDescription;
            } else {
                $scope.Student.HasDisability = false;
                $scope.Student.DisabilityDescription = "none";
                $scope.StudentP.HasDisability = false;
                $scope.StudentP.DisabilityDescription = "none";
            }
            $scope.StudentP.Race = $scope.Student.Race.name;
            $scope.StudentP.Gender = $scope.Student.Gender;
            $scope.StudentP.CurrentOccupation = $scope.Student.CurrentOccupation;
            var myfields = "";
            for (var i = 0; i < $scope.Student.StudyFields.length; i++) {
                myfields += $scope.Student.StudyFields[i].name + ",";
            }

            $scope.StudentP.StudyField = myfields;
            $scope.StudentP.HighestAcademicAchievement = $scope.Student.InstituitionType.level;
            $scope.StudentP.YearOfAcademicAchievement = $scope.Student.MarksYearAttained;
            $scope.StudentP.DateOfBirth = $scope.Student.DateOfBirth;
            $scope.StudentP.NumberOfViews = null;
            $scope.StudentP.Essay = $scope.Student.Essay;
            $scope.StudentP.GuardianPhone = $scope.Student.GuardianPhone;
            $scope.StudentP.GuardianEmail = $scope.Student.GuardianEmail;
            if ($scope.SelectedGenderM) {
                $scope.StudentP.Gender = "Male";
            } else {
                $scope.StudentP.Gender = "Female";
            }
            $scope.StudentP.GuardianRelationship = $scope.Student.GuardianRelationship.name;
            $scope.StudentP.IDDocumentPath = $scope.Student.IDDocumentPath;
            $scope.StudentP.CVPath = $scope.Student.CVPath
            $scope.StudentP.AgreeTandC = true;
            $scope.StudentP.InstitutionID = 1;
            apiService.post('/api/student/savestudent', $scope.StudentP, saveStudentDone, saveStudentFailed);
         }

        $scope.testStudent = function () {
            for (var i = 0; i < $scope.Student.Marks.length; i++) {
                $scope.Student.Marks[i].StudentId = $rootScope.repository.loggedUser.userIden;
                $scope.Student.Marks[i].Period = $scope.Student.MarksYearAttained;
            }
            $scope.StudentMarks = $scope.Student.Marks;
            apiService.post('/api/student/saveAcademicRecord', $scope.StudentMarks, saveStudentDone, saveStudentFailed);
            
        }

        function saveStudentDone() {
            $location.path('/bursify/student/home');
           // saveAddress();
        }

        function saveAddress() {
            $scope.Address = {
                "AddressType": "Postal",
                "PreferredAddress": "",
                "StreetAddress": "",
                "Province": "",
                "City": "",
                "PostOfficeBoxNumber": "",
                "PostOfficeName": "",
                "PostalCode": ""
            };


             $scope.Address.StreetAddress = $scope.Student.ResStreetAddress;
             $scope.Address.Province = $scope.Student.ResProvince;
             $scope.Address.City = $scope.Student.ResCity;
             $scope.Address.PostalCode = $scope.Student.ResPostCode
             //execute when the postal address of the student is the same as the residential address
             if ($scope.PostalSameAs) {
                 notificationService.displayInfo("Same");
                 $scope.Address.AddressType = "Main";
                 // pass address

             } else if (!$scope.PostalSameAs) {
                 // pass the address 
                 $scope.Address.AddressType = "Residential";
                 //call api 

                 // pass the postal address
                 $scope.Address.AddressType = "Postal";
                 $scope.Address.StreetAddress = $scope.Student.PostStreetAddress;
                 $scope.Address.Province = $scope.Student.PostProvince;
                 $scope.Address.City = $scope.Student.PostCity;
                 $scope.Address.PostalCode = $scope.Student.PostPostalCode;
                 // call api again
             }
        }

        function saveStudentFailed() {
            notificationService.displayError('Account set up Failed');
        }



        //function saveStudentCompleted() {
        //    notificationService.displayInfo('Account set up complete.');
        //    $location.path('/bursify/student/home');
        //}
    

        var self = this, j = 0, counter = 0;
        self.mode = 'query';
        self.activated = true;
        self.determinateValue = 30;
        self.determinateValue2 = 30;
        self.showList = [];
        /**
         * Turn off or on the 5 themed loaders
         */
        self.toggleActivation = function () {
            if (!self.activated) self.showList = [];
            if (self.activated) {
                j = counter = 0;
                self.determinateValue = 30;
                self.determinateValue2 = 30;
            }
        };
        $interval(function () {
            self.determinateValue += 1;
            self.determinateValue2 += 1.5;
            if (self.determinateValue > 100) self.determinateValue = 30;
            if (self.determinateValue2 > 100) self.determinateValue2 = 30;
            // Incrementally start animation the five (5) Indeterminate,
            // themed progress circular bars
            if ((j < 2) && !self.showList[j] && self.activated) {
                self.showList[j] = true;
            }
            if (counter++ % 4 == 0) j++;
            // Show the indicator in the "Used within Containers" after 200ms delay
            if (j == 2) self.contained = "indeterminate";
        }, 100, 0, true);
        $interval(function () {
            self.mode = (self.mode == 'query' ? 'determinate' : 'query');
        }, 7200, 0, true);


    }

})(angular.module('BursifyApp'));

