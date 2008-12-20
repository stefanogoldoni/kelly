using System.Collections.Generic;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_constructing_a_rotation_matrix {
		[Fact]
		public void Rotating_the_Y_unit_vector_90_degrees_about_the_X_axis_results_in_the_Z_unit_vector() {
			Assert.Equal(Vector.UnitZ, Rotate90Degrees(Vector.UnitY, Vector.UnitX), EpsilonComparer.VectorComparer);
		}

		[Fact]
		public void Rotating_the_Z_unit_vector_90_degrees_about_the_Y_axis_results_in_the_X_unit_vector() {
			Assert.Equal(Vector.UnitX, Rotate90Degrees(Vector.UnitZ, Vector.UnitY), EpsilonComparer.VectorComparer);
		}

		[Fact]
		public void Rotating_the_X_unit_vector_90_degrees_about_the_Z_axis_results_in_the_Y_unit_vector() {
			Assert.Equal(Vector.UnitY, Rotate90Degrees(Vector.UnitX, Vector.UnitZ), EpsilonComparer.VectorComparer);
		}

		private static Vector Rotate90Degrees(Vector vectorToRotate, Vector rotationAxis) {
			var transformation = Matrix.Rotation(rotationAxis, 90d.ToRadians());
			return transformation * vectorToRotate;
		}
	}
}
