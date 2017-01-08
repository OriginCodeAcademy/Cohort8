"use strict";

// describe the feature under test
describe("weather api factory tests", function() {
    var WeatherFactory, httpBackend, toastr;

    // setup the top level module
    beforeEach(angular.mock.module("app"));

    // inject the factory httpBackend
    beforeEach(inject(function(_WeatherFactory_, $httpBackend) {
        WeatherFactory = _WeatherFactory_;
        httpBackend = $httpBackend;
        toastr = toastr;
    }));

    afterEach(function() {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    // verify we can access the method we need to test
    it("should have a getWeather method", function() {
        expect(angular.isFunction(WeatherFactory.getWeather)).toBe(true);
    })

    // verify the expected response
    it("should return a valid response", function() {

        // setup httpBackend
        httpBackend
            .whenGET("http://api.openweathermap.org/data/2.5/weather?APPID=9df2180a41f8a77f7f435abb28cafd81&id=524901")
            .respond({ name: "Moscow" });

        toastr = {
            success: function(message, title, options) {

            }
        }

        spyOn(toastr, 'success');

        // fake the call to the api
        WeatherFactory.getWeather({ APPID: "9df2180a41f8a77f7f435abb28cafd81", id: 524901 })

        // test the response
        .then(function(response) {
            expect(response.data.name).toBe("Moscow");
            expect(response.status).toEqual(200);
        });

        httpBackend.flush();

    });

    it("should throw an error on a server exception", function() {
        var result, error;

        // setup httpBackend
        httpBackend
            .expectGET("http://api.openweathermap.org/data/2.5/weather?APPID=9df2180a41f8a77f7f435abb28cafd81&id=524901")
            .respond(500);

        var promise = WeatherFactory.getWeather({ APPID: "9df2180a41f8a77f7f435abb28cafd81", id: 524901 });

        promise.then(function(data) {
            result = data;
        }, function(data) {
            error = data;
        });

        httpBackend.flush();

        // test the response
        expect(result).toBeUndefined();
        expect(error.status).toEqual(500);

    });

});
