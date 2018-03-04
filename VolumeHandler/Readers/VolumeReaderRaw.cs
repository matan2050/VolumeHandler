using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using VolumeHandler.Core;

namespace VolumeHandler.Readers
{
	/// <summary>
	/// Class implements reading volume data from raw file
	/// raw file contains dimensions in header (metadata)
	/// followed by float values for each voxel
	/// </summary>
	class VolumeReaderRaw : VolumeReaderAbstract
	{
		public VolumeReaderRaw(string _path)
		{
			this.Path = _path;
		}

		public override Volume ReadVolume()
		{
			if (Path == null)
			{
				throw new NullReferenceException("Volume path not defined");
			}

			uint dimX, dimY, dimZ;
			float[,,] data;
			using (StreamReader sr = new StreamReader(Path))
			{
				dimX = (uint)sr.Read();
				dimY = (uint)sr.Read();
				dimZ = (uint)sr.Read();

				data = new float[dimX, dimY, dimZ];

				for (int i = 0; i < dimX; i++)
				{
					for (int j = 0; j < dimY; j++)
					{
						for (int k = 0; k < dimZ; k++)
						{
							data[i, j, k] = (float)sr.Read();
						}
					}
				}
			} //using

			return new Volume(dimX, dimY, dimZ, data);
		} //ReadVolume
	}//VolumeReaderRaw
}//namespace
