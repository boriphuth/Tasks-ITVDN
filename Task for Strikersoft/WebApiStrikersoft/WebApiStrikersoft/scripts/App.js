var module = angular.module("ClinicModule", []);
var controller = module.controller("clinCtrl", function ($scope, $http) {
    $scope.report = [
        //{ ID: "", PatientName: "", PatientAge: "", CurrentDoctorName: "", VisitDoctorName: "", Diagnosise: "", VisitDate: "" }
    ];
    $scope.patients = [
         //{ ID: "", Name: "", Age: "", CurrentDoctorID: "" }
    ];
    $scope.doctors = [
        //{ ID: "", Name: "" }
    ];
    $scope.records = [
        //{ ID: "", PatienID: "", DoctorID: "", Diagnosise: "", VisitDate: "" }
    ];
    $scope.addDoctor = function (doctor) {
        if (angular.isDefined(doctor) && angular.isDefined(doctor.Name)) {
            $scope.addNewDoctor(doctor);
            $scope.doctor = {};
        }
    }
    $scope.addPatient = function (patient) {
        if (angular.isDefined(patient) && angular.isDefined(patient.Name)) {
            $scope.addNewPatient(patient);
            $scope.patient = {};
        }
    }

    $scope.loadDoctors = function () {
        $http.get('/api/doctors').
         success(function (data) {
             $scope.doctors = data;
         })
    };
    $scope.addNewDoctor = function (doctor) {
        doctor.ID = "";
        $http.post('/api/doctors',doctor).
         success(function (data) {
             $scope.loadDoctors();
         })
    };
    $scope.loadPatients = function () {
        $http.get('/api/patients').
         success(function (data) {
             $scope.patients = data;
         })
    };
    $scope.addNewPatient = function (patient) {
        patient.ID = "";
        $http.post('/api/patients', patient).
         success(function (data) {
             $scope.loadPatients();
         })
    };
    $scope.loadReport = function () {
        $http.get('/api/report').
         success(function (data) {
             $scope.report = data;
         })
    };
   
});


