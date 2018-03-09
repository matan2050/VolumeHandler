using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Filters
{
	public class ConvolutionFilter : FilterBase
	{
		private float[,,] Kernel = null; //{ get; private set; }

		private uint kernelSizeX;
		private uint kernelSizeY;
		private uint kernelSizeZ;

		public ConvolutionFilter(uint sizeX, uint sizeY, uint sizeZ)
		{
			if ((sizeX % 2 == 0) || (sizeY % 2 == 0) ||(sizeZ % 2 == 0))
			{
				throw new Exception("Kernel should be of uneven size in all dims");
			}

			kernelSizeX = sizeX;
			kernelSizeY = sizeY;
			kernelSizeZ = sizeZ;
		}

		public void SetKernel(float[,,] kernel)
		{
			this.Kernel = kernel;
		}

		public override Volume RunFilter(Volume vol)
		{
			// TODO implement filter flow
			if (Kernel == null)
			{
				throw new Exception("Kernel must be initialized prior to running filter");
			}

			var filteredVol = new Volume(vol);

			uint endBoundsX = vol.DimX - kernelSizeX / 2 + 1;
			uint endBoundsY = vol.DimY - kernelSizeY / 2 + 1;
			uint endBoundsZ = vol.DimZ - kernelSizeZ / 2 + 1;

			for (uint i = kernelSizeX / 2 + 1; i < endBoundsX; i++)
			{
				for (uint j = kernelSizeY / 2 + 1; j < endBoundsY; j++)
				{
					for (uint k = kernelSizeZ / 2 + 1; k < endBoundsZ; k++)
					{
						float currentVal = 0;

						for (int ii = 0; ii < kernelSizeX; ii++)
						{
							for (int jj = 0; jj < kernelSizeY; jj++)
							{
								for (int kk = 0; kk < kernelSizeZ; kk++)
								{
									currentVal += vol.Data[
										i - kernelSizeX / 2 + 1,
										j - kernelSizeY / 2 + 1,
										k - kernelSizeZ / 2 + 1] * Kernel[ii, jj, kk];
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
