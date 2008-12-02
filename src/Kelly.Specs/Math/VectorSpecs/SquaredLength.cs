using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class SquaredLength {
		[Fact]
		public void IsEqualToTheLengthOfTheVectorSquared() {
			Assert.Equal(1f, new Vector(1, 0, 0).SquaredLength);
			Assert.Equal(2f, new Vector(1, 1, 0).SquaredLength);
			Assert.Equal(3f, new Vector(1, 1, 1).SquaredLength);
			Assert.Equal(14f, new Vector(3, 2, 1).SquaredLength);
		}
	}
}