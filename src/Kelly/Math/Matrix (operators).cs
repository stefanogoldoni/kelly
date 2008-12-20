using System.Linq;

namespace Kelly.Math {
	public partial class Matrix {
		public static Matrix operator *(float scalar, Matrix matrix) {
			return matrix * scalar;
		}

		public static Matrix operator *(Matrix matrix, float scalar) {
			return new Matrix(
				matrix.Select(el => el * scalar));
		}

		public static Matrix operator *(Matrix left, Matrix right) {
			var result = new Matrix();

			for (var row = 0; row < 4; row++) {
				for (var col = 0; col < 4; col++) {
					result[row, col]
						= left[row, 0] * right[0, col]
						+ left[row, 1] * right[1, col]
						+ left[row, 2] * right[2, col]
						+ left[row, 3] * right[3, col];
				}
			}

			return result;
		}

		public static Vector operator *(Matrix matrix, Vector vector) {
			// assume W coordinate is always 0
			return new Vector(
				matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y + matrix[0, 2] * vector.Z,
				matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y + matrix[1, 2] * vector.Z,
				matrix[2, 0] * vector.X + matrix[2, 1] * vector.Y + matrix[2, 2] * vector.Z
			);
		}

		public static Point operator *(Matrix matrix, Point point) {
			// assume W coordinate is always 1
			return new Point(
				matrix[0, 0] * point.X + matrix[0, 1] * point.Y + matrix[0, 2] * point.Z + matrix[0, 3],
				matrix[1, 0] * point.X + matrix[1, 1] * point.Y + matrix[1, 2] * point.Z + matrix[1, 3],
				matrix[2, 0] * point.X + matrix[2, 1] * point.Y + matrix[2, 2] * point.Z + matrix[2, 3]
			);
		}

		public static bool operator ==(Matrix left, Matrix right) {
			return left.Equals(right);
		}

		public static bool operator !=(Matrix left, Matrix right) {
			return !left.Equals(right);
		}
	}
}