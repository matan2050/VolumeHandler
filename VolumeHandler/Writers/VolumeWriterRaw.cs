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
			this.Volume = _vol;
		}

    public override void WriteVolume(string path)
    {
      // TODO validate path

      if (Volume == null)
      {
        throw new NullReferenceException("Volume for export is null");
      }

      using (FileStream file = new FileStream(path, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(file))
        {
          writer.Write(Volume.DimX);
          writer.Write(Volume.DimY);
          writer.Write(Volume.DimZ);

          writer.Write((float)Volume.DimX * Volume.VoxelSizeX);
          writer.Write((float)Volume.DimY * Volume.VoxelSizeY);
          writer.Write((float)Volume.DimZ * Volume.VoxelSizeZ);

          for (uint i = 0; i < Volume.DimX; i++)
          {
            for (uint j = 0; j < Volume.DimY; j++)
            {
              for (uint k = 0; k < Volume.DimZ; k++)
              {
                writer.Write(Volume.Data[i, j, k]);
              }
            }
          }
        } //using
      }
		} //WriteVolume
	} //VolumeWriterRaw
}
