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
		public float[,,] Kernel = null; //{ get; private set; }
		public uint[] KernelSize = null; // { get; private set; }

		public ConvolutionFilter(float[,,] kernel,
														 uint sizeX,
														 uint sizeY,
														 uint sizeZ)
		{
			if (sizeX * sizeY * sizeZ != kernel.Length)
			{
				throw new IndexOutOfRangeException("kernel size mismatch");
			}

			if ((sizeX % 2 == 0) || (sizeY % 2 == 0) ||(sizeZ % 2 == 0))
			{
				throw new Exception("Kernel should be of uneven size in all dims");
			}

			Kernel = kernel;
			KernelSize = new uint[3] { sizeX, sizeY, sizeZ };
		}

		public Volume RunFilter(Volume vol)
		{
			// TODO implement filter flow
			if (Kernel == null)
			{
				throw new Exception("Kernel must be initialized prior to running filter");
			}

			var filteredVol = new Volume(vol);

			uint endBoundsX = vol.DimX - KernelSize[0] / 2 + 1;
			uint endBoundsY = vol.DimY - KernelSize[1] / 2 + 1;
			uint endBoundsZ = vol.DimZ - KernelSize[2] / 2 + 1;

			for (uint i = KernelSize[0] / 2 + 1; i < endBoundsX; i++)
			{
				for (uint j = KernelSize[1] / 2 + 1; j < endBoundsY; j++)
				{
					for (uint k = KernelSize[2] / 2 + 1; k < endBoundsZ; k++)
					{
						float currentVal = 0;

						for (int ii = 0; ii < KernelSize[0]; ii++)
						{
							for (int jj = 0; jj < KernelSize[1]; jj++)
							{
								for (int kk = 0; kk < KernelSize[2]; kk++)
								{
									currentVal += vol.Data[
										i - KernelSize[0] / 2 + 1,
										j - KernelSize[1] / 2 + 1,
										k - KernelSize[2] / 2 + 1] * Kernel[ii, jj, kk];
								}
							}
						}

						filteredVol.Data[i, j, k] = currentVal;
					}
				}
			}

			return vol;
		}
	}
}
