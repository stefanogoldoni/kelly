using System;
using FrigginAwesome;

namespace Kelly.Math {
	/// <summary>
	/// Our 4x4 matrix class.
	/// 
	/// We represent matrices using row-major form.
	/// </summary>
	public class Matrix {
		private Matrix() {
			_values = new float[4, 4];
		}

		public Matrix(
			float _00, float _01, float _02, float _03,
			float _10, float _11, float _12, float _13,
			float _20, float _21, float _22, float _23,
			float _30, float _31, float _32, float _33) {

			_values = new float[4, 4];
			_values[0, 0] = _00;
			_values[0, 1] = _01;
			_values[0, 2] = _02;
			_values[0, 3] = _03;

			_values[1, 0] = _10;
			_values[1, 1] = _11;
			_values[1, 2] = _12;
			_values[1, 3] = _13;

			_values[2, 0] = _20;
			_values[2, 1] = _21;
			_values[2, 2] = _22;
			_values[2, 3] = _23;

			_values[3, 0] = _30;
			_values[3, 1] = _31;
			_values[3, 2] = _32;
			_values[3, 3] = _33;
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
			return _values[0, 0] * Determinant3x3(Minor(0, 0))
				- _values[0, 1] * Determinant3x3(Minor(0, 1))
				+ _values[0, 2] * Determinant3x3(Minor(0, 2))
				- _values[0, 3] * Determinant3x3(Minor(0, 3));
		}

		private float Determinant3x3(float[,] matrix) {
			var a = matrix[0, 0];
			var b = matrix[0, 1];
			var c = matrix[0, 2];

			var d = matrix[1, 0];
			var e = matrix[1, 1];
			var f = matrix[1, 2];

			var g = matrix[2, 0];
			var h = matrix[2, 1];
			var i = matrix[2, 2];

			return ((a * e * i) + (b * f * g) + (c * d * h))
				- ((g * e * c) + (h * f * a) + (i * d * b));
		}

		/// <summary>
		/// Returns the 3x3 minor matrix for the passed row and column.
		/// More info at http://en.wikipedia.org/wiki/Cofactor_(linear_algebra)
		/// </summary>
		private float[,] Minor(int row, int column) {
			var minor = new float[3, 3];

			for (int x = 0, minorX = 0; x < 4; x++) {
				if (x == row)
					continue;

				for (int y = 0, minorY = 0; y < 4; y++) {
					if (y == 0)
						continue;

					minor[minorX, minorY] = _values[x, y];
					minorY++;
				}

				minorX++;
			}

			return minor;
		}

		public Matrix Transpose() {
			var transpose = new Matrix();

			for (var row = 0; row < 4; row++)
			for (var col = 0; col < 4; col++) {
				transpose[row, col] = this[col, row];
			}

			return transpose;
		}

		public static Matrix operator *(Matrix left, Matrix right) {
			throw new NotImplementedException();
		}

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

		public static Vector operator *(Vector vector, Matrix matrix) {
			// Vectors have a w coordinate of 0, so we don't have to worry about the last column of the matrix
			return new Vector(
				Vector.DotProduct(vector, new Vector(matrix[0, 0], matrix[0, 1], matrix[0, 2])),
				Vector.DotProduct(vector, new Vector(matrix[1, 0], matrix[1, 1], matrix[1, 2])),
				Vector.DotProduct(vector, new Vector(matrix[2, 0], matrix[2, 1], matrix[2, 2]))
			);
		}

		public static Point operator *(Point point, Matrix matrix) {
			var vector = point.ToVector();

			// Points have a w coordinate of 1, so we just add the last column into the results for each row
			return new Point(
				Vector.DotProduct(vector, new Vector(matrix[0, 0], matrix[0, 1], matrix[0, 2])) + matrix[0, 3],
				Vector.DotProduct(vector, new Vector(matrix[1, 0], matrix[1, 1], matrix[1, 2])) + matrix[1, 3],
				Vector.DotProduct(vector, new Vector(matrix[2, 0], matrix[2, 1], matrix[2, 2])) + matrix[2, 3]
			);
		}

		public static readonly Matrix Zero = Matrix.UniformScaling(0f);
		public static readonly Matrix Identity = Matrix.UniformScaling(1f);
	}
}
