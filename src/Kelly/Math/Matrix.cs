using System;
using FrigginAwesome;

namespace Kelly.Math {
	public class Matrix {
		private Matrix() {
			_values = new float[4, 4];
		}

		private readonly float[,] _values;

		public float this[int x, int y] {
			get { return _values[x, y]; }
			private set { _values[x, y] = value; }
		}

		public Matrix Inverse() {
			throw new NotImplementedException();
		}

		public float CalculateDeterminant() {
			throw new NotImplementedException();
		}

		public static Matrix operator *(Matrix left, Matrix right) {
			throw new NotImplementedException();
		}

		public static Matrix Scaling(float value) {
			var m = new Matrix();
			m[0, 0] = value;
			m[1, 1] = value;
			m[2, 2] = value;
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

		public static readonly Matrix Zero = Matrix.Scaling(0f);
		public static readonly Matrix Identity = Matrix.Scaling(1f);
	}
}
