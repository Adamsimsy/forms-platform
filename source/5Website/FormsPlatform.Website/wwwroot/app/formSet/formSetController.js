(function () {
    'use strict';

    angular
        .module('formsClient')
        .controller('formsetController', formsetController);

    formsetController.$inject = ['$http']; 

    function formsetController($http) {
        /* jshint validthis:true */
        var vm = this;
        activate();

        function activate() {

            $http.get('/api/formset').
              success(function (data, status, headers, config) {
                  // this callback will be called asynchronously
                  // when the response is available
                  vm.formSet = data[0];
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
        }
    }
})();
