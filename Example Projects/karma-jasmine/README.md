# Angular Unit Test Demo

## Setup

### Installing Karma and plugins

Navigate to the webroot of the project you wish to test.

npm init  (accept the defaults)

#### Install Karma:
$ npm install karma --save-dev

#### Install Jasmine:
$ npm install jasmine-core --save-dev

#### Install plugins that your project needs:
$ npm install karma-jasmine karma-chrome-launcher --save-dev 

This will install karma, jasmine-core, karma-jasmine and karma-chrome-launcher packages into node_modules in your current working directory and also save these as devDependencies in package.json, so that any other developer working on the project will only have to do npm install in order to get all these dependencies installed.

#### Install Karma Commandline Interface
$ npm install -g karma-cli

#### Install the Angular Mocking library using bower
$ bower install angular-mocks

Now, you can run Karma simply by typing karma from anywhere and it will always run the local version.

#### Create a tests folder
mkdir tests

#### Define the karma configuration file

$ karma init karma.conf.js

Answer the prompts as follows:

Which testing framework do you want to use?
Hit return to accept the default value i.e. jasmine.

Do you want to use Require.js ?
Hit return to accept the default value i.e. no.

Do you want to capture any browsers automatically ?
Hit return to accept the default value i.e. Chrome.

What is the location of your source and test files ?
Enter the following value:

tests/*.spec.js
Don’t worry if you accidentally skipped this, we can directly edit the config file at a later stage.

Should any of the files included by the previous patterns be excluded ?
Hit return to accept the default value.

Do you want Karma to watch all the files and run the tests on change ?
Hit return to accept the default value. i.e. yes

The config file called karma.conf.js will be created in the root folder.

We can use this file to run the tests from the Terminal/Command Prompt with the command:

karma start karma.conf.js

At this point the test output will show errors, since we have only a test with no implementation.

Enter Ctrl + C in the Terminal/Command Prompt to terminate the process.

Note: as a slight optimization I like to update the package.json with the scripts section as follows:

{
  "scripts": {
    "test": "karma start karma.conf.js"
  },
  "devDependencies": {
    "jasmine-core": "^2.3.4",
    "karma": "^0.12.31",
    "karma-chrome-launcher": "^0.1.12",
    "karma-jasmine": "^0.3.5"
  }
}
This change means that I can enter npm test rather than the specific karma configuration detail.

To verify the change to package.json, running the following from the Terminal/Command prompt will also start the karma process:

$ npm test

## Testing a Factory

#### $httpBackend

During unit testing, we want our unit tests to run quickly and have no external dependencies so we don’t want to send XHR or JSONP requests to a real server. All we really need is to verify whether a certain request has been sent or not, or alternatively, just let the application make requests, respond with pre-trained responses and assert that the end result is what we expect it to be.

This mock implementation can be used to respond with static or dynamic responses via the expect and when apis and their shortcuts (expectGET, whenPOST, etc).

There are two ways to specify what test data should be returned as http responses by the mock backend when the code under test makes http requests:

$httpBackend.expect - specifies a request expectation
$httpBackend.when - specifies a backend definition

Create a file under the tests directory to test a factory. Example: weather.service.spec.js

Edit the list of files in karma.conf.js to include the files needed for this test:

    // list of files / patterns to load in the browser
    files: [
      'bower_components/angular/angular.min.js',
      'bower_components/angular-mocks/angular-mocks.js',
      'app/app.js',
      'app/weather/weather.service.js',
      'tests/weather.service.spec.js'
    ], 

Use the recorded demo to create a unit test for a factory with the following:

A describe statement declaring what's being tested (the factory)

A beforeEach statement to setup the parent module (as defined in app.js)

A beforeEach statement injecting the factory and httpbackend service

An it statement verifying that you can access the method(s) you wish to test

An it statement testing a successful api call. For this you will need to: a) setup http backend with a whenGET method and the expected response b) call the injected service c) write expectations to test the response  d) remember to add a httpBackend.flush() after your expectations to explicitly flush the pending request.

An it statement testing the error handler of your api call. For this you will need to: a) setup http backend with an expectGet method and the expected response b) call the injected service c) flush the pending request d) write expectations to test the response.

## Testing a Controller with a Dependency

#### the Jasmine Spy

In order to simulate a dependency which the example controller has on the WeatherFactory, we will need a mock. A mock is a fake object that poses as the real McCoy in order to satisfy the inherent dependency. In Jasmine, mocks are referred to as spies. The Jasmine spyOn() method can be used to dummy an existing method of the actual factory, as well as to set the expected response.

Create a file under the tests directory to test a controller. Example: weather.controller.spec.js

As with the factory, edit the list of files in karma.conf.js to include the files needed for this test.

Use the recorded demo to create a unit test for a controller with the following:

A describe statement declaring what's being tested (the controller)

A beforeEach statement to setup the parent module (as defined in app.js)

A describe statement declaring the mock for the dependency

A beforeEach statement injecting $controller, $rootScope, $q and the weather factory dependency. Add a Jasmine spy to mock the getWeather method with a return value of the deferred promise. Initialize the test controller, and, since the example controller uses controllerAs syntax, assign it to the local variable vm for testing our results.

An it statement testing a successful call. For this you will need to a) add a statement to resolve the promise with the expected result. b) manually call the digest cycle using $scope's $apply method c) write some expectations against the vm object to verify the expected response.

An it statement testing the error handler for the call. For this you will need to a) add a statement to reject the promise. b) manually call the digest cycle using $scope's $apply method c) write some expectations against the vm object to verify the expected error message response.
