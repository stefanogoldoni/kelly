using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class OpSubtraction {
		[Fact]
		public void ReturnsDifferenceOfTwoVectors() {
			Assert.Equal(
				new Vector(1f, 0, -1f),
				Vector.UnitX - Vector.UnitZ);

			Assert.Equal(
				new Vector(0, 0, 0),
				new Vector(5, 6, 7) - new Vector(5, 6, 7));

			Assert.Equal(
				new Vector(3, -4, 12),
				new Vector(5, 7, 18) - new Vector(2, 11, 6));
		}
	}
}