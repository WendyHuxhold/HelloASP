namespace HelloASP.Controllers {

    export class CityListController {

        public cities;

        // private is an access modifier, and it is dependency injected
        constructor(private $http: ng.IHttpService) {
            $http.get('/api/cities').then((response) => {
                this.cities = response.data;
            }).catch((response) => {
                console.log(response);
            });
        }
    }

    export class CityController {
        public name: string;
        public forecasts: any[];
        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
            $http.get<any>(`/api/cities/${$stateParams['state']}/${$stateParams['cityName']}`)
                .then((response) => {
                    this.name = response.data.name;
                    this.forecasts = response.data.forecasts;
                })
        }
    }

    //    export class AddCityController {
    //        //not good to put $http in the constructor because there won't be data yet
    //        constructor(private $http: ng.IHttpService) { }

    //        public addCity() 
    //        this.$http.post('url', city)
    //        }
    //}

    export class AddCityController {
        //not good to put $http in the constructor because there won't be data yet
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) { }

        public addCity(city, currentTemp, currentDesc) {
            this.$http.post('/api/cities',{
                city: city,
                temp: currentTemp,
                description: currentDesc
            })
                .then((response) => {
                    console.log(response);
                    this.$state.go("home");
                })
                .catch((response) => {
                    console.log(response.data);
                });

        }
    }



}
