(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('navigationController', navigationController);

    navigationController.$inject = ['$scope', '$location', 'formsetFactory'];
    
    function navigationController($scope, $location, formsetFactory) {
        /* jshint validthis:true */
        var vm = this;

        formsetFactory.query(function (data) {
            vm.forms = data[0].Forms;
            vm.formSetId = data[0].Id;
        });

        activate();

        function activate() {
        }
    }
})();
