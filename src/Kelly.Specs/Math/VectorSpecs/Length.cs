using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class Length {
		[Fact]
		public void IsEqualToSquareRootOfSquaredLength() {
			var a = new Vector(43, 29, -14);

			Assert.Equal((float)System.Math.Sqrt(a.SquaredLength), a.Length);
		}

		[Fact]
		public void IsEqualToLengthOfVector() {
			Assert.Equal(
				1f,
				new Vector(1, 0, 0).Length);

			Assert.Equal(
				5f,
				new Vector(5, 0, 0).Length);

			Assert.Equal(
				5f,
				new Vector(0, 5, 0).Length);

			Assert.Equal(
				5f,
				new Vector(0, 0, 5).Length);
		}

	}
}