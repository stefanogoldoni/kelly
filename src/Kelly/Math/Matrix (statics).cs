using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelly.Math {
	public partial class Matrix {
		public static readonly Matrix Zero = new Matrix(Enumerable.Repeat(0f, 16));
		public static readonly Matrix Identity = UniformScaling(1f);

		public static Matrix UniformScaling(float value) {
			return Scaling(value, value, value);
		}

		public static Matrix Scaling(float x, float y, float z) {
			var m = new Matrix();
			m[0, 0] = x;
			m[1, 1] = y;
			m[2, 2] = z;
			m[3, 3] = 1f;
			return m;
		}

		public static Matrix Translation(float x, float y, float z) {
			var m = new Matrix();
			m[0, 3] = x;
			m[1, 3] = y;
			m[2, 3] = z;
			m[3, 3] = 1f;
			return m;
		}

		public static Matrix Rotation(Vector axis, float degrees) {
			throw new NotImplementedException();
		}

		public static Matrix PerspectiveProjection(Vector position, Vector view, Vector up, float fieldOfView, float aspectRatio) {
			throw new NotImplementedException();
		}

		public static Matrix OrthogonalProjection() {
			throw new NotImplementedException();
		}
	}
}
