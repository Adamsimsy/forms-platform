(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('navigationController', navigationController);

    navigationController.$inject = ['$scope', '$location'];
    
    function navigationController($scope, $location) {
        /* jshint validthis:true */

  
        var vm = this;
        vm.formSetId = $scope.$parent.vm.formSet.Id;
        vm.forms = $scope.$parent.vm.formSet.Forms;
        activate();

        function activate() {
        }
    }
})();
