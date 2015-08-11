using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheAgency.Models
{
	[Table("Nemeses")]
	public class Nemesis
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsAlive { get; set; }
		[JsonIgnore]
		[XmlIgnore]
		[IgnoreDataMember]
		public ICollection<Observation> Observations { get; set; }
	}
}