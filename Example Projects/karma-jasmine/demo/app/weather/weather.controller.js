(function() {
    'use strict';

    angular
        .module('app')
        .controller('WeatherController', WeatherController);

    WeatherController.$inject = ['WeatherFactory'];

    /* @ngInject */
    function WeatherController(WeatherFactory) {
        var vm = this;
        vm.title = 'WeatherController';

        getWeather();



        var msg = "Our Code Blog";

        function show() {

            var msg = "Hello World !";

            console.log("Value of 'msg' inside the function " + msg);

        }

        console.log("Value of 'msg' outside the function : " + msg);


        show();







        function getWeather() {
            WeatherFactory.getWeather().then(
                function(data) {

                    vm.results = data;

                },
                function(error) {
                    vm.error = 'There has been an error!';
                });
        }
    }
})();
