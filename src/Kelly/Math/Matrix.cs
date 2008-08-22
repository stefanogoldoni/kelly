using System;
using FrigginAwesome;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Kelly.Math {
	/// <summary>
	/// Our 4x4 matrix class.
	/// 
	/// We represent matrices using row-major form.
	/// </summary>
	[DebuggerDisplay("{ToString()}")]
	public class Matrix {
		private Matrix() {
			_values = new float[4, 4];
		}

		public Matrix(IEnumerable<float> values) {
			_values = new float[4, 4];

			int row = 0, col = 0;

			foreach (var element in values) {
				if (row >= 4) {
					throw new ArgumentException("The passed enumerable contained more than 16 elements.", "values");
				}

				_values[row, col] = element;

				col++;

				if (col == 4) {
					row++;

					if (row < 4) {
						col = 0;
					}
				}
			}

			if (row < 4 || col < 4) {
				throw new ArgumentException("The passed enumerable contained fewer than 16 elements.", "values");
			}
		}

		public Matrix(float[,] values) {
			if (values.GetLength(0) != 4 || values.GetLength(1) != 4) {
				throw new ArgumentException("The passed array does not have the correct dimensions. You can only initialize a matrix from a 4-by-4 array.", "values");
			}

			_values = new float[4, 4];
			Array.Copy(values, _values, 16);
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

		public static bool operator ==(Matrix left, Matrix right) {
			return left.Equals(right);
		}

		public static bool operator !=(Matrix left, Matrix right) {
			return !left.Equals(right);
		}

		public override bool Equals(object obj) {
			if (object.ReferenceEquals(this, obj))
				return true;

			var matrix = obj as Matrix;

			if (object.ReferenceEquals(matrix, null))
				return false;

			for (var row = 0; row < 4; row++)
			for (var col = 0; col < 4; col++) {
				if (matrix[row, col] != this[row, col])
					return false;
			}

			return true;
		}

		public override int GetHashCode() {
			var hashCode = 0;

			foreach (var value in _values) {
				hashCode = (hashCode << 5) ^ value.GetHashCode();
			}

			return hashCode;
		}

		public Matrix Clone(){
			return new Matrix(_values);
		}

		public override string ToString() {
			var builder = new StringBuilder();

			for (var row = 0; row < 4; row++) {
				builder.AppendFormat("{{{0}, {1}, {2}, {3}}}", this[row, 0], this[row, 1], this[row, 2], this[row, 3]);
			}

			return builder.ToString();
		}
	}
}
