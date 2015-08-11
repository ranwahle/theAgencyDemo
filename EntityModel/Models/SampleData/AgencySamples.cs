using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace TheAgency.Models
{
	public static class ConcurrentDictionaryExtender
	{
		public static void AddOrUpdate<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			dictionary.AddOrUpdate(key, value, (s, val) => val);
		}

	}

	public class AgencySamples
	{
		private static ConcurrentDictionary<string, Agent> _agents = new ConcurrentDictionary<string, Agent>();
		private static ConcurrentDictionary<int, Nemesis> _nemeses = new ConcurrentDictionary<int, Nemesis>();
		private static ConcurrentDictionary<int, Observation> _observations = new ConcurrentDictionary<int, Observation>();

		static AgencySamples()
		{
			// Initialize the in-memory store once

			_agents.AddOrUpdate("bond", new Agent { Id = "Bond", Alias = "007", FullName = "James Bond", Version = 1, Nemeses = new List<Nemesis>(), Observations = new List<Observation>() });
			_agents.AddOrUpdate("powers", new Agent { Id = "Powers", Alias = "Danger", FullName = "Austin Powers", Version = 1, Nemeses = new List<Nemesis>(), Observations = new List<Observation>() });
			_agents.AddOrUpdate("bourne", new Agent { Id = "Bourne", Alias = "Delta-One", FullName = "Jason Bourne",  Version = 1, Nemeses = new List<Nemesis>(), Observations = new List<Observation>() });
			_agents.AddOrUpdate("bristow", new Agent { Id = "Bristow", Alias = "Bluebird", FullName = "Sydney Bristow", Version = 1, Nemeses = new List<Nemesis>(), Observations = new List<Observation>() });
            _agents.AddOrUpdate("english", new Agent { Id = "English", Alias = "Mr. Bean", FullName = "Johnny English", Version = 1, Nemeses = new List<Nemesis>(), Observations = new List<Observation>() });

			_nemeses.AddOrUpdate(1, new Nemesis { Id = 1, Name = "Dr. Evil", IsAlive = true });
			_nemeses.AddOrUpdate(2, new Nemesis { Id = 2, Name = "Dr. No", IsAlive = false});
			_nemeses.AddOrUpdate(3, new Nemesis { Id = 3, Name = "Goldfinger", IsAlive = false});
			_nemeses.AddOrUpdate(4, new Nemesis { Id = 4, Name = "Goldmember", IsAlive = true});
			_nemeses.AddOrUpdate(5, new Nemesis { Id = 5, Name = "Stavro", IsAlive = false});
			_nemeses.AddOrUpdate(6, new Nemesis { Id = 6, Name = "Patty O’Brien", IsAlive = false });
			_nemeses.AddOrUpdate(7, new Nemesis { Id = 7, Name = "Leonid Arkadin", IsAlive = true });
			_nemeses.AddOrUpdate(8, new Nemesis { Id = 8, Name = "Alexander Conklin", IsAlive = false });
			_nemeses.AddOrUpdate(9, new Nemesis { Id = 9, Name = "Allison ", IsAlive = false });
            _nemeses.AddOrUpdate(10, new Nemesis { Id = 10, Name = "Pascal Sauvage", IsAlive = true });
			
			_observations.AddOrUpdate(1, new Observation { Id = 1, Date = new DateTime(1958, 4, 4), Description = "Selling missiles", Priority = Priorities.RedAlert, ObservedNemeses = new List<Nemesis>() });
			_observations.AddOrUpdate(2, new Observation { Id = 2, Date = new DateTime(1997, 7, 23), Description = "Attaching laser to a shark", Priority = Priorities.High, ObservedNemeses = new List<Nemesis>() });
			_observations.AddOrUpdate(3, new Observation { Id = 3, Date = new DateTime(1964, 1, 4), Description = "Entering a casino", Priority = Priorities.Low, ObservedNemeses = new List<Nemesis>() });
			_observations.AddOrUpdate(4, new Observation { Id = 4, Date = new DateTime(2007, 12, 20), Description = "Buying ammunition", Priority = Priorities.High, ObservedNemeses = new List<Nemesis>() });
			_observations.AddOrUpdate(5, new Observation { Id = 5, Date = new DateTime(1997, 7, 15), Description = "Planting a bomb", Priority = Priorities.RedAlert, ObservedNemeses = new List<Nemesis>() });
			_observations.AddOrUpdate(6, new Observation { Id = 6, Date = new DateTime(1981, 7, 15), Description = "Petting his cat", Priority = Priorities.Guarded, ObservedNemeses = new List<Nemesis>() });
            _observations.AddOrUpdate(7, new Observation { Id = 7, Date = new DateTime(2003, 2, 21), Description = "Stealing the crown jewels", Priority = Priorities.Guarded, ObservedNemeses = new List<Nemesis>() });

			_observations[1].ObservedNemeses.Add(_nemeses[2]);
			_observations[2].ObservedNemeses.Add(_nemeses[1]);
			_observations[2].ObservedNemeses.Add(_nemeses[3]);
			_observations[3].ObservedNemeses.Add(_nemeses[3]);
			_observations[4].ObservedNemeses.Add(_nemeses[8]);
			_observations[5].ObservedNemeses.Add(_nemeses[6]);
			_observations[6].ObservedNemeses.Add(_nemeses[5]);
            _observations[7].ObservedNemeses.Add(_nemeses[10]);

			_agents["bond"].Observations.Add(_observations[1]);
			_agents["powers"].Observations.Add(_observations[2]);
			_agents["bond"].Observations.Add(_observations[3]);
			_agents["bourne"].Observations.Add(_observations[4]);
			_agents["powers"].Observations.Add(_observations[5]);
			_agents["bond"].Observations.Add(_observations[6]);
            _agents["english"].Observations.Add(_observations[7]);

			_agents["bond"].Nemeses.Add(_nemeses[2]);
			_agents["bond"].Nemeses.Add(_nemeses[3]);
			_agents["bond"].Nemeses.Add(_nemeses[5]);			
			_agents["powers"].Nemeses.Add(_nemeses[1]);
			_agents["powers"].Nemeses.Add(_nemeses[4]);
			_agents["powers"].Nemeses.Add(_nemeses[6]);
			_agents["bourne"].Nemeses.Add(_nemeses[7]);
			_agents["bourne"].Nemeses.Add(_nemeses[8]);
			_agents["bristow"].Nemeses.Add(_nemeses[9]);
            _agents["english"].Nemeses.Add(_nemeses[10]);
		}

		public static ConcurrentDictionary<string, Agent> Agents
		{
			get
			{
				return _agents;
			}
		}
		public static ConcurrentDictionary<int, Nemesis> Nemeses
		{
			get
			{
				return _nemeses;
			}
		}
		public static ConcurrentDictionary<int, Observation> Observations
		{
			get
			{
				return _observations;
			}
		}



	}
}