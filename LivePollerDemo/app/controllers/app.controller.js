(function() {
    'use strict';

    angular
        .module('poller')
        .controller('appCtrl', appCtrl);

    appCtrl.$inject = ['$timeout', 'dataService'];

    function appCtrl($timeout, dataService) {
        var vm = this;

        vm.pollApi = pollApi;
        vm.data = [];

        pollApi();
        /**********************/
        function pollApi() {
            $timeout(function() {
                dataService.getDataPoint().then(function(res) {
                    var jsonData = JSON.parse(res);
                    if (!(jsonData.pointX == 0 && jsonData.pointY == 0)) {
                        vm.data.push(jsonData);
                    }
                });
                vm.pollApi();
            }, 1000);
        }
    }
})();