(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formSetController', formSetController);

    formSetController.$inject = ['$http']; 

    function formSetController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'formSetController';
        activate();

        function activate() {

            $http.get('/api/formset').
              success(function (data, status, headers, config) {
                  // this callback will be called asynchronously
                  // when the response is available
                  vm.title = data[0].Title;
                  vm.forms = data[0].Forms;
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
        }
    }
})();
