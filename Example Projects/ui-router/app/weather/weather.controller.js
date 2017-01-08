(function() {
    'use strict';

    angular
        .module('app')
        .controller('WeatherController', WeatherController);

    WeatherController.$inject = ['WeatherFactory', '$scope'];

    /* @ngInject */
    function WeatherController(WeatherFactory, $scope) {
        var vm = this;
        vm.title = 'WeatherController';

        getWeather();

        function getWeather() {
            WeatherFactory.getWeather().then(
                function(data) {

                    vm.results = data;

                }).catch(function() {
                vm.error = 'There has been an error!';
            });
        }

    }
})();
