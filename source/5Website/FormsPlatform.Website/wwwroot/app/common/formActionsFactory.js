(function () {
    'use strict';

    angular
        .module('commonServices')
        .factory('formActionsFactory', ['$resource', formActionsFactory]);

    function formActionsFactory($resource) {
        return $resource('/api/formactions');
    }
})();