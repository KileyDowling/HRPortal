var myApp = angular.module('demoApp', []);

myApp.controller('mainController',function($scope, $filter, $http) {
    $http.get('/api/EmployeeDirectory')
        .success(function(result) {
            $scope.employees = result;
        })
    .error(function(data, status) {

        console.log(data);
            console.info(status);
        });

});