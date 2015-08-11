using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAgency.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TheAgency.Models
{
	public class Observation
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[ScaffoldColumn(false)]
		public int Id { get; set; }
		[ScaffoldColumn(false)]
		public DateTime Date { get; set; }		
		public string Description { get; set; }			

		// This property will not be mapped
		[JsonIgnore]
		[XmlIgnore]
		[IgnoreDataMember]
		[Column("Priority")]
		[ScaffoldColumn(false)]
		public int PriorityValue { get; set; }

		public Priorities Priority
		{
			get { return (Priorities)PriorityValue; }
			set { PriorityValue = (int)value; }
		}

		[ScaffoldColumn(false)]
		[Display(Name="Nemeses observed")]
		public ICollection<Nemesis> ObservedNemeses { get; set; }
	}
}