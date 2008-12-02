using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class OpMultiplication {
		[Fact]
		public void IsCommutative() {
			var vector = new Vector(3, -49, 17);
			var scalar = 14.7f;

			Assert.Equal(vector * scalar, scalar * vector);
		}

		[Fact]
		public void ReturnsVectorScaledBySpecifiedAmount() {
			Assert.Equal(
				new Vector(2, 4, 6),
				new Vector(1, 2, 3) * 2);

			Assert.Equal(
				new Vector(2, 0, 0),
				new Vector(1, 0, 0) * 2);

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(2, 2, 2) * .5f);
		}
	}
}