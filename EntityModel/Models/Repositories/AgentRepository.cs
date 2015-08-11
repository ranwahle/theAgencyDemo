using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;
using System.Data.Entity.Infrastructure;

namespace TheAgency.Models
{
	public class AgentRepository : IAgentRepository
	{
		private AgencyManagerContext _database = new AgencyManagerContext();

		private Agent GetAgent(string id)
		{
			return _database.Agents.FirstOrDefault(a => a.Id == id);
		}

		public void Update(Agent updatedAgent)
		{
			Agent agent = GetAgent(updatedAgent.Id);
			agent.Alias = updatedAgent.Alias;
			agent.FullName = updatedAgent.FullName;			
			agent.Version++;

			_database.SaveChanges();
		}

		public Agent Get(string id)
		{
			return GetAgent(id);
		}

		public IQueryable<Agent> GetAll()
		{
			return _database.Agents;
		}

		public Agent Add(Agent agent)
		{
			agent.Version = 1;
			_database.Agents.Add(agent);
			_database.SaveChanges();
			return agent;
		}

		public Agent Delete(string id)
		{
			Agent agent = GetAgent(id);
			
			if (agent == null)
			{
				return null;
			}

			_database.Agents.Remove(agent);

			try
			{
				_database.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return null;
			}

			return agent;
		}

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}