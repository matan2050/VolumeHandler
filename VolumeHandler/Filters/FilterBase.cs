using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Filters
{
	public abstract class FilterBase
	{
		public abstract Volume RunFilter(Volume vol);
	}
}
