(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('fieldController', fieldController);

    fieldController.$inject = ['$scope'];

    function fieldController($scope) {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() { }
    }
})();
