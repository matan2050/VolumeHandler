using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using VolumeHandler.Core;

namespace VolumeHandler.Writers
{
	public class VolumeWriterRaw : VolumeWriterAbstract
	{
		public VolumeWriterRaw(Volume _vol)
		{
			this.vol = _vol;
		}

		public override void WriteVolume(string path)
		{
			// TODO validate path

			if (vol == null)
			{
				throw new NullReferenceException("Volume for export is null");
			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.Write(vol.DimX);
				sw.Write(vol.DimY);
				sw.Write(vol.DimZ);

				for (uint i = 0; i < vol.DimX; i++)
				{
					for (uint j = 0; j < vol.DimY; j++)
					{
						for (uint k = 0; k < vol.DimZ; k++)
						{
							sw.Write(vol.Data[i, j, k]);
						}
					}
				}
			} //using
		} //WriteVolume
	} //VolumeWriterRaw
}
