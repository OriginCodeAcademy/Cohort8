# San Diego Top Spots with Error Handling

There are some great places to see in downtown San Diego. In this project you'll retro-fit the ever popular San Diego Top Spots app so that it can handle errors gracefully and report various conditions to the UI.

<img src="http://i.imgur.com/4UU4Ye4.png" />

## Toastr
1. Install angular-toastr using Bower. Be sure and save it to your dependencies in bower.json.
2. Inject toastr into the top-level module of your application.
3. Inject toastr into your TopSpots controller.

## Tasks
1. If you haven't done so already, move the $http call that retrieves the 'topspots.json' data file into a factory and inject it into your controller.
2. Inject the $q service into the factory, add an error handler method to the response routine and implement the $q promise logic as demonstrated in class.
3. Add a custom error handler for the use case where no data was returned by the $http call.
4. Add a success toastr to the controller to render when the call completes without error.
5. Add an info toastr to the controller to render when the call completes but with no data returned.
6. Add an error toastr to the controller to render when the call errors out.


## Turn In Instructions
* Push your changes to GitHub using `git push origin master`
* [Click here to create an issue in the class repository](https://www.github.com/OriginCodeAcademy/Cohort8/issues/new?title=10-TopSpotsAngular-ErrorHandling&body=1.%20Where%20can%20I%20find%20your%20repository%3F%20(Paste%20the%20url%20of%20your%20repository%20below)%0A%0A2.%20What%20did%20you%20enjoy%20most%20about%20this%20project%3F%0A%0A3.%20What%20was%20the%20toughest%20part%3F%0A%0A)
    * Include a link to your repository in the description
    * Answer the questions filled out for you in the description