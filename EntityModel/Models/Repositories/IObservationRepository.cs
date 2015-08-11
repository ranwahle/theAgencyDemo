using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAgency.Models
{
	public interface IObservationRepository : IDisposable
	{
		Observation Get(string agentId, DateTime date);
		IEnumerable<Observation> GetAll(string agentId);
		Observation AddOrUpdate(string agentId, int[] nemesesIds, Observation observation);
	}
}
