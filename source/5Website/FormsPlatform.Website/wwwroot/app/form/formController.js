(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['$scope', 'formsetFactory'];

    function formController($scope, formsetFactory) {

        var vm = this;

        formsetFactory.get({ id: 1 }, function (data) {
            vm.form = data.Forms[1];
        });

        activate();        

        function activate() { }
    }
})();
