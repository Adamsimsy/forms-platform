(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$http'];

    function controller($http) {
        activate();        

        function activate() {

            $http.get('/api/todo').
              success(function (data, status, headers, config) {
                  // this callback will be called asynchronously
                  // when the response is available
                  alert(data[0].Title);
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
        }
    }
})();
