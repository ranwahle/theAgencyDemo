using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TheAgency.Models
{
	public class Agent
	{
		[Required(ErrorMessage="You must specify agent Id")]
        [StringLength(10, ErrorMessage="ID is limited to 10 characters. I'm a cheap bastard")] 
		public string Id { get; set; }
        
        [Required]
		[StringLength(100)]          
		[Display(Name="Full Name")]
		public string FullName { get; set; }

        public string Alias { get; set; }
		
        [ScaffoldColumn(false)]
		public int Version { get; set; }
		
        [ScaffoldColumn(false)]
		public ICollection<Nemesis> Nemeses { get; set; }
		
        [ScaffoldColumn(false)]
		public ICollection<Observation> Observations { get; set; }
		
        [NotMapped]        
		[ScaffoldColumn(false)]        
		public string Image { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        public string ImageLink { get; set; }

	}
}
