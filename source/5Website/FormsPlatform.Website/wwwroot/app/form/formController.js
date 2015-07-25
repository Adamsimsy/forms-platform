(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['$scope'];

    function formController($scope) {

        var vm = this;
        vm.title = $scope.form.Title;
        vm.fields = $scope.form.Fields;

        activate();        

        function activate() { }
    }
})();
