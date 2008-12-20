using System;
using System.Linq;

namespace Kelly.Math {
	public partial class Matrix {
		public static readonly Matrix Zero = new Matrix(Enumerable.Repeat(0f, 16));
		public static readonly Matrix Identity = UniformScaling(1f);

		public static Matrix UniformScaling(float value) {
			return Scaling(value, value, value);
		}

		public static Matrix Scaling(float x, float y, float z) {
			var matrix = new Matrix();
			matrix[0, 0] = x;
			matrix[1, 1] = y;
			matrix[2, 2] = z;
			matrix[3, 3] = 1f;
			return matrix;
		}

		public static Matrix Translation(float x, float y, float z) {
			var matrix = new Matrix();
			matrix[0, 3] = x;
			matrix[1, 3] = y;
			matrix[2, 3] = z;
			matrix[3, 3] = 1f;
			return matrix;
		}

		/// <summary>
		///		Creates a matrix that represents a rotation of <paramref name="degrees"/> degrees about <paramref name="axis"/>.
		/// </summary>
		/// <remarks>
		///		We use the same coordinate system as OpenGL (right-handed), and we use their matrix rotation specs as a spec for our rotations.
		///		<see cref="http://opengl.org/documentation/specs/man_pages/hardcopy/GL/html/gl/rotate.html"/>
		/// </remarks>
		public static Matrix Rotation(Vector axis, float degrees) {
			axis = axis.ToUnitVector();

			var x = axis.X;
			var y = axis.Y;
			var z = axis.Z;

			var sin = (float)System.Math.Sin(degrees.ToRadians());
			var cos = (float)System.Math.Cos(degrees.ToRadians());
	
			return new Matrix(
				x * x * (1 - cos) + cos,		x * y * (1 - cos) - (z * sin),	x * z * (1 - cos) + y * sin,	0,
				y * x * (1 - cos) + z * sin,	y * y * (1 - cos) + cos,		y * z * (1 - cos) - x * sin,	0,
				x * z * (1 - cos) - y * sin,	y * z * (1 - cos) + x * sin,	z * z * (1 - cos) + cos,		0,
				0,								0,								0,								0
				);
		}

		public static Matrix PerspectiveProjection(Vector position, Vector view, Vector up, float fieldOfView, float aspectRatio) {
			throw new NotImplementedException();
		}

		public static Matrix OrthogonalProjection() {
			throw new NotImplementedException();
		}
	}
}
