(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['form'];

    function formController(form) {

        var vm = this;

        vm.form = form;

        //formsetFactory.get({ id: 1 }, function (data) {
        //    vm.form = data.Forms[1];
        //});

        activate();        

        function activate() { }
    }
})();
