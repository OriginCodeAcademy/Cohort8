(function() {
    'use strict';

    angular
        .module('app')
        .factory('WeatherFactory', WeatherFactory);

    WeatherFactory.$inject = ['$http', '$q'];

    /* @ngInject */
    function WeatherFactory($http, $q) {

        var service = {
            getWeather: getWeather
        };

        return service;

        ////////////////

        function getWeather() {

            var defer = $q.defer();

            $http({
                method: 'GET',
                url: 'http://api.openweathermap.org/data/2.5/weather',
                params: {
                    APPID:'9df2180a41f8a77f7f435abb28cafd81',
                    id: 524901}
            })
            .then(
                // success
                function(response){
                    if(typeof response.data === 'object'){
                        defer.resolve(response);        
                        toastr.success('We have weather!');
                    } else {
                        defer.reject(response);
                    }
                },
                // failure
                function(error) {
                    defer.reject(error);

                });

                return defer.promise;
            }
    }
})();