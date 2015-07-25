(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formsController', formsController);

    formsController.$inject = ['$scope', 'formsetFactory'];

    function formsController($scope, formsetFactory) {

        var vm = this;
        vm.title = "Forms list";

        formsetFactory.query( function (data) {
            vm.formSets = data;
        });

        activate();        

        function activate() { }
    }
})();
