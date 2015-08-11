(function (angular) {

    var service  = function($http)
    {
        this.getAgents = function () {
            var promise = $http({
                url: 'api/Agents',
                method: 'get'
            });

            return promise;
        };

        this.createAgent = function (agent) {
            var promise = $http({
                url: 'api/Agents',
                method: 'post',
                data: agent

            });

            return promise;
        };

       
    }
    angular.module('agents').service('agentsService', ['$http', service]);

}(window.angular));