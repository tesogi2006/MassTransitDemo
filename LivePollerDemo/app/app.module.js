(function() {
    'use strict';

    angular
        .module('poller')
        .config(appRoutes);
    appRoutes.$inject = ['$routeProvider'];

    function appRoutes($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'app/partials/home.template.html'
            })
            .otherwise({ redirectTo: '/' });
    }
})();