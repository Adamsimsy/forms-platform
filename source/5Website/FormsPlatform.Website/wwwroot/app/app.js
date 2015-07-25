(function () {
    'use strict';

    var app = angular.module('formsClient', [
        // Angular modules 
        'ngResource'
        // Custom modules 
        , 'commonServices'
        // 3rd Party Modules  
        , 'ui.router'
    ]);

    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/forms");

        $stateProvider
            .state("form",
            {
                url: "/form/:formsetId/:formId",
                templateUrl: "app/form/formview.html",
                controller: "formController as vm",
                resolve:
                    {
                        formsetFactory: "formsetFactory",

                        form: function (formsetFactory, $stateParams) {
                            var formsetId = $stateParams.formsetId;
                            var formId = $stateParams.formId;

                            return formsetFactory.get({ formsetId: formsetId, formId: formId }).$promise;
                        }
                    }
            })
            .state("forms",
            {
                url: "/forms",
                templateUrl: "app/forms/formsview.html",
                controller: "formsController as vm"
            })
    }
    ]);

})();