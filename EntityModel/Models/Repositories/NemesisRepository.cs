using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TheAgency.Models
{
	public class NemesisRepository : INemesisRepository
	{
		private AgencyManagerContext _database = new AgencyManagerContext();

		private Agent GetAgent(string id)
		{
			return _database.Agents.First(a => a.Id == id);
		}

		public IQueryable<Nemesis> GetAll(string agentId)
		{
			var query = from agent in _database.Agents.Include(a => a.Nemeses)
						from nemesis in agent.Nemeses
						where agent.Id == agentId
						select nemesis;

			return query;
		}

		public Nemesis Get(string agentId, int id)
		{
			var query = from agent in _database.Agents.Include(a => a.Nemeses)
						from nemesis in agent.Nemeses
						where agent.Id == agentId && nemesis.Id == id
						select nemesis;

			return query.FirstOrDefault();
		}

		public Nemesis Delete(string agentId, int id)
		{
			Nemesis nemesisToDelete = (
				from agent in _database.Agents
				from nemesis in agent.Nemeses
				where agent.Id == agentId && nemesis.Id == id
				select nemesis).FirstOrDefault();

			if (nemesisToDelete == null)
			{
				return null;
			}

			// Perform logical delete
			//_database.Nemeses.Remove(nemesisToDelete);
			nemesisToDelete.IsAlive = false;

			_database.SaveChanges();

			return nemesisToDelete;
		}

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}