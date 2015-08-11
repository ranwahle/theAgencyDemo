using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TheAgency.Models
{
	public class ObservationRepository : IObservationRepository
	{
		private AgencyManagerContext _database = new AgencyManagerContext();

		public Observation Get(string agentId, DateTime date)
		{
			var query = from agent in _database.Agents						
						from obs in agent.Observations
						where agent.Id == agentId && obs.Date == date
						select obs;

			query = query.Include(o => o.ObservedNemeses);
			Observation observation = query.FirstOrDefault();		

			return observation;
		}

		public IEnumerable<Observation> GetAll(string agentId)
		{
			var query = from agent in _database.Agents
						from observation in agent.Observations
						where agent.Id == agentId
						select observation;

			query = query.Include(o => o.ObservedNemeses);
			return query.ToList();

		}

		public Observation AddOrUpdate(string agentId, int[] nemesesIds, Observation observation)
		{
			// Check if observation already exists
			Agent agent = 
				(from a in _database.Agents.Include(ag=>ag.Observations.Select(o => o.ObservedNemeses))
				where a.Id == agentId
				select a).FirstOrDefault();
									
			var existingObservation = agent.Observations.FirstOrDefault(o=>o.Date == observation.Date);
			
			if (existingObservation == null)
			{
				// New, just take the observation object
				existingObservation = observation;				
				existingObservation.ObservedNemeses = new List<Nemesis>();
				agent.Observations.Add(existingObservation);				
			}
			else
			{
				// Existing, update the observation object
				existingObservation.Description = observation.Description;
				existingObservation.Priority = observation.Priority;				
				existingObservation.ObservedNemeses.Clear();
			}			

			foreach (int id in nemesesIds)
			{
				Nemesis nemesis = _database.Nemeses.Find(id);
				existingObservation.ObservedNemeses.Add(nemesis);
			}
						
			_database.SaveChanges();

			return existingObservation;
		}

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}