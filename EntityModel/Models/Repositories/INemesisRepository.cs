using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAgency.Models
{
	public interface INemesisRepository : IDisposable
	{
		Nemesis Get(string agentId, int id);
		IQueryable<Nemesis> GetAll(string agentId);
		Nemesis Delete(string agentId, int id);
	}
}
