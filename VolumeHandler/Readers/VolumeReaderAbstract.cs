using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Readers
{
	public abstract class VolumeReaderAbstract
	{
		protected VolumeReaderAbstract()
		{

		}

		public string Path { get; set; }
		public abstract Volume ReadVolume();
	}
}