﻿(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('navigationController', navigationController);

    navigationController.$inject = ['$scope', '$location', 'formsetFactory'];
    
    function navigationController($scope, $location, formsetFactory) {
        /* jshint validthis:true */
        var vm = this;

        formsetFactory.get({id : 1}, function (data) {
            vm.forms = data.Forms;
            vm.formSetId = data.Id;
        });

        activate();

        function activate() {
        }
    }
})();
