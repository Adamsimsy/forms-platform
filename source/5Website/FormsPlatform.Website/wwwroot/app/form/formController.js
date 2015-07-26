(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['form', 'formsetFactory', 'formActionsFactory', '$state'];

    function formController(form, formsetFactory, formActionsFactory, $state) {

        var vm = this;

        vm.form = form;

        //formsetFactory.get({ id: 1 }, function (data) {
        //    vm.form = data.Forms[1];
        //});

        activate();        

        function activate() { }

        vm.previous = function () {
            //vm.form.$save();
            var nextState = formActionsFactory.save({ direction: 'previous' }, vm.form, function (data) {
                $state.go('form', { formsetId: data.FormsetId, formId: data.FormId });
            });
        }

        vm.next = function () {
            //vm.form.$save();
            var nextState = formActionsFactory.save({ direction: 'next' }, vm.form, function (data) {
                $state.go('form', { formsetId: data.FormsetId, formId: data.FormId });
            });
        }
    }
})();
