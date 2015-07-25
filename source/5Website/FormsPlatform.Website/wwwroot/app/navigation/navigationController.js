(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('navigationController', navigationController);

    navigationController.$inject = ['$scope', '$location', 'formsetFactory'];
    
    function navigationController($scope, $location, formsetFactory) {
        /* jshint validthis:true */
        var vm = this;

        formsetFactory.get({ id: 1 }, function (data) {
            vm.formset = data;

            //vm.formset.Title = "test";

            //vm.formset.$save(function (data) { });
        });

        

        activate();

        function activate() {
        }
    }
})();
