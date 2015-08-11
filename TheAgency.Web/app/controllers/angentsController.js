(function (angular) {

    var controller = function ($http) {

        var self = this, promise = $http({
            url: 'api/Agents',
            method: 'get'
        })
        .success(function(data)
        {
            self.agents = data;
        });
    };

    angular.module('agents').controller('agentsController', ['$http', controller]);

}(window.angular));