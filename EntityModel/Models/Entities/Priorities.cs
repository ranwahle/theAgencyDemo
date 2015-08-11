using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TheAgency.Models
{
	public enum Priorities
	{
		[Description("Low")]
		Low,
		[Description("Guarded")]
		Guarded,
		[Description("High")]
		High,
		[Description("Red Alert!")]
		RedAlert
	}
}
