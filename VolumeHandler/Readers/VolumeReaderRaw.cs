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
      float voxSizeX, voxSizeY, voxSizeZ;
			float[,,] data;
      using (FileStream file = new FileStream(Path, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(file))
        {
          dimX = (uint)reader.Read();
          dimY = (uint)reader.Read();
          dimZ = (uint)reader.Read();

          float mmDimX = (float)reader.Read();
          float mmDimY = (float)reader.Read();
          float mmDimZ = (float)reader.Read();

          voxSizeX = mmDimX / dimX;
          voxSizeY = mmDimY / dimY;
          voxSizeZ = mmDimZ / dimZ;

          data = new float[dimX, dimY, dimZ];

          for (int i = 0; i < dimX; i++)
          {
            for (int j = 0; j < dimY; j++)
            {
              for (int k = 0; k < dimZ; k++)
              {
                data[i, j, k] = (float)reader.Read();
              }
            }
          }
        } //using
      }

			return new Volume(dimX, dimY, dimZ, 
        voxSizeX, voxSizeY, voxSizeZ,
        data);
		} //ReadVolume
	}//VolumeReaderRaw
}//namespace
