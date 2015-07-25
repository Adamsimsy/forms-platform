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
                url: "/form/:formsetId",
                templateUrl: "app/form/formview.html",
                controller: "formController as vm",
                resolve:
                    {
                        formsetFactory: "formsetFactory",

                        formset: function (formsetFactory, $stateParams) {
                            var formsetId = $stateParams.formsetId;

                            return formsetFactory.get({formsetId:formsetId}).$promise;
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