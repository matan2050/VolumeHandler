using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeHandler.Core
{
	public class Volume
	{
		#region properties
		public float[,,] Data { get; private set; }
		public uint DimX { get; private set; }
		public uint DimY { get; private set; }
		public uint DimZ { get; private set; }
    public float VoxelSizeX { get; private set; }
    public float VoxelSizeY { get; private set; }
    public float VoxelSizeZ { get; private set; }
    #endregion

    #region ctor
    public Volume(uint _dimX, uint _dimY, uint _dimZ, 
                  float _voxSizeX, float _voxSizeY, float _voxSizeZ)
		{
			InitHeader(_dimX, _dimY, _dimZ, _voxSizeX, _voxSizeY, _voxSizeZ);
			Data = new float[DimX, DimY, DimZ];
		}

		public Volume(Volume copied)
		{
			InitHeader(copied.DimX, copied.DimY, copied.DimZ, 
        copied.VoxelSizeX, copied.VoxelSizeY, copied.VoxelSizeZ);
			Data = copied.Data;
		}

		public Volume(uint _dimX, uint _dimY, uint _dimZ,
      float _voxSizeX, float _voxSizeY, float _voxSizeZ,
      float[,,] _data)
		{
      InitHeader(_dimX, _dimY, _dimZ, _voxSizeX, _voxSizeY, _voxSizeZ);
      Data = _data;
		}

		private void InitHeader(uint _dimX, uint _dimY, uint _dimZ, 
      float _voxSizeX, float _voxSizeY, float _voxSizeZ)
		{
			DimX = _dimX;
			DimY = _dimY;
			DimZ = _dimZ;
      VoxelSizeX = _voxSizeX;
      VoxelSizeY = _voxSizeY;
      VoxelSizeZ = _voxSizeZ;
    }
		#endregion
	}
}
