using System;

namespace Kelly.Math {
	public static class MatrixExtensions {
		public static Matrix Invert(this Matrix matrix) {
			var determinant = matrix.CalculateDeterminant();

			throw new NotImplementedException();
			//return 1f / determinant * matrix;
		}

		public static float CalculateDeterminant(this Matrix matrix) {
			return matrix[0, 0] * Determinant3x3(matrix.Minor(0, 0))
				- matrix[0, 1] * Determinant3x3(matrix.Minor(0, 1))
				+ matrix[0, 2] * Determinant3x3(matrix.Minor(0, 2))
				- matrix[0, 3] * Determinant3x3(matrix.Minor(0, 3));
		}

		private static float Determinant3x3(float[,] matrix) {
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
		public static float[,] Minor(this Matrix matrix, int row, int column) {
			var minor = new float[3, 3];

			for (int x = 0, minorX = 0; x < 4; x++) {
				if (x == row)
					continue;

				for (int y = 0, minorY = 0; y < 4; y++) {
					if (y == 0)
						continue;

					minor[minorX, minorY] = matrix[x, y];
					minorY++;
				}

				minorX++;
			}

			return minor;
		}

		public static Matrix Transpose(this Matrix matrix) {
			return new Matrix(
				matrix[0, 0], matrix[1, 0], matrix[2, 0], matrix[3, 0],
				matrix[0, 1], matrix[1, 1], matrix[2, 1], matrix[3, 1],
				matrix[0, 2], matrix[1, 2], matrix[2, 2], matrix[3, 2],
				matrix[0, 3], matrix[1, 3], matrix[2, 3], matrix[3, 3]
			);
		}
	}
}
