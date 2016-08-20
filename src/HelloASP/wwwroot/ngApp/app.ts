namespace HelloASP {

    angular.module('HelloASP', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/cityList.html',
                controller: HelloASP.Controllers.CityListController,
                controllerAs: 'controller'

            })
            //weather/"city"
            .state('weather', {
                url: '/weather/:state/:cityName',
                templateUrl: '/ngApp/views/cityWeather.html',
                controller: HelloASP.Controllers.CityController,
                controllerAs: 'controller'
            })
            .state('addCity', {
                url: '/addCity',
                templateUrl: '/ngApp/views/newCity.html',
                controller: HelloASP.Controllers.AddCityController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });



}
