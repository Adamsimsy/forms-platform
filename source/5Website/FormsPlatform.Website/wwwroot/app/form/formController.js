(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formController', formController);

    formController.$inject = ['formset'];

    function formController(formset) {

        var vm = this;

        vm.form = formset.Forms[0];

        //formsetFactory.get({ id: 1 }, function (data) {
        //    vm.form = data.Forms[1];
        //});

        activate();        

        function activate() { }
    }
})();
