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
		#endregion

		#region ctor
		public Volume(uint _dimX, uint _dimY, uint _dimZ)
		{
			InitHeader(_dimX, _dimY, _dimZ);
			Data = new float[DimX, DimY, DimZ];
		}

		public Volume(Volume copied)
		{
			InitHeader(copied.DimX, copied.DimY, copied.DimZ);
			Data = copied.Data;
		}

		public Volume(uint _dimX, uint _dimY, uint _dimZ, float[,,] _data)
		{
			InitHeader(_dimX, _dimY, _dimZ);
			Data = _data;
		}

		private void InitHeader(uint _dimX, uint _dimY, uint _dimZ)
		{
			DimX = _dimX;
			DimY = _dimY;
			DimZ = _dimZ;
		}
		#endregion
	}
}
