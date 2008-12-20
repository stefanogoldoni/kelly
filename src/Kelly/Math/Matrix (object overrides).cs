using System.Diagnostics;
using System.Text;

namespace Kelly.Math {
	[DebuggerDisplay("{ToString()}")]
	public partial class Matrix {
		public override bool Equals(object obj) {
			if (ReferenceEquals(this, obj))
				return true;

			var matrix = obj as Matrix;

			if (ReferenceEquals(matrix, null))
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

			foreach (var value in this) {
				hashCode = (hashCode << 5) ^ value.GetHashCode();
			}

			return hashCode;
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
