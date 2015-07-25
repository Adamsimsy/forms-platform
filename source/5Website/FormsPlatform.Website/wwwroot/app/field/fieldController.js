(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('fieldController', fieldController);

    fieldController.$inject = ['$scope'];

    function fieldController($scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.id = $scope.field.Id;
        vm.label = $scope.field.Label;
        vm.defaultValue = $scope.field.Value;

        activate();

        function activate() { }
    }
})();
