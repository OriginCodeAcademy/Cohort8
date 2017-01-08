describe('weather controller unit tests', function() {

    beforeEach(angular.mock.module('app'));
    var $scope;
    var $controller;
    var $q;
    var deferred;
    var vm;

    describe('with mock of weather factory', function() {
        beforeEach(inject(function(_$controller_, _$rootScope_, _$q_, WeatherFactory) {
            $scope = _$rootScope_.$new();
            $controller = _$controller_;
            $q = _$q_;
            deferred = _$q_.defer();

            // Jasmine Spy to return the deferred object for the getWeather method
            spyOn(WeatherFactory, 'getWeather').and.returnValue(deferred.promise);

            // init controler, passing in spy service
            vm = $controller('WeatherController', {
                $scope: $scope,
                weatherFactory: WeatherFactory
            })
        }));

        it('should return a promise', function() {
            deferred.resolve([{ name: "Moscow" }]);

            $scope.$apply();

            expect(vm.title).toBe("WeatherController");
            expect(vm.results).not.toBe(undefined);
            expect(vm.error).toBe(undefined);
            expect(vm.results[0].name).toBe("Moscow")
        });

        it('should reject promise', function() {
            // reject the promise
            deferred.reject();

            $scope.$apply();

            expect(vm.results).toBe(undefined);
            expect(vm.error).toBe('There has been an error!');
        })

    });
});
