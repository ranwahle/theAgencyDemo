using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheAgency.Models;
using TheAgency.Web.Hubs;

namespace TheAgency.Web.Controllers
{
    public class AgentsController : ApiController
    {
        public IEnumerable<Agent> Get()
        {
            AgentRepository repository = new AgentRepository();
            return repository.GetAll().ToList();
        }

        [Route("Agents/{id:int}")]
        public Agent Get(int id)
        {
            return new Agent { Id = id.ToString() };
        }

        [HttpPost]
        public void CreateAgent(Agent agent)
        {
            if (agent == null)
            {
                //throw new HttpResponseException(new HttpResponseMessage
                //    {
                //        StatusCode = HttpStatusCode.BadRequest,
                //        ReasonPhrase = "Agent Cannot be null"
                //    });
                ModelState.AddModelError("Agent", "Agent cannot be null");
            }
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest
                        //ReasonPhrase = ModelState.
                    }); 
            }
            AgentRepository repository = new AgentRepository();
            repository.Add(agent);
            var context = GlobalHost.ConnectionManager.GetHubContext<AgentsHub>();
            context.Clients.All.addNewAgent(agent);
            //HttpResponseMessage response = RequesBt.CreateResponse<Agent>
            //    (HttpStatusCode.Created, agent);

            //return response;

        }
    }
}
