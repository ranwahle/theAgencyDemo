(function (angular) {

    var _agentsService, controller = function (agentsService, $scope) {
        _agentsService = agentsService;
        var self = this,
            addNewAgent = function(agent)
            {
                self.agents.push(agent);
                $scope.$applyAsync();
            },
            promise = agentsService.getAgents()
        .success(function(data)
        {
            self.agents = data;
        });

        _agentsService.subscribe('newAgent', addNewAgent);

    };

    controller.prototype.saveAgent = function () {
        
        _agentsService.createAgent(this.newAgent);
    };

    angular.module('agents').controller('agentsController', ['agentsService','$scope', controller]);

}(window.angular));