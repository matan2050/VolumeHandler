using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Writers
{
	public abstract class VolumeWriterAbstract
	{
		public abstract void WriteVolume(string path);
		public Volume vol;
	}
}
