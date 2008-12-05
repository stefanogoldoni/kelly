using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class For_static_members {
		[Fact]
		public void The_unit_vectors_all_have_unit_length() {
			Assert.True(Vector.UnitX.IsUnit);
			Assert.True(Vector.UnitY.IsUnit);
			Assert.True(Vector.UnitZ.IsUnit);
		}

		[Fact]
		public void The_zero_vector_has_a_length_of_zero() {
			Assert.Equal(
				0f,
				Vector.Zero.Length);
		}
	}
}