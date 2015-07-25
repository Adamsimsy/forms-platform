(function () {
    'use strict';

    angular
        .module('commonServices')
        .factory('formsetFactory', ['$resource', formsetFactory]);

    function formsetFactory($resource) {
        return $resource('/api/formset/:id');
    }
})();