using System;
using System.Data.Entity;

namespace TheAgency.Models
{
    public class AgencyManagerDatabaseInitializer : DropCreateDatabaseIfModelChanges<AgencyManagerContext>
    {
         protected override void Seed(AgencyManagerContext context)
        {
            base.Seed(context);

			foreach (var agent in AgencySamples.Agents.Values)
            {
                context.Agents.Add(agent);
            }
        }
    }
}
