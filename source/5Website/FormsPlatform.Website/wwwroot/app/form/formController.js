(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['form', 'formsetFactory', 'formActionsFactory', '$state', '$stateParams'];

    function formController(form, formsetFactory, formActionsFactory, $state, $stateParams) {

        var vm = this;

        vm.form = form;

        //formsetFactory.get({ id: 1 }, function (data) {
        //    vm.form = data.Forms[1];
        //});

        activate();        

        function activate() { }

        vm.previous = function () {
            invokeNextAction('previous');
        }

        vm.next = function () {
            invokeNextAction('next');
        }

        function invokeNextAction(direction) {
            var nextState = formActionsFactory.save({ formsetId: $stateParams.formsetId, direction: direction }, vm.form, function (data) {
                $state.go('form', { formsetId: data.FormsetId, formId: data.FormId });
            });
        }
    }
})();
