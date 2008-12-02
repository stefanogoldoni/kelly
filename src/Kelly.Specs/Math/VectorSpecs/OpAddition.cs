using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class OpAddition {
		[Fact]
		public void IsCommutative() {
			var a = new Vector(18, 4, -91);
			var b = new Vector(63, 86, -12);

			Assert.Equal(a + b, b + a);
		}

		[Fact]
		public void ReturnsSumOfTwoVectors() {
			Assert.Equal(
				new Vector(1f, 1f, 0),
				Vector.UnitX + Vector.UnitY);

			Assert.Equal(
				new Vector(1, 2, 3),
				new Vector(1, 0, 3) + new Vector(0, 2, 0));

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(.5f, .3f, .2f) + new Vector(.5f, .7f, .8f));
		}
	}
}