using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VolumeHandler.Core;

namespace VolumeHandler.Filters
{
	public class GaussianFilter : ConvolutionFilter
	{
		public float Sigma { get; private set; }

		public GaussianFilter(
                          float sigma, 
                          uint sizeX, 
                          uint sizeY, 
                          uint sizeZ, 
                          float voxSizeX, 
                          float voxSizeY, 
                          float voxSizeZ
                         ) : base(sizeX, sizeY, sizeZ)
		{
			this.Sigma = sigma;

      base.SetKernel(
        GenerateGaussianKernel(sigma, sizeX, sizeY, sizeZ, voxSizeX, voxSizeY, voxSizeZ)
        );
		}

		private float[,,] GenerateGaussianKernel(
                                             float sigma, 
                                             uint sizeX, 
                                             uint sizeY, 
                                             uint sizeZ,
                                             float voxelSizeX,
                                             float voxelSizeY,
                                             float voxelSizeZ
                                            )
		{
      float[,,] kernel = new float[sizeX, sizeY, sizeZ];
      var gaussian = new Gaussian(sigma);

      var fSizeX = (float)sizeX;
      var fSizeY = (float)sizeY;
      var fSizeZ = (float)sizeZ;

      var midX = Math.Ceiling(fSizeX / 2);
      var midY = Math.Ceiling(fSizeY / 2);
      var midZ = Math.Ceiling(fSizeZ / 2);

			for (int i = 0; i < sizeX; i++)
			{
				var distX = Math.Abs(i - midX);
				for (int j = 0; j < sizeY; j++)
				{
					var distY = Math.Abs(j - midY);
					for (int k = 0; k < sizeZ; k++)
					{
						var distZ = Math.Abs(k - midZ);
						var distFromCenter = Math.Sqrt(Math.Pow(distX, 2) + Math.Pow(distY, 2) + Math.Pow(distZ, 2));

						kernel[i, j, k] = (float)gaussian.CalculateGaussianValue((float)distFromCenter);
					}
				}
			}

			return kernel;
		}


		public override Volume RunFilter(Volume vol)
		{
			return base.RunFilter(vol);
		}
	}


	public class Gaussian
	{
		#region definitions
		private const double SQRT_2_OVER_PI = 0.79788456080286f;
		#endregion

		#region properties
		public float Sigma { get; private set; }
		#endregion

		#region ctor
		public Gaussian(float sigma)
		{
			Sigma = sigma;
		}
		#endregion

		public double CalculateGaussianValue(float distFromMu)
		{
			return (1.0f / (Sigma * SQRT_2_OVER_PI)) 
				* Math.Exp(-0.5f * (Math.Pow(distFromMu / Sigma, 2.0f)));
		}
	}
}
