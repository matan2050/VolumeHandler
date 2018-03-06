using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Filters
{
	public class ConvolutionFilter
	{
		public float[,,] Kernel { get; private set; }
		public uint[] KernelSize { get; private set; }

		public ConvolutionFilter(float[,,] kernel,
														 uint sizeX,
														 uint sizeY,
														 uint sizeZ)
		{
			if (sizeX * sizeY * sizeZ != kernel.Length)
			{
				throw new IndexOutOfRangeException("kernel size mismatch");
			}

			Kernel = kernel;
			KernelSize = new uint[3] { sizeX, sizeY, sizeZ };
		}

		public Volume RunFilter(Volume vol)
		{
			// TODO implement filter flow
			return vol;
		}
	}
}
