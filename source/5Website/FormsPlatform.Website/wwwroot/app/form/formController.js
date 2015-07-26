(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['form', 'formsetFactory', 'formActionsFactory'];

    function formController(form, formsetFactory, formActionsFactory) {

        var vm = this;

        vm.form = form;

        //formsetFactory.get({ id: 1 }, function (data) {
        //    vm.form = data.Forms[1];
        //});

        activate();        

        function activate() { }

        vm.previous = function () {
            //vm.form.$save();
            formActionsFactory.save({ direction: 'previous' },vm.form);
        }

        vm.next = function () {
            //vm.form.$save();
            formActionsFactory.save({ direction: 'next' }, vm.form);
        }
    }
})();
