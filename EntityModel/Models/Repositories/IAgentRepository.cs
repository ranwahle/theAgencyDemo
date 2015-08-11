using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAgency.Models
{
	public interface IAgentRepository : IDisposable
	{
		void Update(Agent updatedAgent);		

		Agent Get(string id);

		IQueryable<Agent> GetAll();

		Agent Add(Agent agent);

		Agent Delete(string id);
	}
}
