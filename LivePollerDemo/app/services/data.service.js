(function() {
    'use strict';

    angular
        .module('poller')
        .service('dataService', dataService);

    dataService.$inject = ['$http'];

    function dataService($http) {
        this.getDataPoint = getDataPoint;

        function getDataPoint() {
            var apiCall = $http({
                method: 'GET',
                url: 'api/data/get'
            });

            var promise = apiCall.then(function(result) {
                var data = result.data;
                return data;
            });

            return promise;
        }
    }
})();